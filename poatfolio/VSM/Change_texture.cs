using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_texture : MonoBehaviour {

    public GameObject Boss_Damage_Model;
    private Texture[] bossTex_main = new Texture[2];
    private Texture[] bossTex_Emi = new Texture[2];
    private Texture[] bossTex_Meta = new Texture[2];
    private Texture[] bossTex_Bump = new Texture[2];

    private int Dam = 0;
    public static bool texchange = false;

    // Use this for initialization
    void Start () {

        Dam = 0;
        texchange = false;
        bossTex_main = Resources.LoadAll<Texture2D>("bossTex_main");
        bossTex_Emi = Resources.LoadAll<Texture2D>("bossTex_Emi");
        bossTex_Meta = Resources.LoadAll<Texture2D>("bossTex_Meta");
        bossTex_Bump = Resources.LoadAll<Texture2D>("bossTex_Bump");

    }
	
	// Update is called once per frame
	void Update () {

        if ((Boss_Player.texture_Change && texchange == false && (Boss_Player.LifeB == 4 || Boss_Player.LifeB == 2))  || Input.GetKeyDown("t"))
        {
#if UNITY_EDITOR
            Debug.Log("texture_change");
#endif
            Boss_Damage_Model.GetComponent<Renderer>().material.SetTexture("_MainTex", bossTex_main[Dam]);

            Boss_Damage_Model.GetComponent<Renderer>().material.SetTexture("_EmissionMap", bossTex_Emi[Dam]);

            Boss_Damage_Model.GetComponent<Renderer>().material.SetTexture("_MetallicGlossMap", bossTex_Meta[Dam]);

            Boss_Damage_Model.GetComponent<Renderer>().material.SetTexture("_BumpMap", bossTex_Bump[Dam]);

            texchange = true;

            Boss_Player.texture_Change = false;

            Dam += 1;

        }
    }
}
