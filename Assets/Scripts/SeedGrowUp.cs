using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowUp : MonoBehaviour {

    public float time = 30;
    private float x = 0;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        float y = getScale(x, 1);

        transform.localScale = new Vector3(y, y, y);

        if (x < 1) { x += (float)(1.0 / time); }

    }

    float getScale(float x, int a) {

        return -(Mathf.Pow((x - a), 2)) + a;

    }
        



}
