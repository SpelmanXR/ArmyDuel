using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public int MinSpeed = -30;
    public int MaxSpeed = +30;
    public SpriteRenderer DirectionFlag;
    public TMPro.TMP_Text TxtMPH;

    int speed = 0;
    public int Speed
    {
        set
        {
            speed = Mathf.Clamp(value, MinSpeed, MaxSpeed);
            DirectionFlag.flipX = speed < 0;
            TxtMPH.text = Mathf.Abs(speed).ToString() + " mph";
        }

        get
        {
            return speed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Speed = Random.Range(MinSpeed, MaxSpeed + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to simulate the shifting of the wind
    public void WindSift(int MinDeltaSpeed = -5, int MaxDeltaSpeed = 5)
    {
        Speed += Random.Range(-MinDeltaSpeed, MaxDeltaSpeed + 1);
    }
}
