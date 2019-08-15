using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float speed= 2;   
    private GameObject transCam;

    private void Start()
    {
        if (transCam == null)
            transCam = GameObject.FindWithTag("TransCam");
    }

    private void LateUpdate()
    {
        transform.SetPositionAndRotation(Vector3.Lerp(transform.position, transCam.transform.position, 2f), Quaternion.Lerp(transform.rotation,transCam.transform.rotation,Time.time*0.5f));
    }
}
    