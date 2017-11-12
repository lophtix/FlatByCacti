using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseRaycast : MonoBehaviour {

    public float rayDistance;
    public GameObject seed;
    public GameObject prefabSeed;
    public float minDistance;
    private int seeds;
    public int totSeeds;

    private Text seedsText;
    private Text seedsAvaliableText;

	// Use this for initialization
	void Start () {
        seeds = totSeeds;

        seedsText = GameObject.Find("SeedsText").GetComponent<Text>();
        seedsAvaliableText = GameObject.Find("SeedsAvailableText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                if (hit.collider.tag == "Ground")
                {
                seed.transform.position = new Vector3(hit.point.x, 1, hit.point.z);

                }

                if (Input.GetMouseButtonDown(0))
                {
                    if (canPlaceSeed())
                    {
                        prefabSeed.transform.position = seed.transform.position;
                        Instantiate(prefabSeed);
                        placeSeed();
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
        GameObject[] placedSeeds = GameObject.FindGameObjectsWithTag("Seeds");
        GameObject[] placedCacti = GameObject.FindGameObjectsWithTag("Cacti");

        if(seeds <= 0)
        {
            return false;
        }


        Vector3 current = seed.transform.position;

        for (int i = 0; i < placedSeeds.Length; i++)
        {
            if(Vector3.Distance(current, placedSeeds[i].transform.position) < minDistance)
            {
                return false;
            }
        }

        for (int i = 0; i < placedCacti.Length; i++)
        {
            if (Vector3.Distance(current, placedCacti[i].transform.position) < minDistance)
            {
                return false;
            }
        }

        return true;
    }

    public void destroySeed()
    {
        totSeeds--;
        seedsText.text = "Seeds: " + totSeeds;

        if(totSeeds <= 0)
        {
            GameObject.Find("WinScreen").GetComponent<Text>().text = "The Balloon Won!";
            Time.timeScale = 0.0f;
        }
    }

    public void placeSeed()
    {
        seeds--;
        seedsAvaliableText.text = "Seeds available: " + seeds;
    }

    public void returnSeed()
    {
        seeds++;
        seedsAvaliableText.text = "Seeds available: " + seeds;
    }

}
