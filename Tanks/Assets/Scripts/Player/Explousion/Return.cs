using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour {
    private void Update () {
        Invoke("ReturnObj",0.2f);
	}
    private void ReturnObj()
    {
        GetComponent<PoolObj>().ReturnToPool();
    }
}
