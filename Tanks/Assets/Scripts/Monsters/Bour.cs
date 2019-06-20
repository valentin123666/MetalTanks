using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bour : MonoBehaviour {
    
    float RotateSpeed= 200, damag = 0.5f;
    void Start () {
		
	}

    void FixedUpdate()
    {
        gameObject.transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tanks")
        {
            other.GetComponent<TanksHels>().healt -= damag * (1 - other.GetComponent<TanksHels>().armor);
        }
    }
}
