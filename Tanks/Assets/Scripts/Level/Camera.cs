using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private GameObject transCam;
    private Vector3 ofSetes;

    void Start()
    {
        if (transCam == null)
            transCam = GameObject.FindWithTag("TransCam");
    }
    void LateUpdate()
    {
        transform.position = transCam.transform.position;
        transform.rotation = transCam.transform.rotation;
    }
}
    