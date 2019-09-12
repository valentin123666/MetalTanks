using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterNav : MonoBehaviour {
    
    public float shootDelaye,speed;

    private float shootDelayeCount,timeClipe;
    private Transform target, owner;
  
    [SerializeField]
    private GameObject Bullet, centerG;

    private AudioSource audio;
    private GameObject player;
    private NavMeshAgent agent;

    private void Start()
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


    private void Update()
    {        
        RaycastHit hit;

        if (Physics.Raycast(owner.position+transform.up, transform.TransformDirection(Vector3.forward), out hit,60f) && (hit.collider.tag == "Tanks"))
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

    private void FixedUpdate()
    {
        shootDelayeCount -= Time.deltaTime;
    }

    private void Shoot()
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
            GameObject Bulet = PoolMenedger.GetObject("Capsule 2", centerG.transform.position, centerG.transform.rotation);
            shootDelayeCount = shootDelaye;
        }
    }
}
