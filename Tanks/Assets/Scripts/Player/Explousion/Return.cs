using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour {
    	

	// Update is called once per frame
	void Update () {
        Invoke("ReturnObj",0.2f);
	}
    void ReturnObj()
    {
        GetComponent<PoolObj>().ReturnToPool();
    }
}
