using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMoveLeg : MonoBehaviour {

    [SerializeField]
    protected float Pos_x;
    //[SerializeField]
    //protected float this_Pos_y;
    [SerializeField]
    protected float Pos_z;

    public GameObject target;

    // Use this for initialization
    void Start () {

        target = GameObject.Find("CenterEyeAnchor");

    }
	
	// Update is called once per frame
	void Update () {

        this.transform.position = new Vector3(target.transform.position.x + Pos_x, this.transform.position.y, target.transform.position.z + Pos_z);

    }

}
