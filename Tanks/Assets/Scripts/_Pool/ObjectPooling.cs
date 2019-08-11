using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Pool/ObjectPooling")]
public class ObjectPooling : MonoBehaviour {

    List<PoolObj> obj;
    Transform objPerent;

    void AddObj(PoolObj sample, Transform Obj_parent)
    {
        GameObject temp = Instantiate(sample.gameObject);
        temp.name = sample.name;
        temp.transform.SetParent(Obj_parent);
        temp.SetActive(false);
        obj.Add(temp.GetComponent<PoolObj>());
    }

    public void Initialize(int count, PoolObj sample , Transform obj_parent)
    {
        obj = new List<PoolObj>();
        objPerent = obj_parent;
           for(int i = 0; i<count; i++)
        {
            AddObj(sample, obj_parent);
        }
    }
    public PoolObj GetObject()
    {
        for (int i = 0; i < obj.Count; i++)
        {
            if (obj[i] != null)
            { 
            if (obj[i].gameObject.activeInHierarchy == false)
            {
                return obj[i];
            }
        }
        }
        AddObj(obj[0], objPerent);
        return obj[obj.Count];
    }

}
