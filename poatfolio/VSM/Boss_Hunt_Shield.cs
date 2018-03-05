using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Hunt_Shield : MonoBehaviour
{

    public GameObject target;
    [SerializeField]
    protected float Rote_x;
    [SerializeField]
    protected float Rote_y;
    [SerializeField]
    protected float Rote_z;
    [SerializeField]
    protected float Pos_x;
    [SerializeField]
    protected float Pos_y;
    [SerializeField]
    protected float Pos_z;

    // Use this for initialization
    void Start()
    {

        target = GameObject.Find("boss");
        //Vector3 targetpos = GameObject.Find("CenterEyeAnchor").transform.position;

    }

    // Update is called once per frame
    void Update()
    {


       if(anime.Moveon == false)
        this.transform.position = new Vector3(target.transform.position.x + Pos_x, target.transform.position.y + Pos_y, target.transform.position.z + Pos_z);

    }
}
