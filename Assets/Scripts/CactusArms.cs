using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusArms : MonoBehaviour {

    public GameObject cactiArm;
	// Use this for initialization
	void Start () {
        float rot = 0;
        int arms = 0;
        float startRotation = Random.Range(0, 360);
        int debug = 0;

        //print(Random.Range(0, arms + 2));

        for (int i = 0; i < 4; i++)
        {

            if ((Random.Range(0, arms + 2)) == 1)
            {
                arms++;
                cactiArm.transform.rotation = Quaternion.Euler(0, (startRotation + rot) % 360, 0);
                cactiArm.transform.localScale = new Vector3(0, 0, 0);
                Instantiate(cactiArm, transform);
                debug++;
            }
            print(debug);
            rot += 90;

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
