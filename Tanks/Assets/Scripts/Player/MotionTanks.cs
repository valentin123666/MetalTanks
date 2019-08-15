using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTanks : MonoBehaviour {
    private Rigidbody rd;
    private GameObject obj ;
    
    public float moveSpeedForw,moveSpeedBakc , turnSpeed;
    public bool flagOver, flagWin;


    private void Awake()
    {
        if (obj == null)
        {
            obj = GameObject.FindWithTag("Magic");
        }
    }
    private void Start()
    {

        rd = GetComponent<Rigidbody>();
        flagOver = false;
        flagWin = false;
    }


    private void Update()
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

    private void Moving()
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
    private void GameOver()
    {
        obj.GetComponent<Canvas>().Game = "Game Over";
    }
    private void GameWin()
    {
        obj.GetComponent<Canvas>().Game = "Yor Win!!!";
    }
}
