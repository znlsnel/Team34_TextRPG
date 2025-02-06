using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Team34_TextRPG
{
	public partial class DataManager
	{
		string GetSavePath(string id) => $"TextRPG_{id}";

		public void Savefile()
		{
			// TODO
			// 아이템 데이터 PlayerData.myItems로 옮기기
			// PlayerData.Weapon에 장착중인 무기 이름 
			// PlayerData.Armor에 장착중인 방어구 이름 

			string json = JsonConvert.SerializeObject(playerData);
			File.WriteAllText(GetSavePath(playerData.name), json);
		} 

		public bool LoadFile(string id)
		{
			string path = GetSavePath(id);
			if (File.Exists(path) == false)
				return false;

			string json = File.ReadAllText(path);
			playerData = JsonConvert.DeserializeObject<PlayerData>(json);

			// TODO
			// 현재 장착중인 아이템, 소지중인 아이템 목록 인벤토리로 업데이트

			return true;
		}
	}
}
