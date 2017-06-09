using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Arrow : MonoBehaviour {
    [HideInInspector]
    public Vector3 velocity;
     
    private float G = 0.05f; // Gravity
    private float LifeSpan = 3f;

	// Use this for initialization
	void Start () {
        // Calculate initial speed 
	}
	
	// Update is called once per frame
	void Update ()
    {
        arrow_movement();

        // Destroy
        if (LifeSpan < 0f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            LifeSpan -= Time.deltaTime;
        }
    }

    // Arrow movement: direction --> click position
    private void arrow_movement()
    {
        // Gravity
        velocity.y -= G;
        // Dot product of Velocity and (1, 0, 0) to calculate the angle
        float dot_Result = Vector3.Dot(velocity.normalized, new Vector3(1f, 0f, 0f));
        // Orientation is always largern than 0
        float orientation = Mathf.Acos(dot_Result);
        if (velocity.y < 0f) { orientation = -orientation; }
        //Debug.Log("velocity = " + velocity);

        // Update arrow's position and orientation
        transform.position += velocity * Time.deltaTime * 10f;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, orientation * 180f / Mathf.PI));
    }
}
