using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelsBour : MonoBehaviour {

    public float healt;
    public float armor;

    GameObject obj;



    void Start()
    {
        armor = 0.5f;
        healt = 40f;
        if (obj == null)
            obj = GameObject.FindWithTag("Magic");
    }


    void Update()
    {
        if (healt <= 0)
        {
            gameObject.GetComponent<PoolObj>().ReturnToPool();
            obj.GetComponent<Canvas>().countMorder++;
            healt = 40f;
        }
    }
}
