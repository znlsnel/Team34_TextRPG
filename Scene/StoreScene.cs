using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public class StoreScene : Scene
	{
		public StoreScene(string name) : base(name){}

		public override void EnterScene()
		{
			Console.Clear();
			Console.WriteLine("[상점]");
			Console.WriteLine("이곳에서 아이템을 구매할 수 있습니다.");

			List<Item> items = DataManager.instance.GetItems();
			ShowItemList(items, false);

			Console.WriteLine();
			Console.WriteLine("1. 아이템 구매");
			Console.WriteLine("2. 아이템 판매");

			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			int value = SpartaRPG.SelectOption(0, 2);

			switch(value)
			{
				case 0: 
					return;

				case 1: OpenStore();
					break;

				case 2: // 아이템 판매 기능
					break;
			}

			EnterScene();
		}

		void OpenStore()
		{
			List<Item> items = DataManager.instance.GetItems();
			PlayerData pd =  DataManager.instance.playerData;

			Console.Clear();
			Console.WriteLine("[상점 - 아이템 구매]");
			Console.WriteLine("이곳에서 아이템을 구매할 수 있습니다.");
			ShowItemList(items, true);

			Console.WriteLine("\n0. 나가기");
			int value = SpartaRPG.SelectOption(0, items.Count);

			if (value == 0) 
				return;

			Item item = items[value - 1];
			if (item.price > pd.gold || DataManager.instance.inventory.isItemInInventory(item))
			{
				OnPurchaseFailed(item);
				OpenStore();
				return;
			}

			pd.gold -= item.price;
			DataManager.instance.inventory.AddItem(item);
			OpenStore();
		}

		void OnPurchaseFailed(Item item)
		{
			PlayerData pd =  DataManager.instance.playerData;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("[아이템 구매 실패]");
			Console.ForegroundColor = ConsoleColor.White;

			if (item.price > pd.gold)
				Console.WriteLine("Gold가 부족합니다.");

			if (DataManager.instance.inventory.isItemInInventory(item))
				Console.WriteLine("이미 소유중인 아이템입니다.");

			Console.WriteLine("\n0. 나가기");
			SpartaRPG.SelectOption();
		}

		void ShowItemList(List<Item> items, bool showNum)
		{
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");

			int cnt = 1;
			foreach (Item item in items)
			{
				string num = showNum ? $"{cnt++}." : "-";
				bool isOwnedItem = DataManager.instance.inventory.isItemInInventory(item);
				string price = isOwnedItem ? "[구매완료]" : $"{item.price} G";
				string type = item is Weapon ? "공격력" : "방어력";
				// 아이템 이름, 아이템 수치, 아이템 설명, [가격 - 구매 완료]

				if (isOwnedItem)
					Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"{num} {item.name} \t| {type} +{item.value} \t| {item.description} \t| {price}");
				Console.ForegroundColor = ConsoleColor.White; 
			}
		}
	}
}
