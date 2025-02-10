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
			 monsters = DataManager.instance.monsterData.GetMonster(stage);
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
			Console.Clear();
			SpartaRPG.Write("Battle!!", ConsoleColor.Magenta);

			if (attacker is PlayerData)
				SpartaRPG.WriteLine(" - 플레이어 턴!", ConsoleColor.Green);
			else
				SpartaRPG.WriteLine(" - 몬스터 턴!", ConsoleColor.Red);


			Console.WriteLine();
			Console.WriteLine($"Lv.{attacker.level} {attacker.name} 의 공격!");

			SpartaRPG.Write($"{target.name}", attacker is PlayerData ? ConsoleColor.Red: ConsoleColor.Green);
			Console.Write(" 을(를) 맞췄습니다 "); 
			SpartaRPG.WriteLine($"[데미지 : {attacker.attack}]", attacker is PlayerData ? ConsoleColor.Green : ConsoleColor.Red);

			Console.WriteLine($"\nLv.{target.level} {target.name}");

			if (target.hp <= attacker.attack)
				Console.WriteLine($"HP {target.hp} -> Dead");
			else
				Console.WriteLine($"HP {target.hp} -> {target.hp - attacker.attack}");
			target.hp = Math.Max(0, target.hp - attacker.attack);

			Console.WriteLine("\n0. 다음");
			SpartaRPG.SelectOption();

			if (target.hp == 0)
				return;

		}

		void ShowResult(bool success)
		{
			Console.Clear();
			PlayerData pd = DataManager.instance.playerData;
			SpartaRPG.WriteLine("Battle!!", ConsoleColor.Magenta);
			Console.WriteLine();
			SpartaRPG.WriteLine($"{(success ? "Victory" : "You Lose")}", success ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed);

			if (success)
				Console.WriteLine($"몬스터에서 몬스터 {monsters.Count}마리를 잡았습니다.\n");

			Console.WriteLine($"HP {playerStartHp} -> {pd.hp}");
			Console.WriteLine("0. 마을로 돌아가기");
			SpartaRPG.SelectOption(); 
		}


		void PrintMonsterInfo(bool includeNum)
		{
			for (int i = 0; i < monsters.Count; i++)
			{
				Monster mst = monsters[i];
				string num = includeNum ? $"{i + 1} " : "";
				string HP = mst.hp > 0 ? "HP " + mst.hp : "Dead";
				SpartaRPG.WriteLine($"{num}Lv.{mst.level} {mst.name} {HP}", mst.hp > 0 ? ConsoleColor.White : ConsoleColor.Red);
			}
		}
	}
}
