using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoveanim : MonoBehaviour {

    public Animator Sanim;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("r"))
        {
            Debug.Log("R key");
            Sanim.SetBool("right_side", true);
            Sanim.SetBool("this_side", false);
        }
        if (Input.GetKey("l"))
        {
            Debug.Log("L key");
            Sanim.SetBool("left_side", true);
            Sanim.SetBool("this_side", false);
        }
        if (Input.GetKey("space"))
        {
            Debug.Log("space key");
            Sanim.SetBool("right_side", false);
            Sanim.SetBool("left_side", false);
            Sanim.SetBool("this_side", true);
        }

    }
}
