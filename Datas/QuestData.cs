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
		public ETaskType type;

        public Quest_Task(string name, int targetCnt, ETaskType type)
        {
            this.name = name;
            this.targetCnt = targetCnt;
            this.type = type;
        }

        public void AchieveStep()
        {
            curCnt++;
            if (curCnt > targetCnt)
                curCnt = targetCnt;
        }
	}
	public enum EQuestState
	{
		Pending,   // 퀘스트 수락 대기
		InProgress, // 진행 중
		Completed   // 완료
	}

	public class QuestData
    {
        public string name;
        public string description;
        public int gold;
        
        public List<Quest_Task> tasks;
        public List<Item> items;
        public EQuestState state { get; private set; } = EQuestState.Pending;

        public QuestData(string name, string description, List<Quest_Task> tasks, List<Item> items, int gold)
        {
            this.name = name;
            this.description = description;
            this.tasks = tasks;
            this.items = items;
            this.gold = gold;
		}

		public bool IsCompleted()
        {
            foreach (Quest_Task task in tasks)
                if (task.isCompleted == false)
                    return false;

            return true;
        }
        public void SetState(EQuestState state)
        {
            this.state = state;
            if (this.state == EQuestState.InProgress)
            {
                foreach (Quest_Task task in  this.tasks)
				    DataManager.instance.AddTask(task.type, task);
			}
        }
	}
}
