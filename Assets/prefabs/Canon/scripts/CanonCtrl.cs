using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonCtrl : MonoBehaviour
{
    public float RestAngle = 9f;
    public float Angle = 0f;
    private float prevAngle = 0f;
    public float TNT = 500f;

    public GameObject gun;
    public Transform muzzle;    //transform of the canon's muzzle

    public CanonBall CanonBallPrefab;
    public Transform CannonGun;
    public bool FlipHorizontal = false;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        UpdateCanonOnScreen();

        if (FlipHorizontal)
        {
            //transform.Rotate(0f, 180f, 0f, Space.World);
            CannonGun.localScale = new Vector3(-CannonGun.localScale.x, CannonGun.localScale.y, CannonGun.localScale.z);
            //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    
    void Update()
    {

        UpdateCanonOnScreen();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Fire");
            Fire();
        }
    }
    

    // Update canon angle on screen
    public void UpdateCanonOnScreen()
    {
        if (Angle != prevAngle)
        {
            gun.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, (FlipHorizontal ? -1 : 1) * (Angle - RestAngle) * Mathf.Sign(transform.localScale.x)));
            prevAngle = Angle;
        }
    }


    public void Fire()
    {

        CanonBall canonBall;
        //Transform orbTransform = new Transform();

        //orbTransform.position = new Vector3(0f, 6f, 0f);

        canonBall = Instantiate(CanonBallPrefab, null);
        canonBall.StartX = muzzle.position.x;
        canonBall.StartY = muzzle.position.y;
        canonBall.Angle = FlipHorizontal ? 180 - Angle : Angle;
        canonBall.Force = TNT;

        //canonBall.CanonBallSprite = OrbSprites[Random.Range(0, OrbSprites.Length)];

        /*
        SpriteRenderer spriteRenderer = canonBall.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = OrbSprites[Random.Range(0, OrbSprites.Length)];
        */

    }
}
