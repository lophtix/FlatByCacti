using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement: MonoBehaviour {

    // Use this for initialization

    public float speed;
    public float rotationSpeed;
    private Rigidbody rb;

    private KeyCode forward = KeyCode.W;
    private KeyCode right = KeyCode.D;
    private KeyCode backwards = KeyCode.S;
    private KeyCode left = KeyCode.A;

    public float GoalRotation = 0;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        int bf = 0;
        int rl = 0;

        if (Input.GetKey(forward))
        {
            bf++;
        }
        if (Input.GetKey(backwards))
        {
            bf--;
        }
        if (Input.GetKey(left))
        {
            rl++;
        }
        if (Input.GetKey(right))
        {
            rl--;
        }

        Vector3 movement = new Vector3(bf, 0.0f, rl);

        rb.AddForce(movement * speed * Time.deltaTime);

        float rot = transform.eulerAngles.y;
        float newRot = Mathf.LerpAngle(rot, GoalRotation, Time.deltaTime * rotationSpeed);

        transform.rotation = Quaternion.Euler(0, newRot, 0);
    }

    public void switchControls()
    {
        KeyCode temp = left;

        left = backwards;
        backwards = right;
        right = forward;
        forward = temp;

        GoalRotation = (GoalRotation + 90) % 360;
    }
}
