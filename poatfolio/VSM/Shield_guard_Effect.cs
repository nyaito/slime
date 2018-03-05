using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_guard_Effect : MonoBehaviour {

    public GameObject Reflection_Effect;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (ShieldAnimation.ArmF == true)
        {
            this.transform.localScale = new Vector3(2, 2, 2);
        }
        else if(ShieldAnimation.ArmF == false)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }

		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (ShieldAnimation.ShieldModeFlag == true) {
            GameObject Effect_parents = Instantiate(Reflection_Effect, transform.position, transform.rotation);
            Effect_parents.transform.parent = transform;
        }
    }

}
