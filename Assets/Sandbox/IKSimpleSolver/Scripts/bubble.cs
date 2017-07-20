using UnityEngine;
using System.Collections;

public class bubble : MonoBehaviour {
    private float lifeSpan = 2f;
    private void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0f)
        {
            Destroy(gameObject);
        }
    }
}
