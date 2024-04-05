using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour
{
    Rigidbody physic;

    [SerializeField] int speed = 5;
    [SerializeField] float nextFireCheck;
    [SerializeField] float fireRate;

    public Boundary boundary;
    public GameObject laser_shot;
    public GameObject shotSpawn;
   

    private void Start()
    {
        physic = GetComponent<Rigidbody>();
        fireRate = 0.25f;
        speed = 5;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireCheck)
        {
            nextFireCheck = Time.time + fireRate;
            Instantiate(laser_shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
        }
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);


        physic.velocity = movement * speed;

        Vector3 position = new Vector3(Mathf.Clamp(physic.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(physic.position.z, boundary.zMin, boundary.zMax)
            );

        physic.position = position;

        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x * -5);


    }
}
