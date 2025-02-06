using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
    public class PlayerStatus : Scene
    {
        public PlayerStatus() : base("플레이어 상태창") { }

        public override void EnterScene()
        {
            PlayerData pd = DataManager.instance.playerData;

            Console.Clear();
            Console.WriteLine("플레이어 상태창");
            Console.WriteLine("캐릭터 정보가 표시됩니다.");
            Console.WriteLine($"\n이름: {pd.name}");
            Console.WriteLine($"레벨: {pd.level}");
            Console.WriteLine($"직업: {pd.classType}");
            Console.WriteLine($"공격력: {pd.attack}");    // ($"공격력: {pd.attack}" + $"+({추가스텟})");
            Console.WriteLine($"방어력: {pd.defense}"); 
            Console.WriteLine($"최대체력: {pd.maxHp}");
            Console.WriteLine($"현재체력: {pd.hp}");
            Console.WriteLine($"Gold: {pd.gold} G");

            Console.WriteLine("\n0.나가기");
            Console.WriteLine("\n원하는 행동을 입력해주세요");
            Console.Write(">>");
            Console.Read();

            int value = SpartaRPG.SelectOption(0,0);
        }
    }
}
