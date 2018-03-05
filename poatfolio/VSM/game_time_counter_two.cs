using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class game_time_counter_two : MonoBehaviour
{

    public Image zero_2;
    public Image one_2;
    public Image two_2;
    public Image three_2;
    public Image four_2;
    public Image five_2;
    public Image six_2;
    public Image seven_2;
    public Image eight_2;
    public Image nine_2;
    public static int Game_timer_three = 0;


    // Use this for initialization
    void Start()
    {

        zero_2.fillAmount = 0.0f;
        one_2.fillAmount = 0.0f;
        two_2.fillAmount = 0.0f;
        three_2.fillAmount = 0.0f;
        four_2.fillAmount = 0.0f;
        five_2.fillAmount = 0.0f;
        six_2.fillAmount = 0.0f;
        seven_2.fillAmount = 0.0f;
        eight_2.fillAmount = 0.0f;
        nine_2.fillAmount = 0.0f;
        Game_timer_three = 0;

    }

    // Update is called once per frame
    void Update()
    {
      


        switch (game_time_counter.Game_timer_2)
        {
            case 0:
                if (Game_timer_three < 1)
                {
                    Game_timer_three += 1;
                    game_time_counter.Game_timer_3 += 1;
                }
                zero_2.fillAmount = 0.0f;
                nine_2.fillAmount = 1.0f;
                break;
            case 1:
                nine_2.fillAmount = 0.0f;
                eight_2.fillAmount = 1.0f;
                break;
            case 2:
                eight_2.fillAmount = 0.0f;
                seven_2.fillAmount = 1.0f;
                break;
            case 3:
                seven_2.fillAmount = 0.0f;
                six_2.fillAmount = 1.0f;
                break;
            case 4:
                six_2.fillAmount = 0.0f;
                five_2.fillAmount = 1.0f;
                break;
            case 5:
                five_2.fillAmount = 0.0f;
                four_2.fillAmount = 1.0f;
                break;
            case 6:
                four_2.fillAmount = 0.0f;
                three_2.fillAmount = 1.0f;
                break;
            case 7:
                three_2.fillAmount = 0.0f;
                two_2.fillAmount = 1.0f;
                break;
            case 8:
                two_2.fillAmount = 0.0f;
                one_2.fillAmount = 1.0f;
                break;
            case 9:
                one_2.fillAmount = 0.0f;
                zero_2.fillAmount = 1.0f;
                break;
            case 10:
                game_time_counter.Game_timer_2 = 0;
                break;
            

        }
    }

}