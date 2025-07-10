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
		
		public void BuyItem(string BuyNumber , Player player , Shop shopItem, List<Item> inventory)
		{
			// out���� index ���� �� �ʱ�ȭ�� �ϸ鼭 ���� ó���� ������ �ڵ�
            if (!int.TryParse(BuyNumber, out int index) || index < 0 || index >= shopItem.ShopItems.Count)
            {
                Console.WriteLine("�߸��� ������ ��ȣ�Դϴ�.");
                return;
            }

            if (index == 0) return;
            Item item = shopItem.ShopItems[index-1];    // 1�� Ŭ���ϸ� 0�� �ε��� �������� ���ŵǰ� �ϱ� ���ؼ� -1�� ����
            
            if (!(item.IsPurchased))
            {
                if (player.PMoney >= item.ItemPrice)
                {

                    item.IsPurchased = true;
                    player.PMoney -= item.ItemPrice;
                    inventory.Add(item);
                    Console.WriteLine($"{item.ItemName}�� ���Ÿ� �Ϸ� �ϼ̽��ϴ�!");
                }
                else
                {
                    Console.WriteLine("Gold�� �����մϴ�!");
                }

            }
            else Console.WriteLine("�̹� ������ �������Դϴ�!");

            

		}

        public void SeeInventoryItem(int index, List<Item> inventory)   //�κ��丮 ������ �� �� �ְ� �ϴ� �Լ�
        {
            foreach (Item item in inventory)   // �κ��丮�� �߰��� ������ �� �� �ְ� �ϱ�
            {
                Console.Write($"-{index}.[{item.ItemRarity}]{item.ItemName}    |{item.ItemAbilityType} {item.ItemEffectValue} | ");
                Console.WriteLine($"{item.ItemDescription}");
                index++;
            }
        }

        public void SeeShopItem(int index, Shop shopItem, Player player)  //���� ������ �� �� �ְ� �ϴ� �Լ�
        {
            foreach (Item item in shopItem.ShopItems)  // ������ �߰��� ������ �� �� �ְ� �ڵ� �ۼ�
            {
                string ISBuy = item.IsPurchased ? "���� �Ϸ�" : $"{item.ItemPrice.ToString()}";  //���� ���� Ȯ���ϰ� �ٸ��� ���. 
                Console.Write($"-{index}.[{item.ItemRarity}]{item.ItemName}    |{item.ItemAbilityType} {item.ItemEffectValue} | ");
                Console.WriteLine($"{item.ItemDescription}    | {ISBuy}");
                index++;
            }
        }

        public void SelectWearItem(int index, string itemNumber, List<Item> inventory)
        {


            // ������ �����ϸ� �����ߴٴ� ǥ�� ��Ÿ���� �ϱ�
            do
            {

                if (!int.TryParse(itemNumber, out int wearIndex) || wearIndex < 0 || wearIndex >= inventory.Count)
                {
                    Console.WriteLine("�߸��� ������ ��ȣ�Դϴ�.");
                    return;
                }

                // ��� ���缭 BuyItem ���� ����ϰ� �ҷ��� �߰�. 
                Console.WriteLine("����Ϸ��� �ƹ� Ű�� ��������...");
                Console.ReadKey();

                Console.Clear();

                foreach (Item item in inventory)   // �κ��丮�� �߰��� ������ �� �� �ְ� �ϱ�
                {
                    if (wearIndex == index)
                    {
                        Console.Write($"-{index}.[E][{item.ItemRarity}]{item.ItemName}    |{item.ItemAbilityType} {item.ItemEffectValue} | ");
                        Console.WriteLine($"{item.ItemDescription}");
                    }
                    else
                    {
                        Console.Write($"-{index}.[{item.ItemRarity}]{item.ItemName}    |{item.ItemAbilityType} {item.ItemEffectValue} | ");
                        Console.WriteLine($"{item.ItemDescription}");
                    }
                    index++;
                }

                if (itemNumber == "0") break;

            } while (true);

        }

	}
}
