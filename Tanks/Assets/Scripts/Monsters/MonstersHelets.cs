using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonstersHelets : MonoBehaviour {
    public float healt = 20f;
    public float armor= 0.5f;
        
    private GameObject obj;

    

    void Start()
    {
        if (obj == null)
            obj = GameObject.FindWithTag("Magic");
    }


    void FixedUpdate()
    {
        if (healt <= 0)
        {
            Destroy(gameObject);
            obj.GetComponent<Canvas>().countMorder++;
        }
    }
}
