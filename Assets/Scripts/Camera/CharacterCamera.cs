using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour {
    public Transform player;
    public Vector3 Mouse_Position;
    public Vector3 mouse_world_position;

    // Update is called once per frame
    void Update () {
        Mouse_Position = Input.mousePosition;
        Mouse_Position.z = 0f;
        mouse_world_position = Camera.main.ScreenToWorldPoint(Mouse_Position);
        mouse_world_position = new Vector3(Mathf.Clamp(mouse_world_position.x - player.position.x, -25f, 25f) / 2.5f, Mathf.Clamp(mouse_world_position.y - player.position.y, -1f, 15f) / 3.5f, 0f);

        transform.position = new Vector3(player.position.x + mouse_world_position.x, player.position.y + mouse_world_position.y + 3f, -10f); // Camera follows the player with specified offset positio
        //transform.position = new Vector3(player.position.x, player.position.y + 3f, -10f); // Camera follows the player with specified offset position
    }
}
