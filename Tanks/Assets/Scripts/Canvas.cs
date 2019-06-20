using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {

    [SerializeField]
    GameObject player;
    [SerializeField]
    Text txtHeal , txtMorder;

    public float countHeal, countMorder;

	void Start () {
        countMorder = 0;
    }
	
	
	void Update () {
        countHeal = player.GetComponent<TanksHels>().healt;
        setText();
	}
    void setText()
    {
        txtHeal.text = "Health: " + countHeal.ToString();
        txtMorder.text = "Morder: " + countMorder.ToString();
    }
}
