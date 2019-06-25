using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction2 : MonoBehaviour {

    Rigidbody rd;

    public float speed;
    public float damag ;

    void Start () {
        rd = GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.up * speed, ForceMode.Impulse);
	}
	
	void OnTriggerEnter(Collider other)
    {
        var getM = other.GetComponent<MonstersHelets>();
        if (other.tag == "Wall")
            Destroy(gameObject);

        if (other.tag =="Monsters")
        {
            if(getM != null)
            {
                getM.healt -= damag * (1 - getM.armor);
                Destroy(gameObject);
            }
        }
    }
}
