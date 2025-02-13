using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
    public class Recovery : Scene
    {
        public Recovery(string name) : base(name) { }

        public override void EnterScene()
        {
            PlayerData pd = DataManager.instance.playerData;
            InventoryData id = DataManager.instance.inventory;
			SpartaRPG.Clear();
			AsciiArt.instance.PrintAsciiArt("RECOVERY", ConsoleColor.Blue);
            Console.WriteLine("[회복하기]");
            Console.WriteLine("이곳에서 포션을 사용할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[포션 목록]");
            Console.WriteLine($"- HP 포션 \t| 보유 개수 : {id.HpPotion}");
            Console.WriteLine($"- MP 포션 \t| 보유 개수 : {id.MpPotion}");
            Console.WriteLine();
            Console.WriteLine("1. HP 포션 사용");
            Console.WriteLine("2. MP 포션 사용");
            Console.WriteLine("\n0.나가기");

            int value = SpartaRPG.SelectOption(0, 2);
            if (value == 0)
                return;

            if (value == 1)
                UseHpPotion();

            if (value == 2)
                UseMpPotion();
                    
			EnterScene();
        }
        void UseHpPotion()
        {
			SpartaRPG.Clear();
			PlayerData pd = DataManager.instance.playerData;
			InventoryData id = DataManager.instance.inventory;

			bool isHpFull = pd.hp == pd.maxHp;
            bool noPotion = id.HpPotion == 0;
			Console.WriteLine("[HP 포션]");

			if (isHpFull)
				Console.WriteLine("이미 체력이 회복된 상태입니다.");

			else if (noPotion)
			    Console.WriteLine("보유중인 HP포션 개수가 [0] 입니다.");

			if (!isHpFull && !noPotion)
			{
				int prev = pd.mp;
				int heal = 30;
				pd.Heal(heal);
				Console.WriteLine($"체력이 회복 되었습니다. MP {prev} -> {pd.hp}");
			}

			Console.WriteLine("\n0. 나가기");
			SpartaRPG.SelectOption();
			return;

			
        }

        void UseMpPotion()
        {
			SpartaRPG.Clear();
			PlayerData pd = DataManager.instance.playerData;
			InventoryData id = DataManager.instance.inventory;

			bool isMpFull = pd.mp == pd.maxMp;
			bool noPotion = id.MpPotion == 0;
			Console.WriteLine("[MP 포션]");


			if (isMpFull)
				Console.WriteLine("이미 마나가 회복된 상태입니다.");

			else if (noPotion)
				Console.WriteLine("보유중인 MP포션 개수가 [0] 입니다.");

			if (!isMpFull && !noPotion)
            {
				int prev = pd.mp;
				int heal = 30;
				pd.mp = Math.Clamp(pd.mp + heal, 0, pd.maxMp);
                Console.WriteLine($"마나가 회복 되었습니다. MP {prev} -> {pd.mp}");
			}

			Console.WriteLine("\n0. 나가기");
			SpartaRPG.SelectOption();
			return;
		}

	}
}