using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MchiineNav : MonoBehaviour {

    [SerializeField]
    GameObject Bullet, centerG, player, Gan;

    NavMeshAgent agent;   
    Transform target, owner;
    Vector3 lasPos;

    public float shootDelaye, speed;

    private float shootDelayeCount;
    private float RotGan = 200f;
    


    void Start()
    {
        shootDelayeCount = 0;
        target = player.transform;
        owner = transform;
        agent = GetComponent<NavMeshAgent>();
    }


    void FixedUpdate()
    {
        var direction = owner.position - target.position;
        direction = direction.normalized;

        RaycastHit hit;
        float Distance = Vector3.Distance(transform.position,player.transform.position);
        if (Distance == 0.0f)
            Distance = 1e-05f;

        if(Physics.Raycast(direction,transform.TransformDirection(Vector3.forward),out hit,Distance)&&(hit.collider.tag !="Wall")&& (hit.collider.tag != "Monsters")&&(hit.collider.tag == "Tanks"))
        {

            // Gan.transform.Rotate(Vector3.up * RotGan * Time.deltaTime);           
            agent.isStopped = true;
            owner.rotation = Quaternion.Lerp(owner.rotation, target.rotation, Time.deltaTime * speed);
            Instantiate(Bullet, centerG.transform.position, centerG.transform.rotation);
            // Shoot();
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        }
       
    }
    void Shoot()
    {
        if (shootDelayeCount <= 0)
        {
            Instantiate(Bullet, centerG.transform.position, centerG.transform.rotation);
            shootDelayeCount = shootDelaye;
        }
    }

}
