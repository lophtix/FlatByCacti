using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDisappear : MonoBehaviour {

    public GameObject cacti;
    public GameObject cactiArm;
    public float time = 30;
    private float x = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float y = getScale(x, 1);

        transform.localScale = new Vector3(y, y, y);

        if (x < 1) { x += (float)(1.0 / time); }
        else
        {
            cacti.transform.position = transform.position;
            cacti.transform.localScale = new Vector3(0, 0, 0);
            Instantiate(cacti);

            float rot = 0;
            int arms = 0;
            float startRotation = Random.Range(0, 360);

            print(Random.Range(0, arms + 2));

            for (int i = 0; i < 4; i++) {

                if (Mathf.Round(Random.Range(0, arms + 2)) == 1)
                {
                    arms++;
                    cactiArm.transform.rotation = Quaternion.Euler(0, (startRotation + rot) % 360, 0);
                    cactiArm.transform.localScale = new Vector3(0, 0, 0);
                    Instantiate(cactiArm, cacti.transform);

                }

                rot += 90;

            }
            Destroy(gameObject);
        }

    }

    float getScale(float x, int a)
    {

        return -(Mathf.Pow((x), 2)) + a;

    }
}
