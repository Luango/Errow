using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour {
	public bool isActive;

	void Start () {
		isActive = false;
	}
	public void activeNote(){
		isActive = true;
	}
}
