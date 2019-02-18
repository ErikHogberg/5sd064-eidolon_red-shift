using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    private SpriteRenderer spr;

    private float m_Cooldown = 0f;
    public float Cooldown = 0.1f;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (m_Cooldown > 0f)
        {
            m_Cooldown -= Time.deltaTime;
        } else
        {
            spr.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && (m_Cooldown == 0f || m_Cooldown < 0f))
        {
            spr.enabled = true;
            m_Cooldown = Cooldown;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (spr.enabled && col.name == "Corpse(Clone)")
        {
            col.GetComponent<CorpseScript>().SpawnZombie();
        }
    }
}
