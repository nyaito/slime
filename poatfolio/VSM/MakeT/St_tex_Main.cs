using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class St_tex_Main : MonoBehaviour {

    public Image st_image1;
    public Image st_image2;
    public Image st_image3;
    public Image st_image4;
    public Image st_image5;
    public Image st_image6;
    public Image st_image7;
    public Image st_image8;
    public Image st_image9;
    public static bool standby_st = false;
    public static bool ready_st = false;
    public static bool change_player = false;
    public float timer = 0;
    float Sudtime = 0;

    AudioSource audioSource;
    public AudioClip StartSE;
    public AudioClip A_ButtonSE;
    public static bool StaSE = false;

    // Use this for initialization
    void Start()
    {

        st_image1.fillAmount = 0.0f;//ラウンド１
        st_image2.fillAmount = 0.0f;//ラウンド２
        st_image3.fillAmount = 0.0f;//ラウンド３
        st_image4.fillAmount = 0.0f;//スタンバイ
        st_image5.fillAmount = 0.0f;//レディ
        st_image6.fillAmount = 0.0f;//GO!!
        st_image7.fillAmount = 0.0f;//交代表示
        st_image8.fillAmount = 0.0f;//サドンデス
        st_image9.fillAmount = 0.0f;//press_A
        Sudtime = 0;
        standby_st = false;
        ready_st = false;
        change_player = false;
        StaSE = false;
        timer = 0;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Boss_tex_Main.round == 0 && standby_st == false)
        {
            st_image1.fillAmount = 1.0f;
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                standby_st = true;
            }
        }

        if (Boss_tex_Main.round >= 1 && change_player == false)
        {
            st_image7.fillAmount = 1.0f;
            if (Input.GetButtonDown("Touth_A") || Input.GetKeyDown("a"))//交代してくださいA
            {
                audioSource.PlayOneShot(A_ButtonSE);
                st_image7.fillAmount = 0.0f;
                change_player = true;
            }
        }

        if (Boss_tex_Main.round == 1 && standby_st == false && change_player == true)
        {
            st_image2.fillAmount = 1.0f;
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                standby_st = true;
            }
        }
        if (Boss_tex_Main.round == 2 && standby_st == false && change_player == true)
        {
            st_image3.fillAmount = 1.0f;
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                standby_st = true;
            }
        }
        if (standby_st == true && ready_st == false)
        {
            st_image1.fillAmount = 0.0f;
            st_image2.fillAmount = 0.0f;
            st_image3.fillAmount = 0.0f;
            st_image4.fillAmount = 1.0f;
            st_image9.fillAmount = 1.0f;

            if (Input.GetButtonDown("Touth_A") || Input.GetKeyDown("a"))//ready_A
            {
                audioSource.PlayOneShot(A_ButtonSE);
                timer = 0;
                Debug.Log("striker_ready");
                Debug.Log("striker_ready_ok");
                st_image9.fillAmount = 0.0f;
                st_image4.fillAmount = 0.0f;
                st_image5.fillAmount = 1.0f;
                ready_st = true;
            }
        }
        //if (OVRInput.GetDown(OVRInput.RawButton.A))
        //{
        //    ready_st = true;
        //    st_image4.fillAmount = 0.0f;
        //    Debug.Log("striker_ready");
        //}
        
        if (anime.Moveon == true && Lift.movecam == false)
        {
            if(timer == 0)
            {
                StaSE = true;
            }
            st_image5.fillAmount = 0.0f;
            st_image6.fillAmount = 1.0f;
            
            timer += Time.deltaTime;

            if (timer >= 2)
            {
                st_image6.fillAmount = 0.0f;
            }
        }
        if(Boss_tex_Main.gamenow == true)
        {
            st_image1.fillAmount = 0.0f;//ラウンド１
            st_image2.fillAmount = 0.0f;//ラウンド２
            st_image3.fillAmount = 0.0f;//ラウンド３
            st_image4.fillAmount = 0.0f;//スタンバイ
            st_image5.fillAmount = 0.0f;//レディ
            st_image6.fillAmount = 0.0f;//GO!!
            st_image7.fillAmount = 0.0f;//交代表示
            st_image8.fillAmount = 0.0f;//交代表示
        }
        if (game_time_counter.time_stop == true)
        {
            st_image8.fillAmount = 1.0f;
            
            Sudtime += Time.deltaTime;
            if (Sudtime >= 2)
            {
                st_image8.fillAmount = 0.0f;
            }
        }

        if(StaSE)
        {
            audioSource.PlayOneShot(StartSE);
            StaSE = false;
        }

    }
}
