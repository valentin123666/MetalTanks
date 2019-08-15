using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction2 : MonoBehaviour {

    private Rigidbody rd; 

    public float speed;
    public float damag ;

    private void Start () {
 
        rd = GetComponent<Rigidbody>();       
	}

    private void FixedUpdate()
    {
        rd.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var getM = other.GetComponent<MonstersHelets>();
        var getComBour = other.GetComponent<HelsBour>();

        if (other.tag == "Wall")
        {
            GameObject Explousion = PoolMenedger.GetObject("Explosion", transform.position, Quaternion.identity);
            GetComponent<PoolObj>().ReturnToPool();
        }
        if (other.tag == "MonstersBour")
        {
            if (getComBour != null)
            {
                GameObject Explousion = PoolMenedger.GetObject("Explosion", transform.position, Quaternion.identity);
                getComBour.healt -= damag * (1 - getComBour.armor);
                GetComponent<PoolObj>().ReturnToPool();
            }
        }
        if (other.tag =="Monsters")
        {
            if(getM != null)
            {
                GameObject Explousion = PoolMenedger.GetObject("Explosion", transform.position, Quaternion.identity);
                getM.healt -= damag * (1 - getM.armor);
                GetComponent<PoolObj>().ReturnToPool();
            }
        }
       
    }
}
