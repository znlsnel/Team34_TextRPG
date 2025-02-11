using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
    public class QuestScene : Scene
    {
        public QuestScene(string name) : base(name) { }

        public override void EnterScene()
        {
            Console.Clear();
            Console.WriteLine("[퀘스트]");
            Console.WriteLine(" ");
            List<QuestData> quests = DataManager.instance.SelectQuest();

            Console.WriteLine("1.퀘스트 목록");
            Console.WriteLine("0.나가기");

            int value = SpartaRPG.SelectOption(0, 1);
            if (value == 0)
                return;


			ShowQuestList(quests);
			EnterScene();
        }

        void ShowQuestList(List<QuestData> quests)
        {
            Console.Clear();
            Console.WriteLine("[퀘스트 목록]\n");

            int cnt = 1;
            foreach (QuestData quest in quests)
                Console.WriteLine($"{cnt++}. {quest.name}");

            Console.WriteLine("\n0. 나가기");
            int idx = SpartaRPG.SelectOption(0, quests.Count);
            if (idx == 0)
                return;

            ShowQuestData(quests[idx-1]);
            ShowQuestList(quests);

		}

        void ShowQuestData(QuestData quest)
        {
			EQuestState state = quest.state;

			Quest_Task qt = DataManager.instance.GetTask(ETaskType.LevelUp);
			if (qt != null)
				qt.curCnt = DataManager.instance.playerData.level;

			Console.Clear();
            string qstate = state == EQuestState.Pending ? "수락 대기" : state == EQuestState.InProgress ? "진행중" : "완료!";
			ConsoleColor stateColor = state == EQuestState.Pending ? ConsoleColor.Yellow : state == EQuestState.InProgress ? ConsoleColor.Blue : ConsoleColor.Green;
			SpartaRPG.Write("Quest!!", ConsoleColor.Magenta);
			SpartaRPG.WriteLine($" - {qstate}", stateColor);


            Console.WriteLine($"\n"+quest.name);
            Console.WriteLine($"\n{quest.description}\n");
            
            if (state != EQuestState.Completed)
            {
				foreach (Quest_Task task in quest.tasks)
					SpartaRPG.WriteLine($"- {task.name} \t{Math.Min(task.curCnt, task.targetCnt)} / {task.targetCnt}", task.isCompleted ? ConsoleColor.DarkYellow : ConsoleColor.Yellow);

				Console.WriteLine("\n- 보상 -");
				foreach (Item reward in quest.items)
					SpartaRPG.WriteLine($"  {reward.name} x 1", ConsoleColor.Cyan);
				SpartaRPG.WriteLine($"  Gold + {quest.gold}", ConsoleColor.Cyan);
			}

            switch (state)
            {
                case EQuestState.Pending:
                    PendingQuest(quest);
                    break;
                case EQuestState.InProgress:
                    InProgressQuest(quest);
                    break;
				case EQuestState.Completed:
                    CompletedQuest(quest);  
					break;
			}
		}
        void PendingQuest(QuestData quest)
        {
			Console.WriteLine("\n1. 수락");
			Console.WriteLine("2. 거절");
            int select = SpartaRPG.SelectOption(1, 2);
            if (select == 1)
            {
                quest.SetState(EQuestState.InProgress);
                ShowQuestData(quest);
			}
		}

        void InProgressQuest(QuestData quest)
        {
			if (quest.IsCompleted())
            {
				Console.WriteLine("\n1. 보상 받기");
				Console.WriteLine("0. 돌아가기");
				int select = SpartaRPG.SelectOption(0, 1);
				if (select == 1)
				{
					foreach (Item reward in quest.items)
						DataManager.instance.inventory.AddItem(reward);
					DataManager.instance.playerData.gold += quest.gold;

					Console.Clear();
					SpartaRPG.WriteLine("[퀘스트 보상]", ConsoleColor.Magenta);
					Console.WriteLine("퀘스트 완료 보상을 습득했습니다!");
					Console.WriteLine("\n0. 돌아가기");
                    quest.SetState(EQuestState.Completed);
					SpartaRPG.SelectOption();
					ShowQuestData(quest);
				}
			}
            else
            {
				Console.WriteLine("\n0. 돌아가기");
				SpartaRPG.SelectOption();
			}
		}

        void CompletedQuest(QuestData quest)
        {
				SpartaRPG.WriteLine("\n**- 완료된 퀘스트입니다. -**\n", ConsoleColor.Blue);
			    Console.WriteLine("\n0. 돌아가기");
			    SpartaRPG.SelectOption();
		}
    }
}
