using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlowMusicNote : MonoBehaviour {
    private Vector3 iniPosition;

    private float lifeSpan = 3.0f;
    private string noteName;
    private float stepSize;
    private float threshold = 10f;

    private AudioSource noteSound;
    public AudioClip keySound;
    private bool hasPlayed = false;
    private bool isShrinking = false;

	// Use this for initialization
	void Start () {
        noteSound = gameObject.GetComponent<AudioSource>();
        noteSound.clip = keySound;
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (!isShrinking)
        {
            this.transform.DOScale(new Vector3(3f, 3f, 1f), lifeSpan);
        }
	}

    private void FixedUpdate()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0f && hasPlayed == false)
        {
            hasPlayed = true;
            if (CalculateDistanceFromPlayer() < threshold)
            {
                noteSound.Play();
            }
        }
        else if (lifeSpan <= 0f && lifeSpan > -1f)
        {
            if (!isShrinking)
            {
                isShrinking = true;
                this.transform.DOScale(new Vector3(0.01f, 0.01f, 1f), 0.3f);
            }
        }
        else if(lifeSpan <= -1f)
        {
            Destroy(this.gameObject);
        }
    }

    private float CalculateDistanceFromPlayer()
    {
        float dis = Vector3.Distance(this.gameObject.transform.position, FlowMusicPlayer.Instance.transform.position);
        return dis;
    }
}
