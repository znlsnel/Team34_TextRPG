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

            switch (value)
            {
                case 0:
                    return;

                case 1:
                    GetQuest();
                    break;
            }
            EnterScene();
        }
        public void GetQuest()
        {
            List<QuestData> quests = DataManager.instance.SelectQuest();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[퀘스트]");
                ShowQuestList(quests, true);

                Console.WriteLine("0.나가기");

                int value = SpartaRPG.SelectOption(0, quests.Count); //퀘스트 숫자만큼
                if (value == 0)
                    return;

                QuestData quest = quests[value - 1];
            }
        }

        
        public void ShowQuestList(List<QuestData> quests, bool showNum)
        {
            Console.Clear();
            Console.WriteLine("퀘스트 목록");

            int cnt = 1;
            foreach (QuestData quest in quests)
            {
                
                string num = showNum ? $"{cnt++}." : "-"; //퀘스트 숫자 or -
                Console.WriteLine($"{num} {quest.name} \t| {quest.description}");
            }

        }
    }
}
