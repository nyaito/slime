using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Damage4_ArmDestroy : MonoBehaviour {

    public Animator anim;

    public GameObject BossArm;

    // Use this for initialization
    void Start () {

        BossArm = GameObject.Find("boss_Arm_inbone");

    }
	
	// Update is called once per frame
	void Update () {

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("finish"))
        {
            Destroy(this.gameObject);
        }

    }
}
