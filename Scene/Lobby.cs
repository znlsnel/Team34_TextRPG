using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public class Lobby : Scene
	{
		Town town = new Town();
		public Lobby() : base("로비"){}
		
		public override void EnterScene()
		{
			SpartaRPG.Clear();
			AsciiArt.instance.PrintAsciiArt("LOBBY", ConsoleColor.Yellow);
			Console.WriteLine("게임에 접속하신 것을 환영합니다.");
			Console.WriteLine("아래의 기능들 중 하나를 선택해 주세요.");
			Console.WriteLine();
			Console.WriteLine("1. 새 게임");
			Console.WriteLine("2. 불러오기");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");

			int value = SpartaRPG.SelectOption(0, 2);
			if (value == 0)
				return;

			switch(value)
			{
				case 1: // 캐릭터 생성씬과 연결
					town.EnterTown();
					break;
				case 2:
					LoadData();
					break;
			}

			EnterScene();
		}

		void LoadData()
		{
			SpartaRPG.Clear();
			Console.WriteLine("[게임 불러오기]");
			Console.WriteLine("아이디를 입력하여 저장된 게임을 불러올 수 있습니다.");
			Console.WriteLine();
			Console.Write("아이디 입력 : ");
			string id = Console.ReadLine();

			SpartaRPG.Clear();
			if (DataManager.instance.LoadFile(id))
			{
				Console.WriteLine("저장된 파일을 찾았습니다!");
				Console.WriteLine("1. 게임 시작");
				Console.WriteLine("0. 나가기");
				 
				int value = SpartaRPG.SelectOption(0, 1);
				if (value == 1)
					town.EnterTown();
				
			} 
			else
			{
				Console.WriteLine("파일을 찾지 못했습니다...");
				Console.WriteLine("0. 나가기");
				SpartaRPG.SelectOption();
			}


		} 
		
	}
}
