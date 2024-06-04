using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireChargeLogic : MonoBehaviour
{
    private bool m_FireCharge = false;

    private void Update()
    {
        m_FireCharge=GameObject.Find("Player").GetComponent<PlayerLogic>().shield;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !m_FireCharge)
        {
            GameObject.Find("Health").GetComponent<HealthLogic>().dodamage(2.0f);
        }
    }
}
