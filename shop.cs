using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    internal class Shop
    {

        public List<Item> ShopItems { get; private set; }

        public Shop()
        {
            ShopItems = new List<Item>
            {
            new Item("언커먼", "수련자 갑옷", "방어력", "+5", "수련에 도움을 주는 갑옷입니다.", 700, "방어구"),
            new Item("레어", "마법 지팡이", "마력", "+15", "마법사가 애용하는 지팡이",2000, "무기"),
            new Item("레어", "스파르타의 갑옷", "방어력", "+15", "가벼운 가죽으로 만든 갑옷", 2000, "방어구"),
            new Item("언커먼", "낡은 검", "공격력", "+2", "쉽게 볼 수 있는 낡은 검 입니다.",500, "무기"),
            new Item("레어", "청동 도끼", "공격력", "+5", "어디선가 사용됐던거 같은 도끼입니다.",700, "무기"),
            new Item("커먼", "스파르타의 창", "공격력", "+7", "스파르타의 전사들이 사용했다는 전설의 창입니다.",1000, "무기"),
            new Item("커먼", "무쇠갑옷", "방어력", "+9", "무쇠로 만들어져 튼튼한 갑옷입니다.",900, "방어구")
            };
        }


    }

}