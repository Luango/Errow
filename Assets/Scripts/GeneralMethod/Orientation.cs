using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOrientation : MonoBehaviour
{
    // Calculate the initial orientation to make arrow hit the clicked point.
    // delta_x = clicked_xPos - current_character_xPos
    // delta_y = clicked_yPos - current_character_yPos
    // v = speed
    // G = gravity
    public float Arrow_init_orientation(float delta_x, float delta_y, float v, float G)
    {
        float a = (delta_y * delta_y + delta_x * delta_x);
        float b = (delta_y * G * delta_x * delta_x) / (v * v) - delta_x * delta_x;
        float c = (Mathf.Pow(delta_x, 4) * Mathf.Pow(G, 2)) / (4 * Mathf.Pow(v, 4));

        // Calculate the roots (-b+sqrt(b^2-fac))/2a 
        float cos_sq_1 = (-b + Mathf.Sqrt(Mathf.Pow(b, 2) - 4 * a * c)) / (2 * a);

        float orientation = Mathf.Acos(Mathf.Sqrt(cos_sq_1));
        orientation = orientation * 180f / Mathf.PI;

        float y_threshold = -(delta_x * delta_x * G) / (3.3f * 3.3f * 2);

        // if delta_y < 0 delta_y > delta_y'
        if (delta_x >= 0)
        {
            if (delta_y < 0 && delta_y < y_threshold)
            {
                orientation = -orientation;
            }
        }
        else
        {
            if (delta_y < 0 && delta_y < y_threshold)
            {
                orientation = -180f + orientation;
            }
            else
            {
                orientation = 180f - orientation;
            }
        }
        orientation = orientation * Mathf.PI / 180f;

        return orientation;
    }
}
