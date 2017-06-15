using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Arrow : Normal_Arrow {
    private void Start()
    {
        LifeSpan = 15f;
        arrow_damage = 0f;
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
    }
}
