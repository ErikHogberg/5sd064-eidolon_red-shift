using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float Speed = 10f;
    public int Damage = 10;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "PlayerCollider")
        {
            collider.GetComponentInParent<PlayerMovement>().health -= Damage;
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
