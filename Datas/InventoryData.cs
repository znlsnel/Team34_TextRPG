using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public class InventoryData
	{
		HashSet<string> myItems = new HashSet<string>();
		Item? weapon;
		Item? armor;
		 
		public bool isItemInInventory(Item item)
		{
			return myItems.Contains(item.name);
		}


		public List<Item> GetMyItems()
		{
			List<Item> list = new List<Item>();

			// TODO
			// Dictionary로 저장된 아이템 목록에 접속 후 리스트에 담기
			//foreach (var item in myItems)
		//		list.Add()
		 
			return list;
		}
		public bool IsEquipped(Item item)
		{
			return weapon == item || armor == item;
		}

		public void EquipItem(Item item)
		{ 
			if (item is Weapon)
			{
				if (weapon == item)
					weapon = null;
				else
					weapon = item;
			}
			else
			{
				if (armor == item)
					armor = null;
				else
					armor = item; 
			}
		}

	}
}
