using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    public Animator Stranim;

    [SerializeField]
    protected float strike_speed = 2;
    [SerializeField]
    protected bool Handedness;
    [SerializeField]
    protected bool MoveLock = true;

    public static bool right = false;
    public static bool left = false;
    public static bool forward = false;
    public static bool back = false;
    public AudioClip StrikerSE;
    AudioSource audioSource;
    public float walker_Check = 0;
    public bool walknow = false;
    public static bool RotateCamera = false;
    public static bool RCameraMove = false;
    public static bool LCameraMove = false;
    float timeVR = 0;

    /**///SEをリソースロードする（配列は必要な数だけ）intで配列番号を指定する。
    //private AudioClip[] se = new AudioClip[10];
    //public static int SE_Number;
    /**/


    void Start () {
        audioSource = GetComponent<AudioSource>();
        walker_Check = 0;
        walknow = false;
        right = false;
        left = false;
        forward = false;
        back = false;
        RotateCamera = false;
        timeVR = 0;
        RCameraMove = false;
        LCameraMove = false;
        //se = Resources.LoadAll<AudioClip>("SE");
    }

    // Update is called once per frame
    void Update()
    {
        /**///リソースロードしたSEを鳴らす。
        //if (Input.GetKeyDown("q"))
        //{
        //    audioSource.PlayOneShot(se[SE_Number]);
        //}
        /**/

        if (Handedness)//チェックを入れると左が移動。
        {
            //↓左スティックの操作
            if (anime.Moveon == true || MoveLock == false ) {
                if (/*OVRInput.Get(OVRInput.RawButton.LThumbstickUp) */ (Input.GetAxisRaw("Oculus_GearVR_LThumbstickY") < 0) || Input.GetKey(KeyCode.UpArrow) )//上
                {
                    walknow = false;
                    walker_Check += Time.deltaTime;
                    //Debug.Log("左アナログスティックを上に倒した");
                    this.transform.Translate(Vector3.forward * strike_speed * Time.deltaTime);//向いてる方向に前進（スティック上）
                    Stranim.SetBool("forward_walk", true);
                    forward = true;
                }
                else if (/*OVRInput.Get(OVRInput.RawButton.LThumbstickDown) && */ (Input.GetAxisRaw("Oculus_GearVR_LThumbstickY") > 0) || Input.GetKey(KeyCode.DownArrow))
                {
                    walknow = false;
                    walker_Check += Time.deltaTime;
                    this.transform.Translate(Vector3.back * strike_speed * Time.deltaTime);//向いてる方向から後退（スティック下）
                    Stranim.SetBool("back_walk", true);
                    back = true;
                }
                else
                {
                    walknow = true;
                    Stranim.SetBool("forward_walk", false);
                    Stranim.SetBool("back_walk", false);
                    forward = false;
                    back = false;
                }


                if (/*OVRInput.Get(OVRInput.RawButton.LThumbstickRight) && */(Input.GetAxisRaw("_GearVR_LThumbstickXstickX") > 0) || Input.GetKey(KeyCode.RightArrow))
                {
                    walknow = false;
                    walker_Check += Time.deltaTime;
                    this.transform.Translate(Vector3.right * strike_speed * Time.deltaTime);//向いてる方向から右移動（スティック右）
                    Stranim.SetBool("right_walk", true);
                    //this.transform.Rotate(0, -120, 0);
                    right = true;
                    
                }
                else if (/*OVRInput.Get(OVRInput.RawButton.LThumbstickLeft) &&*/ (Input.GetAxisRaw("_GearVR_LThumbstickXstickX") < 0) || Input.GetKey(KeyCode.LeftArrow))
                {
                    walknow = false;
                    walker_Check += Time.deltaTime;
                    this.transform.Translate(Vector3.left * strike_speed * Time.deltaTime);//向いてる方向から左移動（スティック左）
                    Stranim.SetBool("left_walk", true);
                    left = true;
                    
                }
                else
                {
                    walknow = true;
                    Stranim.SetBool("left_walk", false);
                    Stranim.SetBool("right_walk", false);
                    //this.transform.Rotate(0, -180, 0);
                    right = false;
                    left = false;
                }
                if ((right && forward) || (right && back) || (left && forward) || (left && back))
                {
                    strike_speed = 4;
                }
                else
                {
                    strike_speed = 5;
                }

                if (walker_Check >= 0 )
                {
                    if (walker_Check >= 0.5f)
                    {
                        audioSource.PlayOneShot(StrikerSE);
                    }
                    if (walker_Check > 0.5f)
                    {
                        walker_Check = 0;
                    }
                }
                else if(walknow == true)
                {
                    walker_Check = 0;
                }
                if (/*OVRInput.Get(OVRInput.RawButton.RThumbstickRight)*/ (Input.GetAxisRaw("Oculus_GearVR_RThumbstickX") < 0) && RotateCamera == false)
                {
                    RotateCamera = true;
                    RCameraMove = true;
                    this.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y + 90, this.transform.localEulerAngles.z);
                }
                else if (/*OVRInput.Get(OVRInput.RawButton.RThumbstickLeft)*/(Input.GetAxisRaw("Oculus_GearVR_RThumbstickX") > 0) && RotateCamera == false )
                {
                    RotateCamera = true;
                    LCameraMove = true;
                    this.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y - 90, this.transform.localEulerAngles.z);
                }

                if (RotateCamera)
                {
                    timeVR += Time.deltaTime;
                    if(timeVR > 1.0f)
                    {
                        RotateCamera = false;
                        timeVR = 0; 
                    }
                }


            }
        }

        else{
            //↓右スティックの操作
            if (OVRInput.Get(OVRInput.RawButton.RThumbstickUp))
            {
                audioSource.PlayOneShot(StrikerSE);
                //Debug.Log("左アナログスティックを上に倒した");
                this.transform.Translate(Vector3.forward * strike_speed * Time.deltaTime);//向いてる方向に前進（スティック上）
                Stranim.SetBool("forward_walk", true);
            }
            else if (OVRInput.Get(OVRInput.RawButton.RThumbstickDown))
            {
                audioSource.PlayOneShot(StrikerSE);
                this.transform.Translate(Vector3.back * strike_speed * Time.deltaTime);//向いてる方向から後退（スティック下）
                Stranim.SetBool("back_walk", true);
            }
            else
            {
                Stranim.SetBool("forward_walk", false);
                Stranim.SetBool("back_walk", false);
            }

            if (OVRInput.Get(OVRInput.RawButton.RThumbstickRight))
            {
                audioSource.PlayOneShot(StrikerSE);
                this.transform.Translate(Vector3.right * strike_speed * Time.deltaTime);//向いてる方向から右移動（スティック右）
                Stranim.SetBool("right_walk", true);
                //this.transform.Rotate(0, -120, 0);
                right = true;
                forward = false;
            }
            else if (OVRInput.Get(OVRInput.RawButton.RThumbstickLeft))
            {
                audioSource.PlayOneShot(StrikerSE);
                this.transform.Translate(Vector3.left * strike_speed * Time.deltaTime);//向いてる方向から左移動（スティック左）
                Stranim.SetBool("left_walk", true);
                left = true;
                forward = false;
            }
            else
            {
                Stranim.SetBool("left_walk", false);
                Stranim.SetBool("right_walk", false);
                //this.transform.Rotate(0, -180, 0);
                forward = true;
                right = false;
                left = false;
            }
        }


        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            OVRGrabber.Triggercheck = 1;
            Debug.Log("Trigger1");
        }

        else if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            OVRGrabber.Triggercheck = 2;
            Debug.Log("Trigger2");
        }
        



    }
   
}