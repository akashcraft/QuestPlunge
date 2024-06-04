using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderLogic : MonoBehaviour
{
    public bool LadderTrigger = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Ladder Climb
        if (collision.CompareTag("Player"))
        {
            LadderTrigger = true;
        }
    }

    void OnTriggerExit2D (Collider2D collision)
    {
        //Ladder Exit
        if (collision.CompareTag("Player"))
        {
            LadderTrigger = false;
        }
    }

}
