using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_tex_Main : MonoBehaviour {

    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Image image6;
    public Image image7;
    public Image image8;
    public Image image9;
    public static int round;
    public static bool standby = false;
    public static bool ready = false;
    public static bool gamenow = false;
    public static bool change_player = false;
    public float timer = 0;
    float Sudtime = 0;

    AudioSource audioSource;
    public AudioClip A_ButtonSE;
    // Use this for initialization
    void Start () {

        image1.fillAmount = 0.0f;//ラウンド１
        image2.fillAmount = 0.0f;//ラウンド２
        image3.fillAmount = 0.0f;//ラウンド３
        image4.fillAmount = 0.0f;//スタンバイ
        image5.fillAmount = 0.0f;//レディ
        image6.fillAmount = 0.0f;//GO！！
        image7.fillAmount = 0.0f;//交代表示
        image8.fillAmount = 0.0f;//サドンデス
        image9.fillAmount = 0.0f;//press_A
        Sudtime = 0;
        standby = false;
        ready = false;
        gamenow = false;
        change_player = false;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (round == 0 && standby == false) 
        {
            image1.fillAmount = 1.0f;
            timer += Time.deltaTime;
            if(timer >= 2)
            {
                standby = true;
            }
        }

        if(round >= 1 && change_player == false)
        {
            image7.fillAmount = 1.0f;
            if (Input.GetButtonDown("Xbox_A") || Input.GetKeyDown("a"))//交代してくださいからAを押すとき
            {
                audioSource.PlayOneShot(A_ButtonSE);
                image7.fillAmount = 0.0f;
                change_player = true;
            }
        }

        if (round == 1 && standby == false && change_player == true)
        {
            image2.fillAmount = 1.0f;
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                standby = true;
            }
        }

        if (round == 2 && standby == false && change_player == true)
        {
            image3.fillAmount = 1.0f;
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                standby = true;
            }
        }

        if (standby == true && ready == false)
        {
            image1.fillAmount = 0.0f;
            image2.fillAmount = 0.0f;
            image3.fillAmount = 0.0f;
            image4.fillAmount = 1.0f;
            image9.fillAmount = 1.0f;
            if (Input.GetButtonDown("Xbox_A") || Input.GetKeyDown("a"))
            {
                audioSource.PlayOneShot(A_ButtonSE);
                Debug.Log("boss_ready");
                timer = 0;
                Debug.Log("boss_ready_ok");
                image9.fillAmount = 0.0f;
                image4.fillAmount = 0.0f;
                image5.fillAmount = 1.0f;
                ready = true;
            }
        }
        //if (OVRInput.GetDown(OVRInput.RawButton.A))
        //{
        //    Debug.Log("Aボタンを押した");
        //}

            if(anime.Moveon == true && Lift.movecam == false)
        {
            image5.fillAmount = 0.0f;
            image6.fillAmount = 1.0f;

            timer += Time.deltaTime;
            if (timer >= 2)
            {
                image6.fillAmount = 0.0f;
                gamenow = true;
            }
        }
        if (game_time_counter.time_stop == true)
        {
            image8.fillAmount = 1.0f;

            Sudtime += Time.deltaTime;
            if (Sudtime >= 2)
            {
                image8.fillAmount = 0.0f;
            }
        }
        if (gamenow)
        {
            image1.fillAmount = 0.0f;//ラウンド１
            image2.fillAmount = 0.0f;//ラウンド２
            image3.fillAmount = 0.0f;//ラウンド３
            image4.fillAmount = 0.0f;//スタンバイ
            image5.fillAmount = 0.0f;//レディ
            image6.fillAmount = 0.0f;//GO！！
            image7.fillAmount = 0.0f;//交代表示
           
        }




        

	}
}
