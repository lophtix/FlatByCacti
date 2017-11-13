using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour {

    public int mouseButton;
    public float force;
    public float maxBuildUp;
    private float timePassed;
    private float mouseX;
    private float mouseY;
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
            mouseY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(mouseButton) && timePassed < maxBuildUp)
        {
            timePassed += Time.deltaTime;
            //arrow(mouseX, mouseY);
        }
        else if (Input.GetMouseButtonUp(mouseButton) || timePassed > maxBuildUp)
        {
            int quadrant = (int) GameObject.FindObjectOfType<CameraMovement>().GoalAngle / 90;
            Vector3 direction;
            float hyp = Mathf.Sqrt(Mathf.Pow((mouseX - Input.mousePosition.x), 2) + Mathf.Pow((mouseY - Input.mousePosition.y), 2));

            if (quadrant == 3)
            {
                direction = new Vector3(mouseX - Input.mousePosition.x, 0.0f, mouseY - Input.mousePosition.y);
            }
            else if (quadrant == 0)
            {
                direction = new Vector3(mouseY - Input.mousePosition.y, 0.0f, -(mouseX - Input.mousePosition.x));
            }
            else if (quadrant == 1)
            {
                direction = new Vector3(-(mouseX - Input.mousePosition.x), 0.0f, -(mouseY - Input.mousePosition.y));
            }
            else
            {
                direction = new Vector3(-(mouseY - Input.mousePosition.y), 0.0f, mouseX - Input.mousePosition.x);
            }

            direction = direction / hyp;

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
    /*
    void arrow(float startX, float startY)
    {
        GameObject arrow = GameObject.Find("Arrow");

        Ray startRay = Camera.main.ScreenPointToRay(new Vector3(startX, startY));
        RaycastHit startHit;

        Ray nowRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit nowHit;

        Vector3 center = new Vector3();

        if (Physics.Raycast(startRay, out startHit, 200))
        {
            if (Physics.Raycast(nowRay, out nowHit, 200)){

                center.x = findCenter(startHit.point.x, nowHit.point.x);
                center.y = (float)0.5;
                center.z = findCenter(startHit.point.z, nowHit.point.z);

                arrow.transform.position = center;
            }
        }


   }

    private float findCenter(float x1, float x2)
    {
        return (x1 + x2) / 2;
    }
    */
}
