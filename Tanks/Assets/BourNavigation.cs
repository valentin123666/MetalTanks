using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BourNavigation : MonoBehaviour
{    
    void Start()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
