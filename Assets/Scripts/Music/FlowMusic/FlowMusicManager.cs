using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMusicManager : MonoBehaviour { 
    public TextAsset sheetMusic;
    private float deltaTime;
    public float DeltaTime;
    //public GameObject musicNoteGameObject;
    private string[] linesInFile;
    private int lineNo = 0;

    private static FlowMusicManager instance = null;
    public static FlowMusicManager Instance
    {
        get
        {
            return instance;
        }
    }
     
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        if(sheetMusic != null)
        {
            linesInFile = sheetMusic.text.Split('\n');
        }
        else
        {
            print("No sheet music!");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    //    deltaTime -= Time.deltaTime;
	}

    private void FixedUpdate()
    {
        deltaTime -= Time.deltaTime;  
        if(deltaTime < 0f)
        {
            if (lineNo < linesInFile.Length)
            { 
                deltaTime = DeltaTime;
                string[] notesInLine = linesInFile[lineNo].Split(new char[0]);

                foreach (string note in notesInLine)
                {
                    GameObject musicNote = GameObject.Find(note);
                    if (musicNote != null)
                    {
                        print(musicNote);
                        GameObject noteObj = (GameObject)Instantiate(musicNote, FlowMusicPlayer.Instance.transform.position + new Vector3(Random.Range(-3f, 15f) + 6f, Random.Range(-10f, 10f), 0f), Quaternion.identity);
                        noteObj.GetComponent<AudioSource>().enabled = true;
                        noteObj.GetComponent<SpriteRenderer>().enabled = true;
                        noteObj.GetComponent<FlowMusicNote>().enabled = true;
                    }
                }
            }
            lineNo++;
        }
    }

    void NextLine()
    {

    }

    void ReadSheetCreateNotes()
    {
        string[] linesInFile = sheetMusic.text.Split('\n');
        int lineNo = 0;
        foreach (string line in linesInFile)
        {
            string[] notesInLine = line.Split(new char[0]);

            foreach (string note in notesInLine)
            { 

            }
            lineNo++;
        }
    }

    void CreateMusicNote(string noteName, int lineNo)
    {
        GameObject musicNote = GameObject.Find(noteName);

        if (musicNote != null)
        { 

        }
    }
}
