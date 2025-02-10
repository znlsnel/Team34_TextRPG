using System;
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

            GetQuest();
            EnterScene();
        }
        void GetQuest()
        {
            List<QuestData> quests = DataManager.instance.SelectQuest();
            while (true)
            {
                Console.Clear();
                ShowQuestList(quests);

                Console.WriteLine("\n0.나가기");

                int value = SpartaRPG.SelectOption(0, quests.Count); //퀘스트 숫자만큼
                if (value == 0)
                    return;

                QuestData quest = quests[value - 1];
            }
        }

        
        void ShowQuestList(List<QuestData> quests)
        {
            Console.Clear();
            Console.WriteLine("[퀘스트 목록]");

            int cnt = 1;
            foreach (QuestData quest in quests)
                Console.WriteLine($"{cnt++}. {quest.name} \t| {quest.description}");
        }

        void ShowQuestData(QuestData quest)
        {
            SpartaRPG.WriteLine("Quest! !", ConsoleColor.Magenta);
            Console.WriteLine();
            Console.WriteLine(quest.name);
            Console.WriteLine();
            Console.WriteLine(quest.description);


        }
        
    }
}
