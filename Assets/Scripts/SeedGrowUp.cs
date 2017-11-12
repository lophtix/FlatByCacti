using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowUp : MonoBehaviour {

    public float growUpTime;
    public float explodeTime;
    private float x = 0;
    private float scale = 1;
    private float sinusAngle = 0;
    public float sinusAngleStop = Mathf.PI*4;
    public float maxSize;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (explodeTime > 0) {
            // Waiting for explosion (countdown using explodeTime--)  
            float y = getScale(x, 1);

            transform.localScale = new Vector3(y, y, y);

            //Scale all children too...
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.localScale = new Vector3(y, y, y);
            }

            if (x < 1) { x += (float) (1.0 / growUpTime); }
            explodeTime--;
        }
        else
        {
            // explodeTime reached zero, so time to swell
            if (sinusAngle < sinusAngleStop)
            {

                //add oscillating code here
                scale += 0.01f * Mathf.Sin(sinusAngle);
                transform.localScale = new Vector3(scale, 1, scale);
                print("sin " + sinusAngle +" scale "+ scale);
                sinusAngle += 0.1f;
            } else
            {
                if (scale < maxSize)
                {
                    //scale += (float)(1.0 / 20);
                    scale += 0.5f;
                    transform.localScale = new Vector3(scale, 1, scale);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    float getScale(float x, int a) {

        return -(Mathf.Pow((x - a), 2)) + a;

    }
        



}
