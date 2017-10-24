﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMusicPlayer : MonoBehaviour {
    private float speed = 0.5f;

    private static FlowMusicPlayer instance = null;
    public static FlowMusicPlayer Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if(instance!= null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 v = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        transform.position += new Vector3(v.x, v.y, 0f);
    }
}
