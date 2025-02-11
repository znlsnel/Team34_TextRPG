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

		
		
		Scene status = new PlayerStatus("상태 확인");
		Scene store = new StoreScene("상점");
		Scene inventory = new InventoryScene("인벤토리");
		Scene dungeon = new DungeonScene("던전");
		Scene recovery = new Recovery("회복하기");
		Scene quest = new QuestScene("퀘스트");

		List<Scene> scenes;

		public Town()
		{
			scenes = new List<Scene>()
			{
				status,
				recovery,
				inventory,
				store,
				quest,
				dungeon,
			};
		}

		public void EnterTown()
		{
		
			Console.Clear();
			Console.WriteLine("이곳은 마을 입니다.");
			Console.WriteLine("아래의 기능중 하나를 선택해 주세요.");
			Console.WriteLine();

			for (int i = 0; i < scenes.Count; i++)
				Console.WriteLine($"{i + 1}. {scenes[i].GetDIsplayName()}");

			Console.WriteLine();
			Console.WriteLine("0. 나가기");

			int value = SpartaRPG.SelectOption(0, scenes.Count);
			if (value == 0)
				return;

			scenes[value - 1].EnterScene();
			EnterTown();
		}

	}
}
