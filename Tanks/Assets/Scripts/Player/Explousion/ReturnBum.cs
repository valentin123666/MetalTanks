using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBum : MonoBehaviour
{
    private float f = 0.5f;
    private void Update()
    {
        Invoke("ReturnObj", f);
    }
    private void ReturnObj()
    {
        GetComponent<PoolObj>().ReturnToPool();
        f = 0.5f;
    }
}
