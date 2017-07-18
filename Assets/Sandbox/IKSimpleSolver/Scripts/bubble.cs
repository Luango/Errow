using UnityEngine;
using System.Collections;

public class bubble : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject.Destroy(gameObject);
    }

}
