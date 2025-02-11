using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public class MonsterData
	{
		public List<Monster[]> stages = new List<Monster[]>();
		Random rand = new Random();
		public MonsterData() 
		{
			InitMonster();		
		}

		void InitMonster()
		{
			// Stage 1 
			stages.Add(new Monster[4]
			{
				new Monster("미니언", 2, 5, 15, ()=>DataManager.instance.ReportTask(ETaskType.KillMinion)),
				new Monster("공허충", 3, 7, 20),
				new Monster("대포미니언", 4, 10, 25, ()=>DataManager.instance.ReportTask(ETaskType.KillMinion)),
				new Monster("슈퍼미니언", 5, 15, 30, ()=>DataManager.instance.ReportTask(ETaskType.KillMinion)),
			});

			// Stage 2 
			stages.Add(new Monster[4]
			{
				new Monster("슬라임", 5, 12, 40),
				new Monster("고블린", 6, 15, 40),
				new Monster("오크", 7, 20, 50),
				new Monster("트롤 ", 8, 25, 70),
			});

			// Stage 3 
			stages.Add(new Monster[4]
			{
				new Monster("스켈레톤", 8, 35, 50),
				new Monster("리자드맨 ", 9, 30, 70),
				new Monster("미믹  ", 10, 25, 150),
				new Monster("하피 ", 11, 55, 90),
			});
		}

		public List<Monster> GetMonster(int idx)
		{
			List<Monster> list = new List<Monster>();

			int length = stages[idx].Length;
			int cnt = rand.Next(3, 6);

			while (cnt-- > 0)
			{
				Monster mst = stages[idx][rand.Next(0, length)].DeepCopy();
				list.Add(mst);
			}

			return list;
		}
	}
}
