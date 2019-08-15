using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMon : MonoBehaviour
{
    private Rigidbody rd;

    private AudioSource audioSource;

    public float speed;

    private float damag = 1f;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rd = GetComponent<Rigidbody>();
       // rd.AddRelativeForce(Vector3.up * speed, ForceMode.Impulse);
    }
    private void FixedUpdate()
    {
        rd.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        var getCom = other.GetComponent<TankHealth>();
        if (other.tag == "Wall")
        {
            GameObject Explousion = PoolMenedger.GetObject("Explosion", transform.position, Quaternion.identity);
            GetComponent<PoolObj>().ReturnToPool();
        }
        if (other.tag == "Tanks")
        {
            if (getCom != null&&getCom.health>0)
            {
                GameObject Explousion = PoolMenedger.GetObject("Explosion", transform.position, Quaternion.identity);                
                getCom.health -= damag * (1 - getCom.armor);
                GetComponent<PoolObj>().ReturnToPool();
            }
        }
    }
}
