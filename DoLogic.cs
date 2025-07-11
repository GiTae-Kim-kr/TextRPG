using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
                string equipMark = item.IsItemWear ? "[E]" : "";
                Console.Write($"-{index}.{equipMark}[{item.ItemRarity}]{item.ItemName}    |{item.ItemAbilityType} {item.ItemEffectValue} | ");
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

        public void SelectWearItem(int index, string itemNumber, List<Item> inventory) // ������ �����ϰ� �����ϴ� �Լ�
        {


            // ������ �����ϸ� �����ߴٴ� ǥ�� ��Ÿ���� �ϱ�

            if (!int.TryParse(itemNumber, out int wearIndex) || wearIndex < 0 || wearIndex >= inventory.Count+1)
            {
                Console.WriteLine("�߸��� ������ ��ȣ�Դϴ�.");
                return;
            }

            if (wearIndex == 0) return;

            // ��� ���缭 BuyItem ���� ����ϰ� �ҷ��� �߰�. 
            Console.WriteLine("����Ϸ��� �ƹ� Ű�� ��������...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(TextRpgCS.EquipmentStatus);


            if (!(inventory[wearIndex-1].IsItemWear))  // ������ �������� �������� ���� ���¶�� true��
            {
                inventory[wearIndex - 1].IsItemWear = true;
            }
            else                                       // ������ �������� �̹� �����Ǿ� �ִ� ���¶�� ������ ���� false��
            {
                inventory[wearIndex - 1].IsItemWear = false;
            }

            SeeInventoryItem(index, inventory);     // �κ��丮 ������ ��Ÿ���� �Լ�.

            Console.WriteLine("\n\n0. ������\n\n");
            Console.Write(TextRpgCS.SetPlayerChoice);


        }



        public void ReflectItemValue(Player player, List<Item> inventory,out string plusStatA,out string plusStatP)    // ������ �����ۿ� ���� ����â ��ȭ
        {

            int addAttack = 0;  // ���� �߰� ��ġ�� ������ ���� ����
            int addProtect = 0;  // ���������� ��� �߰� ��ġ

            plusStatA = "";  // �Լ� �ۿ��� �������� out���� �Ű������� ��������
            plusStatP = "";

            player.BaseAttackP = 10;
            player.BaseProtectP = 5;

            foreach (Item item in inventory)
            {
                

                if (item.IsItemWear)   // �κ��丮���� �����ϰ� �ִ� �������̶��
                {
                    int value = Math.Abs(int.Parse(item.ItemEffectValue));  // "+7" ������ ��Ʈ������ ���������� ��ȯ�� ���밪�� �����ִ� �ڵ�
                    switch (item.ItemAbilityType)  // �����ϰ� �ִ� �������� �ɷ� ������ ���� �ٸ� �ɷ¿� �ݿ�
                    {
                        case "���ݷ�":
                            addAttack += value;
                            plusStatA = $"({addAttack})";
                            break;
                        case "����":
                            addProtect += value;
                            plusStatP = $"({addProtect})";
                            break;

                    }
                }

                if (addAttack > 0) plusStatA = $"(+{addAttack})";
                if (addProtect > 0) plusStatP = $"(+{addProtect})";

                // ���� �ɷ�ġ�� �⺻ �ɷ�ġ + ���� ������ ���ʽ�
                player.AttackP = player.BaseAttackP + addAttack;
                player.ProtectP = player.BaseProtectP + addProtect;
            }
        }

        public void ItemSell (string itemNumber, List<Item> inventory, Player player)
        {
            

            if (!int.TryParse(itemNumber, out int iIndex) || iIndex < 0 || iIndex >= inventory.Count + 1)
            {
                Console.WriteLine("�߸��� ������ ��ȣ�Դϴ�.");
                return;
            }


            if (iIndex == 0) return;
            Item item = inventory[iIndex-1];

            if ((item.IsPurchased))
            {
                double soldMoney = item.ItemPrice * 0.85;
                item.IsPurchased = false;             // �̹� �Ǹ������ϱ� false
                player.PMoney += (int)soldMoney;      // �Ǹűݾ׸�ŭ �����ݾ� ���
                inventory.Remove(item);               //�κ��丮 �����۸���Ʈ���� ����
                item.IsItemWear = false;              // �Ǹ������ϱ� ��������
                Console.WriteLine($"{item.ItemName}�� �ǸŸ� �Ϸ� �ϼ̽��ϴ�!");
                

            }
            else Console.WriteLine("�̹� ������ �������Դϴ�!");


        }

        public void InputNull(string input)
        {
            if (input == null) return;
        }

	}
}
