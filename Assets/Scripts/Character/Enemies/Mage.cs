﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour {
    public Animator _anim_mage;
    public GameObject _Yijo;

    private float shoot_frequency = 3.0f;
    private float attack_range = 30f;
    public GameObject _test_Arrow;
    private Vector3 target_position;
    public Transform shot_position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Movement (No movement)

        // Attack Yijo
        // calculate the distance
        float _distanceToYijo = Vector3.Distance(shot_position.position, _Yijo.transform.position);
        shoot_frequency -= Time.deltaTime;
        if (_distanceToYijo<attack_range&&shoot_frequency<0f)
        {
            // Attack
            target_position = _Yijo.transform.position + new Vector3(0f, 2.5f, 0f);
            Attack_Yijo(target_position);
            shoot_frequency = 3.0f;
        }

        // Hitted
        

        // Die
	}

    private void Attack_Yijo(Vector3 _Yijo_poisition)
    {
        // Instantiate a Magic ball
        Vector3 direction = _Yijo_poisition - shot_position.position;
        direction = direction.normalized;

        GameObject an_arrow = Instantiate(_test_Arrow, shot_position.position, Quaternion.identity) as GameObject;
        float orientation = an_arrow.GetComponent<Normal_Arrow>().Arrow_init_orientation(_Yijo_poisition.x - shot_position.position.x,
        _Yijo_poisition.y - shot_position.position.y, 5.0f, 0.31f);
        Vector3 velocity = new Vector3(Mathf.Cos(orientation), Mathf.Sin(orientation), 0f);

        an_arrow.GetComponent<Normal_Arrow>().velocity = direction * 5.0f; // 5.0f is the speed
    }
}
