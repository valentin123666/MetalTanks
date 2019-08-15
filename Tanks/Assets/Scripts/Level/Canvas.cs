using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {

    private GameObject player;
    [SerializeField]
    private Text txtHeal , txtMorder,txtWeapon,txtGame;
    private Light linght;

    [SerializeField]
    private GameObject myLing;

    [SerializeField]
    private Slider slider;

    private float lin = 0.2f;

    public float countHeal, countMorder;
    public string Game;

    private void Start () {
        linght = myLing.GetComponent<Light>();
        
        if (player == null)
            player = GameObject.FindWithTag("Tanks");
                
        countMorder = 0;
        Game = "";
    }


    private void Update () {
        countHeal = player.GetComponent<TankHealth>().health;

        setText();

        slider.value = countHeal;

        if(countMorder>=GetComponent<MazeSpawn>().countMonsters)
        {
            player.GetComponent<MotionTanks>().flagWin = true;                       
        }

        if (Game== "Game Over")
        {
            GameOver();
        }
        if (Game == "Yor Win!!!")
        {
            GameOver();
        }

    }
    private void setText()
    {
        txtHeal.text = "HEALTH ";
        txtMorder.text = "Morder: " + countMorder.ToString();
        txtWeapon.text = "Weapon: " + player.GetComponent<Bullet>().weapon;
        txtGame.text = Game;
    }
    private void GameOver()
    {
        linght.intensity = linght.intensity - lin * Time.deltaTime;

        if (PlayerPrefs.GetFloat("Score") <= countMorder)
        {
            PlayerPrefs.SetFloat("Score", countMorder);

        }
        if ((linght.intensity == 0)|| (Input.GetKey(KeyCode.Space)))
            Application.LoadLevel("GameOver");       
    }
}
