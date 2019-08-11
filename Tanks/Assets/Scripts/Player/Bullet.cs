using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public GameObject  Centr,  BFGCentr;

   
    public float shootDelayeLitle;
    public float shootDelayeBig;
    public string weapon;

    private bool flag;
    private float shootDelayeCountLitle;
    private float shootDelayeCountBig;
    

    void Start()
    {
       
        weapon = "LFG";
        flag = false;
        shootDelayeCountLitle = 0;
        shootDelayeCountBig = 0;
    }
    
    void Update()
    {
        var get = gameObject.GetComponent<MotionTanks>();
        if (get.flagOver == false&&get.flagWin==false)
        {
            if (Input.GetKey(KeyCode.X) && flag == false && shootDelayeCountLitle <= 0)
            {
                BulletLitle();
            }
            if (Input.GetKeyDown(KeyCode.X) && flag == true && shootDelayeCountBig <= 0)
            {
                BulletBig();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SwichFlag();
                WeaponRename();
            }
        }

        shootDelayeCountLitle -= Time.deltaTime;
        shootDelayeCountBig -= Time.deltaTime;
    }

    string WeaponRename()
    {
        if (weapon == "LFG")
        {
            weapon = "BFG";
            return weapon;
        }
        else
        {
            weapon = "LFG";
            return weapon;
        }
    }

    bool SwichFlag()
    {
        if (flag == false)
        {
            flag = true;
            return flag;
           
        }
        else
        {
            flag = false;
            return flag;            
        }
    }
    void BulletLitle()
    {
        GameObject bulletLitle = PoolMenedjer.GetObject("Capsule", Centr.transform.position, Centr.transform.rotation);
        shootDelayeCountLitle = shootDelayeLitle;
        
    }

    void BulletBig()
    {
        GameObject bulletBFG = PoolMenedjer.GetObject("Capsule 1", BFGCentr.transform.position, BFGCentr.transform.rotation);       
        shootDelayeCountBig = shootDelayeBig;
    }
}
