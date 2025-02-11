using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.Entities.Behaviors;

namespace Team34_TextRPG
{

    public class PlayerCreateScene : Scene
    {

        public string player { get; set; }
        public string Class { get; set; }
        public PlayerCreateScene(string name) : base(name) { }

        public override void EnterScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("\n원하시는 이름을 설정해주세요.");
            Console.Write(">> ");
            player = Console.ReadLine();
            CreateClass();
        }

        // 직업 선택 기능
        //전사만이 아닌 다른 직업의 선택지를 주고 생성시 고르는 기능
        //직업마다 기본 스탯과 스킬이 다를 수 있습니다
        public void CreateClass()
        {
            // 1. 아래에 나열한 직업들을 List<string>에 담아서 출력 (for문)
            // 2. 이후에 입력을 받고 플레이어가 선택한 직업을 List에서 뽑은 후, 출력
            // "전사를 선택하였습니다"


            // TODO 1번
            List<string> list = new List<string>()
            {
              "전사",
              "도적",
              "마법사",
              "궁수",
              "팔라딘",
            };
            Console.Clear();
            Console.WriteLine("원하시는 직업을 선택해주세요.");
            Console.WriteLine();


            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{i + 1}.{list[i]}");

            int classJob = SpartaRPG.SelectOption(1, 5);
            Class = list[classJob -1];
            Doneplayer();


        }
        // TODO 2번
        public void Doneplayer()
        {
            Console.WriteLine();
            Console.WriteLine("당신은 " + player + "(이)고 직업은 " + Class + " 입니다.");
            Console.WriteLine("\n이것으로 정하겠습니까?");
            Console.WriteLine();
            Console.WriteLine("1. 예");
            Console.WriteLine("2. 아니오");


            int done = SpartaRPG.SelectOption(1, 2);
            Town town = new Town();

            if (done == 1)
            {
                town.EnterTown();
            }

            else
            {
                EnterScene();
            }

            Dictionary<EClassType, string> classJob = new Dictionary<EClassType, string>()
            {
                { EClassType.WARRIOR,"전사"},
                { EClassType.ROGUE,"도적"},
                { EClassType.MAGE,"마법사"},
                { EClassType.ARCHER,"궁수"},
                { EClassType.PALADIN,"팔라딘"},
            };


            Dictionary<EClassType, PlayerClass> dic = new Dictionary<EClassType, PlayerClass>();
            dic.Add(EClassType.WARRIOR, new PlayerClass(EClassType.WARRIOR, 10, 10, 100));
            dic.Add(EClassType.ROGUE, new PlayerClass(EClassType.ROGUE, 6, 14, 90));
            dic.Add(EClassType.MAGE, new PlayerClass(EClassType.MAGE, 20, 5, 150));
            dic.Add(EClassType.ARCHER, new PlayerClass(EClassType.ARCHER, 8, 7, 120));
            dic.Add(EClassType.PALADIN, new PlayerClass(EClassType.PALADIN, 7, 8, 110));




            int value = 1;

            if (value == 1)
            {
                DataManager.instance.playerData.classType = dic[EClassType.WARRIOR].classType;
                DataManager.instance.playerData.attack = dic[EClassType.WARRIOR].attack;
                DataManager.instance.playerData.defense = dic[EClassType.WARRIOR].armor;
                DataManager.instance.playerData.hp = dic[EClassType.WARRIOR].health;
            }
            else if (value == 2)
            {
                DataManager.instance.playerData.classType = dic[EClassType.ROGUE].classType;
                DataManager.instance.playerData.attack = dic[EClassType.ROGUE].attack;
                DataManager.instance.playerData.defense = dic[EClassType.ROGUE].armor;
                DataManager.instance.playerData.hp = dic[EClassType.ROGUE].health;
            }


            else if (value == 3)
            {
                DataManager.instance.playerData.classType = dic[EClassType.MAGE].classType;
                DataManager.instance.playerData.attack = dic[EClassType.MAGE].attack;
                DataManager.instance.playerData.defense = dic[EClassType.MAGE].armor;
                DataManager.instance.playerData.hp = dic[EClassType.MAGE].health;
            }

            else if (value == 4)
            {
                DataManager.instance.playerData.classType = dic[EClassType.ARCHER].classType;
                DataManager.instance.playerData.attack = dic[EClassType.ARCHER].attack;
                DataManager.instance.playerData.defense = dic[EClassType.ARCHER].armor;
                DataManager.instance.playerData.hp = dic[EClassType.ARCHER].health;
            }

            else
            {
                DataManager.instance.playerData.classType = dic[EClassType.PALADIN].classType;
                DataManager.instance.playerData.attack = dic[EClassType.PALADIN].attack;
                DataManager.instance.playerData.defense = dic[EClassType.PALADIN].armor;
                DataManager.instance.playerData.hp = dic[EClassType.PALADIN].health;

            }

            PlayerData playerData = DataManager.instance.playerData;



        }
    }
}