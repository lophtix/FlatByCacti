using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CactusController : MonoBehaviour {

    public AudioClip bang;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter (Collision other)
    {
        if(other.gameObject.Equals(GameObject.FindObjectOfType<BalloonMovement>().gameObject))
        {
            GameObject.Find("WinScreen").GetComponent<Text>().text = "The Cacti Won!";
            Time.timeScale = 0.0f;
            SoundManager.instance.PlaySingle(bang);
            Destroy(other.gameObject);
        }
    }
}
