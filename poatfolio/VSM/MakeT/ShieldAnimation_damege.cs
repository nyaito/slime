using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimation_damege : MonoBehaviour {
    public Animator anima;
    public static bool DamF = false;
    private bool Dam_SE = false;
    public float TIme = 0.0f;
    public GameObject Damage_Effect;

    AudioSource audioSource;
    public AudioClip ShieldDamageSE;
    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
        Dam_SE = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (DamF)
        {
            TIme = TIme + Time.deltaTime;
            if (TIme >= 1.0f)
            {
                anima.SetBool("damege", false);
                TIme = 0.0f;
                DamF = false;
                Dam_SE = false;
            }
        }
    }
    //オブジェクトが衝突したとき
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "ball")
        {
            anima.SetBool("damege", true);
            DamF = true;
            if (Dam_SE == false)
            {
                audioSource.PlayOneShot(ShieldDamageSE);
                GameObject Effect_parents = Instantiate(Damage_Effect, transform.position, transform.rotation);
                Effect_parents.transform.parent = transform;
                Dam_SE = true;
            }
        }
    }
}
