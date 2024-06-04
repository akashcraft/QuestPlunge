using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MainLoad : MonoBehaviour
{
    public GameObject MainLoadGrp; //Full Canvas
    public CanvasGroup PlayCanObj; //Play Button
    public GameObject MainHeadObj; //Main Head
    public GameObject LowerObj; //Lower Group
    public CanvasGroup NewGame; //LevelSelect Button
    public CanvasGroup QuitButton; //Quit Button
    private MusicHandler musicHandler;
    private int GameLevel;

    public void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    public void MainLoadShow()
    {
        PlayCanObj.LeanAlpha(1, 0.2f);
        NewGame.LeanAlpha(1, 0.2f);
        QuitButton.LeanAlpha(1, 0.2f);
        MainHeadObj.LeanMoveLocalY(190, 0.2f).setEaseInOutQuart();
        LowerObj.LeanMoveLocalY(0, 0.2f).setEaseInOutQuart();
    }
    public void MainLoadHide()
    {
        if (!PlayerPrefs.HasKey("GameLevel"))
        {
            GameLevel = 1;
            PlayerPrefs.SetInt("GameLevel", 1);
            PlayerPrefs.Save();
        }
        else
        {
            GameLevel = PlayerPrefs.GetInt("GameLevel");
        }
        PlayCanObj.LeanAlpha(0, 0.2f);
        NewGame.LeanAlpha(0, 0.2f);
        QuitButton.LeanAlpha(0, 0.2f).setOnComplete(MainLoadHideComplete);
        MainHeadObj.LeanMoveLocalY(Screen.height+20, 0.2f).setEaseInOutQuart();
        LowerObj.LeanMoveLocalY(-Screen.height, 0.2f).setEaseInOutQuart();
        musicHandler.PlaySFX(musicHandler.Click);
    }

    private void MainLoadHideComplete()
    {
        MainLoadGrp.SetActive(false);
        GameObject.Find("LevelHandler").GetComponent<LoadLevel>().Load(GameLevel);
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
