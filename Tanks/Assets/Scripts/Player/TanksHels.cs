using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksHels : MonoBehaviour {
    public float healt = 100f;
    public float armor = 0.2f;
    void Start()
    {

    }


    void FixedUpdate()
    {
        if (healt <= 0)
        {
            gameObject.GetComponent<MotionTanks>().flag = true;
        }
    }
}
