using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterNav : MonoBehaviour {
    
    public float shootDelaye,speed;

    private float shootDelayeCount;
    private Transform target, owner;
  
    [SerializeField]
    GameObject Bullet, centerG, player;
    NavMeshAgent agent;

    void Start()
    {
        target = player.transform;
        owner = transform;
        shootDelayeCount = 0;
        agent = GetComponent<NavMeshAgent>();
      
    }


    void Update()
    {
        var direction = owner.position - target.position;
        direction = direction.normalized;
        

        if(Vector3.Angle(direction,-owner.forward)<5)
        {
            Shoot();
        }

        float Distance = Vector3.Distance(owner.position, target.transform.position);
        if (Distance == 0.0f)
            Distance = 1e-05f;
        RaycastHit hit;

        if (Physics.Raycast(direction, transform.TransformDirection(-Vector3.forward),out hit, direction.magnitude))
        {
            agent.isStopped = true;
            var targetRotation = direction;
            direction.y = 0;
            owner.rotation = Quaternion.Lerp(owner.rotation, Quaternion.LookRotation(targetRotation) , Time.deltaTime*speed); 
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
