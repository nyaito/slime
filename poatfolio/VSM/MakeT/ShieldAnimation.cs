using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimation : MonoBehaviour {
    public Animator animator;
    public static bool ShieldModeFlag = true;//trueならシールドモード
    public bool CatchAnimFlag = false;//trueならボールが判定内にある状態

    public bool ActF = false;//掴めないときに押すとtrueになってアクションアニメーションを再生させる
    public bool ActF2 = false;//掴めないときに押すとtrueになってアクションアニメーションを再生させる
    public static bool CatF = false;//掴めるときに押すとtrueになってキャッチアニメーションを再生させる
    public bool ThrF = false;//投げるアニメーションのフラグ
   
    public static bool ThrowAnimMove = false;
    public static bool Fire = false;

    public float time = 0.0f;

    public static bool ArmF = true;//ボールを持ったままモード変更しないようにする
 
    public static float rote_S = 0;
    public static bool shield_rote_A;
    public static bool shield_rote_S;
    public static bool Arm_mode_now = false;

    public GameObject Rotate_Effect;

    AudioSource audioSource;
    public AudioClip ShieldSpinSE;

    void Start()
    {
        ThrowAnimMove = false;
        ShieldModeFlag = true;
        CatchAnimFlag = false;
        Arm_mode_now = false;
        Fire = false;
        CatF = false;
        ActF = false;
        ActF2 = false;
        ThrF = false;
        ArmF = true;

        time = 0.0f;

        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "ball")
        {
            CatchAnimFlag = true;
#if UNITY_EDITOR
            Debug.Log("Catch");
#endif
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ball")
        {
            CatchAnimFlag = false;
        }
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //if (Input.GetButtonDown("joystick button 0") == true && flag && ArmF)
        //{
        //    //ゲームパッドに使う仮想ボタンが押し下げられた時にする処理
        //    this.transform.Rotate(new Vector3(0, 1, 0), 180);
        //    animator.SetBool("take", true);
        //    animator.SetBool("noShield", true);
        //    flag = false;
        //}
        if (anime.Moveon == true || change_shield.MoveLock == false)
        {            
            //if (Input.GetButtonDown("Change_Shield_A") && ShieldModeFlag && ArmF && stateInfo.IsName("Normal"))
            if(Boss_Player.ArmFLAG)
            {
                if (stateInfo.IsName("Normal"))
                {
#if UNITY_EDITOR
                    Debug.Log("Arm_Change");
#endif
                    Arm_mode_now = true;
                    shield_rote_A = true;
                    //this.transform.Rotate(new Vector3(0, 1, 0), rote_S);
                    if (ShieldModeFlag)
                    {
                        GameObject Effect_parents = Instantiate(Rotate_Effect, transform.position, transform.rotation);
                        Effect_parents.transform.parent = transform;
                        audioSource.PlayOneShot(ShieldSpinSE);
                    }
                    ShieldModeFlag = false;
                    animator.SetBool("take", true);
                    animator.SetBool("noShield", true);
 
                }
            }
            //if (Input.GetButtonDown("Change_Shield_S") && ShieldModeFlag == false && ArmF == false && stateInfo.IsName("Nomotion"))
            if (Boss_Player.ArmFLAG == false)
            {
                if (stateInfo.IsName("Nomotion"))
                {
                    Arm_mode_now = false;
                    shield_rote_S = true;
                    //this.transform.Rotate(new Vector3(0, 1, 0), rote_S);
                    if (ShieldModeFlag == false)
                    {
                        GameObject Effect_parents = Instantiate(Rotate_Effect, transform.position, transform.rotation);
                        Effect_parents.transform.parent = transform;
                        audioSource.PlayOneShot(ShieldSpinSE);
                    }
                    ShieldModeFlag = true;
                    animator.SetBool("RT", false);
                    animator.SetBool("throw", false);
                    animator.SetBool("catch", false);
                    animator.SetBool("action", false);
                    animator.SetBool("take", false);
                    animator.SetBool("noShield", false);
                    ArmF = true;
                }

            }

            if(Ball_bomb.Striker_catch_timer > Ball_bomb.ball_hold_time)
            {
                animator.SetBool("bomb", true);
                animator.SetBool("action", false);
                animator.SetBool("catch", false);
                animator.SetBool("throw", false);
                ActF = false;
                CatchAnimFlag = false;
            }
            else if (Ball_bomb.Striker_catch_timer == 0)
            {
                animator.SetBool("bomb", false);
                animator.SetBool("RT", false);
            }

            if (ShieldModeFlag == false)//アームモード時
            {

                if (((Input.GetAxis("Shot_Catch") < 0.0f) || (Input.GetButtonDown("Change_Shield_A") && Input.GetAxis("Shot_Catch") < 0.0f)) && CatchAnimFlag == true && ShieldAnimation_damege.DamF == false && ThrF == false && Fire == false && ActF2 == false)
                {
                    animator.SetBool("RT", true);
                    animator.SetBool("catch", true);
                    CatF = true;
                    ActF = false;
                    ArmF = true;
                    if(CatF)
                    {
                        animator.SetBool("action", false);
                    }

                    if (((Input.GetAxis("Shot_Catch") < 0.0f) || (Input.GetButtonDown("Change_Shield_A") && Input.GetAxis("Shot_Catch") < 0.0f)))
                    {
                        if ((Input.GetButtonDown("Xbox_A") && ((Input.GetAxis("Shot_Catch") < 0.0f) || (Input.GetButtonDown("Change_Shield_A") && Input.GetAxis("Shot_Catch") < 0.0f))) && stateInfo.IsName("Catch") || Input.GetKeyDown("a"))
                        {
                            Fire = true;
                            animator.SetBool("throw", true);
                            ThrowAnimMove = true;
                            ThrF = true;

                        }
                    }
                }
                else if (((Input.GetAxis("Shot_Catch")  == 0.00f) || (Input.GetButtonDown("Change_Shield_A") && Input.GetAxis("Shot_Catch") == 0.00f)))
                {
                    animator.SetBool("RT", false);
                    animator.SetBool("throw", false);
                    animator.SetBool("catch", false);
                    animator.SetBool("action", false);
                    CatF = false;
                    Fire = false;
                    ArmF = false;
                }
                else if (((Input.GetAxis("Shot_Catch") < 0.0f) || (Input.GetButtonDown("Change_Shield_A") && Input.GetAxis("Shot_Catch") < 0.0f)) && CatchAnimFlag == false && ShieldAnimation_damege.DamF == false && ActF == false)
                {
                    ActF = true;
                    ActF2 = true;
                }
                else if (ActF)
                {
                    animator.SetBool("action", true);
                    time = time + Time.deltaTime;
                    ArmF = true;
                    if (time >= 0.2f)
                    {
                        animator.SetBool("action", false);
                        time = 0.0f;
                        ActF = false;
                        ActF2 = false;
                    }
                }
                else if (ThrF)
                {
                    ArmF = true;
                    time = time + Time.deltaTime;

                    if (time >= 0.1f)
                    {
                        animator.SetBool("RT", false);
                        Fire = false;
                        time = 0.0f;
                        ThrowAnimMove = false;
                        ThrF = false;
                    }
                }
            }                   
        }
    }
}
