using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_Hunt_cam : MonoBehaviour
{

    public GameObject target;
    [SerializeField]
    protected float Pos_x;
    [SerializeField]
    protected float Pos_y;
    [SerializeField]
    protected float Pos_z;
    [SerializeField]
    protected bool FPS;

    // Use this for initialization
    void Start()
    {

        //target = GameObject.Find("robotest7_Shield_touka");
        //Vector3 targetpos = GameObject.Find("CenterEyeAnchor").transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (target.transform.position.y < 9 && anime.Moveon && FPS == false)
        {
//#if UNITY_EDITOR
//            Debug.Log("camera stay");
//            Debug.Log(target.transform.position.y);
//#endif
            this.transform.position = new Vector3(target.transform.position.x + Pos_x, this.transform.position.y, target.transform.position.z + Pos_z);
        }
        else if((target.transform.position.y >= 8 && anime.Moveon || Lift.movecam == true ) && FPS == false)
        {
//#if UNITY_EDITOR
//            Debug.Log("camera move");
//            Debug.Log(target.transform.position.y);
//#endif
            this.transform.position = new Vector3(target.transform.position.x + Pos_x, target.transform.position.y + Pos_y, target.transform.position.z + Pos_z);
        }
        else if (FPS)
        {
            this.transform.position = new Vector3(target.transform.position.x + Pos_x, target.transform.position.y + Pos_y, target.transform.position.z + Pos_z);
        }

    }
}

