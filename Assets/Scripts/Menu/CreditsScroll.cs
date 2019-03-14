using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{

    public float ScrollSpeed;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += ScrollSpeed * Time.deltaTime;
        transform.position = pos;

    }
}
