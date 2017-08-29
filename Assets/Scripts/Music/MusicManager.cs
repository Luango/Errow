using UnityEngine;
using System.IO;
using System.Collections;

// Create music notes on the musical cylinder from sheet music
public class MusicManager : MonoBehaviour {
	public TextAsset sheetMusic; 
	public GameObject musicNoteGameObject;

	void Start () {
		readSheetCreateNotes ();
	}

	void readSheetCreateNotes() { 
		string[] linesInFile = sheetMusic.text.Split('\n');
		int lineNo = 0;
		foreach (string line in linesInFile)
		{
			Vector3 position = calculateNotePosition(lineNo);

			string[] notesInLine = line.Split (new char[0]);
			foreach (string note in notesInLine) {
				createMusicNote (note, position);
			}
			lineNo++;
		}
	}

	void createMusicNote(string noteName, Vector3 position){
		// find the gameobj with the note name
		GameObject musicNote = GameObject.Find(noteName);
		if (musicNote != null&&musicNote.tag != "MusicPlanet") {
			GameObject musicCylinder = musicNote.transform.Find ("musicCylinder").gameObject;
			// create a note on that position (on cylinder)
			if (musicCylinder != null) {
				Vector3 musicNotePosition = musicCylinder.transform.position + position;
				GameObject newNote = (GameObject)Instantiate (musicNoteGameObject, musicNotePosition, Quaternion.identity);
				newNote.transform.parent = musicCylinder.transform;
			}
		}
	}

	// Calculate nth note's position on the cylinder
	Vector3 calculateNotePosition(int n){
		Vector3 position;
		const float radius = 0.5f;
		float x = 0f;
		float y = 0f;
		float z = 0f; 
		const float deltaTheta = 3.0f / 360f;
		float startPosition;
		startPosition = 1050;

		y = radius * Mathf.Sin (startPosition / 360f - n * deltaTheta);
		z = radius * Mathf.Cos (startPosition / 360f - n * deltaTheta);
		position = new Vector3 (x, y, z);

		return position;
	}
}
