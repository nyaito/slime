using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeHitCheck : MonoBehaviour {

    public static bool S_Spawn = false;
    public GameObject S_Ball;
    public static float S_Spawntime = 0;
    public static bool First_Spawn = true;



    // Use this for initialization
    void Start () {

        S_Spawn = false;
        First_Spawn = true;
      

    }
	
	// Update is called once per frame
	void Update () {

        if (S_Spawn)
        {

            S_Spawntime += Time.deltaTime;
#if UNITY_EDITOR
            //Debug.Log(S_Spawntime);
#endif
            if (S_Spawntime >= 5)
            {
                Instantiate(S_Ball, new Vector3(0f, 6f, 6f), transform.rotation);
                //S_Spawntime = 0;
                S_Spawn = false;
            }
        }



    }

    void OnTriggerEnter(Collider other)
    {
        if (OVRGrabber.ballcatch == false)
        {
            if (other.tag == "ball")
            {
#if UNITY_EDITOR
                Debug.Log("Trigger_ball_strike");
#endif
                if(Striker_Under_Ball.ball_under == false && game_time_counter.time_stop == false)
                {
                    Destroy(other.gameObject);
                    other = null;
                    Striker.Strike_Damage = true;
                        if (Striker.LifeA != 1)
                        {
                            S_Spawn = true;
                        }
                  
                }

                else if (game_time_counter.time_stop)
                {
                    Striker.LifeA -= 1;
                    Striker.Strike_Damage = true;

                    Destroy(other.gameObject);
                    other = null;
                    if (Striker.LifeA == Boss_Player.LifeB)
                    {
                        Striker.LifeA += 1;
                        Striker.Strike_Damage = true;
                        S_Spawn = true;
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
}
