using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	internal class DungeonScene : Scene
	{
		List<Monster> monsters;
		static int stage = 1;
		int playerStartHp = 0;

		public DungeonScene(string name) : base(name){}

		public override void EnterScene() 
		{
			 monsters = DataManager.instance.monsterData.GetMonster(stage-1);
			playerStartHp = DataManager.instance.playerData.hp;
			EnterDungeon();
		}

		void EnterDungeon()
		{
			while (true)
			{
				if (ClearCheck())
				{ 
					ShowResult(true);
					return; 
				}

				PlayerData pd = DataManager.instance.playerData;
				if (pd.hp == 0)
				{
					ShowResult(false);
					return;
				}

				Console.Clear();
				SpartaRPG.WriteLine("Battle!!", ConsoleColor.Magenta);
				Console.WriteLine();

				PrintMonsterInfo(false);

				SpartaRPG.WriteLine("\n\n[내정보]", ConsoleColor.Yellow);
				Console.WriteLine($"Lv. {pd.level}\t{pd.name}");
				Console.WriteLine($"HP {pd.hp}/{pd.maxHp}");

				// 클리어 체크
				
				Console.WriteLine("\n1. 공격");
				 
				int value = SpartaRPG.SelectOption(1, 1);
				SelectMonster();
			}
		}

		bool ClearCheck()
		{
			bool clear = true;
			foreach (Monster monster in monsters)
			{
				if (monster.hp > 0)
				{
					clear = false;
					break;
				}
			}

			return clear;
		}
		void SelectMonster()
		{
			PlayerData pd = DataManager.instance.playerData;

			Console.Clear();
			SpartaRPG.WriteLine("Battle!!", ConsoleColor.Magenta);
			Console.WriteLine();

			PrintMonsterInfo(true);

			SpartaRPG.WriteLine("\n\n[내정보]", ConsoleColor.Yellow);
			Console.WriteLine($"Lv. {pd.level}\t{pd.name}");
			Console.WriteLine($"HP {pd.hp}/{pd.maxHp}");
			Console.WriteLine("\n0. 취소");

			int value = SpartaRPG.SelectOption(0, monsters.Count);
			if (value == 0)
				return;
			
			while (monsters[value-1].hp <= 0)
			{
				Console.WriteLine("\n이미 죽은 몬스터입니다");
				value = SpartaRPG.SelectOption(0, monsters.Count);
				if (value == 0)
					return;
			}

			StartBattle(pd, monsters[value - 1]);

			foreach (Monster mst in monsters)
			{
				if (pd.hp > 0 && mst.hp > 0)
					StartBattle(mst, pd);
			}
			
		}
		
		void StartBattle(Character attacker, Character target)
		{
			Random rand = new Random();
			int damage = attacker.attack * rand.Next(90, 110) / 100;
			bool isCritical = rand.Next(0, 100) < 15;
			bool isDodged = rand.Next(0, 100) < 10;

			if (isCritical)
				damage *= 16 / 10; 

			Console.Clear();
			SpartaRPG.Write("Battle!!", ConsoleColor.Magenta);

			if (attacker is PlayerData)
				SpartaRPG.WriteLine(" - 플레이어 턴!", ConsoleColor.Green);
			else
				SpartaRPG.WriteLine(" - 몬스터 턴!", ConsoleColor.Red);
			
			Console.WriteLine();
			Console.WriteLine($"Lv.{attacker.level} {attacker.name} 의 공격!");

			if (isDodged)
			{
				Console.WriteLine($"{target.name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
				Console.WriteLine("\n0. 다음"); 
				SpartaRPG.SelectOption();
				return;
			}

			SpartaRPG.Write($"{target.name}", attacker is PlayerData ? ConsoleColor.Red: ConsoleColor.Green);
			Console.Write(" 을(를) 맞췄습니다 "); 
			SpartaRPG.WriteLine($"[데미지 : {damage}] {(isCritical ? " - 치명타 공격!!" : "")}", attacker is PlayerData ? ConsoleColor.Green : ConsoleColor.Red);

			Console.WriteLine($"\nLv.{target.level} {target.name}");

			if (target.hp <= damage)
				Console.WriteLine($"HP {target.hp} -> Dead");
			else
				Console.WriteLine($"HP {target.hp} -> {target.hp - damage}");
			target.hp = Math.Max(0, target.hp - damage);

			Console.WriteLine("\n0. 다음");
			SpartaRPG.SelectOption();
		}

		void ShowResult(bool success)
		{
			Console.Clear();
			PlayerData pd = DataManager.instance.playerData;
			SpartaRPG.WriteLine("Battle!!", ConsoleColor.Magenta);
			Console.WriteLine();
			SpartaRPG.WriteLine($"{(success ? "Victory" : "You Lose")}", success ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed);
			Console.WriteLine();

			if (success)
			{
				Console.WriteLine($"몬스터에서 몬스터 {monsters.Count}마리를 잡았습니다.");
				Console.WriteLine();

				int total = 0;
				foreach (Monster mst in monsters)
					total += mst.level;

				SpartaRPG.WriteLine($"경험치 {pd.exp} -> {pd.exp + total}", ConsoleColor.Yellow);
				int prevLevel = pd.level;
				bool levelUp = pd.AddExp(total);
				if (levelUp)
					SpartaRPG.WriteLine($"Level Up ! ! {prevLevel} -> {pd.level}", ConsoleColor.Yellow);
			}


			ConsoleColor color = ConsoleColor.DarkRed; 
			{
				float rate = (float)pd.hp / pd.maxHp;
				if (rate > 0.8)
					color = ConsoleColor.Green;
				else if (rate > 0.5)
					color = ConsoleColor.Blue;
				else if (rate > 0.25)
					color = ConsoleColor.Red;
			}
			
			SpartaRPG.WriteLine($"HP {playerStartHp} -> {pd.hp}", color);

			Console.WriteLine("\n0. 마을로 돌아가기");
			SpartaRPG.SelectOption(); 
		}


		void PrintMonsterInfo(bool includeNum)
		{
			for (int i = 0; i < monsters.Count; i++)
			{
				Monster mst = monsters[i];
				string num = includeNum ? $"{i + 1} " : "";
				string HP = mst.hp > 0 ? "HP " + mst.hp : "Dead";
				SpartaRPG.WriteLine($"{num}Lv.{mst.level} {mst.name} {HP}", mst.hp > 0 ? ConsoleColor.White : ConsoleColor.DarkGray);
			}
		}
	}
}
