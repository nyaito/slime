using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    //ボールをキャッチしているときの判定に用いる
    public static bool CatchFlag = true;//trueで掴める状態falseで掴んでいる状態
    public static bool ThrowFlag = false;//trueで投げれる状態falseで投げれない

    public bool CatchSpace_In = false;

    public static bool Goff = false;//←掴んだときの重力切り替え
   
    //投擲時のボールのスピード
    public float speed1;

    //回転の中心をとるために使う変数
    private Vector3 targetPos;

    public GameObject Shot_effct;

    AudioSource audioSource;
    public AudioClip CatchSE;
    public AudioClip ShotSE;
    public AudioClip ReflectSE;
    public float ballSP = 0f;

    public Vector3 ballSpeed = Vector3.zero;
    public static bool ballPulse;

    void Start()
    {
        CatchSpace_In = false;
        CatchFlag = true;
        ThrowFlag = false;
        Goff = false;
        audioSource = GetComponent<AudioSource>();
        ballSpeed = Vector3.zero;
        ballPulse = false;
        ballSP = -1.5f;
    }

    void Update()
    {
        Rigidbody ballRigid = this.GetComponent<Rigidbody>();
        ballSpeed = ballRigid.velocity;


        //targetにシールドの情報を入れる
        Transform target = GameObject.Find("robotest7_Shield_touka").transform;
        //変数targetPosにSampleの位置情報を取得
        targetPos = target.position;

        if (CatchSpace_In && ShieldAnimation_damege.DamF == false)
        {
            if (ShieldAnimation.CatF && CatchFlag && ShieldAnimation.Arm_mode_now && ShieldAnimation.Fire == false)
            {
                audioSource.PlayOneShot(CatchSE);
                Rigidbody lRigid = this.GetComponent<Rigidbody>();
                Goff = true;
                lRigid.velocity = Vector3.zero;
                lRigid.angularVelocity = Vector3.zero;
                CatchFlag = false;
            }

            if (CatchFlag == false && ShieldAnimation.Fire == false && ShieldAnimation.CatF)
            {
                ThrowFlag = true;
                this.transform.position = targetPos - (target.forward * 2);
            }
            //ボールを投げるためのもの
            if (ThrowFlag == true && CatchFlag == false && ShieldAnimation.ThrowAnimMove && ShieldAnimation.Fire)
            {
                this.GetComponent<Rigidbody>().AddForce((target.forward) * speed1, ForceMode.VelocityChange);
                Goff = false;
                ThrowFlag = false;
                CatchFlag = true;
                ShieldAnimation.ThrowAnimMove = false;
                audioSource.PlayOneShot(ShotSE);
                GameObject Effect_parents = Instantiate(Shot_effct, this.transform.position, this.transform.rotation);
                Effect_parents.transform.parent = transform;
            }

            if (ShieldAnimation.Fire == false && ShieldAnimation.CatF == false)
            {
                Goff = false;
                ThrowFlag = false;
                CatchFlag = true;
            }

            if (ballPulse)
            {
                ballSpeed *= ballSP;
                this.GetComponent<Rigidbody>().velocity = ballSpeed;
            }        
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Shield_Coll" && ShieldAnimation.Arm_mode_now == true)
        {
            CatchSpace_In = true;
        }
        if (other.tag == "Ball_plus" && ShieldAnimation.Arm_mode_now == false)
        {
            ballPulse = true;
            audioSource.PlayOneShot(ReflectSE);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Shield_Coll")
        {
            
            CatchSpace_In = false;
            Goff = false;
            ThrowFlag = false;
            CatchFlag = true;
            
            ShieldAnimation.ThrowAnimMove = false;
        }
        if(other.tag == "Ball_plus")
        {
            ballPulse = false;
        }

        if(other.tag == "Destroy_Wall")
        {
            Destroy(this.gameObject);
            StrikeHitCheck.S_Spawn = true;
        }
    }

}