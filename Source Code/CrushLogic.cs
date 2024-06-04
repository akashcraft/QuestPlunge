using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class CrushLogic : MonoBehaviour
{

    private GameObject player;
    private GameObject healthLogic;

    private void Start()
    {
        healthLogic = GameObject.Find("Health");
        player = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Crushed
        if (collision.CompareTag("Player"))
        {
            if (!player.GetComponent<PlayerLogic>().shield)
            {
                healthLogic.GetComponent<HealthLogic>().dodamage(6f);
            }
        }
    }
}
