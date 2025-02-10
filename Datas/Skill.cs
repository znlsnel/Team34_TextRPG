using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{

	public abstract class Skill
	{
		public string name { get; protected set;  }
		public string desc { get; protected set; }
		public int mp { get; protected set; }
		
		public abstract void OnSkill(List<Monster> monsters, PlayerData pd);
	}

	public class AlphaStrikeSkill : Skill
	{
		public AlphaStrikeSkill()
		{
			name = "알파 스트라이크";
			desc = "공격력 * 2 로 하나의 적을 공격합니다.";
			mp = 10;
		}
		 
		public override void OnSkill(List<Monster> monsters, PlayerData pd)
		{
			Console.Clear();
			SpartaRPG.WriteLine($"스킬 {name}을 사용합니다! 몬스터를 선택해주세요", ConsoleColor.Blue);
			SpartaRPG.WriteLine($"[{desc}]", ConsoleColor.Green);
			Console.WriteLine();
		
			List<Monster >list = new List<Monster>();
			foreach (Monster m in monsters)
				if (m.hp > 0) list.Add(m);

			for (int i = 0; i < list.Count; i++)
				Console.WriteLine($"{i+1}. Lv.{list[i].level} {list[i].name}  HP {list[i].hp}");

			int value = SpartaRPG.SelectOption(1, list.Count);

			int prev = list[value - 1].hp;
			list[value - 1].Damage(pd.attack * 2);
			Console.Clear();
			Console.WriteLine($"Lv.{list[value - 1].level} {list[value - 1].name}을(를) 공격했습니다  HP {prev} -> {list[value-1].hp}");
			Console.WriteLine("\n0. 돌아가기");

			SpartaRPG.SelectOption();
		}
	}

	public class DubleStrikeSkill : Skill
	{
		public DubleStrikeSkill()
		{
			name = "더블 스트라이크";
			desc = "공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다";
			mp = 15;
		}

		public override void OnSkill(List<Monster> monsters, PlayerData pd)
		{
			Console.Clear();
			SpartaRPG.WriteLine($"스킬 {name}을 사용합니다!", ConsoleColor.Blue);
			SpartaRPG.WriteLine($"[{desc}]", ConsoleColor.Green);
			Console.WriteLine();

			Random rand = new Random();
			HashSet<int> idxs = new HashSet<int>();

			int cnt = 0;
			foreach (Monster mst in monsters)
				if (mst.hp > 0) cnt++;

			cnt = Math.Min(2, cnt);
			while (idxs.Count < cnt)
			{
				int idx = rand.Next(0, monsters.Count );
				if (monsters[idx].hp > 0) 
					idxs.Add(idx);
			}

			Console.WriteLine("\n1. 스킬 사용");
			SpartaRPG.SelectOption(1, 1);

			Console.Clear();
			foreach (int i in idxs)
			{
				int hp = monsters[i].hp;
				monsters[i].Damage(pd.attack * 2);
				Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name}  HP {hp} -> {monsters[i].hp}");
			}

			Console.WriteLine("\n0. 돌아가기");
			SpartaRPG.SelectOption();
		}
	}

	public class HeallingSkill : Skill
	{
		public HeallingSkill()
		{
			name = "힐링";
			desc = "최대 체력의 20%를 회복합니다";
			mp = 20;
		}

		public override void OnSkill(List<Monster> monsters, PlayerData pd)
		{
			Console.Clear();
			SpartaRPG.WriteLine($"스킬 {name}을 사용합니다!", ConsoleColor.Blue);
			SpartaRPG.WriteLine($"[{desc}]", ConsoleColor.Green);
			Console.WriteLine();

			Console.WriteLine("\n1. 스킬 사용");
			SpartaRPG.SelectOption(1, 1);

			int hp = pd.hp;
			pd.Heal(pd.maxHp / 5);

			Console.Clear();
			Console.WriteLine("체력을 회복합니다!");
			Console.WriteLine($"{pd.name} HP {hp} -> {pd.hp}"); 
			

			Console.WriteLine("\n0. 돌아가기");
			SpartaRPG.SelectOption();
		}
	}

}
