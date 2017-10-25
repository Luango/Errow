using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMusicManager : MonoBehaviour { 
    public TextAsset sheetMusic;
    public float DeltaTime;
    private float deltaTime;
    private string[] linesInFile;
    private int lineNo = 0;
    private Vector3 prePos;
    private int stepsCount;
    private float stepSize = 0.05f;
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
        prePos = FlowMusicPlayer.Instance.transform.position + new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0f);
        stepsCount = 0;
    }

    private void FixedUpdate()
    {
        deltaTime -= Time.deltaTime;  
        if(deltaTime < 0f)
        {
            print(lineNo);
            if (lineNo < linesInFile.Length)
            {
                
                deltaTime = DeltaTime;
                string[] notesInLine = linesInFile[lineNo].Split(new char[0]);

                foreach (string note in notesInLine)
                {
                    GameObject musicNote = GameObject.Find(note);
                    if (stepsCount < 30)
                    {
                        stepsCount++;
                    }
                    if (musicNote != null)
                    {
                        print(musicNote);
                        Vector3 newPos = prePos + new Vector3(Random.Range(-8f, 8f)*stepSize*stepsCount, Random.Range(-8f, 8f) * stepSize * stepsCount, 0f);
                        GameObject noteObj = (GameObject)Instantiate(musicNote, newPos, Quaternion.identity);
                        noteObj.GetComponent<AudioSource>().enabled = true;
                        noteObj.GetComponent<SpriteRenderer>().enabled = true;
                        noteObj.GetComponent<FlowMusicNote>().enabled = true;
                        prePos = newPos;
                        stepsCount = 0;
                    }
                }
            }
            lineNo++;
        }
    }

    void ReadSheetCreateNotes()
    {
        string[] linesInFile = sheetMusic.text.Split('\n');
        int lineNo = 0;
        foreach (string line in linesInFile)
        {
            string[] notesInLine = line.Split(new char[0]);       
            lineNo++;
        }
    }
}
