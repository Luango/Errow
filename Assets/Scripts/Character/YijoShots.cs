using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YijoShots : MonoBehaviour {
    struct init_arrow
    {
        public Vector3 Yijo_Position;
        public Vector3 MouseRelease_Position;
        public Vector3 velocity;
    }
    private init_arrow _Arrow;
    private float arrow_ini_speed = 5.0f;
    public GameObject a_test_arrow;

    private void Awake()
    {
        _Arrow.Yijo_Position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire1"))
        {
            // Yijo position
            _Arrow.Yijo_Position = transform.position + new Vector3(0f, 2.5f, 0f);

            // Mouse released position
            _Arrow.MouseRelease_Position = Input.mousePosition;
            _Arrow.MouseRelease_Position.z = 0f;
            _Arrow.MouseRelease_Position = Camera.main.ScreenToWorldPoint(_Arrow.MouseRelease_Position);

            // Normalized velocity to hit the point.
            float orientation = calculate_orientation(_Arrow.MouseRelease_Position.x - _Arrow.Yijo_Position.x, 
                _Arrow.MouseRelease_Position.y - _Arrow.Yijo_Position.y, arrow_ini_speed, 0.39f);
            _Arrow.velocity = new Vector3(Mathf.Cos(orientation), Mathf.Sin(orientation), 0f);
            
            GameObject an_arrow = Instantiate(a_test_arrow, _Arrow.Yijo_Position, Quaternion.Euler(new Vector3(0f, 0f, orientation * 180f / Mathf.PI))) as GameObject;
            an_arrow.GetComponent<Normal_Arrow>().velocity = _Arrow.velocity * arrow_ini_speed;
        }
    }

    // Hit the clicking point
    private float calculate_orientation(float x, float y, float v, float G)
    {
        float a = (y * y + x * x);
        float b = (y * G * x * x) / (v * v) - x * x; // G=0 ==> - x * x
        float c = (Mathf.Pow(x,4) * Mathf.Pow(G, 2)) / (4 * Mathf.Pow(v, 4)); // G=0 ==> c=0

        // Calculate the roots (-b+sqrt(b^2-fac))/2a 
        float cos_sq_1 = (-b + Mathf.Sqrt(Mathf.Pow(b, 2) - 4 * a * c)) / (2 * a);
        
        float orientation = Mathf.Acos(Mathf.Sqrt(cos_sq_1));
        orientation = orientation * 180f / Mathf.PI;

        float y_threshold = -(x * x * G) / (arrow_ini_speed * arrow_ini_speed * 2);

        // if y < 0 y > y'
        if (x >= 0)
        {
            if (y < 0 && y < y_threshold)
            {
                orientation = -orientation;
            }
        } else
        {
            if (y < 0 && y < y_threshold)
            {
                orientation = -180f + orientation;
            } else
            {
                orientation = 180f - orientation;
            }
        }
        orientation = orientation * Mathf.PI / 180f;

        return orientation;
    }
}
