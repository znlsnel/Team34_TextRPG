﻿using System;
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
            if (item is Weapon)
            {
                if (weapon == item)
                {
                    DataManager.instance.ReportTask(ETaskType.EquipItem, -1);
                    DataManager.instance.ReportTask(ETaskType.EquipWeapon, -1);
                    weapon = null;
                }
                else
                {
                    DataManager.instance.ReportTask(ETaskType.EquipItem, 1);
                    DataManager.instance.ReportTask(ETaskType.EquipWeapon, 1);
                    weapon = item;
                }
            }
            else
            {
                if (armor == item)
                {
                    DataManager.instance.ReportTask(ETaskType.EquipItem, -1);
                    armor = null;
                }
                else
                {
                    DataManager.instance.ReportTask(ETaskType.EquipItem, 1);
                    armor = item;
                }
            }
        }

        public void AddItem(Item item)
		{
			myItems.Add(item.name);
		}

	}
}
