using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Bar_Control : MonoBehaviour {

    private Texture[] Boss_Life = new Texture[5];
    private Texture[] Striker_Life = new Texture[5];
    public Sprite[] Striker_life_bosscam = new Sprite[5];
   

    public GameObject Boss_Life_Bar;
    public GameObject Striker_Life_Bar;
    public GameObject Striker_Life_Bar_Boss_side;
    // Use this for initialization

    void Start () {


        Boss_Life = Resources.LoadAll<Texture2D>("UI/UI_Life_Bar_Boss");
        Striker_Life = Resources.LoadAll<Texture2D>("UI/UI_Life_Bar_Striker");

        Striker_life_bosscam = Resources.LoadAll<Sprite>("UI/BScam_ST_HP");

    }

    // Update is called once per frame
    void Update () {

        Boss_Life_Bar.GetComponent<Renderer>().material.SetTexture("_EmissionMap", Boss_Life[Boss_Player.LifeB - 1]);
        Striker_Life_Bar.GetComponent<Renderer>().material.SetTexture("_EmissionMap", Striker_Life[Striker.LifeA - 1]);

        Striker_Life_Bar_Boss_side.GetComponent<Image>().sprite = Striker_life_bosscam[Striker.LifeA - 1];
    }
}