using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LevelTrigger : MonoBehaviour
{
    public int LevelNumber;
    private MusicHandler musicHandler;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            musicHandler.StopSFX();
            GameObject.Find("LevelHandler").GetComponent<LoadLevel>().Load(LevelNumber);
            GameObject.Find("Player").transform.position = new Vector3(0f, -3.58f, -2f);
        }
    }
}
