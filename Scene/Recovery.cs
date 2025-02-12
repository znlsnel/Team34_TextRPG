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

			SpartaRPG.Clear();
			AsciiArt.instance.PrintAsciiArt("RECOVERY", ConsoleColor.Blue);
            Console.WriteLine("회복");
			Console.WriteLine("포션을 사용하면 체력 30 회복할수있습니다.");
            Console.WriteLine($"최대체력: {pd.maxHp}");
            Console.WriteLine($"현재체력: {pd.hp}");

            Console.WriteLine("\n1.사용하기");
            Console.WriteLine("0.나가기");

            int value = SpartaRPG.SelectOption(0, 1);
            if (value == 0)
                return;

            switch (value)
            {
                case 1:
                    UsePotion();
                    break;
            }
            EnterScene();

        }
        public void UsePotion()
        {
            PlayerData pd = DataManager.instance.playerData;

            int heal = 30;
            pd.hp += heal;

            if(pd.hp > pd.maxHp)
            {
            pd.hp = pd.maxHp;
            }
        }
    }
}