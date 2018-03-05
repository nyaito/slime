using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Destoy_Zone : MonoBehaviour
{
    public float Zone_timer;
    public float Del_time;
    int ball_spawn_side = 2;
#if UNITY_EDITOR
    //ボールが判定内にあると増え続ける。
    //消える限界時間。
#endif

    // Use this for initialization
    void Start()
    {
        ball_spawn_side = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "ball")//トリガー判定内にボールが入ると起動。
        {
            Zone_timer += Time.deltaTime;
#if UNITY_EDITOR
            Debug.Log("Zone_ball");
#endif
            if (Zone_timer >= Del_time) {//消える限界時間を越えると起動
                
                Destroy(other.gameObject);//ボールを消す。
                other = null;
                
                if(ball_spawn_side % 2 == 0)//偶数回にはボス側、奇数回にはストライカーにスポーンする。
                {
                    BossHitCheck.B_Spawn = true;
                    ball_spawn_side += 1;
                }
                else if(ball_spawn_side % 2 == 1)
                {
                    StrikeHitCheck.S_Spawn = true;
                    ball_spawn_side += 1;
                }

                Zone_timer = 0;
            }

        }
    }

    private void OnTriggerExit(Collider other)//判定外に出ると時間をリセット。
    {
        if (other.tag == "ball")
        {
            Zone_timer = 0;
        }
    }
}
