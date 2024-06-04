using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLogic : MonoBehaviour
{
    private bool allowfire = true;
    private MusicHandler musicHandler;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (allowfire && collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            allowfire = false;
            GameObject.Find("CannonBall").GetComponent<Animator>().SetTrigger("Fire");
            GameObject.Find("CannonBall").GetComponent<CannonBallLogic>().playonce = true;
            musicHandler.PlaySFX(musicHandler.CannonFire);
            Invoke("Refill", 0.5f);
        }
    }

    private void Refill()
    {
        allowfire = true;
    }
}
