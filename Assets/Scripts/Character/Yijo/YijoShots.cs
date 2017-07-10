using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YijoShots : MonoBehaviour {
    struct Arrow
    {
        public Vector3 Yijo_Position;
        public Vector3 MouseRelease_Position;
        public Vector3 velocity;
    }
    private Arrow _Arrow;
    private float arrow_ini_speed = 8.0f;
    public GameObject a_test_arrow;

    public Transform shootingPosition;

    // Add the arrow to the render plane
    public GameObject Fluid_Plane;

    private void Awake()
    {
        _Arrow.Yijo_Position = shootingPosition.position;
    }
	
	// Update is called once per frame
	void Update () {
        // Shot the arrow
        if (Input.GetButtonUp("Fire1") && ArrowManager.Space_Arrow_Num > 0)
        {

            ArrowManager.Space_Arrow_Num--;
            // Yijo position
            _Arrow.Yijo_Position = shootingPosition.position;

            // Mouse released position
            _Arrow.MouseRelease_Position = Input.mousePosition;
            _Arrow.MouseRelease_Position.z = 0f;
            _Arrow.MouseRelease_Position = Camera.main.ScreenToWorldPoint(_Arrow.MouseRelease_Position);

            GameObject an_arrow = Instantiate(a_test_arrow, _Arrow.Yijo_Position, Quaternion.identity) as GameObject;
            float orientation = an_arrow.GetComponent<Normal_Arrow>().Arrow_init_orientation(_Arrow.MouseRelease_Position.x - _Arrow.Yijo_Position.x,
            _Arrow.MouseRelease_Position.y - _Arrow.Yijo_Position.y, arrow_ini_speed, 0.31f);
            _Arrow.velocity = new Vector3(Mathf.Cos(orientation), Mathf.Sin(orientation), 0f);
            an_arrow.GetComponent<Normal_Arrow>().velocity = _Arrow.velocity * arrow_ini_speed;
            an_arrow.GetComponent<Normal_Arrow>().shooter = transform.gameObject;

            if (Fluid_Plane != null)
            {
                Fluid_Plane.GetComponent<FluidSimulator>().AddArrow(an_arrow);
            }
        }
    }
}
