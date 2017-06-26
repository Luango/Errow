using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YijoStatus : MonoBehaviour {
    static public float curr_health;
    public float max_health;
    public float health_recover_speed = 0f;
    public bool damaged;

    static public float curr_mana;
    public float max_mana;
    public float mana_recover_speed = 0f;
    public bool casted;

    static public int yuan;

    // Current arrow type.
    public enum Arrow_Type {Normal, Space};
    public static Arrow_Type current_Arrow;

    // Equipments: Head, Armor, Pants, Feet.
    struct Equipment
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            AddYuan();
            collision.gameObject.GetComponent<Coins>().PickedUp();
        }
    }
    // Use this for initialization
    void Awake () {
        current_Arrow = Arrow_Type.Normal;
        max_health = 100000f;
        curr_health = max_health;
        yuan = 1000;
	}

    void Update()
    {
        HealthRecover();
        ManaRecover();

        if (curr_health < 0f)
        {
            Debug.Log("SI LE");
            Destroy(this.gameObject);
        }
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
        YijoStatusUI.UpdateHealth();
    }

    // Cast speel arrow
    public void Casted(float manaCosts)
    {
        curr_mana -= manaCosts;
        YijoStatusUI.UpdateMana();
    }

    public void AddYuan()
    {
        yuan += 1;
        YijoStatusUI.UpdateYuan();
    }
}
