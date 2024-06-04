using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogic : MonoBehaviour
{
    MusicHandler musicHandler;
    public GameObject Key;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Key.LeanAlpha(0f, 0.5f).setOnComplete(done);
            musicHandler.PlaySFX(musicHandler.ItemPickup);
            GameObject.Find("GateCheck").GetComponent<GateLogic>().KeyGrabbed = true;            
        }
    }

    private void done()
    {
        Key.SetActive(false);
    }

    public void Reset()
    {
        Key.SetActive(true);
        Key.LeanAlpha(1f, 0.1f);
    }
}
