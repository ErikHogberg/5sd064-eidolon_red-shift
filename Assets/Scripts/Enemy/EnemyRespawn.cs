using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject Archer, Peasant, Knight;
    public int EnemiesToKill = 20;
    public int EnemiesAlive = 0;

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
        if (EnemiesAlive < 3)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    Instantiate(Archer, respawnPosition, transform.rotation, enemies);
                    EnemiesAlive++;
                    break;
                case 1:
                    Instantiate(Peasant, respawnPosition, transform.rotation, enemies);
                    EnemiesAlive++;
                    break;
                case 2:
                    Instantiate(Knight, respawnPosition, transform.rotation, enemies);
                    EnemiesAlive++;
                    break;
            }
        }
    }
}
