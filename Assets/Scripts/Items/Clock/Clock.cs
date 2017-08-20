using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Clock : MonoBehaviour {
    private Transform MinutesPointer;
    private Transform HoursPointer;

    private void Awake()
    {
        if(MinutesPointer == null) MinutesPointer = this.transform.Find("MinutesPointer"); 
        if(HoursPointer == null) HoursPointer = this.transform.Find("HoursPointer");
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void RandomTime()
    {
        float RandomMin = Random.Range(-180f, 180f);
        float RandomHour = Random.Range(-180f, 180f);

        MinutesPointer.DORotate(new Vector3(0f, 0f, RandomMin), Random.Range(2f, 5f));
        HoursPointer.DORotate(new Vector3(0f, 0f, RandomHour), Random.Range(2f, 5f));
    }
}
