using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;

// Create music notes on the musical cylinder from sheet music
public class MusicManager : MonoBehaviour {
	public TextAsset sheetMusic; 
	public GameObject musicNoteGameObject;
    public float deltaTheta;
    public float startPosition;
    public float rotationSpeed;

    public List<MusicGroup> MusicGroups; 
     
    void Start () {
		ReadSheetCreateNotes ();
	}

	void ReadSheetCreateNotes() { 
		string[] linesInFile = sheetMusic.text.Split('\n');
		int lineNo = 0;
		foreach (string line in linesInFile)
		{
			string[] notesInLine = line.Split (new char[0]);

			foreach (string note in notesInLine) {
				CreateMusicNote (note, lineNo);
			}
			lineNo++;
		}
	}

    // Needs: 1. Which group, group has same center? 2. Which note? 3. What's radius? 
	void CreateMusicNote(string noteName, int lineNo){
		GameObject musicNote = GameObject.Find(noteName);
        /*
        if (musicNote != null)
        {
            print(musicNote);
            GameObject parentGroup = (GameObject)musicNote.transform.parent.gameObject;
            print(parentGroup);

            Vector3 musicNotePosition = parentGroup.transform.position + position;
            GameObject newNote = (GameObject)Instantiate(musicNoteGameObject, musicNotePosition, Quaternion.identity);
            newNote.transform.parent = parentGroup.transform;
        }*/
        
        if (musicNote != null)
        {
            //float radius = musicNote.GetComponent<>

            GameObject musicCylinder = musicNote.transform.Find ("musicCylinder").gameObject;
            float radius = musicCylinder.GetComponent<MusicBoxMain>().radius;
            Vector3 position = CalculateNotePosition(lineNo, radius);
            if (musicCylinder != null) {
				Vector3 musicNotePosition = musicCylinder.transform.position + position;
				GameObject newNote = (GameObject)Instantiate (musicNoteGameObject, musicNotePosition, Quaternion.identity);
				newNote.transform.parent = musicCylinder.transform;
			}
		}
    }
    
	Vector3 CalculateNotePosition(int n, float radius){
		Vector3 position;
		float x = 0f;
		float y = 0f;
		float z = 0f; 

		y = radius * Mathf.Cos (startPosition / 360f - n * deltaTheta);
		x = radius * Mathf.Sin (startPosition / 360f - n * deltaTheta);
		position = new Vector3 (x, y, z);

		return position;
	}
}
