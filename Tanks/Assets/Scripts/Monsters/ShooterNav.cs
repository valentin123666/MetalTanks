using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterNav : MonoBehaviour {
    
    public float shootDelaye,speed;

    private float shootDelayeCount;
    private Transform target, owner;
  
    [SerializeField]
    GameObject Bullet, centerG;

    GameObject player;
    NavMeshAgent agent;

    void Start()
    {
        if (player == null)
            player = GameObject.FindWithTag("Tanks");

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
    }

    void FixedUpdate()
    {
        shootDelayeCount -= Time.deltaTime;
    }

    void Shoot()
    {
        if(shootDelayeCount<=0)
        {
            Instantiate(Bullet, centerG.transform.position, centerG.transform.rotation);
            shootDelayeCount = shootDelaye;
        }
    }
}
