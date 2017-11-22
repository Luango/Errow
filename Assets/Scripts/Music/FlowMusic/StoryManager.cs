using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour {
    private List<GameObject> StoryNotes;

	// Use this for initialization
	void Start () {
		foreach(Transform child in transform)
        {
            StoryNotes.Add(child.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
