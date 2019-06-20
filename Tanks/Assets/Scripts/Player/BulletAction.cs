using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour {
    public float speed;
    public float damag = 2f;
    Vector3 lasPos;

    void Awake()
    {
        lasPos = transform.position;
    }
    void Strat()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        

        Quaternion CurrenStep = gameObject.transform.rotation;
        transform.LookAt(lasPos, transform.up);

        RaycastHit hit;
        float Distance = Vector3.Distance(lasPos, transform.position);
        if (Distance == 0.0f)
            Distance = 1e-05f;

        if (Physics.Raycast(lasPos, transform.TransformDirection(Vector3.back), out hit, Distance) && (hit.collider.tag == "Monsters"))
        {
            if (hit.collider.gameObject.GetComponent<MonstersHelets>() != null)
            {
                hit.collider.gameObject.GetComponent<MonstersHelets>().healt -= damag * (1 - hit.collider.gameObject.GetComponent<MonstersHelets>().armor);
                Destroy(gameObject);
            }
        }
        else if (Physics.Raycast(lasPos, transform.TransformDirection(Vector3.back), out hit, Distance) && (hit.collider.tag == "Wall"))
        {
            Destroy(gameObject);
        }

        gameObject.transform.rotation = CurrenStep;
        lasPos = gameObject.transform.position;
    }
}
