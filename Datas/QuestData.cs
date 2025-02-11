using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{

    public enum ETaskType
    {
        KillMinion,
        LevelUp,
        EquipItem,
    }

    public class Quest_Task
    {
        public string name;
		public int targetCnt = 0;
		public int curCnt = 0;
        public bool isCompleted => curCnt >= targetCnt; 
        public Quest_Task(string name, int targetCnt, ETaskType type)
        {
            this.name = name;
            this.targetCnt = targetCnt;
            DataManager.instance.AddTask(type, this); 
        }

        public void AchieveStep()
        {
            curCnt++;
            if (curCnt > targetCnt)
                curCnt = targetCnt;
        }
	}

    public class QuestData
    {
        public string name;
        public string description;
        public bool IsCompleted;
        public int gold;
        
        public List<Quest_Task> tasks;
        public List<Item> items;

        public QuestData(string name, string description, List<Quest_Task> tasks, List<Item> items, int gold)
        {
            this.name = name;
            this.description = description;
            this.IsCompleted = false;
            this.tasks = tasks;
            this.items = items;
            this.gold = gold;

		}
    }
}
