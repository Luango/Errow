using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour {
    private List<Transform> StoryNotes = new List<Transform>();
    private int Index = 0;
    private float deltaTime = 0.3f;

    private static StoryManager instance = null;
    public static StoryManager Instance
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

        foreach (Transform child in transform)
        {
            print(child);
            StoryNotes.Add(child);
            child.gameObject.SetActive(false);
        }
    }
    
	// Update is called once per frame
	void Update () {
        deltaTime -= Time.deltaTime;
        if (FlowMusicManager.Instance != null && deltaTime<0f)
        {
            if (Index < StoryNotes.Count && FlowMusicManager.Instance.lineNo % 25 == 0)
            {
                StoryNotes[Index].gameObject.SetActive(true);
                StoryNotes[Index].position = FlowMusicPlayer.Instance.StoryTransform.position;
                Index++;
            }
            deltaTime = 0.3f;
        }
	}
}
