using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoverScript : MonoBehaviour {



    Rigidbody rb;
    public float moveSpeed;
    public float rotateSpeed;

    int size;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        size = GetComponent<CubeEatScript>().size;



        Vector3 vel = rb.velocity;

        vel = transform.forward * Input.GetAxis("Vertical") * moveSpeed * size;

        vel.y = rb.velocity.y;

        transform.Rotate(Vector3.up,Input.GetAxis("Horizontal") * rotateSpeed);

        rb.velocity = vel;
	}
}
