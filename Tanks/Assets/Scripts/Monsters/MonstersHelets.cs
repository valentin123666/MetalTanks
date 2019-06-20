using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonstersHelets : MonoBehaviour {
    public float healt = 20f;
    public float armor= 0.5f;

    

    void Start()
    {

    }


    void FixedUpdate()
    {
        if (healt <= 0)
        {
            Destroy(gameObject);
            GetComponent<Canvas>().countMorder++;
        }
    }
}
