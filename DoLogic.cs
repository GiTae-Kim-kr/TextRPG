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
            if (!int.TryParse(BuyNumber, out int index) || index < 0 || index >= shopItem.ShopItems.Count+1)
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

            Item selectitem = inventory[wearIndex-1];

            if (selectitem.IsItemWear)
            {
                Console.WriteLine($"{selectitem.ItemName}�� ���� ���� �մϴ�!");
                inventory[wearIndex - 1].IsItemWear = false;
                return;
            }

            bool alreadyEquipped = false;  // ���� �迭 ������ �� �̹� ������ �� �ִ��� Ȯ������ ����
            foreach (Item item in inventory)
            {
                if (item.ItemTag == selectitem.ItemTag && item.IsItemWear)
                { // ������ �������� �±׶� ���� �±��� ������ �߿��� �����Ѱ� �ִٸ� ����
                    item.IsItemWear = false;  // ���� ������ ������ ���� ����
                    alreadyEquipped = true;  //  �̹� ������ �� �ִٰ� ǥ��
                    if (alreadyEquipped)
                    {
                        Console.WriteLine("�̹� ���� �迭�� �������� ���� ���Դϴ�!");
                        Console.WriteLine($"{item.ItemName}�� ������ �����մϴ�.");
                        
                    }
                }
            }

            selectitem.IsItemWear = true;    // ������ �������� ������ ����
            Console.WriteLine($"{selectitem.ItemName}��(��) �����Ͽ����ϴ�!");

            // ��� ���缭 BuyItem ���� ����ϰ� �ҷ��� �߰�. 
            Console.WriteLine("����Ϸ��� �ƹ� Ű�� ��������...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(TextRpgCS.EquipmentStatus);

            SeeInventoryItem(index, inventory);     // �κ��丮 ������ ��Ÿ���� �Լ�.

            Console.WriteLine("\n\n0. ������\n\n");
            Console.Write(TextRpgCS.SetPlayerChoice);

        }



        public void ReflectItemValue(Player player, List<Item> inventory,out string plusStatA,out string plusStatP)    // ������ �����ۿ� ���� ����â ��ȭ
        {

            float addAttack = 0.0f;  // ���� �߰� ��ġ�� ������ ���� ����
            float addProtect = 0.0f;  // ���������� ��� �߰� ��ġ

            plusStatA = "";  // �Լ� �ۿ��� �������� out���� �Ű������� ��������
            plusStatP = "";


            foreach (Item item in inventory)
            {
                

                if (item.IsItemWear)   // �κ��丮���� �����ϰ� �ִ� �������̶��
                {
                    float value = Math.Abs(float.Parse(item.ItemEffectValue));  // "+7" ������ ��Ʈ������ ���������� ��ȯ�� ���밪�� �����ִ� �ڵ�
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
                player.AttackP = player.PBaseAP + addAttack;
                player.ProtectP = player.PBasePP + addProtect;
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

        public void ReflectDungeonResult(Player player, string difficulty, out int PastHealth, out int PastMoney, out bool isSuccess)
        {
            PastHealth = player.PHealthC;   // ���� �� HP
            PastMoney = player.PMoney;      // ���� �� ���
            isSuccess = true;

            int properProtect;  // ���� ����
            int minusHealth;   // ü�� ���Ұ�
            int minusValue;
            

            if (difficulty == "Easy")
            {
                difficultyReward(player, 5, 1000 , PastHealth, PastMoney, out isSuccess);
            }
            else if (difficulty == "Normal")
            {
                difficultyReward(player, 11, 1700, PastHealth, PastMoney, out isSuccess);
                
            }
            else if (difficulty == "Hard")
            {
                difficultyReward(player, 17, 2500, PastHealth, PastMoney, out isSuccess);
                
            }

            if (player.PHealthC < 0)
            {
                player.PHealthC = 0;
                
            }
        }

        public void difficultyReward(Player player, int properProtect, int baseReward, int PastHealth, int PastMoney, out bool isSuccess)
        {
            
            int minusValue;
            Random rand = new Random();
            
            if (player.ProtectP < properProtect)        // ���� ���º��� ���ٸ�
            {
                           // ���� ��ü����
                int successValue = rand.Next(1, 101);   // 1~100 ���� ���� ���� �̱�
                if (successValue <= 40)                 // 40% Ȯ���� ����������
                {
                    player.PHealthC = PastHealth / 2;    // ü�� �������� ����
                    isSuccess = false;
                }
                else                                     // ���� ���º��� ������ 60% Ȯ���� �������� ��
                {
                    minusValue = rand.Next(20, 36) + (int)(properProtect - player.ProtectP);  // 20~35 ���Ҽ�ġ ���� �̱� - ���� ���� = ���� ���� ��ġ
                    player.PHealthC = PastHealth - minusValue;
                    // ���ݷ¿� ���� ��� �߰� ����
                    double plusRewardValue = rand.NextDouble() * (player.AttackP * 2 - player.AttackP) + player.AttackP;  // 0 ~10 ���̿� 10 �����ָ� 10~20���� ��.
                    player.PMoney = PastMoney + baseReward + (int)(baseReward * (plusRewardValue / 100.0));
                    isSuccess = true;
                    
                }
            }
            else   // ���� ���º��� ���ٸ� �׻� ����
            {
                minusValue = rand.Next(20, 36) + (int)(properProtect - player.ProtectP);  // 20~35 ���Ҽ�ġ ���� �̱� - ���� ���� = ���� ���� ��ġ
                player.PHealthC = PastHealth - minusValue;
                // ���ݷ¿� ���� ��� �߰� ����
                double plusRewardValue = rand.NextDouble() * (player.AttackP * 2 - player.AttackP) + player.AttackP;  // 0 ~10 ���̿� 10 �����ָ� 10~20���� ��.
                player.PMoney = PastMoney + baseReward + (int)(baseReward * (plusRewardValue / 100.0));
                isSuccess = true;
                
            }

        }

        public void LevelUp(Player player, int ClearCount)    // ���� �� �Լ�
        {


            if (player.PLevel == ClearCount)
            {
                player.PLevel = ClearCount+1;
                player.PBaseAP = player.PBaseAP + 0.5f;
                player.PBasePP += 1;
                player.AttackP +=  Math.Abs(player.PBaseAP - player.AttackP);   // �׳� ���̽������� �����ָ� ���� ���ߴµ� ������ Ȯ���� �ȵ�
                player.ProtectP += Math.Abs(player.PBasePP - player.P��rotectP);  // ����â���� ReflectValue�Լ��� AttackP �� �����Ű�°� �־ �װ� �����ؾ� �߰��� ������ ���� �ݿ���.
                // �׷��� �������Ǹ� �ٷ� ����â���� Ȯ���� �� �ְ� AttackP, ProtectP ���� �������ִ� ��.

                Console.WriteLine($"�����մϴ�! Level�� LV.{player.PLevel - 1}���� LV.{player.PLevel}�� �Ǽ̽��ϴ�!");
            }
        }


        public void InputNull(string input)
        {
            if (input == null) return;
        }

	}
}
