﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utilities {


	class Timer {
		float time;
		bool running;

		/// <summary>
		/// Creates a timer, doesn't start it
		/// </summary>
		public Timer() {
			running = false;
		}

		/// <summary>
		/// Creates a timer, starts it with a set countdown
		/// </summary>
		/// <param name="time">Countdown time</param>
		public Timer(float time) {
			Restart(time);
		}

		/// <summary>
		/// Starts/restarts the timer with the specified countdown time.
		/// </summary>
		/// <param name="time">Countdown time</param>
		public void Restart(float time) {
			this.time = time;
			running = true;
		}

		/// <summary>
		/// Counts the timer down the specified amount.
		/// The timer stops once it's out of time and needs to be restarted with a new time.
		/// Returns true if (and only if) it reaches 0 on this update.
		/// </summary>
		/// <param name="dt">Amount to count dowm.</param>
		/// <returns>
		/// Returns true if it counts past 0 this update.
		/// Returns false if it hasn't reached 0 yet, or if it has already reached 0 and is no longer running.
		/// </returns>
		public bool Update( float dt ) {
			if (!running) {
				return false;
			}

			time -= dt;
			if (time < 0) {
				running = false;
				return true;
			}

			return false;
		}

		/// <summary>
		/// Check wether the timer is running.
		/// </summary>
		/// <returns>Returns false if the timer either has not been started or has run out of time.</returns>
		public bool IsRunning() {
			return running;
		}

	}
}
