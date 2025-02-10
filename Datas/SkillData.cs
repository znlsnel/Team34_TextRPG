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
		
			for (int i = 0; i < monsters.Count; i++)
				Console.WriteLine($"{i+1}. Lv.{monsters[i].level} {monsters[i].name}  HP {monsters[i].hp}");

			int value = SpartaRPG.SelectOption(1, monsters.Count);

			while (monsters[value-1].hp == 0)
			{
				Console.Write("이미 죽은 몬스터입니다.");
				value = SpartaRPG.SelectOption(1, monsters.Count);
			}

			int prev = monsters[value - 1].hp;
			monsters[value - 1].Damage(pd.attack * 2);
			Console.WriteLine($"Lv.{monsters[value - 1].level} {monsters[value - 1].name}을(를) 공격했습니다  HP {prev} -> {monsters[value-1].hp}");
			Console.WriteLine("\n0. 돌아가기");

			SpartaRPG.SelectOption(1, monsters.Count);
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
			while (idxs.Count < 2)
				idxs.Add(rand.Next(0, monsters.Count - 1));

			Console.WriteLine("\n1. 스킬 사용");
			SpartaRPG.SelectOption(1, 1);

			foreach (int i in idxs)
			{
				int hp = monsters[i].hp;
				monsters[i].Damage(pd.attack * 2);
				Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name}  HP {hp} -> {monsters[i].hp}");
			}

			Console.WriteLine("\n0. 돌아가기");
			SpartaRPG.SelectOption(1, monsters.Count);
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
			Console.WriteLine($"{pd.name} HP {hp} -> {pd.hp}"); 
			

			Console.WriteLine("\n0. 돌아가기");
			SpartaRPG.SelectOption(1, monsters.Count);
		}
	}

	public class SkillData
	{
	}
}
