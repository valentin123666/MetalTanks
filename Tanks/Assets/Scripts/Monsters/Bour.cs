using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bour : MonoBehaviour {
    
    float RotateSpeed= 200, damag = 0.5f;
    void Start () {
		
	}

    void OnTriggerStay(Collider other)
    {
        var GetHels = other.GetComponent<TanksHels>();
        if (other.tag == "Tanks"&&GetHels.healt>0)
        {
            GetHels.healt -= damag * (1 - other.GetComponent<TanksHels>().armor);
            gameObject.transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
        }
    }
}
