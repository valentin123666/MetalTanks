using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour {
    public float health;
    public float armor;
    private void Start()
    {
        health = 100f;
        armor = 0.2f;
    }


    private void FixedUpdate()
    {
        if (health <= 0)
        {
            gameObject.GetComponent<MotionTanks>().flagOver = true;
        }
    }
}
