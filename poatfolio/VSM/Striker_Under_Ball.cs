using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker_Under_Ball : MonoBehaviour
{
    public static bool ball_under = false;

    // Use this for initialization
    void Start()
    {
        ball_under = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "ball")
        {
            ball_under = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ball")
        {
            ball_under = false;
        }
    }
}

