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
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("\n원하시는 이름을 설정해주세요.");
            Console.Write(">> ");
            string name = Console.ReadLine();
            CreateClass(name);
        }

        public void CreateClass(string name)
        {
            Console.WriteLine();
			List<PlayerClass> pc= new List<PlayerClass>();

			foreach (var p in DataManager.instance.playerClass)
                pc.Add(p.Value);
            
            int cnt = 1;
             foreach (var cs in pc)
			{
                string n = DataManager.instance.playerClassName[cs.classType];
                Console.WriteLine($"{cnt++} {n} \t 공격력 : {cs.attack} \t 방어력 : {cs.armor} \t| 체력 : {cs.health}");
            }


            Console.WriteLine();
            Console.WriteLine("원하시는 직업을 선택해주세요.");

            int idx = SpartaRPG.SelectOption(1, pc.Count)-1;
            DataManager.instance.playerData = new PlayerData(name, 1, pc[idx].classType, pc[idx].attack, pc[idx].armor, pc[idx].health, 1000);
            Doneplayer();
        }
        // TODO 2번
        public void Doneplayer()
        {

            Console.Clear();
            Console.WriteLine("캐릭터 생성이 완료되었습니다.");
			Console.WriteLine("1. 마을로 가기");
            Console.WriteLine("0. 나가기");
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