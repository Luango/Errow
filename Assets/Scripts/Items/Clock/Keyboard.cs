using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Keyboard : MonoBehaviour {
	public void ButtonPressed()
    {
        this.transform.DOMoveY(0.05f, 0.1f);
    }

    public void ButtonReleased()
    {
        this.transform.DOMoveY(0.4754565f, 0.1f);
    }
}
