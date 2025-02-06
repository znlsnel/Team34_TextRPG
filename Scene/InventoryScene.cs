using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public class InventoryScene : Scene
	{
		public InventoryScene(string name) : base(name){}


		public override void EnterScene()
		{
			Console.WriteLine("[인벤토리]");
			Console.WriteLine("이곳에서 소유중인 아이템을 관리할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
		}


	}
}
