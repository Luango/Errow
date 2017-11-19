using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MusicStar : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Vector3 size = transform.localScale;
        transform.localScale = new Vector3(0f, 0f, 0f);
        transform.DOScale(size, 1f);
	}
    
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime*100f);
    }
}
