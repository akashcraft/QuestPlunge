using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallLogic : MonoBehaviour
{

    private MusicHandler musicHandler;
    public bool playonce = true;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            if (playonce)
            {
                musicHandler.PlaySFX(musicHandler.BossHurt);
                playonce = false;
            }
            GameObject.Find("Boss").GetComponent<SpikeLogic>().HoldHits -= 1;
            
        }
    }
}
