using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float score = 0;
    private float counter;
    public float scorePerSecond = 1;
    public float eatSeedPoints = 50;
    public AudioClip eatingSound;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        counter += Time.deltaTime;

        if (counter > scorePerSecond)
        {
            score++;
            GameObject.Find("Score").GetComponent<Text>().text = "Balloon score: " + score;
            counter = 0;
        }
        


        transform.position = new Vector3(transform.position.x, 1, transform.position.z);

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

    public void addEatSeedPoints()
    {
        GameObject.Find("Score").GetComponent<Text>().text = "Balloon score: " + score;
        score += eatSeedPoints;

        SoundManager.instance.PlaySingle(eatingSound);
    }
}
