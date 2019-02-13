using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private GameObject player;
    private float m_Cooldown = 0f;
    public float Cooldown = 0.1f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (m_Cooldown > 0f)
        {
            m_Cooldown -= Time.deltaTime;
        }
        if (m_Cooldown == 0f || m_Cooldown < 0f)
        {
            Shoot();
            m_Cooldown = Cooldown;
        }
    }

    void Shoot()
    {
        if(player)
        {
            Vector2 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
