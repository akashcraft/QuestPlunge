using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y+2, transform.position.z);
        }
    }
}
