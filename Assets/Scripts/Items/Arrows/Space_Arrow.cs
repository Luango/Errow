using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Arrow : Normal_Arrow {
    public GameObject Yijo;

    void Start()
    {
        G = 0.05f;
        LifeSpan = 15f;
        arrow_damage = 0f;
        Yijo = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Arrow_movement();

        if (LifeSpan < 0f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            LifeSpan -= Time.deltaTime;
        }
        if (Input.GetKeyDown("space"))
        {
            TransportYijo();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.timeScale == 1.0F)
                Time.timeScale = 0.1F;
            else
                Time.timeScale = 1.0F;
        }
    }

    // Transport Yijo
    private void TransportYijo()
    {
        Yijo.transform.position = transform.position;
    }

    // Following Camera

}
