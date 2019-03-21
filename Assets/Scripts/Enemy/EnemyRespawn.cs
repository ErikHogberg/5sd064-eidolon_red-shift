using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject Enemy1, Enemy2, Enemy3, Enemy4, Enemy5;
    public int MaxEnemies = 5;
    public int EnemiesToKill = 20;
    public bool InfiniteSpawn = false;

    private int EnemiesAlive = 0;
    private Vector3 stageDimensions;
    private Vector3 respawnPosition;
    private Transform enemies;

    private void Start()
    {
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        enemies = GameObject.Find("Enemies").transform;
    }

    private void Update()
    {
        respawnPosition = new Vector3(stageDimensions.x + Random.Range(4f, 10f), Random.Range(-2f, 2f), 0);
        if (EnemiesAlive < MaxEnemies && EnemiesToKill > 1)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    if(Enemy1)
                    {
                        Instantiate(Enemy1, respawnPosition, transform.rotation, enemies);
                        EnemiesAlive = EnemiesAlive + 1;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 1:
                    if (Enemy2)
                    {
                        Instantiate(Enemy2, respawnPosition, transform.rotation, enemies);
                        EnemiesAlive = EnemiesAlive + 1;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 2:
                    if (Enemy3)
                    {
                        Instantiate(Enemy3, respawnPosition, transform.rotation, enemies);
                        EnemiesAlive = EnemiesAlive + 1;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 3:
                    if (Enemy4)
                    {
                        Instantiate(Enemy4, respawnPosition, transform.rotation, enemies);
                        EnemiesAlive = EnemiesAlive + 1;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 4:
                    if (Enemy5)
                    {
                        Instantiate(Enemy5, respawnPosition, transform.rotation, enemies);
                        EnemiesAlive = EnemiesAlive + 1;
                        break;
                    }
                    else
                    {
                        break;
                    }
                default:
                    break;

            }
        }
    }

    public void EnemyKilled(bool offScreen)
    {
        if(!offScreen)
        {
            if(!InfiniteSpawn)
            {
                EnemiesToKill = EnemiesToKill - 1;
            }
            EnemiesAlive = EnemiesAlive - 1;
        }
        else
        {
            EnemiesAlive = EnemiesAlive - 1;
        }
    }
}
