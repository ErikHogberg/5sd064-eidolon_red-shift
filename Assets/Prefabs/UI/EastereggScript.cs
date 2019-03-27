using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EastereggScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Stop menu music
        Destroy(Assets.Scripts.Globals.PeristentMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
