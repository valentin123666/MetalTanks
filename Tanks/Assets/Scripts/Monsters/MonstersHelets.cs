using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonstersHelets : MonoBehaviour {
    public float healt;
    public float armor, countHealt;

    private GameObject obj;

    private void Start()
    {
        healt = countHealt;
        if (obj == null)
            obj = GameObject.FindWithTag("Magic");
    }


    private void Update()
    {
        if (healt <= 0)
        {
          gameObject.GetComponent<PoolObj>().ReturnToPool();
            obj.GetComponent<Canvas>().countMorder++;
            healt = countHealt;
        }
    }
}
