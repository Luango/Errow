using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Keyboard : MonoBehaviour {
    private bool canPress = true;
    private bool completed = true;
	public void ButtonPressed()
    {
        if (canPress == true && completed == true)
        {
            completed = false;
            this.transform.DOMoveY(transform.position.y - 0.3054565f, 0.1f).OnComplete( () => {
                canPress = false;
                completed = true;
             });
        }
    }

    public void ButtonReleased()
    {
        if (canPress == false)
        {
            completed = false;
            this.transform.DOMoveY(transform.position.y + 0.3054565f, 0.1f).OnComplete( () => {
                canPress = true;
                completed = true;
            });
        }
    }
}
