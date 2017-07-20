using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public GameObject targetObject;
    public Transform targetTrans;

    private float generatingTime = 2f;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 6; i++)
        {
            GameObject target = Instantiate(targetObject, targetTrans.position + (3 - i) * new Vector3(2f, 0f, 0f), Quaternion.identity);
            target.transform.parent = null;
        }
    }
	
	// Update is called once per frame
    // Move right
	void Update () {
        transform.Translate(new Vector2(Time.deltaTime*2f, 0f));
        generatingTime -= Time.deltaTime;
        if(generatingTime < 0f)
        {
            print("generate a ball");
            generatingTime = 2f;
            for (int i = 0; i < 6; i++)
            {
                GameObject target = Instantiate(targetObject, targetTrans.position + (3-i) * new Vector3(Random.Range(1.8f,2.2f), 0f, 0f), Quaternion.identity);
                target.transform.parent = null;
            }
        }
	}
}
