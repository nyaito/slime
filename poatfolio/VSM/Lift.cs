using UnityEngine;
using System.Collections;

public class Lift : MonoBehaviour
{
    //public float timeOut;
    //private float timeElapsed;
    //bool gamestart = false;
    //public float up = 0.5F;
    //public float down = -0.5F;
    public static Vector3 speeder;
    public static bool  movecam = true;
    float liftspeed  = 0.75f;

    public int BGMcount = 0;
    AudioSource audioSource;
    public AudioClip LiftUpSE;
    public AudioClip LiftTopSE;
    public static bool ReadyBGM = false;
    public static bool ThrowBomBGM = false;
    public static bool BGMStop = false;
    public bool Lift_BGM_Cheacker = false;
    public bool BGM_Lift_Stop = false;

    // Use this for initialization
    void Start()
    {
        BGMcount = 0;
        movecam = true;
        speeder = this.transform.position;
        BGMStop = false;
        audioSource = GetComponent<AudioSource>();
        ReadyBGM = true;
        ThrowBomBGM = false;
        Lift_BGM_Cheacker = false;
        BGM_Lift_Stop = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (anime.Moveon == true && StrikeHitCheck.First_Spawn == true && movecam == false)
        {
            StrikeHitCheck.S_Spawntime = 4.5f;
            StrikeHitCheck.S_Spawn = true;
            StrikeHitCheck.First_Spawn = false;
            Debug.Log("first_spawn");
        }
        //transform.position += transform * Time.deltaTime * speed;
        if (movecam == true)
        {
            if (St_tex_Main.ready_st == true && Boss_tex_Main.ready == true)//ここにSEやBGMのフラグを入れたいけどmovecamの中は何度も呼び出されるから何度も再生されている状態になっています
            {
                
#if UNITY_EDITOR
                Debug.Log("up");
#endif
                

                //現在の位置を空のVector3 speederに代入   
                if (Lift_BGM_Cheacker == true)
                {
                        BGMStop = false;
                        ThrowBomBGM = true;
                        Lift_BGM_Cheacker = false;
#if UNITY_EDITOR
                        Debug.Log("BGM_stop and start");
#endif
                    
                }
                if (BGM_Lift_Stop == false && BGMStop == false)
                {
                    
                    BGM_Lift_Stop = true;
                    BGMStop = true;
                    Lift_BGM_Cheacker = true;
                }


                this.transform.position = new Vector3(speeder.x, speeder.y += liftspeed * Time.deltaTime, speeder.z);//speederに毎秒0.5づつ上昇するようにしそれを現在の位置に代入。

                if (Input.GetKey("l"))
                {
                    liftspeed = 2.8f;
                }
                //this.transform.Translate(Vector3.up * 2 * Time.deltaTime);           
                         
            }
            if (speeder.y >= 0)//Yの座標が0を越えると上昇を止める。
            {
                BGMStop = false;
#if UNITY_EDITOR
                Debug.Log("stop and false");
#endif

//                if (BGMcount == 0)
//                {
//                    ThrowBomBGM = true;
//                    BGMcount += 100;
//#if UNITY_EDITOR
//                    Debug.Log("TROBOM_BGM_start");
//#endif
//                }
                movecam = false;//リフトの上昇停止
                //anime.comeplayer = false;//リフトが上がり切るとフラグをfalseにしてループを防ぐ。
            }
            else if (speeder.y >= -1f && speeder.y < -0.1)
            {
                audioSource.PlayOneShot(LiftTopSE);
#if UNITY_EDITOR
                Debug.Log("motion");
#endif
                if (speeder.y > -0.2)
                {
                    audioSource.Stop();
                    anime.comeplayer = true;//リフトが上がり切る手前で再生開始
                }
            }
            else if(speeder.y <= -2 && St_tex_Main.ready_st == true && Boss_tex_Main.ready == true)
            {
                audioSource.PlayOneShot(LiftUpSE);
                
#if UNITY_EDITOR
                Debug.Log("Lift_UP_SE");
#endif
            }
        }
    }
}