using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement: MonoBehaviour {

    // Use this for initialization

    public float speed;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        rb.AddForce(movement * speed);
    }
}
