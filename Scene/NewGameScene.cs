using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public class NewGameScene : Scene
	{
		public NewGameScene(string name) : base(name){}
		Town town = new Town();
		public override void EnterScene()
		{
			SpartaRPG.Clear();
			AsciiArt.instance.PrintAsciiArt("NEW-GAME", ConsoleColor.Green);
			Console.WriteLine("[새 게임]");
			Console.WriteLine("이곳에서 캐릭터를 생성할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 캐릭터 생성");
            Console.WriteLine("0. 나가기");
			int value = SpartaRPG.SelectOption(0, 1);

			if (value == 0)
				return;

			CreateCharacter();
			EnterScene();
		}

		void CreateCharacter()
		{
			SpartaRPG.Clear();
			Console.WriteLine("[캐릭터 생성]");
			Console.WriteLine("생성할 닉네임(아이디)을 입력해주세요\n");
            Console.Write(">>  ");
            string id = "";

			while(id.Length < 2)
				id = Console.ReadLine();

			SelectClass(id);
		}

		void SelectClass(string id)
		{
			SpartaRPG.Clear();
			Console.WriteLine("[직업 선택]");
			Console.WriteLine("직업을 선택해주세요");
			Console.WriteLine();
			List<PlayerClass> pc = DataManager.instance.GetPlayerClasses();

			for (int i = 0; i < pc.Count; i++)
				Console.WriteLine($"{i + 1}. {pc[i].name} \t|공격력 : {pc[i].attack} " +
					$"\t | 방어력 : {pc[i].armor} \t|HP : {pc[i].health}  \t|MP : {pc[i].mp}");

			Console.WriteLine("\n0. 나가기");
			int value = SpartaRPG.SelectOption(0, pc.Count);
			if (value == 0)
				return;

			PlayerClass myClass = pc[value - 1];
			DataManager.instance.playerData = new PlayerData(id, myClass.classType, myClass.attack, 
				myClass.armor,myClass.health, myClass.mp);

            Console.WriteLine();
			for (int i = 0; i < 10; i++)
			{
                Console.Write(" - ");
                Thread.Sleep(50);		
			}
			GoTown();
		}

		void GoTown()
		{
			SpartaRPG.Clear();
			Console.WriteLine("[캐릭터 생성 완료!]");
			Console.WriteLine("캐릭터 생성이 완료되었습니다. 마을로 가서 모험을 즐겨보세요!");
            Console.WriteLine();
            Console.WriteLine("1. 마을로 가기");
            Console.WriteLine("0. 나가기");

			int value = SpartaRPG.SelectOption(0, 1);
			if (value == 0)
				return;

			town.EnterTown();
		}
	}

}
