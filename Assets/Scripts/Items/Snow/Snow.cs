using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour {
    private float lifeSpan = 15f;
    private float speed = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lifeSpan -= Time.deltaTime;
        transform.Translate(Vector3.down * speed, Space.World);
        transform.Rotate(new Vector3(Random.Range(-11f, 11f), Random.Range(-11f, 11f), 0f));
        if (lifeSpan < 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
