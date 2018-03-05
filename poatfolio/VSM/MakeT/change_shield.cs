using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_shield : MonoBehaviour
{
    public float angle = 1;
    public float count = 0;

    public float Move_speed;

    public float moveX = 0;
    public float moveY = 0;
    public float move = 1;
    public static bool right = false;
    public static bool left = false;
    public static bool front = false;
    public bool Shield_Damage = false;
    [SerializeField]
    protected float Shield_move_space;
    [SerializeField]
    protected float Shield_move_space_y;

    public static bool MoveLock = true;

    float maxRotate = 45;//回転角の最大値//
    float tmpRotate_Change = 0;//現在の回転角//
    float tmpRotate_Y = 0;//現在の回転角//
    //float tmpRotate_X = 0;//現在の回転角//
    float startRotation_Change;//最初のグローバルY座標//
    float startRotation_Y;//最初のグローバルY座標//
    float Arm_mode_Rotation_Y;//アームモード時のグーローバルY座標
    //float startRotation_Change_arm_mode;
    //float startRotation_X;
    //float Arm_mode_Rotation_X;
    public float Damtimer = 0;
    public float adRotate = 100;
    public float Chage_Rotate = 2000;

    public GameObject Life_Effect;


    AudioSource audioSource;
    public AudioClip ShieldSizeUpSE;

    // Use this for initialization
    void Start()
    {
        startRotation_Y = this.transform.rotation.eulerAngles.y; //最初のグローバルのY座標を代入//
        Arm_mode_Rotation_Y = (-180 + this.transform.rotation.eulerAngles.y); //最初のグローバルのY座標を代入//

        //startRotation_X = this.transform.rotation.eulerAngles.y;
        //Arm_mode_Rotation_X = (-180 + this.transform.rotation.eulerAngles.y);

        startRotation_Change = this.transform.rotation.eulerAngles.y;
        //startRotation_Change_arm_mode = (-180 + this.transform.rotation.eulerAngles.y);

        Damtimer = 0;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        startRotation_Change = this.transform.rotation.eulerAngles.y;
        //startRotation_Change_arm_mode = (-180 + this.transform.rotation.eulerAngles.y);

        if (anime.Moveon == true || MoveLock == false)
        {

            if (Input.GetAxisRaw("Horizontal3") < 0)//左回り
            {    
                if (ShieldAnimation.ShieldModeFlag == true)
                {
                    this.transform.Rotate(new Vector3(0, adRotate, 0) * Time.deltaTime);
                    tmpRotate_Y += (adRotate * Time.deltaTime);
                    if (tmpRotate_Y >= maxRotate)
                    {
                        this.transform.rotation = Quaternion.Euler(0, startRotation_Y + 45, 0);
                        tmpRotate_Y = 45;
                    }
                }
                else
                {
                    this.transform.Rotate(new Vector3(0, adRotate, 0) * Time.deltaTime);
                    tmpRotate_Y += (adRotate * Time.deltaTime);
                    if (tmpRotate_Y >= maxRotate)
                    {
                        this.transform.rotation = Quaternion.Euler(0, Arm_mode_Rotation_Y + 45, 0);
                        tmpRotate_Y = 45;
                    }
                }
            }

            if (Input.GetAxisRaw("Horizontal3") > 0)//右回り
            {
                if (ShieldAnimation.ShieldModeFlag == true)
                {
                    this.transform.Rotate(new Vector3(0, -adRotate, 0) * Time.deltaTime);
                    tmpRotate_Y -= (adRotate * Time.deltaTime);
                    if (tmpRotate_Y <= maxRotate * -1)
                    {
                        this.transform.rotation = Quaternion.Euler(0, startRotation_Y - 45, 0);
                        tmpRotate_Y = -45;
                    }
                }
                else
                {
                    this.transform.Rotate(new Vector3(0, -adRotate, 0) * Time.deltaTime);
                    tmpRotate_Y -= (adRotate * Time.deltaTime);
                    if (tmpRotate_Y <= maxRotate * -1)
                    {
                        this.transform.rotation = Quaternion.Euler(0, Arm_mode_Rotation_Y - 45, 0);
                        tmpRotate_Y = -45;
                    }
                }
            }

            //if (Input.GetAxisRaw("Vertical3") < 0)//下
            //{
            //    if (ShieldAnimation.ShieldModeFlag == true)
            //    {
            //        this.transform.Rotate(new Vector3(-adRotate, -adRotate, 0) * Time.deltaTime);
            //        tmpRotate_X -= (adRotate * Time.deltaTime);
            //        if (tmpRotate_X <= maxRotate * -1)
            //        {
            //            this.transform.rotation = Quaternion.Euler(startRotation_X - 45, this.transform.rotation.y, 0);
            //            tmpRotate_X = -45;
            //        }
            //    }
            //    else
            //    {
            //        this.transform.Rotate(new Vector3(-adRotate, -adRotate, 0) * Time.deltaTime);
            //        tmpRotate_X -= (adRotate * Time.deltaTime);
            //        if (tmpRotate_X <= maxRotate * -1)
            //        {
            //            this.transform.rotation = Quaternion.Euler(startRotation_X - 45, this.transform.rotation.y, 0);
            //            tmpRotate_X = -45;
            //        }
            //    }
            //}

            //if (Input.GetAxisRaw("Vertical3") > 0)//上
            //{
            //    if (ShieldAnimation.ShieldModeFlag == true)
            //    {
            //        this.transform.Rotate(new Vector3(adRotate, adRotate, 0) * Time.deltaTime);
            //        tmpRotate_X += (adRotate * Time.deltaTime);
            //        if (tmpRotate_X >= maxRotate)
            //        {
            //            this.transform.rotation = Quaternion.Euler(startRotation_X + 45, this.transform.rotation.y, 0);
            //            tmpRotate_X = 45;
            //        }
            //    }
            //    else
            //    {
            //        this.transform.Rotate(new Vector3(adRotate, adRotate, 0) * Time.deltaTime);
            //        tmpRotate_X += (adRotate * Time.deltaTime);
            //        if (tmpRotate_X >= maxRotate)
            //        {
            //            this.transform.rotation = Quaternion.Euler(startRotation_X + 45, this.transform.rotation.y, 0);
            //            tmpRotate_X = 45;
            //        }
            //    }

            //}

            if (ShieldAnimation.shield_rote_A == true)
            {
                this.transform.Rotate(new Vector3(0, -Chage_Rotate, 0) * Time.deltaTime);
                tmpRotate_Change -= (Chage_Rotate * Time.deltaTime);
                if (tmpRotate_Change <= 180 * -1)
                {
                    this.transform.rotation = Quaternion.Euler(0, startRotation_Change, 0);
                    tmpRotate_Change = -180;
                    ShieldAnimation.shield_rote_A = false;
                }
            }
            if (ShieldAnimation.shield_rote_S == true)
            {
                this.transform.Rotate(new Vector3(0, Chage_Rotate, 0) * Time.deltaTime);
                tmpRotate_Change += (Chage_Rotate * Time.deltaTime);
                if (tmpRotate_Change >= 0)
                {
                    this.transform.rotation = Quaternion.Euler(0, startRotation_Change , 0);
                    tmpRotate_Change = 0;
                    ShieldAnimation.shield_rote_S = false;
                }
            }


            if (moveY < Shield_move_space_y)
            {
                if (Input.GetAxisRaw("Vertical2") > 0)//上
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Move_speed, this.transform.position.z);
                    moveY += Move_speed;
                }
            }
            if (moveY > -Shield_move_space_y)
            {
                if (Input.GetAxisRaw("Vertical2") < 0)//下
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - Move_speed, this.transform.position.z);
                    moveY -= Move_speed;
                }
            }

            if (moveX < Shield_move_space)
            {
                if (Input.GetAxisRaw("Horizontal2") < 0)//右
                {
                    this.transform.position = new Vector3(this.transform.position.x + Move_speed, this.transform.position.y, this.transform.position.z);
                    moveX += Move_speed;
                }
            }
            if (moveX > -Shield_move_space)
            {
                if (Input.GetAxisRaw("Horizontal2") > 0)//左
                {
                    this.transform.position = new Vector3(this.transform.position.x - Move_speed, this.transform.position.y, this.transform.position.z);
                    moveX -= Move_speed;
                }
            }
            //if( (Input.GetAxisRaw("Vertical2") > 0 && Input.GetAxisRaw("Horizontal2") < 0) || (Input.GetAxisRaw("Vertical2") > 0 && (Input.GetAxisRaw("Horizontal2") > 0)) )
            //{

            //}
            //else if( (Input.GetAxisRaw("Vertical2") < 0 && Input.GetAxisRaw("Horizontal2") < 0) || (Input.GetAxisRaw("Vertical2") < 0 && (Input.GetAxisRaw("Horizontal2") > 0)) )
            //{ 

            //}


            if (-Shield_move_space / 2 < moveX && moveX < Shield_move_space / 2)
            {
                front = true;
                right = false;
                left = false;
            }
            else if (-Shield_move_space < moveX && moveX < -Shield_move_space / 2)
            {
                front = false;
                right = true;
                left = false;
            }
            else if (Shield_move_space / 2 < moveX && moveX < Shield_move_space)
            {
                front = false;
                right = false;
                left = true;

            }
            if (ShieldAnimation_damege.DamF == true)
            {
#if UNITY_EDITOR
                Debug.Log("Dam_ON");
#endif
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                Damtimer = 0;
                Shield_Damage = true;
                

            }
            if (Shield_Damage == true)
            {
#if UNITY_EDITOR
                Debug.Log("Damtimer_ON");
#endif
                Damtimer += Time.deltaTime;
            }
            if (Damtimer >= 10f)
            {
                GameObject Effect_parents = Instantiate(Life_Effect, transform.position, transform.rotation);
                Effect_parents.transform.parent = transform;
                transform.localScale = new Vector3(2, 2, 2);
                audioSource.PlayOneShot(ShieldSizeUpSE);
                Shield_Damage = false;
                Damtimer = 0;
            }

        }

    }


}

