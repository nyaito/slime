using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Model_Change : MonoBehaviour {

    private GameObject[] Boss_Model = new GameObject[2];
    public static bool Modelchange = false;
    public static bool Model_ok = false;
    private GameObject BossGloup;

    // Use this for initialization
    void Start () {

        Modelchange = false;
        Model_ok = false;

        Boss_Model = Resources.LoadAll<GameObject>("prefab");

        BossGloup  = Instantiate(Boss_Model[1], transform.position, transform.rotation);
        //BossGloup.transform.SetParent(transform, false);
        BossGloup.transform.parent = transform;
        BossGloup.transform.localScale = Vector3.one;
    }
	
	// Update is called once per frame
	void Update () {

        if ((Boss_Player.LifeB == 1 && Modelchange == false ))
        {
            Destroy(BossGloup);
            BossGloup = null;
            BossGloup = Instantiate(Boss_Model[0], transform.position, transform.rotation);
            BossGloup.transform.parent = transform;
            BossGloup.transform.localScale = Vector3.one;
            
            Modelchange = true;

        }
        else if (Modelchange && Model_ok == false )
        {
            Model_ok = true;
            
            anime.BossHit = true;
            BossHitCheck.B_Spawn = true;
        }
		
	}
}
