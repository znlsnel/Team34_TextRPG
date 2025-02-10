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
        public Dictionary<string, QuestData> quests = new Dictionary<string, QuestData>();
        public Dictionary<ETaskType, Quest_Task> tasks = new Dictionary<ETaskType, Quest_Task>();
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

			

		}

		public void CreateMainQuest(string name, string dec, List<Quest_Task> tasks, List<Item> items, int gold)
        {
            QuestData quest = new QuestData(name, dec, tasks, items, gold);
            quests.Add(name, quest);
        }


        
    }
}