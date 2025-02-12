using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public class InventoryScene : Scene
	{
		public InventoryScene(string name) : base(name){}
		public override void EnterScene() 
		{
			Console.Clear();
			Console.WriteLine("[인벤토리]");
			Console.WriteLine("이곳에서 소유중인 아이템을 관리할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");

			Console.WriteLine("1. 장착 관리");
            Console.WriteLine("2. 포션 관리");
			Console.WriteLine("0. 나가기");
			int value = SpartaRPG.SelectOption(0, 2);
			if (value == 1) OpenInventory(); 
			else if (value == 2) OpenPotionInventory();

		} 

		void OpenInventory(bool equipMode = false)
		{
			Console.Clear();
			Console.WriteLine("[인벤토리 - 장착관리]");
			Console.WriteLine("이곳에서 아이템을 장착할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			InventoryData inventory = DataManager.instance.inventory;
			List<Item> items = DataManager.instance.inventory.GetMyItems();

			int cnt = 1;
			foreach (Item item in items)
			{
				// 장착 모드의 경우 숫자 포함 (1.)
				string num = equipMode ? $"{cnt++}" : "";
				bool isEquipped = inventory.IsEquipped(item);
				string equip = isEquipped ? "[E]" : "";

				// 장착중인 아이템은 초록색으로 표시
				if (isEquipped) Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"-{num}{equip} {item.name} \t| {(item is Weapon ? "공격력" : "방어력")} +{item.value} \t| {item.description} \t");
				 
				// 다시 하얀 글씨로 돌아오기
				Console.ForegroundColor = ConsoleColor.White;
			}

			Console.WriteLine(); 
			if (items.Count == 0)
			{
				Console.WriteLine("소지중인 아이템이 없습니다!");
				Console.WriteLine();
				Console.WriteLine("0. 나가기");
				SpartaRPG.SelectOption();
				return;
			}

			 if (equipMode == false)
				Console.WriteLine("1. 장착");
			
			Console.WriteLine("0. 나가기");

			int value = SpartaRPG.SelectOption(0, equipMode ? items.Count : 1);
			if (value == 0)
				return;

			// 장착모드가 false이고 value가 0이 아니라면 장착 모드로 다시 실행
			if (equipMode == false)
			{
				OpenInventory(true);
				return;
			}

			DataManager.instance.inventory.EquipItem(items[value - 1]);
			OpenInventory(equipMode);
		}
		void OpenPotionInventory()
		{

			StoreScene storeScene = new StoreScene("보유 포션");
			List<Potion> potions = DataManager.instance.GetPotions();

            Console.Clear();
			Console.ForegroundColor= ConsoleColor.DarkCyan;
            Console.WriteLine("[포션 관리]");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
            Console.WriteLine("이곳에서 포션보유 개수를 확인 할 수 있습니다..");
            Console.WriteLine();
            Console.WriteLine();

			storeScene.ShowPotionList(potions, false, false);
			
            Console.WriteLine("\n0. 나가기");
			int value = SpartaRPG.SelectOption(0, 0);
			return;




        }

	}
}
