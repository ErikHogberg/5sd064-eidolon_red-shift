using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    private float m_Cooldown = 0f;
    public float Cooldown = 0.1f;

	void Update () {
        if (m_Cooldown > 0)
        {
            m_Cooldown -= Time.deltaTime;
        }
        if (Input.GetButton("Fire1") && (m_Cooldown == 0 || m_Cooldown < 0))
        {
            Shoot();
            m_Cooldown = Cooldown;
        }
	}

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
