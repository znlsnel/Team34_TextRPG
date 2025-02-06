using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	// ==== 구현 기능 ====
	// 각 Scene으로 이동
	// 게임 종료

	public class Town
	{
	

		public void EnterTown()
		{
			Console.Clear();
            Console.WriteLine("이곳은 마을 입니다.");
            Console.WriteLine("아래의 기능중 하나를 선택해 주세요.");
			Console.WriteLine();
			Console.WriteLine("1. 상태창");
			Console.WriteLine("2. 전투시작");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");

			int value = SpartaRPG.SelectOption(0,2);
			
			
				
				
		}

	}
}
