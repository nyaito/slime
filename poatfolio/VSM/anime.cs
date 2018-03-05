using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime : MonoBehaviour {

    public Animator anim;

    public static bool comeplayer = false; 
    public static bool BossHit = false;
    public static bool Moveon = false;
    public bool BossanimeSE = false;

    public GameObject Boss_Damage_Effect;


    AudioSource audioSource;
    public AudioClip BossStartSE;
    public float boss_se_time = 0;

#if UNITY_EDITOR
    //リフト上昇確認用
    //ボスにボールが当たったかどうか
    //リフトが上がりきるまで動けなくする用
    //ボスのSEが連続再生されないようにする用
    //ボスのエフェクトを格納する。
    //ボスのスタートSEを格納する用
    //SEの再生時間管理用
#endif

    // Use this for initialization
    void Start()
    {
        if (Boss_Model_Change.Model_ok)//モデル変更後にフラグが切り替わってない時用。
        {
            Boss_Model_Change.Model_ok = false;
        }

        BossanimeSE = false;
        comeplayer = false;
        BossHit = false;
        Moveon = false;
        boss_se_time = 0;
        //anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Boss_Model_Change.Model_ok)//モデル変更した祭の不具合が起きないようにする為。
        {
            Moveon = true;
            
        }
#if UNITY_EDITOR
        //if (Input.GetKeyDown("t"))
        //{
        //    Boss_Damage_Model.GetComponent<Renderer>().material.SetTexture("_EmissionMap", boss);
        //}
#endif
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);//現在再生しているアニメーションを検知する。

        if (comeplayer == true)//リフトが上がると再生するようにする
        {
#if UNITY_EDITOR
            Debug.Log("start_true");

#endif

            anim.SetBool("start", true);//ここでフラグを切り替えてる。anim←「Animatorで宣言した変数名」.SetBool("フラグの名前", trueかfalse)anim.SetFloat("speed", -1);←逆再生とかに使う。

            
            if (BossanimeSE == false){

                audioSource.PlayOneShot(BossStartSE);//SEの再生
                BossanimeSE = true;
            }
        
            if (stateInfo.IsName("this_side_S"))//今再生しているアニメーションの名前が一致したらif文内を実行
            {
#if UNITY_EDITOR
                Debug.Log("start_false");
#endif
                anim.SetBool("start", false);
                Moveon = true;
                comeplayer = false;
            }
        }



        if (change_shield.right == true)//シールドの位置によって再生するボスのアニメーションを切り替える。
        {
#if UNITY_EDITOR
            Debug.Log("R key");
#endif
            anim.SetBool("right_side", true);
            anim.SetBool("this_side", false);
            anim.SetBool("left_side", false);

        }
        if (change_shield.left == true)
        {
#if UNITY_EDITOR
            Debug.Log("L key");
#endif
            anim.SetBool("left_side", true);
            anim.SetBool("this_side", false);
            anim.SetBool("right_side", false);

        }
        if (change_shield.front == true)
        {
#if UNITY_EDITOR
            Debug.Log("space key");
#endif
            anim.SetBool("right_side", false);
            anim.SetBool("left_side", false);
            anim.SetBool("this_side", true);

        }
        if(BossHit == true || Input.GetKeyDown("h"))//ボスがダメージをくらった際の処理。
        {
#if UNITY_EDITOR
            Debug.Log("Ball_hit_anime");
#endif
            anim.SetBool("hit_ball", true);
            if (stateInfo.IsName("hit_damage"))//ダメージアニメーションを再生している時にエフェクトを出す。
            {
                GameObject Effect_parents = Instantiate(Boss_Damage_Effect, transform.position, transform.rotation);//エフェクトを生成してこのスクリプトが貼ってあるオブジェクトの子オブジェクトにする。
                Effect_parents.transform.parent = transform;//
                BossHit = false;
            }
        }
        if(BossHit == false)
        {
            anim.SetBool("hit_ball", false);
        }

  
    }

}