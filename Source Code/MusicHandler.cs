using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioSource Background;
    public AudioSource SFX;

    public float BGMVolume = 1f;
    public float SFXVolume = 1f;

    public AudioClip BGM0;
    public AudioClip BGM1;
    public AudioClip BGM2;
    public AudioClip BGM3;
    public AudioClip BGM4;
    public AudioClip BGM5;
    public AudioClip BGM6;
    public AudioClip BGM7;
    public AudioClip Click;
    public AudioClip Hover;
    public AudioClip Death;
    public AudioClip Purchase;
    public AudioClip PurchaseFail;
    public AudioClip PowerUp1;
    public AudioClip CoinCollect;
    public AudioClip GhastAttack;
    public AudioClip Ghast;
    public AudioClip ChargeExplosion;
    public AudioClip SnowWalk;
    public AudioClip ItemPickup;
    public AudioClip OpenDoor;
    public AudioClip Sword;
    public AudioClip EnemyDeath;
    public AudioClip Boat;
    public AudioClip BossStart;
    public AudioClip BossHurt;
    public AudioClip CannonFire;
    public AudioClip MarioGoldBlock;
    public AudioClip AmongUs;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("BGMVolume") || !PlayerPrefs.HasKey("SFXVolume"))
        {
            BGMVolume = 0.5f;
            PlayerPrefs.SetFloat("BGMVolume", 0.5f);
            SFXVolume = 1.0f;
            PlayerPrefs.SetFloat("SFXVolume", 1.0f);
            PlayerPrefs.Save();
        }
        else
        {
            BGMVolume = PlayerPrefs.GetFloat("BGMVolume");
            SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        }
        Background.clip = BGM0;
        Background.volume = BGMVolume;
        SFX.volume = SFXVolume;
        Background.loop = true;
        Background.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

    public void PlayBGM(AudioClip clip)
    {
        Background.clip = clip;
        Background.Play();
    }
    public void StopSFX()
    {
        SFX.Stop();
    }
    public void ChangeSFXVolume(float volume)
    {
        SFXVolume = volume;
        SFX.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

    public void ChangeBGMVolume(float volume)
    {
        BGMVolume = volume;
        Background.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
        PlayerPrefs.Save();
    }
}
