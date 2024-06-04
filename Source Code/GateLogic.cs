using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLogic : MonoBehaviour
{
    public bool KeyGrabbed = false;
    private bool playsound = true;
    public GameObject Key;
    MusicHandler musicHandler;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (KeyGrabbed)
            {
                GameObject.Find("LockedGate").LeanMoveLocalY(3.58f, 0.2f).setEaseInOutQuad();
                if (playsound)
                {
                    musicHandler.PlaySFX(musicHandler.OpenDoor);
                    playsound = false;
                }
            }
        }
    }

    public void Reset()
    {
        KeyGrabbed = false;
        GameObject.Find("LockedGate").LeanMoveLocalY(-1.51f, 0.1f);
        playsound = true;
        Key.GetComponent<KeyLogic>().Reset();
    }
}
