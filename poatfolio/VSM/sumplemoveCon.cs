using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sumplemoveCon : MonoBehaviour {

    public Animator Stranim;
    public static bool right = false;
    public static bool left = false;
    public static bool forward = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // 左スティックのよこ方向の傾き
        if (Input.GetAxis("Horizontal") < 0)//左に傾いてる
        {
            this.transform.Translate(Vector3.left * 2 * Time.deltaTime);//向いてる方向から左移動（スティック左）
            Stranim.SetBool("left_walk", true);
            //this.transform.Rotate(0, -240, 0);
            left = true;
            forward = false;
        }
        else if (0 < Input.GetAxis("Horizontal"))//右に傾いてる
        {
            this.transform.Translate(Vector3.right * 2 * Time.deltaTime);//向いてる方向から右移動（スティック右）
            Stranim.SetBool("right_walk", true);
            //this.transform.Rotate(0, -120, 0);
            right = true;
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
        // 左スティックのたて方向の傾き
        if (0 < Input.GetAxis("Vertical"))//上に傾いてる
        {
            this.transform.Translate(Vector3.forward * 2 * Time.deltaTime);//向いてる方向に前進（スティック上）
            Stranim.SetBool("forward_walk", true);
        }
        else if (Input.GetAxis("Vertical") < 0) //下に傾いてる
        {
            this.transform.Translate(Vector3.back * 2 * Time.deltaTime);//向いてる方向から後退（スティック下）
            Stranim.SetBool("back_walk", true);
        }
        else
        {
            Stranim.SetBool("forward_walk", false);
            Stranim.SetBool("back_walk", false);
        }

        /**/


        //// 右スティックのよこ方向の傾き
        //if ( 0 < Input.GetAxis("Horizontal3"))//左に傾いてる
        //{
        //    this.transform.Translate(Vector3.left * 2 * Time.deltaTime);//向いてる方向から左移動（スティック左）
        //    Stranim.SetBool("left_walk", true);
        //    //this.transform.Rotate(0, -240, 0);
        //    left = true;
        //    forward = false;
        //}
        //else if (Input.GetAxis("Horizontal3") < 0)//右に傾いてる
        //{
        //    this.transform.Translate(Vector3.right * 2 * Time.deltaTime);//向いてる方向から右移動（スティック右）
        //    Stranim.SetBool("right_walk", true);
        //    //this.transform.Rotate(0, -120, 0);
        //    right = true;
        //    forward = false;
        //}
        //else
        //{
        //    Stranim.SetBool("left_walk", false);
        //    Stranim.SetBool("right_walk", false);
        //    //this.transform.Rotate(0, -180, 0);
        //    forward = true;
        //    right = false;
        //    left = false;

        //}
        //// 右スティックのたて方向の傾き
        //if (0 < Input.GetAxis("Vertical3"))//上に傾いてる
        //{
        //    this.transform.Translate(Vector3.forward * 2 * Time.deltaTime);//向いてる方向に前進（スティック上）
        //    Stranim.SetBool("forward_walk", true);
        //}
        //else if (Input.GetAxis("Vertical3") < 0) //下に傾いてる
        //{
        //    this.transform.Translate(Vector3.back * 2 * Time.deltaTime);//向いてる方向から後退（スティック下）
        //    Stranim.SetBool("back_walk", true);
        //}
        //else
        //{
        //    Stranim.SetBool("forward_walk", false);
        //    Stranim.SetBool("back_walk", false);
        //}


    }
}
