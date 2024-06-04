using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    public GameObject Coin;
    private TextMeshProUGUI CoinText;
    private int CoinValue;
    private bool collected = true;
    private MusicHandler musicHandler;
    void Start()
    {
        GameObject coincount = GameObject.Find("CoinCount");
        CoinText = coincount.GetComponent<TextMeshProUGUI>();
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    private void Complete()
    {
        Coin.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Coin Collected
        if (collision.CompareTag("Player") && collected)
        {
            musicHandler.PlaySFX(musicHandler.CoinCollect);
            CoinValue = int.Parse(CoinText.text);
            CoinValue = CoinValue + 1;
            CoinText.text = CoinValue.ToString();
            Coin.LeanMoveLocalY(1, 0.5f).setEaseInOutQuart();
            Coin.LeanAlpha(0, 0.5f).setOnComplete(Complete);
        }
    }
}
