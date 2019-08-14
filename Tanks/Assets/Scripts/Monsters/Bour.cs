using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bour : MonoBehaviour {
      
    AudioSource audio;

    float timeClipe;

    float RotateSpeed= 200, damag = 0.2f;
    void Start () {
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("Volume");
        timeClipe = audio.clip.length;    
    }

    void Update()
    {
        if(timeClipe<audio.clip.length)
        {
            timeClipe += Time.deltaTime;
          
        }
        if (timeClipe > audio.clip.length)
            timeClipe = audio.clip.length;

        

    }

    void OnTriggerStay(Collider other)
    {
        audio.volume = PlayerPrefs.GetFloat("Volume");
        var GetHels = other.GetComponent<TanksHels>();
        if (GetHels != null && GetHels.healt > 0)
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

                GetHels.healt -= damag * (1 - GetHels.armor);

                gameObject.transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
               if (GetHels.healt < 0)
                {
                    audio.mute = true;
                }
            }
        }
              
    }
    void OnTriggerExit(Collider other)
    {    
            audio.volume = 0;
    }    
}
