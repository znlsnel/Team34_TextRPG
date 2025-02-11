using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Team34_TextRPG;

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

			foreach (var item in myItems)
				list.Add(DataManager.instance.items[item]);

			return list;
		}
		public bool IsEquipped(Item item)
		{
			return weapon == item || armor == item;
		}

		public void EquipItem(Item item)
		{
			PlayerData pd = DataManager.instance.playerData;
			if (item is Weapon)
			{
				if (weapon == item)
				{
					pd.attack -= weapon.value;
					weapon = null;
				}
				else
				{
					if (weapon != null)
					pd.attack -= weapon.value;
					weapon = item;
					pd.attack += item.value;
				}
			}
			else
			{
				if (armor == item)
				{
					pd.defense -= armor.value;
					armor = null;
				}
				else
				{
					if(armor != null)
					pd.defense -= armor.value;
					armor = item;
					pd.defense += item.value;
				}
			}
		}

		public void AddItem(Item item)
		{
			myItems.Add(item.name);
		}

	}
}
