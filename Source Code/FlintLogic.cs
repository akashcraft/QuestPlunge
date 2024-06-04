using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintLogic : MonoBehaviour
{
    MusicHandler musicHandler;
    public GameObject Flint;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Flint.LeanAlpha(0f, 0.5f).setOnComplete(done);
            musicHandler.PlaySFX(musicHandler.ItemPickup);
            GameObject.Find("NetherPortal").GetComponent <PortalLogic>().OpenPortal();

        }
    }
    private void done()
    {
        Flint.SetActive(false);
    }

    public void Reset()
    {
        Flint.SetActive(true);
        Flint.LeanAlpha(1f, 0.1f);
    }
}
