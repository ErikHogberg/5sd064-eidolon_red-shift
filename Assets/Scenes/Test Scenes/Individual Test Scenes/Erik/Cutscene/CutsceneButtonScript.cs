using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
				GetComponent<Button>().onClick.AddListener(GetComponentInParent<CutsceneFrameScript>().SwitchFrame);

	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
