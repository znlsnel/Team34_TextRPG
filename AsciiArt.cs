using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Team34_TextRPG
{
	public class AsciiArt
	{
		public static AsciiArt instance;
		Dictionary<char, string> asciiArt = new Dictionary<char, string>()
		{
			{'A',  "  _  \r\n / \\ \r\n| o |\r\n|_n_|\r\n     \r\n"},
			{'B', " ___ \r\n| o )\r\n| o \\\r\n|___/\r\n     \r\n" },
			{'C', "  __ \r\n / _|\r\n( (_ \r\n \\__|\r\n     \r\n" },
			{'D', " __  \r\n|  \\ \r\n| o )\r\n|__/ \r\n     \r\n" },
			{'E', " ___ \r\n| __|\r\n| _| \r\n|___|\r\n     \r\n" },
			{'F', " ___ \r\n| __|\r\n| _| \r\n|_|  \r\n     \r\n"},
			{'G', "  __ \r\n / _|\r\n( |_n\r\n \\__/\r\n     \r\n"},
			{'H', " _ _ \r\n| U |\r\n|   |\r\n|_n_|\r\n     \r\n" },
			{'I', " _ \r\n| |\r\n| |\r\n|_|\r\n   \r\n" },
			{'J', "   _ \r\n  | |\r\nn_| |\r\n\\__/ \r\n     \r\n" },
			{'K', " _  _\r\n| |//\r\n|  ( \r\n|_|\\\\\r\n     \r\n"},
			{'L', " _   \r\n| |  \r\n| |_ \r\n|___|\r\n     "},
			{'M', " _   _ \r\n| \\_/ |\r\n| \\_/ |\r\n|_| |_|\r\n       \r\n" },
			{'N', " _  _ \r\n| \\| |\r\n| \\\\ |\r\n|_|\\_|\r\n      \r\n" },
			{'O',  "  _  \r\n / \\ \r\n( o )\r\n \\_/ \r\n     \r\n" },
			{'P',  " ___ \r\n| o \\\r\n|  _/\r\n|_|  \r\n     \r\n"},
			{'Q', "  _  \r\n / \\ \r\n( o )\r\n \\_,7\r\n     \r\n" },
			{'R' , " ___ \r\n| o \\\r\n|   /\r\n|_|\\\\\r\n     \r\n"},
			{'S' , " __ \r\n/ _|\r\n\\_ \\\r\n|__/\r\n    \r\n"},
			{'T', " ___ \r\n|_ _|\r\n | | \r\n |_| \r\n     \r\n" },
			{'U' , " _ _ \r\n| | |\r\n| U |\r\n|___|\r\n     \r\n"},
			{'V', " _ _ \r\n| | |\r\n| V |\r\n \\_/ \r\n     \r\n" },
			{'W' , " _ _ _ \r\n| | | |\r\n| V V |\r\n \\_n_/ \r\n       \r\n"},
			{'X' , "__ __\r\n\\ V /\r\n ) ( \r\n/_n_\\\r\n     \r\n"},
			{'Y' , "__ __\r\n\\ V /\r\n \\ / \r\n |_| \r\n     \r\n"},
			{'Z' , " ___ \r\n|_ / \r\n /(_ \r\n/___|\r\n     \r\n"},
			{'1', " _ \r\n/o|\r\n ||\r\n L|\r\n   \r\n"},
			{'2', " __ \r\n[o )\r\n /( \r\n/__|\r\n    \r\n"},
			{'3', " ___\r\n|_ /\r\n__)\\\r\n\\__/\r\n    \r\n"},
			{'4', "   . \r\n  /| \r\n /o| \r\nL___|\r\n     \r\n"},
			{'5', " __ \r\n| _/\r\n\\_ \\\r\n|__/\r\n    \r\n"},
			{'6', "  _ \r\n // \r\n/o \\\r\n\\__/\r\n    \r\n"},
			{'7', " ____\r\n|__ /\r\n  // \r\n //  \r\n     \r\n"},
			{'8', " __ \r\n(o )\r\n/o \\\r\n\\__/\r\n    \r\n"},
			{'9', " __ \r\n/o \\\r\n\\_ /\r\n // \r\n    \r\n"},
			{'0', "  _  \r\n / \\ \r\n| 0 |\r\n \\_/ \r\n     \r\n"},
		};
		public string currString = "";
		public AsciiArt()
		{
			instance = this;
			currString = PrintAsciiArt("WellCom");
		}
		public string PrintAsciiArt(string text)
		{
			text = text.ToUpper();
			string[] lines = new string[5]; // ASCII 아트는 5줄씩 구성됨

			foreach (char c in text)
			{
				if (asciiArt.ContainsKey(c))
				{
					string[] charLines = asciiArt[c].Split("\r\n");
					for (int i = 0; i < 5; i++)
					{
						lines[i] += charLines[i] + " "; // 글자 간격 추가
					}
				}
				else
				{
					for (int i = 0; i < 5; i++)
					{
						lines[i] += "     "; // 없는 문자 처리 (공백)
					}
				}
			}

			StringBuilder sb = new StringBuilder();
			foreach (string line in lines)
			{
				sb.AppendLine(line);
			}
			
			currString = sb.ToString();
			return currString;
		}

		public async Task RunAnimation(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				var (prevX, prevY) = Console.GetCursorPosition();
				Console.SetCursorPosition(0, 0); // 이전 줄 지우기 
				Console.WriteLine(AddWalls(currString));  
				Console.SetCursorPosition(prevX, prevY); // 이전 줄 지우기

				currString = ShiftLeft(currString);
				await Task.Delay(300); // 애니메이션 속도 조절
			}
		}

		string ShiftLeft(string asciiArt)
		{
			string[] lines = asciiArt.Split("\r\n", StringSplitOptions.None);
			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].Length > 0)
				{
					// 맨 앞 문자 제거하고 뒤에 추가
					lines[i] = lines[i].Substring(1) + lines[i][0];
				}
			}
			return string.Join("\r\n", lines);
		}

		string AddWalls(string asciiArt)
		{
			string[] lines = asciiArt.Split("\r\n", StringSplitOptions.None);
			for (int i = 0; i < lines.Length-1; i++)
			{
				lines[i] = "[] " + lines[i] + " []"; // 양 옆에 [] 추가
			}
			return string.Join("\r\n", lines);
		}

	}
}
