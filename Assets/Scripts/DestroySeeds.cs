using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySeeds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.Equals(GameObject.FindObjectOfType<BalloonMovement>().gameObject))
        {
            GameObject.FindObjectOfType<MouseRaycast>().destroySeed();
            GameObject.FindObjectOfType<BalloonMovement>().addEatSeedPoints();
            Destroy(gameObject);
        }
    }
}
