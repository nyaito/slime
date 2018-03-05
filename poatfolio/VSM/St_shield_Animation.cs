using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St_shield_Animation : MonoBehaviour {

    public Animator anim;
    public GameObject st_shield_Veiw;
    public Texture st_shield_open;
    public Texture st_shield_close;
    private Collider collider;
    public GameObject shield;

    // Use this for initialization
    void Start () {

            collider = this.gameObject.GetComponentInChildren<BoxCollider>();
        shield = GameObject.Find("strike/OVRCameraRig/TrackingSpace/LeftHandAnchor/strikershield/pCube40");
    }

    // Update is called once per frame
    void Update()
    {

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (anime.Moveon)
        {
            anim.SetBool("ST_Shield_Open", true);
        }


        if (stateInfo.IsName("Openver"))//今再生しているアニメーションの名前が一致したらif文内を実行
        {
            shield.SetActive(true);
            collider.enabled = true;
            anim.SetBool("ST_Shield_Open", false);
            st_shield_Veiw.GetComponent<Renderer>().material.SetTexture("_EmissionMap", st_shield_open);
           
            if (Input.GetKeyDown("o"))
            {
                anim.SetBool("ST_Shield_Close", true);
            }
        }
        else if (stateInfo.IsName("Defaultver"))
        {
            shield.SetActive(false);
            collider.enabled = false;
            anim.SetBool("ST_Shield_Close", false);
            st_shield_Veiw.GetComponent<Renderer>().material.SetTexture("_EmissionMap", st_shield_close);

            if (Input.GetKeyDown("p"))
            {
                anim.SetBool("ST_Shield_Open", true);
            }
        }

    }
}
