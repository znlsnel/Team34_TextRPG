﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{

    public class PlayerCreateScene
    {
        public string player { get; set; }
        public string Class { get; set; }

        public void CreatePlayer()
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("\n원하시는 이름을 설정해주세요.");
            Console.Write(">> ");
            string player = Console.ReadLine();
        }


                // 직업 선택 기능
                //전사만이 아닌 다른 직업의 선택지를 주고 생성시 고르는 기능
                //직업마다 기본 스탯과 스킬이 다를 수 있습니다
                public void CreateClass()
                {
                        // 1. 아래에 나열한 직업들을 List<string>에 담아서 출력 (for문)
                        // 2. 이후에 입력을 받고 플레이어가 선택한 직업을 List에서 뽑은 후, 출력
                        // "전사를 선택하였습니다"
                        Console.WriteLine("원하시는 직업을 선택해주세요.");

                        // TODO 1번
                        Console.WriteLine("\n1. 전사");
                        Console.WriteLine("\n2. 도적");
                        Console.WriteLine("\n3. 마법사");
                        Console.WriteLine("\n4. 궁수");
                        Console.WriteLine("\n5. 팔라딘");

                        Console.WriteLine("\n6. 취소");

                        Console.Write(">> ");
                        int Class = SpartaRPG.SelectOption(1, 6);
                        
                         // TODO 2번
                }
        public void Doneplayer()
        {
            Console.WriteLine("당신은 " + player + "!(이)고 직업은 " + CreateClass + " 입니다.");
            Console.WriteLine("\n이것으로 정하겠습니까?");
            Console.WriteLine();
            Console.WriteLine("1. 예");
            Console.WriteLine("\t2. 아니오");

            Console.Write(">> ");
            int Doneplayer = SpartaRPG.SelectOption(1, 2);

        }
    }
}
