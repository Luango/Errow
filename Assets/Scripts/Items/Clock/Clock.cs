using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Clock : MonoBehaviour {
    public GameObject EducationBullet;
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
        
        MinutesPointer.DORotate(new Vector3(0f, 0f, RandomMin), Random.Range(0.2f, 0.5f)).OnComplete(()=>
        {
            // Shoot dead line bullet.
            print("Rotate Completed");
            Transform MinTop = transform.Find("MinutesPointer/MinTop");

            if (EducationBullet != null) {
                GameObject bullet = Instantiate(EducationBullet, MinTop.position, Quaternion.Euler(0f, 0f, RandomMin));
            }

        });
        HoursPointer.DORotate(new Vector3(0f, 0f, RandomHour), Random.Range(0.2f, 0.5f)).OnComplete(()=>
        {
            // Shoot dead line bullet.
            print("Rotate Completed");
            Transform HourTop = transform.Find("HoursPointer/HourTop");
            if (EducationBullet != null)
            {
                GameObject bullet = Instantiate(EducationBullet, HourTop.position, Quaternion.Euler(0f, 0f, RandomHour));
            }
        });
    }
}
