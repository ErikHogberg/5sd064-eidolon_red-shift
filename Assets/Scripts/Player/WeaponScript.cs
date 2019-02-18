using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    private float m_Cooldown = 0f;
    public float Cooldown = 0.1f;

	void Update () {
        if (m_Cooldown > 0f)
        {
            m_Cooldown -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && (m_Cooldown == 0f || m_Cooldown < 0f))
        {
            Shoot();
            m_Cooldown = Cooldown;
        }
	}

    void Shoot()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		bullet.transform.parent = transform.parent.parent;
    }
}
