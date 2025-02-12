using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
    public partial class DataManager
    {

        
        public Dictionary<string, Potion> potions = new Dictionary<string, Potion>();
    
        

        public Dictionary<string, QuestData> quests = new Dictionary<string, QuestData>();
        Dictionary<ETaskType, Quest_Task> tasks = new Dictionary<ETaskType, Quest_Task>();

        public List<QuestData> SelectQuest()

        {
                List<QuestData> list = new List<QuestData>();
                foreach (var quest in quests)
                    list.Add(quest.Value);
                return list;
        }
        public void InitQuest()
        {
            CreateMainQuest(
                    "마을을 위협하는 미니언 처치", 

                    "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\n" +
                    "마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n" +
                    "모험가인 자네가 좀 처치해주게!",

                    new List<Quest_Task> { new Quest_Task("미니언 5마리 처치", 5, ETaskType.KillMinion)},
                    new List<Item> { items["청동 도끼"]},
                    500
                );

			CreateMainQuest(
	            "장비를 장착해보자",
                 
	            "자네가 모험을 떠나려면 적절한 장비를 갖춰야 하지 않겠나?\n" +
	            "장비를 장착하면 전투력이 올라가고, 앞으로의 여정이 훨씬 수월할 걸세.\n" +
	            "먼저 간단한 장비를 하나 착용해보도록 하게!",

	            new List<Quest_Task> { new Quest_Task("장비 장착하기", 1, ETaskType.EquipItem) },
	            new List<Item> { },
	            300
            );

			CreateMainQuest(
	            "더욱 더 강해지기!",

	            "모험을 하다 보면 점점 더 강한 적들과 맞서야 할 걸세.\n" +
	            "레벨이 오를수록 새로운 기술을 익히고, 더 강한 장비를 착용할 수 있지.\n" +
	            "레벨 5에 도달하여 스스로의 힘을 시험해보게!",

	            new List<Quest_Task> { new Quest_Task("레벨 5 도달하기", 5, ETaskType.LevelUp) },
	            new List<Item> { items["무쇠갑옷"] },
	            150
            );

			CreateMainQuest(
	            "나만의 무기를 찾아서!",

	            "맨손으로 싸울 생각은 아니겠지?\n" +
	            "전투에서 살아남으려면 자신의 손에 맞는 무기를 찾는 게 중요하네.\n" +
	            "어떤 무기든 좋으니 하나 장비해보도록 하게!",

	            new List<Quest_Task> { new Quest_Task("무기 장착하기", 1, ETaskType.EquipWeapon) },
	            new List<Item> {},
	            300
            );

		}
        public void AddTask(ETaskType type, Quest_Task task) => tasks.Add(type, task);

        public void ReportTask(ETaskType type, int num = 1)
        {
            if (tasks.ContainsKey(type))
                tasks[type]?.ProgressTask(num);  
		}
        public Quest_Task GetTask(ETaskType type)
        {
            if (tasks.ContainsKey(type))
                return tasks[type];
            return null; 
		}

		public void CreateMainQuest(string name, string dec, List<Quest_Task> tasks, List<Item> items, int gold)
        {
            QuestData quest = new QuestData(name, dec, tasks, items, gold);
            quests.Add(name, quest);
        }
        public List<Potion> GetPotions()
        {
            List<Potion> list = new List<Potion>();
            foreach (var index in potions)
                list.Add(index.Value);
            return list;
        }

      
        public void InitPotion()
        {
            CreatePotion("HpPotion", "Hp를 회복 시켜주는 물약입니다.", 0, 500);
            CreatePotion("MpPotion", "Mp를 회복 시켜주는 물약입니다.", 0, 500);
        }
        

        public void CreatePotion(string name, string dec, int value, int price)
        {
            Potion potion = new Potion(name, dec, value, price);
            potions.Add(name, potion);
        }

        

    }
}