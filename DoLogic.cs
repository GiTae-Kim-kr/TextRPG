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
	{   // �ൿ���� �Լ��� �ۼ��ϴ� ��ũ��Ʈ
		public void BuyItem(int itemIndex, Shop shop, List<Item> inventory)
		{
			if (itemIndex >= 0 && itemIndex < shop.ShopItems.Count)
			{
				Item bought = shop.ShopItems[itemIndex];   //�������� ������ ����

			}
		}

	}
}
