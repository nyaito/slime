using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_Arm_Effect : MonoBehaviour {

    public GameObject Arm_Effect;
    public AudioClip StrikerDamSE;
    public static bool st_effect = false;
    AudioSource audioSource;
    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
        st_effect = false;
    }

    // Update is called once per frame
    void Update () {
        if (Striker.Strike_Damage == true && st_effect == false)
        {
#if UNITY_EDITOR
            Debug.Log("TS_Damage_On");
#endif
            audioSource.PlayOneShot(StrikerDamSE);
            GameObject Effect_parents = Instantiate(Arm_Effect, this.transform.position, this.transform.rotation);
            Effect_parents.transform.parent = transform;
            st_effect = true;
            //Striker.Strike_Damage = false;
        }
	}
}
