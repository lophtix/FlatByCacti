using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowUp : MonoBehaviour {

    public float growUpTime;
    public float explodeTime;
    private float x = 0;
    private float scale = 1;
    public float maxSize;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (explodeTime > 0) {
            float y = getScale(x, 1);

            transform.localScale = new Vector3(y, y, y);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.localScale = new Vector3(y, y, y);
            }

            if (x < 1) { x += (float) (1.0 / growUpTime); }
            explodeTime--;
        }
        else
        {
            if (scale < maxSize)
            {
                scale += (float)(1.0 / 20);
                transform.localScale = new Vector3(scale, 1, scale);
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i));
                }
                
                Destroy(gameObject);
            }
        }

    }

    float getScale(float x, int a) {

        return -(Mathf.Pow((x - a), 2)) + a;

    }
        



}
