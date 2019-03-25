using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
	public static class Globals {
		// Game-wide score
		public static int Score = 0;
		// How many zombies the players starts with on the next level
		private static int startSmallZombies = 0;
		public static int StartSmallZombies {
			get { return startSmallZombies; }
			set {
				if (value + startLargeZombies > 10) {
					startSmallZombies = 10 - startLargeZombies;
				}
			}
		}

		private static int startLargeZombies = 0;
		public static int StartLargeZombies {
			get { return startLargeZombies; }
			set {
				if (value + startSmallZombies > 10) {
					startLargeZombies = 10 - startSmallZombies;
				}
			}
		}

		// The current player
		public static PlayerMovementScript Player;
		// The current level
		public static GameObject Ground;
		// The current dialogue window
		public static DialoguePanelScript DialogueWindow;
		public static NotificationScript NotificationWindow;
		public static FadeScript FadePanel;
		public static Image GameOverPanel;

		public static void GameOver() {
			GameOverPanel.gameObject.SetActive(true);
			StartSmallZombies = 0;
			StartLargeZombies = 0;
		}

	}
}
