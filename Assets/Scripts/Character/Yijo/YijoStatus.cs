using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YijoStatus : MonoBehaviour {
    static public float curr_health;
    public float max_health;
    public float health_recover_speed;
    static public float curr_mana;
    public float max_mana;
    public float mana_recover_speed;

    // Current arrow type.
    public enum Arrow_Type {Normal, Space};
    public static Arrow_Type current_Arrow;

    // Equipments: Head, Armor, Pants, Feet.
    struct Equipment
    {

    }

    // Use this for initialization
    void Start () {
        current_Arrow = Arrow_Type.Normal;
        curr_health = 100;
	}

    void Update()
    {
        HealthRecover();
        ManaRecover();
    }

    private void HealthRecover()
    {
        if (curr_health < max_health)
        {
            curr_health += health_recover_speed;
        }
    }

    private void ManaRecover()
    {
        if (curr_mana < max_mana)
        {
            curr_mana += mana_recover_speed;
        }
    }

    public void ChangeArrow(Arrow_Type arrow_type)
    {
        current_Arrow = arrow_type;
    }

    public void Damaged(float damage)
    {
        curr_health -= damage;
    }
}
