using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBum : MonoBehaviour
{
    float f = 0.5f;
    void Update()
    {
        Invoke("ReturnObj", f);
    }
    void ReturnObj()
    {
        GetComponent<PoolObj>().ReturnToPool();
        f = 0.5f;
    }
}
