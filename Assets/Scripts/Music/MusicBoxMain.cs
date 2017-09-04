using UnityEngine;
using System.Collections;

public class MusicBoxMain : MonoBehaviour {
	private float rotateSpeed;
    public float radius;

    private float orientationOffset;
	// Use this for initialization
	void Start () {
		GameObject musicManager = GameObject.Find("MusicManager");
        rotateSpeed = musicManager.GetComponent<MusicManager>().rotationSpeed;
        //orientationOffset = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<MusicGroup>().orientationOffset; 
        //transform.rotation = Quaternion.Euler(orientationOffset, -90f, 90f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!MusicManager.Pause)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
	}
}
