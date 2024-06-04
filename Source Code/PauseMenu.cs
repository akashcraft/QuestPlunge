using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private MusicHandler musicHandler;
    public GameObject PauseMenuObj;
    private bool ClickedBool = false;
    private float previousTimeScale;

    public void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    public void Clicked()
    {
        if (!ClickedBool)
        {
            musicHandler.PlaySFX(musicHandler.Click);
            ClickedBool = true;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Play");
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            PauseMenuObj.GetComponent<Animator>().SetBool("Open",true);
        } else
        {
            musicHandler.PlaySFX(musicHandler.Click);
            ClickedBool = false;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Pause");
            Time.timeScale = previousTimeScale;
            PauseMenuObj.GetComponent<Animator>().SetBool("Open", false);
        }
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