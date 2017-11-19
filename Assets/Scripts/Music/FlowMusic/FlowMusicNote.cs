﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlowMusicNote : MonoBehaviour {  
    protected float lifeSpan = 3.0f;  
    private float threshold = 20f; 
    
    public AudioClip keySound;
    private bool hasPlayed = false;
    private bool isShrinking = false;
    private int FileID;
    private int SoundID;
    private Color c1 = Color.black;
    private Color c2 = Color.white;
    private GameObject MusicStar;
    private float TimeNoteSpawn = -0.1f;
    private List<GameObject> Notes = new List<GameObject>();
    private int NoteNum = 0;
    private float iniNoteOrientation;
      
    void Start ()
    {
        iniNoteOrientation = Random.Range(-180f,180f);

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        lineRenderer.widthMultiplier = 0.5f;
        lineRenderer.positionCount = 2;

        transform.localScale = new Vector3(4.3f, 4.3f, 1f);

        //try 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;

        FileID = AndroidNativeAudio.load("Piano/" + keySound.name + ".wav"); 
    }
	
	// Update is called once per frame
	void Update () {
        TimeNoteSpawn -= Time.deltaTime;
        if(TimeNoteSpawn<0 && NoteNum < 12)
        { 
            GameObject note = Instantiate(Resources.Load("Prefabs/Note") as GameObject, transform.position, Quaternion.Euler(0f, 0f, 30 * NoteNum + iniNoteOrientation));
            note.transform.localScale = new Vector3(2.7f, 2.7f, 2.7f);
            note.transform.parent = transform;
            note.GetComponent<NoteIndicator>().LifeSpan =  3f - NoteNum * 0.25f;
            Notes.Add(note);

            NoteNum++;
            TimeNoteSpawn = 0.25f;
        }

        if (!isShrinking)
        {
            //this.transform.DOScale(new Vector3(4.30f, 4.30f, 1f), lifeSpan);
        } 
        if (CalculateDistanceFromPlayer() < threshold && !isShrinking)
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, FlowMusicPlayer.Instance.transform.position);

            if (MusicStar == null)
            {
                MusicStar = Instantiate(Resources.Load("Prefabs/MusicStar") as GameObject, transform.position, Quaternion.identity);
            }
        }
        else
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.enabled = false; 
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
                SoundID = AndroidNativeAudio.play(FileID);
                if (transform.parent != null)
                {
                    GameObject tutorialManager = transform.parent.gameObject;
                    if (tutorialManager.GetComponent<TutorialNoteManager>() != null)
                    {
                        tutorialManager.GetComponent<TutorialNoteManager>().isChecked = true;
                    }
                }
            }
        }
        else if (lifeSpan <= 0f && lifeSpan > -1f)
        {
            if (!isShrinking)
            {

                if (CalculateDistanceFromPlayer() < threshold)
                {
                    if (Notes.Count > 0)
                    {
                        foreach (GameObject aNote in Notes)
                        {
                            aNote.transform.DOScale(new Vector3(0f, 0f, 0f), 1f);
                            aNote.transform.DOMove(aNote.transform.up * 100f + transform.position, 1f).OnComplete(() =>
                            {
                                Destroy(aNote);
                            });
                        }
                    }
                }
                else
                {
                    isShrinking = true;
                    this.transform.DOScale(new Vector3(0.0f, 0.0f, 1f), 1f);
                }
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
