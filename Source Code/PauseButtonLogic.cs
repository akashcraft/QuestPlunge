using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonLogic : MonoBehaviour
{
    private MusicHandler musicHandler;
    public GameObject mainLoad;
    public GameObject GreenShell;
    public GameObject RedShell;
    public GameObject Ghast;
    public GameObject Boss;

    public void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    public void ResumeClicked()
    {
        GameObject.Find("Pause").GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
    }

    public void QuitClicked()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void ResetLevelClicked()
    {
        musicHandler.StopSFX();
        int GameLevel = PlayerPrefs.GetInt("GameLevel");
        if (GameLevel == 1)
        {
            GameObject.Find("PushableBox").transform.position = new Vector3(35f, 0f, 2.84f);
            musicHandler.PlayBGM(musicHandler.BGM1);
        }
        else if (GameLevel == 2)
        {
            musicHandler.PlayBGM(musicHandler.BGM2);
            GameObject.Find("PushableBox").transform.position = new Vector3(15.85000038f, -3.48000002f, 2.83f);
            GameObject.Find("NetherPortal").GetComponent<PortalLogic>().ClosePortal();
            Ghast.SetActive(true);
        }
        else if (GameLevel == 3)
        {
            musicHandler.PlayBGM(musicHandler.BGM3);
            RedShell.SetActive(true);
            GameObject.Find("PushableBox").transform.position = new Vector3(20.6599998f, -3.48000002f, -2.83f);
            GameObject.Find("GoldBlock").GetComponent<GoldBlockLogic>().Reset();
            GameObject.Find("GateCheck").GetComponent<GateLogic>().Reset();
        }
        else if (GameLevel == 4)
        {
            musicHandler.PlayBGM(musicHandler.BGM4);
            GameObject.Find("BoatTrigger").GetComponent<BoatLogic>().done = false;
            GameObject.Find("Boat").GetComponent<Animator>().Play("Boat", 0, 0f);
            GreenShell.SetActive(true);
            GameObject.Find("GoldBlock").GetComponent<GoldBlockLogic>().Reset();
        }
        else if (GameLevel == 5)
        {
            musicHandler.PlayBGM(musicHandler.BGM5);
        }
        else if (GameLevel == 6)
        {
            musicHandler.PlayBGM(musicHandler.BGM6);
            Boss.SetActive(true);
            Boss.GetComponent<SpikeLogic>().HoldHits = 100;
            Boss.GetComponent<Animator>().Play("BossIdle", 0, 0f);
        }
        GameObject.Find("Player").transform.position = new Vector3(0f, -3.58f, -2f);
        ResumeClicked();
    }
    public void MainMenuClicked()
    {
        ResetLevelClicked();
        musicHandler.StopSFX();
        GameObject.FindGameObjectWithTag("Level").SetActive(false);
        GameObject.Find("Player").SetActive(false);
        GameObject.Find("In-GameText").SetActive(false);
        mainLoad.SetActive(true);
        musicHandler.PlayBGM(musicHandler.BGM0);
        mainLoad.GetComponentInChildren<MainLoad>().MainLoadShow();
    }

    public void MainMenuWinClicked()
    {
        GameObject.FindGameObjectWithTag("Level").SetActive(false);
        GameObject.Find("Player").SetActive(false);
        mainLoad.SetActive(true);
        musicHandler.PlayBGM(musicHandler.BGM0);
        mainLoad.GetComponentInChildren<MainLoad>().MainLoadShow();
        GameObject.Find("MainMenuWin").SetActive(false);
    }
    public void PointerEnter()
    {
        this.GetComponent<Animator>().SetBool("Hover", true);
        musicHandler.PlaySFX(musicHandler.Hover);
    }
    public void PointerExit()
    {
        this.GetComponent<Animator>().SetBool("Hover", false);
    }
}
