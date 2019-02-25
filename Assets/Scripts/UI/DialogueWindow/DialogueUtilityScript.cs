using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUtilityScript : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void ClickAction() {
		Globals.DialogueWindow.gameObject.SetActive(false);
	}

}
