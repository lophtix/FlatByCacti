using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed;
    public float GoalAngle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = GameObject.FindObjectOfType<BalloonMovement>().transform.position.x;
        float z = GameObject.FindObjectOfType<BalloonMovement>().transform.position.z;

        float rot = transform.eulerAngles.y;

        if (x > 0 && z > 0)
        {
            GoalAngle = 180;
        }
        else if (x <= 0 && z > 0)
        {
            GoalAngle = 90;
        }
        else if (x <= 0 && z <= 0)
        {
            GoalAngle = 0;
        }
        else
        {
            GoalAngle = 270;
        }

        float newRot = Mathf.LerpAngle(rot, GoalAngle, Time.deltaTime * speed);

        transform.rotation = Quaternion.Euler(0, newRot, 0);
        }
    }
