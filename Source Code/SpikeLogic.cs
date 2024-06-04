using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SpikeLogic : MonoBehaviour 
{
    public float DamageValue = 1.0f;
    private GameObject player;
    private HealthLogic healthLogic;
    private bool playerInsideTrigger;
    private bool calledonce = false;
    public bool ActiveEnemy = false;
    public int HitsNeeded = 1;
    public GameObject Enemy;
    public int HoldHits;
    private MusicHandler musicHandler;
    public AudioClip EnemyAttack;
    public AudioClip EnemyDeath;
    private bool EnemyAttackSound = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        healthLogic = FindObjectOfType<HealthLogic>();
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
        HoldHits = HitsNeeded;
    }

    private void validateAttack()
    {
        if (!EnemyAttackSound)
        {
            EnemyAttackSound = true;
            if (EnemyAttack != null)
            {
                musicHandler.PlaySFX(EnemyAttack);
            }
        }
        HoldHits -= 1;
        if (HoldHits <= 0)
        {
            HoldHits = HitsNeeded;
            if (HitsNeeded == 100)
            {
                Enemy.GetComponent<BossLogic>().EndGame();
            }
            Enemy.SetActive(false);
            musicHandler.PlaySFX(EnemyDeath);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Player")){
            if (ActiveEnemy && Input.GetKey(KeyCode.Q)){
                validateAttack();
            } else {
                calledonce = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ActiveEnemy && Input.GetKeyDown(KeyCode.Q))
            {
                validateAttack();
            }
            else
            {
                if (!calledonce && Time.timeScale != 0 && !player.GetComponent<PlayerLogic>().shield)
                {
                    playerInsideTrigger = true;
                    ApplyDamageRepeatedly();
                    calledonce = true;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            calledonce = true;
            EnemyAttackSound = false;
        }
    }

    async void ApplyDamageRepeatedly()
    {

        while (playerInsideTrigger)
        {
            if (Time.timeScale == 0f)
            {
                calledonce = false;
                break;
            }
            if (DamageValue > 0f)
            {
                healthLogic.dodamage(DamageValue);
            }
            await Task.Delay(800);
        }
    }
}
