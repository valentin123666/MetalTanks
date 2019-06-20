using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMon : MonoBehaviour
{
    Rigidbody rd;

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
            Destroy(gameObject);

        if (other.tag == "Tanks")
        {
            if (getCom != null)
            {
                getCom.healt -= damag * (1 - getCom.armor);
                Destroy(gameObject);
            }
        }
    }
}
