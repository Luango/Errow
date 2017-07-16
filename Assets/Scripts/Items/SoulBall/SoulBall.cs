using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBall : MonoBehaviour {
    private float lifeTime = 5f;
    private 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            YijoShots.hasShootSoulBall = false;
            Destroy(this.gameObject);
        }
	}
}
