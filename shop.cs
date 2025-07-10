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
            new Item('A', "강철 검", "공격력", "+10", "튼튼한 강철로 만든 검"),
            new Item('B', "마법 지팡이", "마력", "+15", "마법사가 애용하는 지팡이"),
            new Item('C', "가죽 갑옷", "방어력", "+8", "가벼운 가죽으로 만든 갑옷")
            };
        }
        private void InitializeShopItems()
        {
            // 샘플 아이템 추가  
            ShopItems.Add(new Item('D',"검","공격력", "+3", "기본 검입니다."));

        }

    }

}