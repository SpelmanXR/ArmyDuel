using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public CanonCtrl canonCtrl;
    public int MinTNT = 0;
    public int MaxTNT = 2000;
    public int MinAngle = -30;
    public int MaxAngle = 90;
    public int TNTSmallInc = 2;
    public int TNTBigInc = 20;
    public int AngleSmallInc = 1;
    public int AngleBigInc = 10;
    public TMPro.TMP_Text AngleTxt;
    public TMPro.TMP_Text TNTTxt;

    
    // Start is called before the first frame update
    void Start()
    {
        int tnt = (int)canonCtrl.TNT;
        tnt = Mathf.Clamp(tnt, MinTNT, MaxTNT);
        canonCtrl.TNT = (float)tnt;
        TNTTxt.text = tnt.ToString();

        int angle = (int)canonCtrl.Angle;
        angle = Mathf.Clamp(angle, MinAngle, MaxAngle);
        canonCtrl.Angle = (float)angle;
        AngleTxt.text = angle.ToString();
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public void TNTUp()
    {
        int tnt = (int)canonCtrl.TNT + TNTSmallInc;
        tnt = Mathf.Clamp(tnt, MinTNT, MaxTNT);
        canonCtrl.TNT = (float)tnt;
        TNTTxt.text = tnt.ToString();
    }

    public void TNTUUp()
    {
        int tnt = (int)canonCtrl.TNT + TNTBigInc;
        tnt = Mathf.Clamp(tnt, MinTNT, MaxTNT);
        canonCtrl.TNT = (float)tnt;
        TNTTxt.text = tnt.ToString();
    }

    public void TNTDown()
    {
        int tnt = (int)canonCtrl.TNT - TNTSmallInc;
        tnt = Mathf.Clamp(tnt, MinTNT, MaxTNT);
        canonCtrl.TNT = (float)tnt;
        TNTTxt.text = tnt.ToString();
    }

    public void TNTDDown()
    {
        int tnt = (int)canonCtrl.TNT - TNTBigInc;
        tnt = Mathf.Clamp(tnt, MinTNT, MaxTNT);
        canonCtrl.TNT = (float)tnt;
        TNTTxt.text = tnt.ToString();
    }

    public void AngleUp()
    {
        int angle = (int)canonCtrl.Angle + AngleSmallInc;
        angle = Mathf.Clamp(angle, MinAngle, MaxAngle);
        canonCtrl.Angle = (float)angle;
        AngleTxt.text = angle.ToString();
    }

    public void AngleUUp()
    {
        int angle = (int)canonCtrl.Angle + AngleBigInc;
        angle = Mathf.Clamp(angle, MinAngle, MaxAngle);
        canonCtrl.Angle = (float)angle;
        AngleTxt.text = angle.ToString();
    }

    public void AngleDown()
    {
        int angle = (int)canonCtrl.Angle - AngleSmallInc;
        angle = Mathf.Clamp(angle, MinAngle, MaxAngle);
        canonCtrl.Angle = (float)angle;
        AngleTxt.text = angle.ToString();
    }

    public void AngleDDown()
    {
        int angle = (int)canonCtrl.Angle - AngleBigInc;
        angle = Mathf.Clamp(angle, MinAngle, MaxAngle);
        canonCtrl.Angle = (float)angle;
        AngleTxt.text = angle.ToString();
    }

    public void Fire()
    {
        canonCtrl.Fire();
    }

}
