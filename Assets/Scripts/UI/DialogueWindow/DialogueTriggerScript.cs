using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerScript : MonoBehaviour
{

	// TODO: dialogue text to load as public field
	public TextAsset text;

	private bool activated;
	
	// Start is called before the first frame update
	void Start()
	{
		activated = false;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	

	private void OnTriggerEnter2D(Collider2D collision) {
		if (activated) {
			return;
		}

		if (collision.tag == "Player") {
			Globals.DialogueWindow.gameObject.SetActive(true);
			Globals.DialogueWindow.SetText(text);
			//activated = true;
		}
	}

}
