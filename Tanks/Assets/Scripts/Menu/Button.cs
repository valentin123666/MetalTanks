using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private AudioSource source;

    private void Awake()
    {
        source = GameObject.FindWithTag("Sound").GetComponent<AudioSource>();
    }

    public void ButtonStart()
    {
        if (PlayerPrefs.GetString("Sounds") == "on")
        {
            source.volume = PlayerPrefs.GetFloat("Volume");
            source.Play();
        }
        Application.LoadLevel("Level1");
    }

    public void ButtonExit()
    {
        if (PlayerPrefs.GetString("Sounds") == "on")
        {
            source.volume = PlayerPrefs.GetFloat("Volume");
            source.Play();
        }
        Application.Quit();

    }

    public void ButtonRestart()
    {
        if (PlayerPrefs.GetString("Sounds") == "on")
        {
            source.volume = PlayerPrefs.GetFloat("Volume");
            source.Play();
        }
        Application.LoadLevel("Level1");
    }

    public void ButtonMenu()
    {
        if (PlayerPrefs.GetString("Sounds") == "on")
        {
            source.volume = PlayerPrefs.GetFloat("Volume");
            source.Play();
        }
        Application.LoadLevel("Menu");
    }

    public void Sounds()
    {
        if (PlayerPrefs.GetString("Sounds") == "on")
        {
            source.volume = PlayerPrefs.GetFloat("Volume");
            source.Play();
        }

        if (PlayerPrefs.GetString("Sounds") != "on")
            PlayerPrefs.SetString("Sounds", "on");
        else
            PlayerPrefs.SetString("Sounds", "off");
    }
}
