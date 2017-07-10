using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furfly : MonoBehaviour {
    public Transform startTransform;
    public Transform endTransform; 
    public float speed;
    private bool isAtEnd;
    private Vector3 startPos;
    private Vector3 endPos;

    public GameObject bleeding;

    // Use this for initialization
    private void Awake()
    {
        speed = 13f;
        isAtEnd = false;
        startPos = startTransform.position;
        endPos = endTransform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("bleeding");
        if (collision.gameObject.tag == "Arrow")
        {
            Instantiate(bleeding, transform);
        }
    }

    // Update is called once per frame
    void Update () {
        if(isAtEnd == false)
        {
            // Move to end
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
            // Claculate distance to end
            if(Vector3.Distance(this.gameObject.transform.position, endPos) < 0.5f)
            {
                isAtEnd = true;
            }
        } else
        {
            // Move to start
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            if (Vector3.Distance(this.gameObject.transform.position, startPos) < 0.5f)
            {
                isAtEnd = false;
            }
        }
	}
}
