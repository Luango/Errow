using System.Collections;
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
      
    void Start ()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        lineRenderer.widthMultiplier = 0.5f;
        lineRenderer.positionCount = 2;

        //try 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;

        FileID = AndroidNativeAudio.load("Piano/" + keySound.name + ".wav");
        this.transform.localScale = new Vector3(0f, 0f, 1f);
        for (int i = 0; i < 12; i++)
        {
            GameObject note = Instantiate(Resources.Load("Prefabs/Note") as GameObject, transform.position, Quaternion.Euler(0f, 0f, 30 * i));
            note.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
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
        if (CalculateDistanceFromPlayer() < threshold && !isShrinking)
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, FlowMusicPlayer.Instance.transform.position);

            if (MusicStar == null)
            {
                MusicStar = Instantiate(Resources.Load("Prefabs/MusicStar") as GameObject, transform.position, Quaternion.identity); 
                //MusicStar.transform.parent = this.transform;
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
