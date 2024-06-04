using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLogic : MonoBehaviour
{
    public float portalx;
    public float portaly;
    private MusicHandler musicHandler;
    public AudioClip PortalSound;
    public bool FlintGrabbed = false;
    public GameObject Flint;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && FlintGrabbed)
        {
            GameObject.Find("Player").transform.position = new Vector3(portalx, portaly, -2f);
            musicHandler.PlaySFX(PortalSound);
        }
    }

    public void OpenPortal()
    {
        FlintGrabbed = true;
        GameObject.Find("NetherPortal").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("NetherPortal");
    }
    public void ClosePortal()
    {
        FlintGrabbed = false;
        Flint.GetComponent<FlintLogic>().Reset();
        GameObject.Find("NetherPortal").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("NetherPortalNotLit");
    }
}
