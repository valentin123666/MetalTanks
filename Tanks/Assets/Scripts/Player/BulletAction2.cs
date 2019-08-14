using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction2 : MonoBehaviour {

    Rigidbody rd; 

    public float speed;
    public float damag ;

    void Start () {
 
        rd = GetComponent<Rigidbody>();       
	}
	
   void FixedUpdate()
    {
        rd.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

	void OnTriggerEnter(Collider other)
    {
        var getM = other.GetComponent<MonstersHelets>();
        var getComBour = other.GetComponent<HelsBour>();

        if (other.tag == "Wall")
        {
             GameObject Explousion = PoolMenedjer.GetObject("Explosion", transform.position, Quaternion.identity);
            GetComponent<PoolObj>().ReturnToPool();
        }
        if (other.tag == "MonstersBour")
        {
            if (getComBour != null)
            {
                GameObject Explousion = PoolMenedjer.GetObject("Explosion", transform.position, Quaternion.identity);
                getComBour.healt -= damag * (1 - getComBour.armor);
                GetComponent<PoolObj>().ReturnToPool();
            }
        }
        if (other.tag =="Monsters")
        {
            if(getM != null)
            {
                GameObject Explousion = PoolMenedjer.GetObject("Explosion", transform.position, Quaternion.identity);
                getM.healt -= damag * (1 - getM.armor);
                GetComponent<PoolObj>().ReturnToPool();
            }
        }
       
    }
}
