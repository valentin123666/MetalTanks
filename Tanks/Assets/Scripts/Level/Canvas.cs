using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {
        
    GameObject player;
    [SerializeField]
    Text txtHeal , txtMorder,txtWeapon,txtGame;    
    Light linght;

    [SerializeField]
    GameObject myLing;

    [SerializeField]
    Slider slider;

    private float lin = 0.2f;

    public float countHeal, countMorder;
    public string Game;
       
    void Start () {
        linght = myLing.GetComponent<Light>();
        
        if (player == null)
            player = GameObject.FindWithTag("Tanks");
                
        countMorder = 0;
        Game = "";
    }
	
	
	void Update () {
        countHeal = player.GetComponent<TanksHels>().healt;

        setText();

        slider.value = countHeal;

        if(countMorder>=10)
        {
            player.GetComponent<MotionTanks>().flagWin = true;                       
        }

        if (Game== "GameOver")
        {
            GameOver();
        }

    }
    void setText()
    {
        txtHeal.text = "HEALTH ";
        txtMorder.text = "Morder: " + countMorder.ToString();
        txtWeapon.text = "Weapon: " + player.GetComponent<Bullet>().weapon;
        txtGame.text = Game;
    }
    void GameOver()
    {
        linght.intensity = linght.intensity - lin * Time.deltaTime;

        if (PlayerPrefs.GetFloat("Score") <= countMorder)
        {
            PlayerPrefs.SetFloat("Score", countMorder);

        }
        if (linght.intensity == 0)
            Application.LoadLevel("GameOver");


        if (Input.GetKey(KeyCode.Space))
            Application.LoadLevel("GameOver");

    }
}
