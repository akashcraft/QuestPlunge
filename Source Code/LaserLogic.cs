using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    public SpikeLogic spikeLogic;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SecurityCameraOff");
        spikeLogic.DamageValue = 0f;
        Invoke("ActivateLaser", 2f);
        Invoke("Start", 10f);
    }

    private void ActivateLaser()
    {
        spikeLogic.DamageValue = 3.0f;
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SecurityCamera");
    }
}
