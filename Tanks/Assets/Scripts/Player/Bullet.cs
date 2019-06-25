using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public GameObject Bollet, Centr, BigBollet, BFGCentr;

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
        if (gameObject.GetComponent<MotionTanks>().flag == false)
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
        Instantiate(Bollet, Centr.transform.position, Centr.transform.rotation);
        shootDelayeCountLitle = shootDelayeLitle;
        
    }

    void BulletBig()
    {
        Instantiate(BigBollet, BFGCentr.transform.position, BFGCentr.transform.rotation);
        shootDelayeCountBig = shootDelayeBig;
    }
}
