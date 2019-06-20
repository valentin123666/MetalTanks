using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    
    public GameObject player;
    private Vector3 ofSetes;

    void Start()
    {
        ofSetes = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + ofSetes;
    }
}
