using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour {

    public float rayDistance;
    public GameObject seed;
    public GameObject prefabSeed;
    public float minDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            if(hit.collider.tag == "Ground")
            {
                seed.transform.position = hit.point;

            }

            if (Input.GetMouseButtonDown(0))
            {
                if (canPlaceSeed())
                {
                    prefabSeed.transform.position = seed.transform.position;
                    Instantiate(prefabSeed);
                }
            }
        }
        else
        {
            seed.transform.position = new Vector3(0, -1, 0);
        }
    }

    private bool canPlaceSeed()
    {
        GameObject[] seeds = GameObject.FindGameObjectsWithTag("Seeds");
        GameObject[] cacti = GameObject.FindGameObjectsWithTag("Cacti");



        Vector3 current = seed.transform.position;

        for (int i = 0; i < seeds.Length; i++)
        {
            if(Vector3.Distance(current, seeds[i].transform.position) < minDistance)
            {
                return false;
            }
        }

        for (int i = 0; i < cacti.Length; i++)
        {
            if (Vector3.Distance(current, cacti[i].transform.position) < minDistance)
            {
                return false;
            }
        }

        return true;
    }
}
