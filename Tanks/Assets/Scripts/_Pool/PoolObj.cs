using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Pool/PoolObj")]
public class PoolObj : MonoBehaviour {
      
    public void ReturnToPool()
    {        
        gameObject.SetActive(false);
    }
  
}
