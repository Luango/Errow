using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMusicNote : MonoBehaviour {
    private Vector3 iniPosition;

    private float lifeSpan = 0.0f;
    private string noteName;
    private float stepSize;

    private AudioSource noteSound;
    public AudioClip keySound;
    private bool hasPlayed = false;

	// Use this for initialization
	void Start () {
        noteSound = gameObject.GetComponent<AudioSource>();
        noteSound.clip = keySound;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0f && hasPlayed == false)
        {
            hasPlayed = true;
            noteSound.Play(); 
        }
    }
}
