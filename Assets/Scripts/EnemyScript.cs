﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int health = 100;
    public GameObject Corpse;

    private void Start()
    {
        this.enabled = false;
        gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = false;
    }

    void Update () {
		if(health < 0 || health == 0)
        {
            Instantiate(Corpse, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
	}

    private void OnBecameVisible()
    {
        this.enabled = true;
        gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = true;
    }

    private void OnBecameInvisible()
    {
        this.enabled = false;
        gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = false;
    }
}
