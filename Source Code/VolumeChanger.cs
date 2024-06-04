using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    public MusicHandler musicHandler;
    public int Mode;

    private void Start()
    {
        if (Mode==0) 
        {
            this.GetComponent<Slider>().value = musicHandler.BGMVolume;
        } else if (Mode==1)
        {
            this.GetComponent<Slider>().value = musicHandler.SFXVolume;
        } else if (Mode==2)
        {
            int hold = Mathf.RoundToInt(musicHandler.BGMVolume * 100);
            GameObject.Find("BGMVolumeText").GetComponent<TextMeshProUGUI>().text = hold.ToString() + "%";
        } else if (Mode==3)
        {
            int hold = Mathf.RoundToInt(musicHandler.SFXVolume * 100);
            GameObject.Find("SFXVolumeText").GetComponent<TextMeshProUGUI>().text = hold.ToString() + "%";
        }
    }

    public void OnVolumeChanged(float volume)
    {
        if (Mode==0)
        {
            musicHandler.ChangeBGMVolume(volume);
            int hold = Mathf.RoundToInt(musicHandler.BGMVolume * 100);
            GameObject.Find("BGMVolumeText").GetComponent<TextMeshProUGUI>().text = hold.ToString() + "%";
        } else if (Mode==1)
        {
            musicHandler.ChangeSFXVolume(volume);
            int hold = Mathf.RoundToInt(musicHandler.SFXVolume * 100);
            GameObject.Find("SFXVolumeText").GetComponent<TextMeshProUGUI>().text = hold.ToString() + "%";
        }
    }
}
