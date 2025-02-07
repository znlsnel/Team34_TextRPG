using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
    // ==== 담당 기능 ====
    // 캐릭터 생성, 
    // 저장 데이터 불러오기,
    // 게임 시작

	public class SpartaRPG
	{
		PlayerCreateScene scene = new PlayerCreateScene();
		Town town = new Town();
		public void GameStart()
		{
			Console.WriteLine("게임에 접속하셨습니다.");
			Console.WriteLine("1. 새 게임");
			Console.WriteLine("2. 불러오기");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");

			int value = SelectOption(0, 2);
			if (value == 0)
			{
				Console.WriteLine("게임을 종료합니다.");
				return;
			}	
			else if (value == 1)
			{
				scene.CreatePlayer();
			}
			else if (value == 2)
			{

			}
				
		}

		public void NewGame()
		{
			town.EnterTown();
		}

		public static int SelectOption(int min = 0, int max = 0)
		{
			Console.WriteLine("\n원하시는 행동을 입력해주세요");
			Console.Write(">> ");

			string str;
			bool isNumeric;
			int ret;

			while (true)
			{
				str = Console.ReadLine();
				isNumeric = str.All(char.IsDigit); // 모든 문자가 숫자인지 체크
				ret = isNumeric && str.Length > 0 ? int.Parse(str) : min - 1; // 인자로 받은 범위 안의 수인지 체크

				// 조건에 부합하는 수를 입력받은 경우 반복문 종료
				if (isNumeric && ret >= min && ret <= max)
					break;

				// 조건에 부합하지 않는다면 반복하여 입력 받기
				Console.WriteLine("\n잘못된 입력입니다. 다시 입력해주세요.");
				Console.Write(">> ");
			}

			return ret;
		}
	}
}
