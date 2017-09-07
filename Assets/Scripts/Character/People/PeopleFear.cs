using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PeopleFear : MonoBehaviour {
    private bool trembled = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!trembled)
        {
            trembled = true;
            Trembling();
        }	
	}

    private void Trembling()
    {
        this.transform.DOShakeScale(5f, 0.1f, 10, 90f, true);
    }

}
