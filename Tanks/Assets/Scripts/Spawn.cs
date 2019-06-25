using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [SerializeField]
    private GameObject player, bour, machine, centerMaps, spawn1,spawn2;

    private int countMachine = 0,countBour=0;
    private float timeBour, timeMacine;

	void Awake() {
        Instantiate(player, centerMaps.transform.position, Quaternion.identity);       
    }    
     void Update()
    {
        if(countMachine < 7&&timeMacine<=0)
        {            
            Instantiate(machine, spawn2.transform.position, Quaternion.identity);
            countMachine++;
            timeMacine= 3f;
        }
        if(countBour<3&&timeBour<=0)
        {
            Instantiate(bour, spawn1.transform.position, Quaternion.identity);
            countBour++;
            timeBour = 3f;
        }
        timeMacine -= Time.deltaTime;
        timeBour -= Time.deltaTime;
    }
}
