using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Player : MonoBehaviour {
    public static bool BossDamage = false;
    public static bool ArmFLAG = false;
    public Image image;
    public Image imageS;
    public Image imageA;

    public static int Arm = 0;
    public static int LifeB;

    public static bool B_lose = false;
    public static int B_win = 0;

    public static bool texture_Change = false;

    public Animator animator;

    void Start()
    {
        texture_Change = false;
        image.fillAmount = 1.0f;
        LifeB = 5;
        Arm = 0;       
    }
    void Update()
    {    
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (LifeB == 0 && game_time_counter.time_stop == false)
        {
            LifeB = 5;
            battleResult.Finish = true;
            B_lose = true;           
        }
               
        if(BossDamage == true)
        {
#if UNITY_EDITOR
            Debug.Log("Damage_down");
#endif
            LifeB -= 1;
            image.fillAmount -= 0.2f;
            BossDamage = false;
            texture_Change = true;
            
            //anime.BossHit = false;
        }


        if (anime.Moveon == true || change_shield.MoveLock == false) {
            if (Input.GetButtonDown("Change_Shield_A") && ShieldAnimation.ShieldModeFlag && ShieldAnimation.ArmF)
            {
#if UNITY_EDITOR
                Debug.Log("Arm_Change_UI");
#endif
                if (stateInfo.IsName("Normal"))
                {
                    Arm += 1;
                    Arm %= 2;
                }
            }
            if (Input.GetButtonDown("Change_Shield_S") && ShieldAnimation.ShieldModeFlag == false && ShieldAnimation.ArmF == false)
            {
                if (stateInfo.IsName("Nomotion"))
                {
                    Arm += 1;
                    Arm %= 2;
                }
            }         
        }
        if (Arm == 0)
        {
            imageS.fillAmount = 1.0f;
            imageA.fillAmount = 0.0f;
            ArmFLAG = false;
        }
        else if (Arm == 1)
        {
            imageS.fillAmount = 0.0f;
            imageA.fillAmount = 1.0f;
            ArmFLAG = true;
        }

        /**///デバッグ用ショートカット
        if (Input.GetKeyDown("s"))
        {
            B_lose = true;
            battleResult.Finish = true;
            Debug.Log("s");
        }
        /**/
    }
}
