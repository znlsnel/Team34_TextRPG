using Org.BouncyCastle.Crypto.Signers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{

    public class PlayerCreateScene : Scene
    {
        public PlayerCreateScene(string name) : base(name) { }

        public override void EnterScene()
        {

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("\n원하시는 이름을 설정해주세요.");
            Console.Write(">> ");
            string name = Console.ReadLine();
            CreateClass(name);
        }

        public void CreateClass(string name)
        {
            Console.WriteLine();
			List<PlayerClass> playerClasses= new List<PlayerClass>();

			foreach (var d in DataManager.instance.playerClass)
                playerClasses.Add(d.Value);
            
            int cnt = 1;
             foreach (var pc in playerClasses)
			{
                string n = DataManager.instance.playerClassName[pc.classType];
                Console.WriteLine($"{cnt++} {n} - 공격력 : {pc.attack} \t 방어력 : {pc.armor} \t| 체력 : {pc.health}");
            }

            Console.WriteLine();
            Console.WriteLine("원하시는 직업을 선택해주세요.");

            int idx = SpartaRPG.SelectOption(1, playerClasses.Count)-1;
            DataManager.instance.playerData = new PlayerData(name, 1, playerClasses[idx].classType, playerClasses[idx].attack, playerClasses[idx].armor, playerClasses[idx].health, 1000);
            Doneplayer();
        }
        // TODO 2번
        public void Doneplayer()
        {

            Console.WriteLine();
            Console.WriteLine("캐릭터를 생성하였습니다.");
            Console.WriteLine("\n이대로 진행하시겠습니까?");
            Console.WriteLine();
            Console.WriteLine("1. 예");
            Console.WriteLine("2. 다시 생성하기");
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

            }
    }
}