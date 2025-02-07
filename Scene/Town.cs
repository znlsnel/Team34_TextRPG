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
		Scene store = new StoreScene("상점");
		Scene inventory = new InventoryScene("인벤토리");
		Scene dungeon = new DungeonScene("ss");

		public void EnterTown()
		{
			Console.Clear();
            Console.WriteLine("이곳은 마을 입니다.");
            Console.WriteLine("아래의 기능중 하나를 선택해 주세요.");
			Console.WriteLine();
			Console.WriteLine("1. 상태창");
			Console.WriteLine("2. 인벤토리");
			Console.WriteLine("3 상점");
			Console.WriteLine("4 던전");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");

			int value = SpartaRPG.SelectOption(0, 4);

			if (value == 2)
				inventory.EnterScene();
			else if (value == 3)
				store.EnterScene();
			else if (value == 4)
				dungeon.EnterScene();
				
				
		}

	}
}
