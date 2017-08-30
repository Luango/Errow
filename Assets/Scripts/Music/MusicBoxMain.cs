using UnityEngine;
using System.Collections;

public class MusicBoxMain : MonoBehaviour {
	private float rotateSpeed;
	// Use this for initialization
	void Start () {
		rotateSpeed = RotateSpeed.rotateSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);

	}
}
