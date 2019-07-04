using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Records : MonoBehaviour
{
    void Start()
    {
            GetComponent<Text>().text = PlayerPrefs.GetFloat("Score").ToString();
    }
}