using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public GameObject  Centr,  BFGCentr,bum;  

    public AudioClip audioBFG, audioLFG;
   
    public float shootDelayeLitle, shootDelayeBig;
    public float timeClipLFG;
    public string weapon;


    MotionTanks get;
    AudioSource audioSource;

    private bool flag;
    private float shootDelayeCountLitle;
    private float shootDelayeCountBig;
    

    void Start()
    {
        get = gameObject.GetComponent<MotionTanks>();
        audioSource = GetComponent<AudioSource>();
        weapon = "LFG";
        flag = false;
        shootDelayeCountLitle = 0;
        shootDelayeCountBig = 0;
        timeClipLFG = audioLFG.length;
    }
    
    void Update()
    {
        Shot();
        shootDelayeCountLitle -= Time.deltaTime;
        shootDelayeCountBig -= Time.deltaTime;
        if (timeClipLFG < audioLFG.length)
            timeClipLFG += Time.deltaTime;
        if (timeClipLFG >= audioLFG.length)
            timeClipLFG = audioLFG.length;
    }

    void Shot()
    {
        
        if (get.flagOver == false && get.flagWin == false)
        {
            if (Input.GetKey(KeyCode.X) && flag == false && shootDelayeCountLitle <= 0)
            {
                if (timeClipLFG == audioLFG.length)
                {
                    if (PlayerPrefs.GetString("Sounds") == "on")
                    {
                        audioSource.clip = audioLFG;
                        audioSource.volume = PlayerPrefs.GetFloat("Volume");
                        audioSource.Play();
                        timeClipLFG = 0;
                    }
                }
                BulletLitle();
            }
            if (Input.GetKeyDown(KeyCode.X) && flag == true && shootDelayeCountBig <= 0)
            {
                if (PlayerPrefs.GetString("Sounds") == "on")
                {
                    audioSource.clip = audioBFG;
                    audioSource.volume = PlayerPrefs.GetFloat("Volume");
                    audioSource.Play();
                }
                BulletBig();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SwichFlag();
                WeaponRename();
            }

        }
    }

    string WeaponRename()
    {
        if (weapon == "LFG")
        {
            weapon = "BFG";
            return weapon;
        }
        else
        {
            weapon = "LFG";
            return weapon;
        }
    }

    bool SwichFlag()
    {
        if (flag == false)
        {
            flag = true;
            return flag;
           
        }
        else
        {
            flag = false;
            return flag;            
        }
    }
    void BulletLitle()
    {      
        GameObject bulletLitle = PoolMenedjer.GetObject("Capsule", Centr.transform.position, Centr.transform.rotation);
        shootDelayeCountLitle = shootDelayeLitle;
        
    }

    void BulletBig()
    {
        GameObject Bum = PoolMenedjer.GetObject("Bum", bum.transform.position, bum.transform.rotation);
        GameObject bulletBFG = PoolMenedjer.GetObject("Capsule 1", BFGCentr.transform.position, BFGCentr.transform.rotation);       
        shootDelayeCountBig = shootDelayeBig;
    }
}
