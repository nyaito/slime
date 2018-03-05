using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Striker : MonoBehaviour {
    public static int Shield = 0;
    public static int LifeA;
    public static bool Strike_Damage = false;

    public static bool S_lose = false;
    public static int S_win = 0;
    void Start()
    {
        LifeA = 5;
        Shield = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Strike_Damage == true)
        {
#if UNITY_EDITOR
            Debug.Log("Damage_down_strike");
#endif          
            LifeA -= 1;
            Shield += 1;
            Shield %= 5;
            Strike_Damage = false;
            ST_Arm_Effect.st_effect = false;
            Damage_Camera.SDam = true;                      
        }

        if (LifeA == 0 && game_time_counter.time_stop == false)
        {
            LifeA = 5;
            S_lose = true;
            battleResult.Finish = true;
            
        }

        /**///デバッグ用ショートカット
        if (Input.GetKeyDown("b"))
        {
            S_lose = true;
            battleResult.Finish = true;
            Debug.Log("b");
        }
        /**/
    }
}
