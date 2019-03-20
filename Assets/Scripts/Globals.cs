using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
	public static class Globals {
		// Game-wide score
		public static int Score = 0;
		// How many zombies the players starts with on the next level
		public static int StartZombies = 0;
		// The current player
		public static PlayerMovementScript Player;
		// The current level
		public static GameObject Ground;
		// The current dialogue window
		public static DialoguePanelScript DialogueWindow;
		
	}
}
