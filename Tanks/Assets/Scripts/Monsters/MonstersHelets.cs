using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonstersHelets : MonoBehaviour {
    public float healt = 20f;
    public float armor= 0.5f;
        
    GameObject obj;

    

    void Start()
    {
        if (obj == null)
            obj = GameObject.FindWithTag("Magic");
    }


    void Update()
    {
        if (healt <= 0)
        {
          gameObject.GetComponent<PoolObj>().ReturnToPool();
            obj.GetComponent<Canvas>().countMorder++;
            healt = 20f;
        }
    }
}
