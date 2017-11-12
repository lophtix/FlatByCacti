using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour {

    public int mouseButton;
    public float force;
    private float timePassed;
    private float mouseX;
    private float mouseZ;
    private GameObject[] seeds;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        seeds = GameObject.FindGameObjectsWithTag("Seeds");

        if (Input.GetMouseButtonDown(mouseButton))
        {
            mouseX = Input.mousePosition.x;
            mouseZ = Input.mousePosition.z;
        }
        else if (Input.GetMouseButton(mouseButton) && timePassed < 3)
        {
            timePassed += Time.deltaTime;
            print(timePassed);
        }
        else if (Input.GetMouseButtonUp(mouseButton) || timePassed > 3)
        {
            Vector3 direction = new Vector3(Mathf.Sign(mouseX - Input.mousePosition.x), 0.0f, Mathf.Sign(mouseZ - Input.mousePosition.z)); //gives magnitude?
            for (int i = 0; i < seeds.Length; i++)
            {
                seeds[i].GetComponent<Rigidbody>().AddForce(direction * timePassed * timePassed * force);
            }

            GameObject.Find("Balloon").GetComponent<Rigidbody>().AddForce(direction * timePassed * timePassed * force);

            timePassed = 0;
        }
        else
        {
            timePassed = 0;
        }

    }
}
