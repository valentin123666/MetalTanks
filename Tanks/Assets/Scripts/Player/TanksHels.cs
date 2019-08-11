using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksHels : MonoBehaviour {
    public float healt;
    public float armor;
    void Start()
    {
        healt = 100f;
        armor = 0.2f;
    }


    void FixedUpdate()
    {
        if (healt <= 0)
        {
            gameObject.GetComponent<MotionTanks>().flagOver = true;
        }
    }
}
