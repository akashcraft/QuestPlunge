using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerLogic : MonoBehaviour
{
    public bool repeat;
    private bool done = false;
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!repeat)
            {
                if (!done)
                {
                    playsound();
                    done = true;
                }
            } else
            {
                playsound();
            }
        }
    }

    private void playsound()
    {
        MusicHandler musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
        musicHandler.PlaySFX(sound);
    }
}
