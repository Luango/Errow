using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Arrow : Normal_Arrow {
    public GameObject Yijo;

    private float time_slowed_period = 0f;

    void Start()
    {
        G = 0.05f;
        LifeSpan = 15f;
        arrow_damage = 1f;
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
            // Send Yijo to current space_arrow position.
            TransportYijo();
            // Slow time for 2 seconds.
            time_slowed_period = 1.5f;
        }
        if (time_slowed_period > 0f)
        {
            Time.timeScale = 0.1f;
            time_slowed_period -= Time.deltaTime*10f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    // Transport Yijo
    private void TransportYijo()
    {
        Yijo.transform.position = transform.position;
    }

    // Following Camera

}
