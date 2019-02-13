using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int health = 100;
	
	void Update () {
		if(health < 0 || health == 0)
        {
            Destroy(gameObject);
        }
	}

    private void Start()
    {
        OnBecameInvisible();
    }

    private void OnBecameVisible()
    {
        this.enabled = true;
        transform.Find("EnemyFirePoint").GetComponent<EnemyWeaponScript>().enabled = true;
    }
    private void OnBecameInvisible()
    {
        this.enabled = false;
        transform.Find("EnemyFirePoint").GetComponent<EnemyWeaponScript>().enabled = false;
    }
}
