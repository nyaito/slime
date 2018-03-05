using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class game_time_counter : MonoBehaviour {

    //public Image zero;
    //public Image one;
    //public Image two;
    //public Image three;
    //public Image four;
    //public Image five;
    //public Image six;
    //public Image seven;
    //public Image eight;
    //public Image nine;
    public static float game_timer = 0;
    public static int Game_timer_two = 0;
    public static int Game_timer_2 = 0;
    public static int Game_timer_3 = 0;
    public static bool time_stop = false;

    public static bool BGMStop = false;
    public bool Time_BGM_Cheacker = false;
    public static bool Sudden_Death_in = false;

    /*
    ↑旧タイムUIで使ってた。
    ↓新タイムUI
   */
    private Texture[] st_time = new Texture[10];
    private Sprite[] boss_time = new Sprite[10];
    //private Texture[] Boss_time = new Texture[10];
    public GameObject st_1;
    public GameObject st_10;
    public GameObject st_100;
    public Image boss_1;
    public Image boss_10;
    public Image boss_100;
    //public GameObject boss_1;
    //public GameObject boss_10;
    //public GameObject boss_100;
    public static int game_timer_10 = 0;
    public static int game_timer_100 = 0;
    public bool firstdown_10 = false;
    public bool firstdown_100 = false;
    public bool up_count = false;
    private int Game_Time = 0;

    // Use this for initialization
    void Start () {

        //zero.fillAmount = 1.0f;
        //one.fillAmount = 0.0f;
        //two.fillAmount = 0.0f;
        //three.fillAmount = 0.0f;
        //four.fillAmount = 0.0f;
        //five.fillAmount = 0.0f;
        //six.fillAmount = 0.0f;
        //seven.fillAmount = 0.0f;
        //eight.fillAmount = 0.0f;
        //nine.fillAmount = 0.0f;
        game_timer = 0;
        Game_timer_two = 0;
        Game_timer_2 = 1;
        Game_timer_3 = 8;
        time_stop = false;
        Time_BGM_Cheacker = false;
        Sudden_Death_in = false;
        BGMStop = false;
        /*
          新UI void start↓
         */
        st_time = Resources.LoadAll<Texture2D>("striker_time");
        boss_time = Resources.LoadAll<Sprite>("boss_time");
        //Boss_time = Resources.LoadAll<Texture2D>("boss_time");
        game_timer = 0;
        game_timer_10 = 2;
        game_timer_100 = 9;
        firstdown_10 = false;
        firstdown_100 = false;
        up_count = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("d"))
        {
            Game_timer_2 = 9;
            Game_timer_3 = 9;
        }


        if (anime.Moveon == true && time_stop == false)
        {

           

            //Debug.Log((int)game_timer);
            //Debug.Log(Game_timer_2);
            //Debug.Log(Game_timer_3);

            //            switch ((int)game_timer)
            //            {
            //                case 0:
            //                    if (Game_timer_2 == 9 && Game_timer_3 == 9)
            //                    {
            //                        BGMStop = true;
            //                        time_stop = true;

            //#if UNITY_EDITOR
            //                        Debug.Log("Time up");
            //#endif
            //                    }

            //                    one.fillAmount = 0.0f;
            //                    zero.fillAmount = 1.0f;
            //                    Game_timer_two = 0;
            //                    break;

            //                case 1:
            //                    if (Game_timer_two < 1)
            //                    {
            //                        Game_timer_two += 1;
            //                        Game_timer_2 += 1;
            //                    }

            //                    zero.fillAmount = 0.0f;
            //                    nine.fillAmount = 1.0f;
            //                    break;

            //                case 2:
            //                    nine.fillAmount = 0.0f;
            //                    eight.fillAmount = 1.0f;
            //                    break;

            //                case 3:
            //                    eight.fillAmount = 0.0f;
            //                    seven.fillAmount = 1.0f;
            //                    break;

            //                case 4:
            //                    seven.fillAmount = 0.0f;
            //                    six.fillAmount = 1.0f;
            //                    break;

            //                case 5:
            //                    six.fillAmount = 0.0f;
            //                    five.fillAmount = 1.0f;
            //                    break;

            //                case 6:
            //                    five.fillAmount = 0.0f;
            //                    four.fillAmount = 1.0f;
            //                    break;

            //                case 7:
            //                    four.fillAmount = 0.0f;
            //                    three.fillAmount = 1.0f;
            //                    break;

            //                case 8:
            //                    three.fillAmount = 0.0f;
            //                    two.fillAmount = 1.0f;
            //                    break;

            //                case 9:
            //                    two.fillAmount = 0.0f;
            //                    one.fillAmount = 1.0f;
            //                    break;

            //                case 10:
            //                    game_timer = 0;
            //                    break;
            //            }
            /*
             *↓新タイムUI表示
             * */

            if (Input.GetKeyDown("c"))
            {
                game_timer += 1;
            }

            game_timer += Time.deltaTime;

            Game_Time = (int)game_timer;

#if UNITY_EDITOR
            Debug.Log(Game_Time + "int");
            //Debug.Log(game_timer + "float");
#endif


            
            if (firstdown_10 == false && Game_Time == 1)
            {
                firstdown_10 = true;
                game_timer_10 = 3;
#if UNITY_EDITOR
                Debug.Log("first_time_down_striker");
#endif
            }

            if (Game_Time >= 10 && up_count == false)//1の位
            {

                Game_Time = 0;
                game_timer = 0;
                up_count = true;
                
            }
            if (up_count == true && Game_Time == 1)
            {
                game_timer_10 += 1;
                up_count = false;
            }

            if ((int)game_timer_10 >= 10)//10の位
            {
                game_timer_10 = 0;
                

            }
            if ((int)game_timer_100 >= 9 && game_timer_10 == 0 && Game_Time == 0 && firstdown_100 == false)//100の位
            {
                firstdown_100 = true;

            }
            if (firstdown_100 && game_timer_10 == 1 && Game_Time == 1)
            {
                game_timer_100 = 0;
                firstdown_100 = false;
            }
            //else if ((int)game_timer_10 == 0 && (int)game_timer == 0 && firstdown_100 == false){

            //    firstdown_100 = true;
            //    game_timer_100 = 0;
            //}

            if ((int)game_timer_100 == 0 && (int)game_timer_10 == 0 && Game_Time == 0)//
            {

                BGMStop = true;
                time_stop = true;
                //game_timer = 0;
#if UNITY_EDITOR
                Debug.Log("Time_Out");
#endif
              
            }


            st_1.GetComponent<Renderer>().material.SetTexture("_EmissionMap", st_time[Game_Time]);
            st_10.GetComponent<Renderer>().material.SetTexture("_EmissionMap", st_time[game_timer_10]);
            st_100.GetComponent<Renderer>().material.SetTexture("_EmissionMap", st_time[game_timer_100]);


            boss_1.GetComponent<Image>().sprite = boss_time[Game_Time];
            boss_10.GetComponent<Image>().sprite = boss_time[game_timer_10];
            boss_100.GetComponent<Image>().sprite = boss_time[game_timer_100];


            /**/
        }

        if (Time_BGM_Cheacker)
        {
            Sudden_Death_in = true;
            Time_BGM_Cheacker = false;
        }
        if (BGMStop)
        {
            BGMStop = false;
            Time_BGM_Cheacker = true;
            Sudden_Death_in = true;
        }


    }
}
