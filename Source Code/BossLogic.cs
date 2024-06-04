using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    private Animator animator;
    public GameObject BackDrop;
    private MusicHandler musicHandler;
    public GameObject Icon;
    public GameObject EHealth;
    public GameObject Boss;
    public GameObject Level;
    public GameObject InGame;
    public GameObject MainMenu;
    public void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
        animator = this.GetComponent<Animator>();
        Invoke("StartAnim", 5f);
    }

    private void Update()
    {
        if (Boss.activeSelf && Level.activeSelf)
        {
            Icon.SetActive(true);
            EHealth.SetActive(true);
            int health = this.GetComponent<SpikeLogic>().HoldHits;
            if (health > 0)
            {
                EHealth.GetComponent<TextMeshProUGUI>().text = health.ToString();
            }
        } else
        {
            Icon.SetActive(false);
            EHealth.SetActive(false);
        }
    }
    public void EndGame()
    {
        GameObject.Find("LevelHandler").GetComponent<LoadLevel>().Load(7);
        GameObject.Find("Player").transform.position = new Vector3(0f, -3.58f, -2f);
        EHealth.GetComponent<TextMeshProUGUI>().text = "100";
        this.GetComponent<SpikeLogic>().HoldHits = 100;
        Icon.SetActive(false);
        EHealth.SetActive(false);
        MainMenu.SetActive(true);
        InGame.SetActive(false);
    }

    private void StartAnim()
    {
        if (Boss.activeSelf && Level.activeSelf)
        {
            animator.SetTrigger("Start");
            Invoke("Shaker", 1f);
            Invoke("StartAnim", 15f);
        } else {
            Icon.SetActive(false);
            EHealth.SetActive(false);
        }
    }
    
    private void Shaker()
    {
        if (Boss.activeSelf && Level.activeSelf)
        {
            BackDrop.GetComponent<Animator>().SetTrigger("Shake");
            musicHandler.PlaySFX(musicHandler.BossStart);
        } else {
            Icon.SetActive(false);
            EHealth.SetActive(false);
        }
    }
}
