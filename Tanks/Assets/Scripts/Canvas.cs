using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {
        
    GameObject player;
    [SerializeField]
    Text txtHeal , txtMorder,txtWeapon,txtGameOver;

    public float countHeal, countMorder;
    public string GameOver;
       
    void Start () {
        if (player == null)
            player = GameObject.FindWithTag("Tanks");

        countMorder = 0;
        countMorder = 0;
        GameOver = "";
    }
	
	
	void Update () {
        countHeal = player.GetComponent<TanksHels>().healt;
        setText();
	}
    void setText()
    {
        txtHeal.text = "Health: " + countHeal.ToString();
        txtMorder.text = "Morder: " + countMorder.ToString();
        txtWeapon.text = "Weapon: " + player.GetComponent<Bullet>().weapon;
        txtGameOver.text = GameOver;
    }
}
