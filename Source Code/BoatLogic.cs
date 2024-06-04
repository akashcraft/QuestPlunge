using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatLogic : MonoBehaviour
{
    private MusicHandler musicHandler;
    public bool done = false;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !done)
        {
            done = true;
            musicHandler.PlaySFX(musicHandler.Boat);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            GameObject.Find("Boat").GetComponent<Animator>().SetTrigger("Move");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            GameObject.Find("Boat").GetComponent<Animator>().ResetTrigger("Move");
        }
    }
}
