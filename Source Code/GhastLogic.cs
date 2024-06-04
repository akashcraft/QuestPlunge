using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Unity.VisualScripting;

public class GhastLogic : MonoBehaviour
{
    public GameObject FireCharge;
    public GameObject Ghast;
    public GameObject Level;
    private MusicHandler musicHandler;
    private GameObject player;
    public GameObject Explosion;
    private GameObject NewCharge;
    private GameObject NewExplosion;
    public void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
        player = GameObject.Find("Player");
        Invoke("Attack", 7f);
        Invoke("Start", 14f);
    }

    public async void Attack() { 
        if (Ghast.activeSelf && Level.activeSelf)
        {
            Invoke("Done", 6f);
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("GhastAngry");
            musicHandler.PlaySFX(musicHandler.GhastAttack);
            await Task.Delay(1000);
            Vector3 recorded = player.transform.position;
            NewCharge = Instantiate(FireCharge, transform.position, transform.rotation);
            NewCharge.transform.parent = transform.parent;
            NewCharge.LeanMove(recorded,1.0f);   
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ghast");
            await Task.Delay(1000);
            Destroy(NewCharge);
            musicHandler.PlaySFX(musicHandler.ChargeExplosion);
            NewExplosion = Instantiate(Explosion, recorded, transform.rotation);
        }
    }

    private void Done()
    {
        Destroy(NewExplosion);
    }
}
