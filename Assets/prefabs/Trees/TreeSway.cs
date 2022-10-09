using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSway : MonoBehaviour
{
    public GameObject PineTree;

    //don't sway if the canon ball is moving too slowly
    public float MinCanonBallSpeed = 1f;
    public float TreeDrag = 0.75f;
    Animator TreeAnimator;
    SpriteRenderer TreeSpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        TreeAnimator = PineTree.GetComponent<Animator>();
        TreeSpriteRenderer = PineTree.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

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
                    //Debug.Log("Hit from the right.");
                    TreeSpriteRenderer.flipX = false;
                    TreeAnimator.SetTrigger("sway");
                }
                else
                {
                    //Debug.Log("Hit from the left.");
                    TreeSpriteRenderer.flipX = true;
                    TreeAnimator.SetTrigger("sway");
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
}
