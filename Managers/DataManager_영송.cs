using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;


namespace Team34_TextRPG
{
	public partial class DataManager
	{
		public int dungeonStage = 1;
		public InventoryData inventory = new InventoryData();
		public MonsterData monsterData = new MonsterData();
		public List<Skill> skills = new List<Skill>()
		{
			new AlphaStrikeSkill(),
			new DubleStrikeSkill(),
			new HeallingSkill()
		};
		Dictionary<EClassType, PlayerClass> playerClasses = new Dictionary<EClassType, PlayerClass>();

		public PlayerClass GetPlayerClass(EClassType type) => playerClasses[type];
		public List<PlayerClass> GetPlayerClasses()
		{
			List<PlayerClass> list = new List<PlayerClass>();
			foreach (var p in playerClasses)
				list.Add(p.Value);
			return list;
		}


		string GetSavePath(string id) => $"TextRPG_{id}.json";

		List<Quest_Task> GetTasks()
		{
			List<Quest_Task> list = new List<Quest_Task>();
			foreach (var task in tasks)
				list.Add(task.Value);
			return list;
		}

		public void Savefile()
		{
			// 소유중인 아이템 저장
			List<Item> items = inventory.GetMyItems();
			foreach (Item item in items)
				playerData.saveData.myItems.Add(item.name);

			// 장착중인 아이템 저장
			playerData.saveData.weapon = inventory.weapon == null ?  "" : inventory.weapon.name;
			playerData.saveData.armor = inventory.armor == null ? "" : inventory.armor.name;

			// 퀘스트 진행도 저장
			List<QuestData> quests = GetQuests();
			foreach (QuestData quest in quests)
				playerData.saveData._questStates.Add((quest.name, quest.state));

			// 퀘스트 처리 목록 저장
			List<Quest_Task> myTasks = GetTasks();
            foreach (var task in myTasks)
				playerData.saveData._taskProgress.Add((task.type, task.curCnt));

			// 던전 스테이지 저장
			playerData.saveData.dungeonStage = dungeonStage;


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
			if (playerData == null)
			{
                Console.WriteLine("오류 발생 오류 발생 오류 발생");
				return false;
            }

			// 저장된 아이템 -> 인벤토리로 옮기기
			foreach (string item in playerData.saveData.myItems)
				inventory.AddItem(items[item]);

			// 장착했던 무기 -> 다시 장착
			if (items.ContainsKey(playerData.saveData.weapon))
				inventory.EquipItem(items[playerData.saveData.weapon]);

			// 장착했던 장비 -> 다시 장착
			if (items.ContainsKey(playerData.saveData.armor))
				inventory.EquipItem(items[playerData.saveData.armor]);

			// 저장된 퀘스트 상태 
			foreach (var quest in playerData.saveData._questStates)
				quests[quest.Item1].SetState(quest.Item2);

			// 퀘스트 진행도 
			foreach (var task in playerData.saveData._taskProgress)
			{
				if (tasks.ContainsKey(task.Item1))
					tasks[task.Item1].curCnt = task.Item2;
			} 

			// 던전 스테이지 상태
			dungeonStage = playerData.saveData.dungeonStage;

			return true;
		}

		void InitPlayerClass()
		{
			CreatePlayerClass(EClassType.PALADIN, "팔라딘", 7, 12, 120, 50);
			CreatePlayerClass(EClassType.WARRIOR, "전사", 10, 10, 100, 30);
			CreatePlayerClass(EClassType.ARCHER, "궁수", 15, 8, 70, 40);
			CreatePlayerClass(EClassType.ROGUE, "도적", 12, 8, 80, 50);
			CreatePlayerClass(EClassType.MAGE, "법사", 20, 5, 50, 100);
		}
		void CreatePlayerClass(EClassType type, string name, int att, int arm, int hp, int mp)
		{
			playerClasses.Add(type, new PlayerClass(type, name, att, arm, hp, mp));
		}
	}
}
