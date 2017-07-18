using UnityEngine;
using System.Collections;

public class ArmTrigger : MonoBehaviour {

    public Transform home;


    void OnTriggerStay2D(Collider2D other)
    {
        if(other)
            transform.FindChild("target").position = Vector2.Lerp(transform.FindChild("target").position, other.transform.position,.1f);
        else
            transform.FindChild("target").position = Vector2.Lerp(transform.FindChild("target").position, home.position, .1f);
    }
    
    void Update()
    {
      
    }




}
