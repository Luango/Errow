using UnityEngine;
using System.Collections;

public class bubbleEmitter : MonoBehaviour {
    public GameObject bubble;
    public bool side;
	void Start () {
        StartCoroutine(emit());
    }

    IEnumerator emit()
    {
        GameObject  newBubble = Instantiate(bubble, transform.position, Quaternion.identity) as GameObject;
        if(side)
             newBubble.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(2f, 5f), Random.Range(-.1f, -10f));
        else
            newBubble.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f, -5f), Random.Range(-.1f, -10f));
        yield return new WaitForSeconds(1);
        StartCoroutine(emit());
    }
}
