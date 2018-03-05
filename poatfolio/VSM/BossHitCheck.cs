using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitCheck : MonoBehaviour
{
    public static bool B_Spawn = false;
    public GameObject B_Ball;
    public static float B_Spawntime = 0;
   

    // Use this for initialization
    void Start()
    {
        B_Spawn = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(B_Spawn)
        {
            B_Spawntime += 0.5f * Time.deltaTime;

            if (B_Spawntime >= 9)
            {
#if UNITY_EDITOR
                Debug.Log("ball_spown");
#endif
                Instantiate(B_Ball, new Vector3(0f, 5f, -6f), transform.rotation);
                //B_Spawntime = 0;
                B_Spawn = false;
                Change_texture.texchange = false;
            }
           
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
#if UNITY_EDITOR
            Debug.Log("Trigger_ball");
#endif
            if (game_time_counter.time_stop == false)
            {
                Destroy(other.gameObject);
                other = null;
                    Boss_Player.BossDamage = true;
                    anime.BossHit = true;
                    B_Spawn = true;

                //if (Boss_Player.LifeS != 1)
                //{
                //    B_Spawn = true;
                //}
            }

            else if (game_time_counter.time_stop)
            {
                Boss_Player.LifeB -= 1;
                anime.BossHit = true;
                Destroy(other.gameObject);
                other = null;    
                if (Striker.LifeA == Boss_Player.LifeB)
                {
                    Boss_Player.LifeB += 1;
                    Boss_Player.BossDamage = true;
                    B_Spawn = true;
                }
                else if (Striker.LifeA < Boss_Player.LifeB)
                {
                    Striker.S_lose = true;
#if UNITY_EDITOR
                    Debug.Log("Time out win boss");
#endif
                    battleResult.Finish = true;
                }
                else if (Striker.LifeA > Boss_Player.LifeB)
                {
                    Boss_Player.B_lose = true;
#if UNITY_EDITOR
                    Debug.Log("Time out win striker");
#endif
                    battleResult.Finish = true;
                }
                
                
            }
        }
        
    }
}
