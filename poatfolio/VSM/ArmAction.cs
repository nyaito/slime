using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAction : MonoBehaviour
{

    public Animator Larm;
    public Animator Rarm;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //コントローラの各ボタンが押されたときにデバッグログを出す。
        //    if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        //    {
        //        Debug.Log("左中指トリガーを押した");
        //        Larm.SetBool("L_arm_action", true);
        //    }
        //    else if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        //    {
        //        Debug.Log("左中指トリガーを離した");
        //        Larm.SetBool("L_arm_action", false);
        //    }

        //    if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        //    {
        //        Debug.Log("右中指トリガーを押した");
        //        Rarm.SetBool("R_arm_action", true);
        //    }
        //    else if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        //    {
        //        Debug.Log("右中指トリガーを離した");
        //        Rarm.SetBool("R_arm_action", false);
        //    }
       
    }
}