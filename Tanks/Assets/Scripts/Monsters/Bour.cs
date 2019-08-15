using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bour : MonoBehaviour {
      
    private AudioSource audio;

    private float timeClipe;

    private float RotateSpeed = 200, damag = 0.2f;
    private void Start () {
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("Volume");
        timeClipe = audio.clip.length;    
    }

    private void Update()
    {
        if(timeClipe<audio.clip.length)
        {
            timeClipe += Time.deltaTime;
          
        }
        if (timeClipe > audio.clip.length)
            timeClipe = audio.clip.length;

        

    }

    private void OnTriggerStay(Collider other)
    {
        audio.volume = PlayerPrefs.GetFloat("Volume");
        var GetHels = other.GetComponent<TankHealth>();
        if (GetHels != null && GetHels.health > 0)
        {
            if (other.tag == "Tanks")
            {
                if (PlayerPrefs.GetString("Sounds") == "on")
                {
                    if (timeClipe == audio.clip.length)
                    {
                        audio.volume = PlayerPrefs.GetFloat("Volume");
                        audio.Play();
                        timeClipe = 0;                       
                    }
                }

                GetHels.health -= damag * (1 - GetHels.armor);

                gameObject.transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
               if (GetHels.health < 0)
                {
                    audio.mute = true;
                }
            }
        }
              
    }
    private void OnTriggerExit(Collider other)
    {    
            audio.volume = 0;
    }    
}
