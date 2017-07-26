using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManager : MonoBehaviour {
    public Transform Location;
    public GameObject[] snows;
    public float frequency = 0.05f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        frequency -= Time.deltaTime;
        if (frequency < 0f)
        {
            Instantiate(snows[Random.Range(0, snows.Length)], Location.transform.position+new Vector3(Random.Range(-85f, 85f), 0f, 0f), Quaternion.identity);
            frequency = 0.1f;
        }
	}
}
