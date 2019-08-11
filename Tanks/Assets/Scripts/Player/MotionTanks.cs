using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTanks : MonoBehaviour {
     Rigidbody rd;
     GameObject obj ;
    
    public float moveSpeedForw,moveSpeedBakc , turnSpeed;
    public bool flagOver, flagWin;


    void Awake()
    {
        if (obj == null)
        {
            obj = GameObject.FindWithTag("Magic");
        }
    }
    void Start()
    {

        rd = GetComponent<Rigidbody>();
        flagOver = false;
        flagWin = false;
    }


    void Update()
    {
        Moving();

        if (flagOver == true && flagWin == false)
        {
            GameOver();
        }
        if (flagOver == false && flagWin == true)
        {
            GameWin();
        }
    }

    void Moving()
    {
        if (flagOver == false && flagWin == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rd.transform.Translate(Vector3.forward * moveSpeedForw * Time.deltaTime);

            if (Input.GetKey(KeyCode.DownArrow))
                rd.transform.Translate(-Vector3.forward * moveSpeedBakc * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftArrow))
                rd.transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
                rd.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
           
        }
    }
    void GameOver()
    {
        obj.GetComponent<Canvas>().Game = "GameOver";
    }
    void GameWin()
    {
        obj.GetComponent<Canvas>().Game = "Yor Win!!!";
    }
}
