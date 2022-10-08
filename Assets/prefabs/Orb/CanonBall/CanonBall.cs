using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    public float StartY = 0f;
    public float StartX = 0f;
    public float Angle = 45f;
    public float Force = 1000f;
    public float CanonBallLife = -1f;     //set to 0 or less to disable
    public AudioClip CanonBallClack;    //hit another canon ball
    public AudioClip BlockThump;    //hit block
    public AudioClip GroundThump;   //hit the ground

    //bool firstCollision = true;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //set the initial position of the canon ball
        transform.position = new Vector2(StartX, StartY);

        //apply the force (impulse)
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(Force * Mathf.Cos(Angle * Mathf.Deg2Rad), Force * Mathf.Sin(Angle * Mathf.Deg2Rad), 0f));
      
        //if the user specifies a positive live, set the atuo-destruct timer to the specified number of seconds
        if (CanonBallLife > 0f) Destroy(gameObject, CanonBallLife);

        audioSource = GetComponent<AudioSource>();
        
        CanonBallClack.LoadAudioData();
        BlockThump.LoadAudioData();
        GroundThump.LoadAudioData();
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //get a reference to the object we hit
        GameObject otherObject = collision.gameObject;
        /*
        if (firstCollision)
        {
            //on first collision, change color to gray
            GetComponent<SpriteRenderer>().color = Color.gray;
            firstCollision = false;

            if (otherObject.tag == "Crown")
            {
                audioSource.PlayOneShot(CanonBallClack);
                Debug.Log("YOU WIN!!");
            }
            else if (otherObject.tag == "CanonBall")
            {
                audioSource.PlayOneShot(CanonBallClack);
                //Debug.Log("Hit another canon ball");
            }
            else if (otherObject.tag == "Block")
            {
                audioSource.PlayOneShot(BlockThump);
                //Debug.Log("hit a block");
            }
            else if (otherObject.tag == "Ground")
            {
                audioSource.PlayOneShot(GroundThump);
                //Debug.Log("hit the ground");
            }
            else
            {
                Debug.Log("Hit an unknown object");
            }

        }
        */
    }
}
