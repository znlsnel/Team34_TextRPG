using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{

        // ==== 구현 기능 ====
        // 플레이어 데이터 
        // 아이템 데이터
        // 몬스터 데이터
        //  위 데이터에 대한 접근
        // 데이터는 따로 클래스를 만들기

        public partial class DataManager
        {
                public static DataManager instance;
                public PlayerData player = new PlayerData("sad", 1, EClassType.WARRIOR, 30, 30, 200, 20000);
                

                public DataManager()
                {
                        if (instance == null)
                                instance = this;

                        InitItem();

		}

        }
}
