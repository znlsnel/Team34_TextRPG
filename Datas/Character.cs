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

		public virtual void Damage(int damage)
		{
			hp -= damage;
			if (hp < 0)
				hp = 0;
		}
		public void Heal(int value)
		{
			hp += value;
			if (hp > maxHp)
				hp = maxHp;
		}
	}

	public class PlayerData : Character
	{
		public EClassType classType;

		public int gold;

		public List<string> myItems_saveData = new List<string>();
		public string weapon_saveData = "";
		public string armor_saveData = "";

		public int exp = 0;
		List<int> requiredExp = new List<int>()
		{10, 35, 65, 100, 170, 250, 350, 500, 1000, 1500};

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
		
		public bool AddExp(int e)
		{
			exp += e;

			if (level-1 >= requiredExp.Count)
				return false;

			if (requiredExp[level-1] <= exp)
			{
				level++;
				attack += 3;
				defense += 3;
				maxHp += 20;
				hp += 20;
				return true;
			}
			return false;
		}
	}

	public class Monster : Character
	{
		Action? onDie;
		public Monster(string name, int level, int attack, int hp, Action onDie = null)
		{
			this.name = name;
			this.level = level;
			this.attack = attack;
			this.maxHp = hp;
			this.hp = hp;
			this.onDie = onDie;
		}

		public Monster DeepCopy()
		{
			Monster mst = new Monster(name, level, attack, hp, onDie); 
			return mst;
		}

		public override void Damage(int damage)
		{
			base.Damage(damage);
			if (hp == 0)
			{
				onDie?.Invoke();
			}
		}

	}
}
