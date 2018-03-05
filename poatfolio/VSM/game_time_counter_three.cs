using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class game_time_counter_three : MonoBehaviour
{

    public Image zero_3;
    public Image one_3;
    public Image two_3;
    public Image three_3;
    public Image four_3;
    public Image five_3;
    public Image six_3;
    public Image seven_3;
    public Image eight_3;
    public Image nine_3;


    // Use this for initialization
    void Start()
    {

        zero_3.fillAmount = 0.0f;
        one_3.fillAmount = 0.0f;
        two_3.fillAmount = 0.0f;
        three_3.fillAmount = 0.0f;
        four_3.fillAmount = 0.0f;
        five_3.fillAmount = 0.0f;
        six_3.fillAmount = 0.0f;
        seven_3.fillAmount = 0.0f;
        eight_3.fillAmount = 0.0f;
        nine_3.fillAmount = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {


        switch (game_time_counter.Game_timer_3)
        {
            case 0:
                zero_3.fillAmount = 0.0f;
                nine_3.fillAmount = 1.0f;
                break;
            case 1:
                nine_3.fillAmount = 0.0f;
                eight_3.fillAmount = 1.0f;
                break;
            case 2:
                eight_3.fillAmount = 0.0f;
                seven_3.fillAmount = 1.0f;
                break;
            case 3:
                seven_3.fillAmount = 0.0f;
                six_3.fillAmount = 1.0f;
                break;
            case 4:
                six_3.fillAmount = 0.0f;
                five_3.fillAmount = 1.0f;
                break;
            case 5:
                five_3.fillAmount = 0.0f;
                four_3.fillAmount = 1.0f;
                break;
            case 6:
                four_3.fillAmount = 0.0f;
                three_3.fillAmount = 1.0f;
                break;
            case 7:
                three_3.fillAmount = 0.0f;
                two_3.fillAmount = 1.0f;
                break;
            case 8:
                two_3.fillAmount = 0.0f;
                one_3.fillAmount = 1.0f;
                break;
            case 9:
                one_3.fillAmount = 0.0f;
                zero_3.fillAmount = 1.0f;
                break;


        }
    }

}
