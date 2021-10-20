using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanelScript : MonoBehaviour {

	public Text DialogueText;
	public Text PageNumberText;
	public Text SpeakerTitleText;
	public DialogueUtilityScript NextButton;

	private string[] textPages;
	private Color[] pageColors;
	private string[] pageSpeakerTitles;
	//private string[] pageSpeakerPortraits;

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
			UpdatePage();
		}
	}

	void Start() {
		//Globals.DialogueWindow = this;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			NextButton.ClickNext();
		}
	}

	private void UpdatePage() {
		DialogueText.text = textPages[currentPage];
		PageNumberText.text = "Page " + (currentPage + 1) + "/" + textPages.Length;
		SpeakerTitleText.text = pageSpeakerTitles[currentPage];
		GetComponent<Image>().color = pageColors[currentPage];
	}

	public void SetText(string[] text) {
		textPages = text;
	}

	public void SetText(TextAsset text) {
		string allText = text.text;

		textPages = Regex.Split(allText, "\r\n-\r\n");

		pageColors = new Color[textPages.Length];
		for (int i = 0; i < textPages.Length; i++) {
			pageColors[i] = new Color(0, 0, 0, 0.75f);
		}

		pageSpeakerTitles = new string[textPages.Length];
		//pageSpeakerPortraits = new string[textPages.Length];

		CultureInfo parseCulture = new CultureInfo("en-US", false);

		for (int i = 0; i < textPages.Length; i++) {
			string page = textPages[i];

			bool foundSpeaker = false;
			page = Regex.Replace(page, @"\btitle:\s(.*?)\r?\n", delegate (Match match) {
				pageSpeakerTitles[i] = match.Groups[1].Value.Trim();
				foundSpeaker = true;
				return "";
			}, RegexOptions.Multiline);

			if (!foundSpeaker) {
				if (i == 0) {
					pageSpeakerTitles[i] = "Necromancer";
				} else {
					pageSpeakerTitles[i] = pageSpeakerTitles[i - 1];
				}
			}

			page = Regex.Replace(page, @"\brgb:\s(.*?)\n", delegate (Match match) {
				string[] colors = match.Groups[1].Value.Trim().Split(',');

				float[] rgb = new float[colors.Length];
				for (int j = 0; j < colors.Length; j++) {
					// print($"attempting to parse color \"{colors[j]}\"");
					rgb[j] = (float) double.Parse(colors[j], parseCulture.NumberFormat);
				}

				if (colors.Length == 3) {
					pageColors[i] = new Color(rgb[0], rgb[1], rgb[2], 0.75f);
				} else if (colors.Length == 4) {
					pageColors[i] = new Color(rgb[0], rgb[1], rgb[2], rgb[3]);
				}

				return "";
			}, RegexOptions.Singleline);

			textPages[i] = page;
		}

		currentPage = 0;
		UpdatePage();
	}

	// return true if flipped to last page
	public bool NextPage() {
		CurrentPage++;
		if (CurrentPage == textPages.Length - 1) {
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
