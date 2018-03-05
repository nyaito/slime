using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 str = this.transform.eulerAngles;

        if ((MoveScript.right && MoveScript.back == false) || (MoveScript.left && MoveScript.back))
        {
            this.transform.eulerAngles = new Vector3(0, 240, 0);
        }
        else if ((MoveScript.left == true && MoveScript.back == false) || (MoveScript.right && MoveScript.back) )
        {
            this.transform.eulerAngles = new Vector3(0, 120, 0);
        }
        else if (MoveScript.forward == true || MoveScript.back == true)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
}
