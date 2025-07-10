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
	internal class DoLogic
	{   // 행동관련 함수를 작성하는 스크립트
		public void BuyItem(int itemIndex, Shop shop, List<Item> inventory)
		{
			if (itemIndex >= 0 && itemIndex < shop.ShopItems.Count)
			{
				Item bought = shop.ShopItems[itemIndex];   //상점에서 아이템 샀음

			}
		}

	}
}
