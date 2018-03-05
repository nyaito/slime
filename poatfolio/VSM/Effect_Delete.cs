using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Delete : MonoBehaviour {

    public float Effect_Delete_Time = 0;
    public float Effect_Time;
    [SerializeField]
    protected string Effect_name;

    // Use this for initialization
    void Start () {

        var h  = EffekseerSystem.PlayEffect(Effect_name, this.transform.position);
        h.SetScale(this.transform.localScale);
        h.SetRotation(this.transform.rotation);

        Effect_Delete_Time = 0;
	}
	
	// Update is called once per frame
	void Update () {

        Effect_Delete_Time += Time.deltaTime;

        if (Effect_Delete_Time > Effect_Time)
        {
            Destroy(this.gameObject);
            Effect_Delete_Time = 0;
        }

	}
}
