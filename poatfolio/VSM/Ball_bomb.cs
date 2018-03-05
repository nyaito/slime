using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class Ball_bomb : MonoBehaviour {

    public float Boss_catch_timer;
    public static float Striker_catch_timer;
    public static float ball_hold_time = 8;
#if UNITY_EDITOR
    //掴んでられる限界時間
    // public GameObject ball_bomb;
#endif

    private float Ccolor = 0.5f;
    private Renderer r;


    // Use this for initialization
    void Start () {
        Ccolor = 0.5f;
        r = GetComponent<Renderer>(); //Rendererコンポーネントを取得（Material取得のため）

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m")) {//ボールの色が変わるのを確認する為
            r.material.EnableKeyword("_EMISSION");
            r.material.SetColor("_EmissionColor", new Color(1.5f, 0, 0)); //とりあえずEmissionで真っ赤にしてみる
        }

        if (game_time_counter.time_stop == false)
        {
#if UNITY_EDITOR
            //if(Boss_catch_timer > ball_hold_time/2 || Striker_catch_timer > ball_hold_time / 2)
            //{
            //    r.material.EnableKeyword("_EMISSION");
            //    r.material.SetColor("_EmissionColor", new Color(1.5f, 0, 0)); //とりあえずEmissionで真っ赤にしてみる
            //}
#endif

            if (OVRGrabber.ballcatch == true)//VR側が掴んだら
            {
                Boss_catch_timer += Time.deltaTime;
                Ccolor -= (Time.deltaTime/10);
                if (Ccolor <= 0)
                    Ccolor = 0;

                r.material.EnableKeyword("_EMISSION");
                r.material.SetColor("_EmissionColor", new Color(1.5f, Ccolor, 0));

                if (Boss_catch_timer > ball_hold_time)//ボールを持ってる時間が持てる限界時間を越えると入る（ボス）
                {
#if UNITY_EDITOR
                    /*自機にダメージがはいって、アニメーションを再生。徐々にボールの色を変更。
                    持ってる時間をリセットしボールを消す。
                    変更してたカラーを元に戻し、ボールをスポーンさせる。*/
#endif
                    Ccolor = 0.5f;
                    Striker.Strike_Damage = true;
                    Boss_catch_timer = 0;
                    Destroy(this.gameObject);
                    r.material.EnableKeyword("_EMISSION");
                    r.material.SetColor("_EmissionColor", new Color(1.5f, 0.5f, 0));
                    BossHitCheck.B_Spawn = true;
                }

            }
            else if (OVRGrabber.ballcatch == false && ball.CatchFlag == true)//VR側が離したら
            {
                Ccolor = 0.5f;
                Boss_catch_timer = 0;
                r.material.EnableKeyword("_EMISSION");
                r.material.SetColor("_EmissionColor", new Color(1.5f, 0.5f, 0));
            }

            if (ball.CatchFlag == false)//ディスプレイ側が掴んだら
            {
                Striker_catch_timer += Time.deltaTime;

                Ccolor -= (Time.deltaTime/10);
                if (Ccolor <= 0)
                    Ccolor = 0;

                r.material.EnableKeyword("_EMISSION");
                r.material.SetColor("_EmissionColor", new Color(1.5f, Ccolor, 0));

                if (Striker_catch_timer > ball_hold_time)//ボールを持ってる時間が持てる限界時間を越えると入る（ストライカー）
                {
#if UNITY_EDITOR
                    /*自機にダメージがはいって、アニメーションを再生。徐々にボールの色を変更。
                     持ってる時間をリセットしボールをけす。
                     変更してたカラーを元に戻し、ボールをスポーンさせる。
                     ※ボスのライフが2か1じゃない時のみ*/
#endif
                    Ccolor = 0.5f;
                    Boss_Player.BossDamage = true;
                    anime.BossHit = true;
                    Boss_catch_timer = 0;
                    Destroy(this.gameObject);
                    //ball_bomb = null;
                    r.material.EnableKeyword("_EMISSION");
                    r.material.SetColor("_EmissionColor", new Color(1.5f, 0.5f, 0));
                    if (Boss_Player.LifeB != 2 && Boss_Player.LifeB != 1)
                    {
                        StrikeHitCheck.S_Spawn = true;
                    }
                    
                    
                }

            }
            else if (ball.CatchFlag == true && OVRGrabber.ballcatch == false)//ディスプレイ側が離したら
            {
                Ccolor = 0.5f;
                Striker_catch_timer = 0;
                r.material.EnableKeyword("_EMISSION");
                r.material.SetColor("_EmissionColor", new Color(1.5f, 0.5f, 0));
            }
        }

        else
        {
            Striker_catch_timer = 0;
            Boss_catch_timer = 0;
        }

    }
   
}
