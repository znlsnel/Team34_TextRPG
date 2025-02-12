﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{

        // ==== 구현 기능 ====
        // 플레이어 데이터 
        // 아이템 데이터
        // 몬스터 데이터
        //  위 데이터에 대한 접근
        // 데이터는 따로 클래스를 만들기

    public partial class DataManager
    {
        public static DataManager instance;
        public PlayerData playerData = new PlayerData("sad", 1, EClassType.WARRIOR, 30, 30, 200, 20000);

        public Dictionary<string, Item> items = new Dictionary<string, Item>();


	    public DataManager()
        {
            if (instance == null)
                    instance = this;

			InitPotion();
			InitItem();
            InitQuest();
        }
		public List<Item> GetItems()
		{
			List<Item> list = new List<Item>();
			foreach (var index in items)
				list.Add(index.Value);


			return list;
		}

		public void InitItem()
		{
			CreateWeapon("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 600);
			CreateWeapon("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, 1500);
			CreateWeapon("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 2000);

			CreateArmor("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 5, 1000);
			CreateArmor("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 9, 2000);
			CreateArmor("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 15, 3500);
		}

		public void CreateWeapon(string name, string dec, int value, int price)
		{
			Weapon weapon = new Weapon(name, dec, value, price);
			items.Add(name, weapon);
		}
		public void CreateArmor(string name, string dec, int value, int price)
		{
			Armor armor = new Armor(name, dec, value, price);
			items.Add(name, armor);
		}
	}
}
