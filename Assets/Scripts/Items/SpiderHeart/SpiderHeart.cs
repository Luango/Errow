using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHeart : MonoBehaviour {
    private GameObject FemaleSpider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Find the FemaleSpider.
        // find
        FemaleSpider = GameObject.FindGameObjectWithTag("FemaleSpider");
        // Move the heart to the FemaleSpider.
        if (FemaleSpider != null)
        {
            gameObject.transform.Translate((FemaleSpider.transform.position - gameObject.transform.position) * Time.deltaTime);
        }

        if (FemaleSpider != null)
        {
            if (Vector3.Distance(gameObject.transform.position, FemaleSpider.transform.position) < 3f)
            {
                FemaleSpider.GetComponent<FemaleSpider>().health += 1;
                Destroy(this.gameObject);
            }
        }
	}
}
