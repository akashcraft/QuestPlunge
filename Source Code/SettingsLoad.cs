using UnityEngine;
using System.Threading.Tasks;

public class SettingsLoad : MonoBehaviour
{
    private MusicHandler musicHandler;
    public GameObject FromPage;
    public GameObject ToPage;

    public void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    public void Clicked()
    {   
        musicHandler.PlaySFX(musicHandler.Click);
        FromPage.LeanAlpha(0, 0.1f);
        ToPage.LeanAlpha(1, 0.1f).setOnComplete(MoveComplete);
    }

    private void MoveComplete()
    {
        FromPage.SetActive(false);
        ToPage.SetActive(true);
    }

    public void QuitClicked()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void ClearDataClicked()
    {
        PlayerPrefs.DeleteAll();
        Clicked();
        musicHandler.PlayBGM(musicHandler.BGM0);
    }

    public async void AboutClicked()
    {
        Clicked();
        await Task.Delay(200);
        GameObject.Find("AboutSign").LeanMoveLocalY(-157, 0.5f).setEaseInOutQuart();
    }

    public async void AboutClosed()
    {
        GameObject.Find("AboutSign").LeanMoveLocalY(-970, 0.5f).setEaseInOutQuart();
        await Task.Delay(300);
        Clicked();
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
