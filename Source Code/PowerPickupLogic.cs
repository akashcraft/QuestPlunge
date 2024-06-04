using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PowerPickupLogic : MonoBehaviour
{
    public GameObject Pickup;
    public int Powertype;
    private MusicHandler musicHandler;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            GameObject.Find("SpeedPU").GetComponent<PowerLogic>().ClickedFreePU(Powertype);
            musicHandler.PlaySFX(musicHandler.ItemPickup);
            Pickup.LeanMoveLocalY(5.75f, 0.5f).setEaseInOutQuart();
            Pickup.LeanAlpha(0, 0.5f).setOnComplete(done);
        }
    }

    private void done()
    {
        Pickup.SetActive(false);
    }

    public void Reset()
    {
        Pickup.LeanAlpha(1, 0.5f);
        Pickup.SetActive(true);
    }
}
