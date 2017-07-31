using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleSpider : MonoBehaviour {
    public GameObject SpiderEmit;
    private float SpiderShootingTime = Constants.FemaleSpiderShootingTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SpiderShootingTime -= Time.deltaTime;
        if (SpiderShootingTime < 0f)
        {
            Instantiate(SpiderEmit, transform.position, Quaternion.identity);
            SpiderShootingTime = Constants.FemaleSpiderShootingTime;
        }
	}
}
