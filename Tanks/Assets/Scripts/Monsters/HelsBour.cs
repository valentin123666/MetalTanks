using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelsBour : MonoBehaviour {

    public float healt,countHealts;
    public float armor;

    private GameObject obj;



    private void Start()
    {
        healt = countHealts;
        if (obj == null)
            obj = GameObject.FindWithTag("Magic");
    }


    private void Update()
    {
        if (healt <= 0)
        {
            gameObject.GetComponent<PoolObj>().ReturnToPool();
            obj.GetComponent<Canvas>().countMorder++;
            healt = countHealts;
        }
    }
}
