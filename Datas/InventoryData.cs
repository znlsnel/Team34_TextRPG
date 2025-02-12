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
		public Item? weapon;
		public Item? armor;
		 
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
            if (item == null)
                return;

            PlayerData pd = DataManager.instance.playerData;
            if (item is Weapon)
            {
                if (weapon == item)
                {
                    DataManager.instance.ReportTask(ETaskType.EquipItem, -1);
                    DataManager.instance.ReportTask(ETaskType.EquipWeapon, -1);
                    pd.attack -= weapon.value;
                    weapon = null;
                }
                else
                {
                    DataManager.instance.ReportTask(ETaskType.EquipItem, 1);
                    DataManager.instance.ReportTask(ETaskType.EquipWeapon, 1);
                    if(weapon != null)
                        pd.attack -= weapon.value;
                    weapon = item;
                    pd.attack += weapon.value;
                }
            }
            else
            {
                if (armor == item)
                {
                    DataManager.instance.ReportTask(ETaskType.EquipItem, -1);
                    pd.defense -= armor.value;
                    armor = null;
                }
                else
                {
                    DataManager.instance.ReportTask(ETaskType.EquipItem, 1);
                    if (armor != null)
                        pd.defense -= armor.value;
                    armor = item;
                    pd.defense += armor.value;
                }
            }
        }

        public void AddItem(Item item)
		{
			myItems.Add(item.name);
		}
        public void RemoveItem(Item item)
        {
            myItems.Remove(item.name);
        }
		public int HpPotion = 0;

		public int MpPotion = 0;
    }
}
