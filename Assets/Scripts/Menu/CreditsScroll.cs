using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour {


    public float ScrollSpeed;
    public float SpaceSpeed = 2.0f;

    void Update()
    {
        float speed = ScrollSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed *= SpaceSpeed;
        }

        Vector3 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;

		Vector3 pos = transform.position;
		pos.y += ScrollSpeed * Time.deltaTime;
		transform.position = pos;

	}
}
