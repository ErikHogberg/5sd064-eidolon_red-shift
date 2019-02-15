using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utilities {


	class Timer {
		float time;
		bool running;

		public Timer() {
			running = false;
		}

		public Timer(float time) {
			Restart(time);
		}

		public void Restart(float time) {
			this.time = time;
			running = true;
		}

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

		public bool IsRunning() {
			return running;
		}

	}
}
