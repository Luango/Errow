using UnityEngine;
using System.Collections;

public class SoundBar : MonoBehaviour {
	public AudioSource note;
	public GameObject hitParticle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "MusicNote") {
			if (this.tag == "PlanetMusicBar"&&other.gameObject.GetComponent<MusicNote>().isActive==true) {
				GameObject newHitParticle = (GameObject)Instantiate (hitParticle, other.transform.position, Quaternion.identity);
				Destroy (newHitParticle, 3f);
			}
			if (other.transform.gameObject.GetComponent<MusicNote> ().isActive) {
				note.Play ();
			}
		}
	}
}
