using UnityEngine;
using System.Collections;

public class MusicBoxMain : MonoBehaviour {
	private float rotateSpeed;
	// Use this for initialization
	void Start () {
		GameObject musicManager = GameObject.Find("MusicManager");
        rotateSpeed = musicManager.GetComponent<MusicManager>().rotationSpeed;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);

	}
}
