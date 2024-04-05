using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody physic;
    public int speed = 5;
    public GameObject explosion;
    void Start()
    {
        speed = 5;
        physic = GetComponent<Rigidbody>();
        physic.angularVelocity = Random.insideUnitSphere * speed;
        physic.velocity = transform.forward * -speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube_Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }


}
