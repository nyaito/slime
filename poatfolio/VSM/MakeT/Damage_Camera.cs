using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage_Camera : MonoBehaviour {

    public Image BImage1;
    public Image BImage2;
    public Image BImage3;
    public Image BImage4;
    public Image BImage5;
    public Image SImage1;
    public Image SImage2;
    public Image SImage3;
    public Image SImage4;
    public Image SImage5;

    public float Btimer = 0;
    public float Stimer = 0;

    public static bool BDam = false;

    public static bool SDam = false;

    // Use this for initialization
    void Start()
    {
        BImage1.fillAmount = 0.0f;//1B
        BImage2.fillAmount = 0.0f;//2B
        BImage3.fillAmount = 0.0f;//3B
        BImage4.fillAmount = 0.0f;//4B
        BImage5.fillAmount = 0.0f;//LastB
        SImage1.fillAmount = 0.0f;//1S
        SImage2.fillAmount = 0.0f;//2S
        SImage3.fillAmount = 0.0f;//3S
        SImage4.fillAmount = 0.0f;//4S
        SImage5.fillAmount = 0.0f;//LastS

        BDam = false;
        SDam = false;

        Btimer = 0;
        Stimer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if((Boss_Player.BossDamage && BDam == false) || (Input.GetKey(KeyCode.Y) && BDam == false))
        {
            BDam = true;
        }

        if ((Striker.Strike_Damage && SDam == false) || (Input.GetKey(KeyCode.R) && SDam == false))
        {
            SDam = true;
        }

        if (BDam && Boss_Player.LifeB > 1)
        {
            Btimer = Btimer + Time.deltaTime;
            BImage1.fillAmount = 1.0f;
            if (Btimer > 0.05f)
            {
                BImage2.fillAmount = 1.0f;
                if (Btimer > 0.1f)
                {
                    BImage3.fillAmount = 1.0f;
                    if (Btimer > 0.15f)
                    {
                        BImage4.fillAmount = 1.0f;


                        if (Btimer > 3.0f)
                        {
                            BImage1.fillAmount = 0.0f;
                            BImage2.fillAmount = 0.0f;
                            BImage3.fillAmount = 0.0f;
                            BImage4.fillAmount = 0.0f;
                            BDam = false;
                            Btimer = 0.0f;
                        }

                    }
                }
            }
        }
        else if (Boss_Player.LifeB == 1)
        {
            BImage5.fillAmount = 1.0f;
        }


        if (SDam && Striker.LifeA > 1)
        {
            Stimer = Stimer + Time.deltaTime;
            SImage1.fillAmount = 1.0f;
            if (Stimer > 0.05f)
            {
                SImage2.fillAmount = 1.0f;
                if (Stimer > 0.1f)
                {
                    SImage3.fillAmount = 1.0f;
                    if (Stimer > 0.15f)
                    {
                        SImage4.fillAmount = 1.0f;

                        if (Stimer > 3.0f)
                        {
                            SImage1.fillAmount = 0.0f;
                            SImage2.fillAmount = 0.0f;
                            SImage3.fillAmount = 0.0f;
                            SImage4.fillAmount = 0.0f;
                            SDam = false;
                            Stimer = 0.0f;
                        }

                    }
                }
            }
        }
        else if (Striker.LifeA == 1)
        {
            SImage5.fillAmount = 1.0f;
        }

    }
}
