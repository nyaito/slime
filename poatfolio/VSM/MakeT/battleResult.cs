using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class battleResult : MonoBehaviour
{

    //public static int turn = 0;
    public  static bool boss;
    public static bool striker;
    public static bool Finish = false;
    public static bool timeout = false;
    public static bool BGMStop_result = false; 
    // Use this for initialization
    void Start()
    {

        Finish = false;
        timeout = false;
        BGMStop_result = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss_tex_Main.round == 0 && Finish)
        {
#if UNITY_EDITOR
            Debug.Log("round1_finish");
#endif
           
                if (Striker.S_lose)//ボスの勝ち
                {
                    Boss_Player.B_win += 1;
                    Striker.S_lose = false;
                    boss = true;
                    Boss_tex_Main.round += 1;
#if UNITY_EDITOR
                    Debug.Log("Boss  B_win round");
#endif
                }
                else if (Boss_Player.B_lose)//ストの勝ち
                {
                    Striker.S_win += 1;
                    Boss_Player.B_lose = false;
                    striker = true;
                    Boss_tex_Main.round += 1;
#if UNITY_EDITOR
                    Debug.Log("St  S_win  round");
#endif
                }

           
            BGMStop_result = true;
            Finish = false;
            StartCoroutine(GoToLoadSceneCoroutine());
            
        }

        else if (Boss_tex_Main.round == 1 && Finish)
        {
#if UNITY_EDITOR
            Debug.Log("round2_finish");
#endif
            BGMStop_result = true;
            if (Striker.S_lose && striker)//一回戦でストが勝った。二回戦でボスが勝った。（連勝でリザルトへ）
            {
                Boss_Player.B_win += 3;
                Boss_Player.B_lose = false;
                
#if UNITY_EDITOR
                Debug.Log("round2_finish_A");
#endif
                Finish = false;
                StartCoroutine(GoToresultBSSceneCoroutine());
            }
            if (Boss_Player.B_lose && striker)//一回戦でストが勝った。二回戦でストが勝った。（第三ラウンドへ）
            {
                Boss_Player.B_win += 1;
                Boss_Player.B_lose = false;
                Boss_tex_Main.round += 1;
                Finish = false;
               
                StartCoroutine(GoToLoadSceneCoroutine());
#if UNITY_EDITOR
                Debug.Log("round2_finish_D");
#endif
            }

            if (Striker.S_lose && boss)//一回戦でボスが勝った。二回戦でボスが勝った。（第三ラウンドへ）
            {
                Striker.S_win += 1;
               Striker.S_lose = false;
                Boss_tex_Main.round += 1;
                Finish = false;
                
                StartCoroutine(GoToLoadSceneCoroutine());
#if UNITY_EDITOR
                Debug.Log("round2_finish_B");
#endif
            }

            if (Boss_Player.B_lose && boss)//一回戦でボスが勝った。二回戦目でストが勝った。（連勝でリザルトへ）
            {
                Striker.S_win += 3;
                Boss_Player.B_lose = false;
               
#if UNITY_EDITOR
                Debug.Log("round2_finish_C");
#endif
                Finish = false;
                StartCoroutine(GoToresultSTSceneCoroutine());
            }
        }

        else if (Boss_tex_Main.round == 2 && Finish)
        {
#if UNITY_EDITOR
            Debug.Log("round3_finish");
#endif
            BGMStop_result = true;
            if (Striker.S_lose)
            {
                Boss_Player.B_win += 2;
                Striker.S_lose = false;
                
                StartCoroutine(GoToresultBSSceneCoroutine());
            }
            if (Boss_Player.B_lose)
            {
                Striker.S_win += 2;
                Boss_Player.B_lose = false;
               
                StartCoroutine(GoToresultSTSceneCoroutine());
            }
        }

    }

    IEnumerator GoToresultSTSceneCoroutine()
    {

        // 1秒間待つ(フェードアウト用)
        yield return new WaitForSeconds(0.0f);

        // 次のシーンに遷移
        SceneManager.LoadScene("resultST");
    }

    IEnumerator GoToresultBSSceneCoroutine()
    {

        //1秒間待つ(フェードアウト用)
        yield return new WaitForSeconds(0.0f);

        // 次のシーンに遷移
        SceneManager.LoadScene("resultBS");
    }

    IEnumerator GoToLoadSceneCoroutine()
    {

        // 1秒間待つ(フェードアウト用)
        yield return new WaitForSeconds(0.0f);

        // 次のシーンに遷移
        SceneManager.LoadScene("load");
    }
}


