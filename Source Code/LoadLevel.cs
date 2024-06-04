using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LoadLevel : MonoBehaviour
{
    private MusicHandler musicHandler;
    public GameObject InGameText; //InGame Text
    public GameObject Player;
    public GameObject levelSelect;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;
    public GameObject Level5;
    public GameObject Level6;
    public GameObject Level7;
    public GameObject Boss;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    private void HideAll()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Level4.SetActive(false);
        Level5.SetActive(false);
        Level6.SetActive(false);
        Level7.SetActive(false);
    }
    public void Load(int level)
    {
        levelSelect.SetActive(false);
        HideAll();
        if (level == 1)
        {
            Level1.SetActive(true);
            musicHandler.PlayBGM(musicHandler.BGM1);
        } else if (level == 2)
        {
            Level2.SetActive(true);
            musicHandler.PlayBGM(musicHandler.BGM2);
        }
        else if (level == 3)
        {
            Level3.SetActive(true);
            musicHandler.PlayBGM(musicHandler.BGM3);
        }
        else if (level == 4)
        {
            Level4.SetActive(true);
            musicHandler.PlayBGM(musicHandler.BGM4);
        }
        else if (level == 5)
        {
            Level5.SetActive(true);
            musicHandler.PlayBGM(musicHandler.BGM5);
        }
        else if (level == 6)
        {
            Level6.SetActive(true);
            musicHandler.PlayBGM(musicHandler.BGM6);
            Boss.SetActive(true);
            Boss.GetComponent<BossLogic>().Start();
        }
        else if (level == 7)
        {
            Level7.SetActive(true);
            musicHandler.PlayBGM(musicHandler.BGM7);
            musicHandler.PlaySFX(musicHandler.AmongUs);
        }
        Player.SetActive(true);
        InGameText.SetActive(true);
        if (level == 7)
        {
            level = 6;
        }
        PlayerPrefs.SetInt("GameLevel", level);
        PlayerPrefs.Save();
    }
}
