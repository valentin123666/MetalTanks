using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class PoolMenedger {
    private static PoolPsrt[] pools;
    private static GameObject objPerent;
    

    [System.Serializable]
    public struct PoolPsrt
    {
        public string name;
        public PoolObj prefab;
        public int count;
        public ObjectPooling ferul;
    }
    public static void Initialize (PoolPsrt[]newPools)
    {
        pools = newPools;
        objPerent = new GameObject();
        objPerent.name = "Pool";
        for(int i =0; i < pools.Length;i++)
        {
            if(pools[i].prefab!=null)
            {
                pools[i].ferul = new ObjectPooling();
                pools[i].ferul.Initialize(pools[i].count, pools[i].prefab, objPerent.transform);
            }
        }
    }
    public static GameObject GetObject(string name, Vector3 position, Quaternion rotate)
    {
        GameObject result = null;
        if (pools != null)
        {
            for(int i =0; i < pools.Length; i++)
                if(string.Compare (pools [i].name, name)==0)
                {
                    result = pools[i].ferul.GetObject().gameObject;
                    result.transform.position = position;
                    result.transform.rotation = rotate;
                    result.SetActive(true);
                    return result;
                }
        }
        return result;
    }

}
