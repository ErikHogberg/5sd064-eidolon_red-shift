﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanelScript : MonoBehaviour {

	public Text DialogueText;

	private string[] textPages;
	private int currentPage = 0;
	public int CurrentPage {
		get { return currentPage; }
		set {
			if (value >= textPages.Length) {
				currentPage = textPages.Length - 1;
			} else if (value < 0) {
				currentPage = 0;
			} else {
				currentPage = value;
			}
			DialogueText.text = textPages[currentPage];
		}
	}

	void Start() {
		//Globals.DialogueWindow = this;
	}

	void Update() {

	}

	public void SetText(string[] text) {
		textPages = text;
	}

	public void SetText(TextAsset text) {
		string allText = text.text;
		//textPages = allText.Split('-');
		textPages = Regex.Split(allText, "\r\n-\r\n");
		currentPage = 0;
		DialogueText.text = textPages[currentPage];

	}

	// return true if flipped to last page
	public bool NextPage() {
		CurrentPage++;
		if (CurrentPage == textPages.Length-1) {
			return true;
		}
		return false;
	}

	// return true if flipped to first page
	public bool PrevPage() {
		CurrentPage--;
		if (CurrentPage == 0) {
			return true;
		}
		return false;
	}

	public bool IsOnLastPage() {
		return CurrentPage == textPages.Length - 1;
	}

	public bool IsOnFirstPage() {
		return currentPage == 0;
	}

}
