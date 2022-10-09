using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    //don't sway if the canon ball is moving too slowly
    public float MinCanonBallSpeed = 1f;
    public float TreeDrag = 0.75f;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public GameObject SwayTrigger;
    public GameObject CatchCollider;
    //set the collider catch point.  0=middle of tree;-1.2 = foot of tree; +1.2 = top of tree
    public float CatchPoint = -1.2f;

    const float LOCKOUT_TIME_SEC = 0.5f;
    float lockoutPeriod;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D bc = CatchCollider.GetComponent<BoxCollider2D>();
        bc.offset = new Vector2(0, CatchPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time < lockoutPeriod) return;

        lockoutPeriod = Time.time + LOCKOUT_TIME_SEC; //lockout for 0.5 second

        if (collision.gameObject.tag == "CanonBall")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(rb.velocity.magnitude.ToString("0.00"));

            //sway only if we are above the min canon ball speed
            if (rb.velocity.magnitude > MinCanonBallSpeed)
            {
                //Debug.Log("sway");
                if (rb.velocity.x > 0)
                {
                    Debug.Log("Hit from the right.");
                    spriteRenderer.flipX = false;
                    animator.SetTrigger("sway");
                }
                else
                {
                    Debug.Log("Hit from the left.");
                    spriteRenderer.flipX = true;
                    animator.SetTrigger("sway");
                }
            }
            else
            {
                //don't sway
                //Debug.Log("Too slow");
            }

            //slow down the canon ball when it hits a tree.
            rb.velocity *= TreeDrag;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        //when we hit the hill, lock in the position and get rid of the catch collider.

        if (collision.gameObject.tag == "Hill")
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;

            //rb.gravityScale = 0f;  //once trees are placed, turn off gravity.
            //rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation; //lock rotation and position
            rb.velocity = Vector2.zero;

            //disable the collider
            CatchCollider.SetActive(false);

            //GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
