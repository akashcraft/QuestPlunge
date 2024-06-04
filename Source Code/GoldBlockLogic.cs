using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBlockLogic : MonoBehaviour
{
    public GameObject Pickup;
    private MusicHandler musicHandler;
    private bool Complete = false;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Complete)
        {
            Complete = true;
            Pickup.LeanMoveLocalY(2.7f, 0.3f).setEaseInOutQuad();
            musicHandler.PlaySFX(musicHandler.MarioGoldBlock);
        }
    }

    public void Reset()
    {
        Pickup.LeanMoveLocalY(0.05f, 0.1f);
        Pickup.LeanAlpha(1, 0.1f);
        Complete = false;
        Pickup.GetComponent<PowerPickupLogic>().Reset();
    }
}
