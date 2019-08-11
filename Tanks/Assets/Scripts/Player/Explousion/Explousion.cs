using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explousion : MonoBehaviour {

    public float radius, force;

    Transform secondPos;
    Collider[] col;

    bool flag = false;
    void Start() {
        
    }
   
    void FixedUpdate()
    {
        col = Physics.OverlapSphere(transform.position, radius);
        if (flag == false)
            poh();
    }

    void Update()
    {
        Invoke("Return", 0.2f);
    }

    void Return()
    {       
          GetComponent<PoolObj>().ReturnToPool();
    }
    void poh()
    {
        foreach (Collider c in col)
        {
            if (c.tag == "BumComponent")
            {
                c.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
                flag = true;
            }
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
