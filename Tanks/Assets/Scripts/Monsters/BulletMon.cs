using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMon : MonoBehaviour
{
    Rigidbody rd;
    [SerializeField]
    GameObject explousion;

    public float speed;

    private float damag = 1f;
    

    void Start()
    {

        rd = GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.up * speed, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {

        var getCom = other.GetComponent<TanksHels>();
        if (other.tag == "Wall")
        {
            GameObject Explousion = PoolMenedjer.GetObject("Explosion", transform.position, Quaternion.identity);
            GetComponent<PoolObj>().ReturnToPool();
        }
        if (other.tag == "Tanks")
        {
            if (getCom != null&&getCom.healt>0)
            {
                GameObject Explousion = PoolMenedjer.GetObject("Explosion", transform.position, Quaternion.identity); getCom.healt -= damag * (1 - getCom.armor);
                getCom.healt -= damag * (1 - getCom.armor);
                GetComponent<PoolObj>().ReturnToPool();
            }
        }
    }
}
