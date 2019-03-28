using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript : MonoBehaviour
{
    public float BulletSpeed = 12f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private GameObject player;
    private Collider2D playerInRange;
    private float m_Cooldown = 0f;
    public int Damage = 10;
    public float Cooldown = 0.1f;
    //Mick's edit start
    public AudioSource Arrow;
    public AudioSource Sword_Swing;
    //mick's edit end



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
        if (m_Cooldown <= 0f)
        {
            if(GetComponentInParent<EnemyScript>() == null)
            {
                switch(GetComponentInParent<BossScript>().BossType)
                {
                    case Type.King:
                        Shoot();
                        m_Cooldown = Cooldown;
                        break;
                    case Type.Queen:
                        Melee();
                        m_Cooldown = Cooldown;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (GetComponentInParent<EnemyScript>().EnemyType)
                {
                    case Type.Archer:
                        Shoot();
                        m_Cooldown = Cooldown;
                        break;
                    case Type.Knight:
                        Melee();
                        break;
                    case Type.Peasant:
                        Melee();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void Shoot()
    {
        if (player)
        {
            Vector2 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			var animator = GetComponentInParent<Animator>();
			if (animator != null) {
				GetComponentInParent<Animator>().SetTrigger("Attack");
			}
            Invoke("ArrowShoot", 0.5f);
        }
    }

    void ArrowShoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (GameObject.Find("Ground") == true)
        {
            bullet.transform.parent = Assets.Scripts.Globals.Ground.transform;
        }
        bullet.GetComponent<EnemyBulletScript>().Speed = BulletSpeed;
        //Mick's edit start
        if (Arrow != null)
        {
            Arrow.Play();
        }
		//Mick's edit end
		var animator = GetComponentInParent<Animator>();
		if (animator != null) {
			animator.ResetTrigger("Attack");
		}
    }
    void Melee()
    {
        if(playerInRange != null && playerInRange.tag == "Player")
        {
            //Mick's edit start
            if (Sword_Swing != null)
            {
                Sword_Swing.Play();
            }
            //Mick's edit end
            PlayerMovementScript movementScript = playerInRange.GetComponent<PlayerMovementScript>();
			if (movementScript == null) {
				movementScript = playerInRange.GetComponentInParent<PlayerMovementScript>();
			}
			movementScript.TakeDamage(Damage);   
            m_Cooldown = Cooldown;
            GetComponentInParent<SpriteRenderer>().color = new Color32(164, 164, 164, 255);
            GetComponentInParent<EnemyScript>().movementCooldown = 1f;
            GetComponentInParent<Animator>().SetTrigger("Attack");
        } else if (playerInRange != null && playerInRange.tag == "Zombie")
        {
            //Mick's edit start
            if (Sword_Swing != null)
            {
                Sword_Swing.Play();
            }
            //Mick's edit end
            playerInRange.GetComponentInParent<ZombieBehaviourScript>().TakeDamage(Damage);
            m_Cooldown = Cooldown;
            GetComponentInParent<SpriteRenderer>().color = new Color32(164, 164, 164, 255);
            GetComponentInParent<EnemyScript>().movementCooldown = 1f;
            GetComponentInParent<Animator>().SetTrigger("Attack");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = null;
    }
}
