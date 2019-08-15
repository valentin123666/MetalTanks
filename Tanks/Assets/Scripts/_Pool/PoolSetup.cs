using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Pool/PoolSetup")]
public class PoolSetup : MonoBehaviour {

    [SerializeField]
    private PoolMenedger.PoolPsrt[] pools;

    void OnValidate()
    {
        for(int i= 0; i<pools.Length;i++)
        {
            if(pools[i].name==null)
            pools[i].name = pools[i].prefab.name;
        }
    }
    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        PoolMenedger.Initialize(pools);
    }
}
