using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Keyboard : MonoBehaviour {
	public void ButtonPressed()
    {
        this.transform.DOMoveY(transform.position.y + 0.0754565f, 0.1f);
    }

    public void ButtonReleased()
    {
        this.transform.DOMoveY(transform.position.y - 0.0754565f, 0.1f);
    }
}
