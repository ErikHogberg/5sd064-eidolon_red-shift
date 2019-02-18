﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseScript : MonoBehaviour
{
    public GameObject Zombie;
    public void SpawnZombie(GameObject player)
    {
        var zombie = Instantiate(Zombie, transform.position, transform.rotation);
		zombie.transform.parent = transform.parent;
		zombie.GetComponent<ZombieBehaviourScript>().Player = player;
        Destroy(gameObject);
    }
}
