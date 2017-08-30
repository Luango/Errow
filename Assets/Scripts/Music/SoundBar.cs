using UnityEngine;
using System.Collections;

public class SoundBar : MonoBehaviour {
	public AudioSource note;
	public GameObject hitParticle;

	void OnTriggerEnter2D(Collider2D other)
    {
        print("Music Note Outside");
        if (other.transform.tag == "MusicNote")
        {
            print("Music Note");
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
