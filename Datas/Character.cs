using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public abstract class Character
	{
		public string name;
		public int level;
		public int attack;

		public int defense;
		public int maxHp;
		public int hp;
	}

	public class PlayerData : Character
	{
		public EClassType classType;

		public int gold;

		public List<string> myItems = new List<string>();
		public string weapon = "";
		public string armor = "";

		public PlayerData(string name, int level, EClassType type, int attack, int d, int maxHp, int gold)
		{
			this.name = name;
			this.level = level;
			this.classType = type;
			this.attack = attack;
			this.defense = d;
			this.maxHp = maxHp;
			this.hp = maxHp;
			this.gold = gold;
		}
	}

	public class Monster : Character
	{
		public Monster(string name, int level, int attack, int hp)
		{
			this.name = name;
			this.level = level;
			this.attack = attack;
			this.maxHp = hp;
			this.hp = hp;
		}
	}
}
