using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationBullet : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hi collision");
        if (collision.tag == "Player" || collision.tag == "Others")
        {
            print("hi player");
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
