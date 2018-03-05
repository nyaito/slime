using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headmove : MonoBehaviour {

    public GameObject target ;
    [SerializeField]
    protected float Rote_x;
    
    private float Rote_y;
    [SerializeField]
    protected float Rote_z;
    [SerializeField]
    protected float Pos_x;
    [SerializeField]
    protected float Pos_y;
    [SerializeField]
    protected float Pos_z;
 

    // Use this for initialization
    void Start () {

        target = GameObject.Find("CenterEyeAnchor");
        //Vector3 targetpos = GameObject.Find("CenterEyeAnchor").transform.position;
        Rote_y = 180;
       
    }
	
	// Update is called once per frame
	void Update () {


        this.transform.rotation = Quaternion.Euler(target.transform.localEulerAngles.x + Rote_x, target.transform.localEulerAngles.y + Rote_y, target.transform.localEulerAngles.z + Rote_z);
        this.transform.position = new Vector3(target.transform.position.x + Pos_x, target.transform.position.y + Pos_y, target.transform.position.z + Pos_z);

        if (anime.Moveon)
        {
            if (MoveScript.RCameraMove)
            {
                Debug.Log(Rote_y);
                MoveScript.RCameraMove = false;
                Rote_y += 90;
                //this.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y + 90, this.transform.localEulerAngles.z);
            }
            else if (MoveScript.LCameraMove)
            {
                Debug.Log(Rote_y);
                MoveScript.LCameraMove = false;
                Rote_y -= 90;
                //this.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y - 90, this.transform.localEulerAngles.z);
            }

            
        }

    }
}
