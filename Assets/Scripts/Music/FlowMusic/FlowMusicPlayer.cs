using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

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
        transform.DOScale(8f, 0.804f).SetLoops(-1, LoopType.Yoyo);
    }
	
	// Update is called once per frame
	void Update () {

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        Vector2 v = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        transform.position += new Vector3(v.x, v.y, 0f);
        
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE 
        Touch myTouch = Input.GetTouch(0);
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        Vector2 dir = touchPos - (new Vector2(transform.position.x, transform.position.y));
        dir.Normalize();
        transform.position += new Vector3(dir.x*speed, dir.y*speed, 0f);
#endif
    }
}
