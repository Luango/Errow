﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteIndicator : MonoBehaviour {
    public float LifeSpan; 
	
	// Update is called once per frame
	void Update () {
        LifeSpan -= Time.deltaTime;
        print("Life Span : " + LifeSpan);
        if (LifeSpan <= 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
