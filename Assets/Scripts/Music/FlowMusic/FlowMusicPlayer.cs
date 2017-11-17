﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class FlowMusicPlayer : MonoBehaviour {
    private float speed = 100f;

    private static FlowMusicPlayer instance = null;
    private Rigidbody2D body;

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
        //transform.DOScale(9.5f, 0.804f).SetLoops(-1, LoopType.Yoyo);
        body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Vector2 v = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*2f);
            body.AddForce(v * speed, ForceMode2D.Force);
        }
          
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        // use accleration control 
        Vector2 v2 = new Vector2(Input.acceleration.x, Input.acceleration.y); 
        body.AddForce(v2 * speed * 5f, ForceMode2D.Force);

        float angle = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2f);
#endif
    }
}
