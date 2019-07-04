using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public void ButtonStart()
    {
        Application.LoadLevel("Level1");
    }
    public void ButtonRestart()
    {
        Application.LoadLevel("Level1");
    }
    public void ButtonMenu()
    {
        Application.LoadLevel("Menu");
    }
}
