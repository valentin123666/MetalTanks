using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour {
	void Update () {
        Invoke("ReturnObj",0.2f);
	}
    void ReturnObj()
    {
        GetComponent<PoolObj>().ReturnToPool();
    }
}
