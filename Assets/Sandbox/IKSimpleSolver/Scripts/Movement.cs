using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    // Move right
	void Update () {
        transform.Translate(new Vector2(Time.deltaTime*2f, 0f));
	}
}
