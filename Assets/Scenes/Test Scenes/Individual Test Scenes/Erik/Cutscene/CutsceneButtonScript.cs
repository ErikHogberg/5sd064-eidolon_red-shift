using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneButtonScript : MonoBehaviour {

	void Start() {
		GetComponent<Button>().onClick.AddListener(GetComponentInParent<CutsceneFrameScript>().SwitchFrame);

	}

}
