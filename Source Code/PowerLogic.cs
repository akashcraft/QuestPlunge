using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PowerLogic : MonoBehaviour
{
    private GameObject musicHandler;
    private GameObject coinCount;
    private bool PowerActive = false;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler");
        coinCount = GameObject.Find("CoinCount");
    }
    public void ClickedFreePU(int powertype)
    {
        GameObject powerbar = null;
        GameObject bar = null;
        if (powertype == 1)
        {
            powerbar = GameObject.Find("SpeedPowerBar");
            bar = GameObject.Find("SpeedBar");
        }
        else if (powertype == 2)
        {
            powerbar = GameObject.Find("JumpPowerBar");
            bar = GameObject.Find("JumpBar");
        }
        else if (powertype == 3)
        {
            powerbar = GameObject.Find("RegenPowerBar");
            bar = GameObject.Find("RegenBar");
        }
        else if (powertype == 4)
        {
            powerbar = GameObject.Find("ShieldPowerBar");
            bar = GameObject.Find("ShieldBar");
        }
        Clicked(powerbar, bar, powertype, 0);
    }
    public void ClickedPU(int powertype)
    {
        int cost = 5;
        GameObject powerbar = null;
        GameObject bar = null;
        if (powertype == 1)
        {
            powerbar = GameObject.Find("SpeedPowerBar");
            bar = GameObject.Find("SpeedBar");
            cost = 5;
        } else if (powertype == 2)
        {
            powerbar = GameObject.Find("JumpPowerBar");
            bar = GameObject.Find("JumpBar");
            cost = 5;
        }
        else if (powertype == 3)
        {
            powerbar = GameObject.Find("RegenPowerBar");
            bar = GameObject.Find("RegenBar");
            cost = 10;
        }
        else if (powertype == 4)
        {
            powerbar = GameObject.Find("ShieldPowerBar");
            bar = GameObject.Find("ShieldBar");
            cost = 10;
        }
        Clicked(powerbar, bar, powertype, cost);
    }

    public async void Clicked(GameObject powerbar,GameObject bar,int powertype, int cost)
    {
        int CoinValue = int.Parse(coinCount.GetComponent<TextMeshProUGUI>().text);
        PowerActive = GameObject.Find("SpeedPU").GetComponent<PowerLogic>().PowerActive
            || GameObject.Find("JumpPU").GetComponent<PowerLogic>().PowerActive
            || GameObject.Find("RegenPU").GetComponent<PowerLogic>().PowerActive
            || GameObject.Find("ShieldPU").GetComponent<PowerLogic>().PowerActive;
        if (CoinValue >= cost && !PowerActive)
        {
            PowerActive = true;
            if (powertype == 1)
            {
                GameObject.Find("Player").GetComponent<PlayerLogic>().MoveSpeed = 16;
            } else if (powertype == 2)
            {
                GameObject.Find("Player").GetComponent<PlayerLogic>().JumpSpeed = 21;
                GameObject.Find("Health").GetComponent<HealthLogic>().ignorefall = true;
            } else if (powertype == 3)
            {
                ReviveHealth();
            } else if (powertype == 4)
            {
                GameObject.Find("Player").GetComponent<PlayerLogic>().shield = true;
                GameObject.Find("Health").GetComponent<HealthLogic>().ignorefall = true;
            }
            musicHandler.GetComponent<MusicHandler>().PlaySFX(musicHandler.GetComponent<MusicHandler>().Purchase);
            coinCount.GetComponent<TextMeshProUGUI>().text = (CoinValue - cost).ToString();
            powerbar.LeanMoveLocalX(-652,0.3f).setEaseInOutQuad();
            bar.LeanMoveLocalX(-9f, 10f).setEaseInOutQuad();
            bar.LeanScaleX(0f, 10f).setEaseInOutQuad();
            musicHandler.GetComponent<MusicHandler>().PlaySFX(musicHandler.GetComponent<MusicHandler>().PowerUp1);
            await Task.Delay(10000);
            powerbar.LeanMoveLocalX(-1222, 0.3f).setEaseInOutQuad();
            await Task.Delay(1000);
            bar.LeanMoveLocalX(0.23f,0.1f).setEaseInOutQuad();
            bar.LeanScaleX(1f, 0.1f).setEaseInOutQuad();
            SetAllFalse();
            if (powertype == 1)
            {
                GameObject.Find("Player").GetComponent<PlayerLogic>().MoveSpeed = 8;
            }
            else if (powertype == 2)
            {
                GameObject.Find("Player").GetComponent<PlayerLogic>().JumpSpeed = 11;
                GameObject.Find("Health").GetComponent<HealthLogic>().ignorefall = false;
            }
            else if (powertype == 4)
            {
                GameObject.Find("Player").GetComponent<PlayerLogic>().shield = false;
                GameObject.Find("Health").GetComponent<HealthLogic>().ignorefall = false;
            }
        } else if (!PowerActive){ 
            musicHandler.GetComponent<MusicHandler>().PlaySFX(musicHandler.GetComponent<MusicHandler>().PurchaseFail);
            coinCount.GetComponent<Animator>().SetTrigger("CoinFail 0");
        }
    }

    private void SetAllFalse()
    {
        GameObject.Find("SpeedPU").GetComponent<PowerLogic>().PowerActive = false;
        GameObject.Find("JumpPU").GetComponent<PowerLogic>().PowerActive = false;
        GameObject.Find("RegenPU").GetComponent<PowerLogic>().PowerActive = false;
        GameObject.Find("ShieldPU").GetComponent<PowerLogic>().PowerActive = false;
    }

    private async void ReviveHealth()
    {
        for (int i = 0;i< 10; i++)
        {
            GameObject.Find("Health").GetComponent<HealthLogic>().dodamage(-0.5f,false);
            await Task.Delay(1000);
        }
    }

    public void PowerEnter(GameObject power)
    {
        musicHandler.GetComponent<MusicHandler>().PlaySFX(musicHandler.GetComponent<MusicHandler>().Hover);
        power.LeanScale(new Vector3(18.2f,18.2f,18.2f), 0.2f);
    }

    public void PowerExit(GameObject power)
    {
        power.LeanScale(new Vector3(16.56f, 16.56f, 16.56f), 0.2f);
    }
}
