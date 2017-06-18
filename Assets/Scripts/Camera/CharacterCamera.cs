using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour {
    public Transform player;
    public Vector3 Mouse_Position;
    public Vector3 mouse_world_position;
    public Vector3 difference;
    private float tracking_time;

    // Update is called once per frame
    void Update () {
        Mouse_Position = Input.mousePosition;
        Mouse_Position.z = 0f;
        mouse_world_position = Camera.main.ScreenToWorldPoint(Mouse_Position);
        mouse_world_position = new Vector3(Mathf.Clamp(mouse_world_position.x - player.position.x, -25f, 25f) / 2.5f, Mathf.Clamp(mouse_world_position.y - player.position.y, -15f, 15f) / 2.5f, 0f);
        
        Vector3 target = new Vector3(player.position.x + mouse_world_position.x, player.position.y + mouse_world_position.y, -10f);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime*700f);
    }
}
