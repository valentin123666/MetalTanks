using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterNav : MonoBehaviour {
    
    public float shootDelaye,speed;

     float shootDelayeCount,timeClipe;
     Transform target, owner;
  
    [SerializeField]
    GameObject Bullet, centerG;

    AudioSource audio;
    GameObject player;
    NavMeshAgent agent;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (player == null)
            player = GameObject.FindWithTag("Tanks");

        timeClipe = audio.clip.length;
        target = player.transform;
        owner = transform;
        shootDelayeCount = 0;
        agent = GetComponent<NavMeshAgent>();
      
    }


    void Update()
    {        
        RaycastHit hit;

        if (Physics.Raycast(owner.position+transform.up, transform.TransformDirection(Vector3.forward), out hit,60f) && (hit.collider.tag != "Wall") && (hit.collider.tag != "Monsters") && (hit.collider.tag == "Tanks"))
        {           
                agent.isStopped = true;
                Shoot();                     
        }
        else
        {            
               agent.isStopped = false;
               agent.SetDestination(target.position);
        }

        if(timeClipe < audio.clip.length)
           timeClipe += Time.deltaTime;

        
        if (timeClipe > audio.clip.length)
            timeClipe = audio.clip.length;

    }

    void FixedUpdate()
    {
        shootDelayeCount -= Time.deltaTime;
    }

    void Shoot()
    {
        if(shootDelayeCount<=0)
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
            Instantiate(Bullet, centerG.transform.position, centerG.transform.rotation);
            shootDelayeCount = shootDelaye;
        }
    }
}
