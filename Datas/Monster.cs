using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public class Monster
	{
		public string name;
		public int level;
		public int attack;
		public int health;

		public Monster(string name, int level, int attack, int hp)
		{
			this.name = name;
			this.level = level;
			this.attack = attack;
			this.health = hp;
		}
	}
}
