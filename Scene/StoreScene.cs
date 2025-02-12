using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Team34_TextRPG
{
	public class StoreScene : Scene
	{
		public StoreScene(string name) : base(name){}

		public override void EnterScene()
		{
			PlayerData pd = DataManager.instance.playerData;
			Console.Clear();
			Console.WriteLine("[상점]");
			Console.WriteLine("이곳에서 아이템을 구매할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{pd.gold}");
			List<Potion> potions = DataManager.instance.GetPotions();
            List<Item> items = DataManager.instance.GetItems();
			ShowItemList(items, false);
			ShowPotionList(potions, false, false);

			
			Console.WriteLine();
			Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 포션 구매");
			Console.WriteLine("3. 아이템 판매");

			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			int value = SpartaRPG.SelectOption(0, 3);

			switch(value)
			{
				case 0: 
					return;

				case 1: OpenStore();
					break;
				case 2: PotionStore();
					break;
				case 3: SellStore();// 아이템 판매 기능
					break;
			}

			EnterScene();
		}

		void OpenStore()
		{
			List<Item> items = DataManager.instance.GetItems();
			List<Potion> potions =  DataManager.instance.GetPotions();
			PlayerData pd =  DataManager.instance.playerData;

			Console.Clear();
			Console.WriteLine("[상점 - 아이템 구매]");
			Console.WriteLine("이곳에서 아이템을 구매할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{pd.gold}");
            ShowItemList(items, true);
			
			//show 포션리스트 포션이면 골드만 지불
			// 아이템 리스트를 출력할 때 무기장비,포션을 따로관리
			//만약 플레이어의 입력이 포션이라면?
			//출력시 포션이름 효과 현재보유개수
			//선택시 인벤토리++ 골드차감
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
				string price = isOwnedItem ? $"[구매완료] {item.price} G" : $" {item.price} G";
				string type = "";
				if (item is Weapon) type = "공격력";
				else if (item is Armor) type = "방어력";
				else if (item is Potion) type = "보유 개수";
                // 아이템 이름, 아이템 수치, 아이템 설명, [가격 - 구매 완료]



                if (isOwnedItem)
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White; 
                }

                Console.WriteLine($"{num} {item.name} \t| {type} +{item.value} \t| {item.description} \t| {price}");




            }
			Console.ForegroundColor= ConsoleColor.White;
		}

        public void ShowPotionList(List<Potion> potions, bool showNum ,bool showPrice)
        {
            Console.WriteLine();
            Console.WriteLine("[포션 목록]");
            int cnt = 1;
            foreach (Potion potion in potions)
            {
                string num = showNum ? $"{cnt++}." : "-";
                bool isOwnedItem = DataManager.instance.inventory.isItemInInventory(potion);
                string price = $" {potion.price} G";
				int potioncnt = DataManager.instance.inventory.HpPotion;
				if(potion.name == "MpPotion")
				{
					potioncnt = DataManager.instance.inventory.MpPotion;
				}

				// 아이템 이름, 아이템 수치, 아이템 설명, [가격 - 구매 완료]
				string priceprice = showPrice ? ($"{price}") : "";

                Console.WriteLine($"{num} {potion.name} \t| {"보유 개수"} : {potioncnt} \t| {potion.description} \t| {priceprice}");
				

            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        void SellStore()
		{

            List<Item> owneditems = DataManager.instance.inventory.GetMyItems();
            PlayerData pd = DataManager.instance.playerData;

            Console.Clear();
            Console.WriteLine("[상점 - 아이템 판매]");
            Console.WriteLine("이곳에서 보유한 아이템을 판매할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{pd.gold}");

            ShowItemList(owneditems, true);

          

			

            Console.WriteLine("\n0. 나가기");
			int value = SpartaRPG.SelectOption(0, owneditems.Count);

			if (value == 0)
			{
				return;
			}

			Item item = owneditems[value - 1];

            int sellPrice = item.price / 2; 
            pd.gold += sellPrice; 
            DataManager.instance.inventory.RemoveItem(item); 

            Console.Clear();
            Console.WriteLine($"[아이템 판매 완료]");
			Console.WriteLine($" {item.name}을(를) {sellPrice} G에 판매하였습니다.");
            Console.WriteLine("\n0. 계속하기");
            SpartaRPG.SelectOption(0, 0);

			SellStore();
            
        }
		void PotionStore()
		{
            
            List<Potion> potions = DataManager.instance.GetPotions();
            PlayerData pd = DataManager.instance.playerData;

            Console.Clear();
            Console.WriteLine("[상점 - 아이템 구매]");
            Console.WriteLine("이곳에서 아이템을 구매할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{pd.gold}");
            ShowPotionList(potions, true, true);
            Console.WriteLine("\n0. 나가기");
            int value = SpartaRPG.SelectOption(0, potions.Count);

			if (value == 0)
				return;
            Potion potion = potions[value - 1];
			if(potion.price > pd.gold)
			{
				OnPotionFailed(potion);
				PotionStore();
				return;
			}
			pd.gold -= potion.price;
			if(value == 1)
			DataManager.instance.inventory.HpPotion += 1;
			if(value == 2)
			DataManager.instance.inventory.MpPotion += 1;

			Console.Clear();
            Console.WriteLine("[포션 구매 완료~!]");
            Console.WriteLine($"{potion.name}을 구매 하셨습니다.");
            Console.WriteLine("\n0. 계속하기");
			SpartaRPG.SelectOption(0, 0);
			PotionStore();
			
        }
        void OnPotionFailed(Potion potion)
        {
            PlayerData pd = DataManager.instance.playerData;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[아이템 구매 실패]");
            Console.ForegroundColor = ConsoleColor.White;

            if (potion.price > pd.gold)
                Console.WriteLine("Gold가 부족합니다.");
;

            Console.WriteLine("\n0. 나가기");
            SpartaRPG.SelectOption();
        }



    }
}
