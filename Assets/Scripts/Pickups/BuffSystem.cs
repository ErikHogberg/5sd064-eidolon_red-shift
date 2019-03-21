using Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Pickups {
	public enum BuffType {
		HpRegen,
		ZombieHpRegen,
		ZombieSpeedUp,
		Invulnerability,
		NoWeaponCooldown,
		FullAutoWeapon,
		DamageIncrease,
		AoEWeapon,
	}

	public struct Buff {
		public BuffType Type;
		public float BuffStrength;
		public Timer Timer;

		public Buff(BuffType Type, float BuffStrength, float Duration) {
			this.Type = Type;
			this.BuffStrength = BuffStrength;
			Timer = new Timer(Duration);
		}
	}

	public class BuffSystem {
		private List<Buff> buffs = new List<Buff>();

		public BuffSystem() {

		}

		public void AddBuff(Buff buff) {
			buffs.Add(buff);
		}

		public List<Buff> Update() {
			List<Buff> endedBuffs = new List<Buff>();

			buffs.RemoveAll((Buff buff)=> {
				if (buff.Timer.Update()) {
					endedBuffs.Add(buff);
					return true;
				}
				return false;
			});

			return endedBuffs;
		}

	}
}
