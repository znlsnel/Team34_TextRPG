using System;
using System.Collections.Generic;
using System.Drawing;
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
		AsciiArt asci = new AsciiArt();

		Lobby lobby = new Lobby();
		DataManager dataManager = new DataManager();
		public void GameStart()
		{
			Console.CursorVisible = false;
			CancellationTokenSource cts = new CancellationTokenSource();
			Task animationTask = asci.RunAnimation(cts.Token);
			lobby.EnterScene();
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
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
					isNumeric = keyInfo.KeyChar >= '0' && keyInfo.KeyChar <= '9';
					ret = isNumeric ? int.Parse(keyInfo.KeyChar.ToString()) : min - 1;

					// 조건에 부합하는 수를 입력받은 경우 반복문 종료
					if (isNumeric && ret >= min && ret <= max)
						break;

					return ret;
				}
			}
		}

		public static void WriteLine(string str, ConsoleColor color)
		{
			Console.ForegroundColor = color; 
			Console.WriteLine(str);
			Console.ForegroundColor = ConsoleColor.White;
		}
		  
		public static void Write(string str, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write(str);
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void Clear()
		{
			Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
        }
	}
}
