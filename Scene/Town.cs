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
            Console.WriteLine("마을");
			Console.WriteLine("0. 나가기");
			SpartaRPG.SelectOption();

        }
	}
}
