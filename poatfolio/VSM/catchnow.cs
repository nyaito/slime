using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchnow : MonoBehaviour {

    public Rigidbody ball;

    AudioSource audioSource;
    public AudioClip CatchSE;
    public AudioClip ShotSE;

    public bool stcatch = false;

    public AudioClip audioClip;
    OVRHapticsClip hapticsClip;


    // Use this for initialization
    void Start () {

        ball = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        stcatch = false;
        hapticsClip = new OVRHapticsClip(audioClip);

    }
    Collider GetCollider(GameObject leg)
    {
        Collider legcoll = leg.GetComponent<Collider>();
        return legcoll;
    }

    // Update is called once per frame
    void Update () {

        if(OVRGrabber.ballcatch == true)//スクリプト上でisTriggerの制御をしてる。
        {
            if (stcatch == false)
            {
                if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0 || OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0)
                {
                    OVRHaptics.RightChannel.Mix(hapticsClip);
                }
                else if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > 0 || OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0)
                {
                    OVRHaptics.LeftChannel.Mix(hapticsClip);
                }
                audioSource.PlayOneShot(CatchSE);
                stcatch = true;
            }
            ball.isKinematic = true;//rigidbodyのiskinematicのチェックを入れる。
            GetComponent<SphereCollider>().isTrigger = true;//ボールのcolliderのtriggerを切り替える。

        }
        else if(OVRGrabber.ballcatch == false)
        {
            if(stcatch == true)
            {
                if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0 || OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0)
                {
                    OVRHaptics.RightChannel.Mix(hapticsClip);
                }
                else if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > 0 || OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0)
                {
                    OVRHaptics.LeftChannel.Mix(hapticsClip);
                }
                audioSource.PlayOneShot(ShotSE);
                stcatch = false;
            }
            ball.isKinematic = false;
            GetComponent<SphereCollider>().isTrigger = false;
            
        }
		
	}
}