using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseScript : MonoBehaviour
{
    public GameObject Zombie;
    public void SpawnZombie()
    {
        Instantiate(Zombie, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
