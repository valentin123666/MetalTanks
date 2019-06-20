﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public GameObject Bollet, Centr, BigBollet, BFGCentr;

    public float shootDelayeLitle;
    public float shootDelayeBig;

    private bool flag;
    private float shootDelayeCountLitle;
    private float shootDelayeCountBig;

    void Start()
    {
        flag = false;
        shootDelayeCountLitle = 0;
        shootDelayeCountBig = 0;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.X) && flag == false && shootDelayeCountLitle<=0)
        {
            BulletLitle();
        }
        if (Input.GetKeyDown(KeyCode.X) && flag == true && shootDelayeCountBig <= 0)
        {
            BulletBig();
        }
        if (Input.GetKeyDown(KeyCode.Z))
            SwichFlag();

        shootDelayeCountLitle -= Time.deltaTime;
        shootDelayeCountBig -= Time.deltaTime;
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