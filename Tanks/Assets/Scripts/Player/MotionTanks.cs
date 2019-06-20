using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTanks : MonoBehaviour {
    private Rigidbody rd;

    public float moveSpeed , turnSpeed;



    void Start()
    {
        rd = GetComponent<Rigidbody>();

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            Moving(1);

        if (Input.GetKey(KeyCode.DownArrow))
            Moving(2);

        if (Input.GetKey(KeyCode.LeftArrow))
            Moving(3);

        if (Input.GetKey(KeyCode.RightArrow))
            Moving(4);
    }

    void Moving(int click)
    {
        switch (click)
        {
            case 1:
                rd.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                break;
            case 2:
                rd.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
                break;
            case 3:
                rd.transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);
                break;
            case 4:
                rd.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
                break;
        }
    }
}
