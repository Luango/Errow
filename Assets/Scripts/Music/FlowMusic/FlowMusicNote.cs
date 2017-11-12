using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlowMusicNote : MonoBehaviour {
    private Vector3 iniPosition;

    private float lifeSpan = 3.0f;
    private string noteName;
    private float stepSize;
    private float threshold = 20f;
    private List<GameObject> Notes;

    private AudioSource noteSound;
    public AudioClip keySound;
    private bool hasPlayed = false;
    private bool isShrinking = false;
    private int FileID;
    private int SoundID;

    // Use this for initialization
    private void Awake()
    {
        FileID = AndroidNativeAudio.load("Piano/" + keySound.name + ".wav");
    }
    void Start ()
    {
        //noteSound = gameObject.GetComponent<AudioSource>();
        //noteSound.clip = keySound;
        this.transform.localScale = new Vector3(0f, 0f, 1f);
        for (int i = 0; i < 12; i++)
        {
            GameObject note = Instantiate(Resources.Load("Prefabs/Note") as GameObject, transform.position, Quaternion.Euler(0f, 0f, 30 * i));
            note.transform.parent = transform;
            note.GetComponent<NoteIndicator>().LifeSpan = i * 0.25f + 0.25f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!isShrinking)
        {
            this.transform.DOScale(new Vector3(4.30f, 4.30f, 1f), lifeSpan);
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
            }
        }
        else if (lifeSpan <= 0f && lifeSpan > -1f)
        {
            if (!isShrinking)
            {
                isShrinking = true;
                this.transform.DOScale(new Vector3(0.0f, 0.0f, 1f), 0.3f);
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
