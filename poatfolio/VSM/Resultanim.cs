using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resultanim : MonoBehaviour {

    public Animator anim_st;
    public Animator anim_bs;

    public int count = 0;
    AudioSource audioSource;
    public AudioClip ResultBGM;
    // Use this for initialization
    void Start () {

        
        Boss_tex_Main.round = 0;
        battleResult.BGMStop_result = false;
        count = 0;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (count == 0)
        {
            audioSource.PlayOneShot(ResultBGM);
            count += 1;
        }

        if (Boss_Player.B_win >= 3)
        {
            anim_st.SetBool("st_lose", true);
            anim_bs.SetBool("boss_win", true);
        }

        if (Striker.S_win >= 3)
        {
            anim_st.SetBool("st_win", true);
            anim_bs.SetBool("boss_lose", true);
        }

    }
}
