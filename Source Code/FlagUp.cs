using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagUp : MonoBehaviour
{
    public GameObject Flag;
    private bool done = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !done)
        {
            Flag.LeanMoveLocalY(8, 1.0f).setEaseInOutQuart();
            done = true;
        }
    }
}
