using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public enum EClassType
	{
		WARRIOR = 1 << 0,
		ROGUE = 1 << 1,
		MAGE = 1 << 2,
		ARCHER = 1 << 3,
		PALADIN = 1 << 4,
		NONE = WARRIOR | MAGE | ROGUE | ARCHER | PALADIN,
	} 

	public class PlayerClass
	{
		public EClassType classType;
		public int attack;
		public int armor;
		public int health;

		public PlayerClass(EClassType type, int att, int arm, int hp)
		{
			this.classType = type;
			this.attack = att;
			this.armor = arm;
			this.health = hp;
		}
	}
}
