using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class YijoStatusUI : MonoBehaviour {
    public GameObject health;
    public GameObject mana;
    private bool damaged;
    private bool casted; // Shot special arrow

	// Use this for initialization
	void Start () {
        damaged = false;
        Text manaText = mana.GetComponent<Text>();
        manaText.text += YijoStatus.curr_mana;
        Text healthText = health.GetComponent<Text>();
        healthText.text += YijoStatus.curr_health;
    }
	
	// Update is called once per frame
	void Update () {
        if (damaged)
        {
            Text healthText = health.GetComponent<Text>();
            healthText.text += YijoStatus.curr_health;
        }

        if (casted)
        {
            Text manaText = mana.GetComponent<Text>();
            manaText.text += YijoStatus.curr_mana;

        }

        damaged = false;
        casted = false;
	}
}
