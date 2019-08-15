using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterNav : MonoBehaviour {

    private NavMeshAgent agent;
    [SerializeField]
    private GameObject player;
    private Transform target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Tanks");
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        target = player.transform;
        agent.SetDestination(target.position);
    }
}
