using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEmits : MonoBehaviour {
    public Vector3 playerPos;

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        }	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, playerPos, 50f * Time.deltaTime);
	}
}
