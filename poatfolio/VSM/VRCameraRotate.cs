using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCameraRotate : MonoBehaviour {

    public GameObject target;

    // Use this for initialization
    void Start () {

        target = GameObject.Find("CenterEyeAnchor");
    }
	
	// Update is called once per frame
	void Update() {

        //target.transform.rotation = Quaternion.Euler(target.transform.localEulerAngles.x, target.transform.localEulerAngles.y, target.transform.localEulerAngles.z);

        if (target.transform.localEulerAngles.y > 100 && target.transform.localEulerAngles.y < 150)
        {
#if UNITY_EDITOR
            Debug.Log("Camera_right");
#endif
            this.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x , 270, this.transform.localEulerAngles.z);
            target.transform.rotation = Quaternion.Euler(target.transform.localEulerAngles.x, 180, target.transform.localEulerAngles.z);

        }
        else if(target.transform.localEulerAngles.y > -100 && target.transform.localEulerAngles.y < -150)
        {
#if UNITY_EDITOR
            Debug.Log("Camera_left");
#endif
            this.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, 90, this.transform.localEulerAngles.z);
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("Camera_forward");
#endif
            this.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, 180, this.transform.localEulerAngles.z);
        }
	}
}
