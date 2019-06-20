using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBour : MonoBehaviour {
    public float RotateSpeed;
	
	void Start () {
		
	}
	
	
	void FixedUpdate () {
        gameObject.transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
	}
}
