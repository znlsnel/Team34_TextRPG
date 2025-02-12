using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public class SaveScene : Scene
	{
		public SaveScene(string name) : base(name){}

		public override void EnterScene()
		{
			SpartaRPG.Clear();
			AsciiArt.instance.PrintAsciiArt("SAVE DATA", ConsoleColor.Red);

			Console.WriteLine("[저장]");
			Console.WriteLine("이곳에서 게임 데이터를 저장할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("1. 저장하기");
			Console.WriteLine("2. 불러오기");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			int value = SpartaRPG.SelectOption(0, 2);
			if (value == 0)
				return;

			if (value == 1)
				SaveData();

			else if (value == 2)
				LoadData();

			EnterScene();
		}

		void SaveData()
		{
			SpartaRPG.Clear();

			for (int i = 0; i < 10; i++)
			{
				Console.Write(" - ");
				Thread.Sleep(50);
			}
			SpartaRPG.Clear();

			DataManager.instance.Savefile();
			Console.WriteLine("저장이 완료 되었습니다!");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			SpartaRPG.SelectOption();
		}

		void LoadData()
		{
			AsciiArt.instance.PrintAsciiArt("LOAD DATA", ConsoleColor.Yellow);

			SpartaRPG.Clear();
			Console.WriteLine("[불러오기]");
			Console.WriteLine("이곳에서 게임 데이터를 저장할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("불러올 캐릭터의 이름일 입력해주세요");
			Console.Write(">> ");
			string readData = Console.ReadLine();

			SpartaRPG.Clear();
			Console.WriteLine("[불러오기]");
			Console.WriteLine("정말 불러오시겠습니까? 기존 데이터는 삭제됩니다.");
			Console.WriteLine("\n1. 확인"); 
			Console.WriteLine("0. 취소");

			int value = SpartaRPG.SelectOption(0, 1);
			if (value == 0)
				return;

			SpartaRPG.Clear();
			if (DataManager.instance.LoadFile(readData))
				Console.WriteLine("불러오기 성공!");

			else
				Console.WriteLine("저장 데이터 불러오기에 실패했습니다.");


			Console.WriteLine("\n0. 나가기");
			SpartaRPG.SelectOption();

		}


	}
}
