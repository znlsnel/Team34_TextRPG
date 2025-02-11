﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine("[퀘스트 목록]");

            int cnt = 1;
            foreach (QuestData quest in quests)
                Console.WriteLine($"{cnt++}. {quest.name}");

            int idx = SpartaRPG.SelectOption(1, quests.Count)-1;
            ShowQuestData(quests[idx]);
        }

        void ShowQuestData(QuestData quest)
        {
            Console.Clear();
            SpartaRPG.WriteLine("Quest! !", ConsoleColor.Magenta);
            Console.WriteLine();
            Console.WriteLine(quest.name);
            Console.WriteLine();
            Console.WriteLine(quest.description);
			Console.WriteLine();

            
			foreach (Quest_Task task in quest.tasks)
            {
                SpartaRPG.WriteLine($"- {task.name} \t{task.curCnt} / {task.targetCnt}", task.isCompleted ? ConsoleColor.DarkYellow : ConsoleColor.Yellow);
            }

            bool questCompleted = quest.IsCompleted();
            if (questCompleted)
            {
				Console.WriteLine("\n1. 보상 받기");
                foreach (Item reward in quest.items)
                    Console.WriteLine($"   {reward.name} + 1");
                Console.WriteLine($"   Gold + {quest.gold}");

				Console.WriteLine("\n0. 나가기");
				int select = SpartaRPG.SelectOption(0, 1);

                if (select == 0)
                    return;
                else
                {
                    foreach (Item reward in quest.items)
                        DataManager.instance.inventory.AddItem(reward);
                    DataManager.instance.playerData.gold += quest.gold;

                    Console.Clear();
                    SpartaRPG.WriteLine("[퀘스트 보상]", ConsoleColor.Magenta);
                    Console.WriteLine("퀘스트 완료 보상을 습득했습니다!");
                    Console.WriteLine("\n0. 나가기");
                    SpartaRPG.SelectOption();
				}
			}
            else
            {
				Console.WriteLine("\n0. 나가기");
				SpartaRPG.SelectOption();
			}
		}
        
    }
}
