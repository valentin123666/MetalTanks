using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlExplousion : MonoBehaviour {

    GameObject obj;
    void Start()
    {
         obj = PoolMenedjer.GetObject("Cube (3)", transform.position, transform.rotation);
    } 
	void Update() {
        if (obj.activeSelf == false)
            Spawn();
    }
    void Spawn(){
         obj = PoolMenedjer.GetObject("Cube (3)", transform.position, transform.rotation);
        }
}
