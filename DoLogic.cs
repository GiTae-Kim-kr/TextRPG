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
	{   // 행동관련 함수를 작성하는 스크립트
		
		public void BuyItem(string BuyNumber , Player player , Shop shopItem, List<Item> inventory)
		{
			// out으로 index 선언 및 초기화도 하면서 예외 처리를 진행한 코드
            if (!int.TryParse(BuyNumber, out int index) || index < 0 || index >= shopItem.ShopItems.Count)
            {
                Console.WriteLine("잘못된 아이템 번호입니다.");
                return;
            }

            if (index == 0) return;
            Item item = shopItem.ShopItems[index-1];    // 1번 클릭하면 0번 인덱스 아이템이 구매되게 하기 위해서 -1을 해줌
            
            if (!(item.IsPurchased))
            {
                if (player.PMoney >= item.ItemPrice)
                {

                    item.IsPurchased = true;
                    player.PMoney -= item.ItemPrice;
                    inventory.Add(item);
                    Console.WriteLine($"{item.ItemName}을 구매를 완료 하셨습니다!");
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다!");
                }

            }
            else Console.WriteLine("이미 구매한 아이템입니다!");

            

		}

        public void SeeInventoryItem(int index, List<Item> inventory)   //인벤토리 아이템 볼 수 있게 하는 함수
        {
            foreach (Item item in inventory)   // 인벤토리에 추가한 아이템 볼 수 있게 하기
            {
                string equipMark = item.IsItemWear ? "[E]" : "";
                Console.Write($"-{index}.{equipMark}[{item.ItemRarity}]{item.ItemName}    |{item.ItemAbilityType} {item.ItemEffectValue} | ");
                Console.WriteLine($"{item.ItemDescription}");
                index++;
            }
        }

        public void SeeShopItem(int index, Shop shopItem, Player player)  //상점 아이템 볼 수 있게 하는 함수
        {
            foreach (Item item in shopItem.ShopItems)  // 상점에 추가한 아이템 볼 수 있게 코드 작성
            {
                string ISBuy = item.IsPurchased ? "구매 완료" : $"{item.ItemPrice.ToString()}";  //구매 여부 확인하고 다르게 출력. 
                Console.Write($"-{index}.[{item.ItemRarity}]{item.ItemName}    |{item.ItemAbilityType} {item.ItemEffectValue} | ");
                Console.WriteLine($"{item.ItemDescription}    | {ISBuy}");
                index++;
            }
        }

        public void SelectWearItem(int index, string itemNumber, List<Item> inventory) // 아이템 장착하고 해제하는 함수
        {


            // 아이템 선택하면 착용했다는 표시 나타나게 하기

            if (!int.TryParse(itemNumber, out int wearIndex) || wearIndex < 0 || wearIndex >= inventory.Count+1)
            {
                Console.WriteLine("잘못된 아이템 번호입니다.");
                return;
            }

            if (wearIndex == 0) return;

            // 잠깐 멈춰서 BuyItem 문구 출력하게 할려고 추가. 
            Console.WriteLine("계속하려면 아무 키나 누르세요...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(TextRpgCS.EquipmentStatus);


            if (!(inventory[wearIndex-1].IsItemWear))  // 선택한 아이템이 장착되지 않은 상태라면 true로
            {
                inventory[wearIndex - 1].IsItemWear = true;
            }
            else                                       // 선택한 아이템이 이미 장착되어 있던 상태라면 해제를 위해 false로
            {
                inventory[wearIndex - 1].IsItemWear = false;
            }

            SeeInventoryItem(index, inventory);     // 인벤토리 아이템 나타내는 함수.

            Console.WriteLine("\n\n0. 나가기\n\n");
            Console.Write(TextRpgCS.SetPlayerChoice);


        }



        public void ReflectItemValue(Player player, List<Item> inventory,out string plusStatA,out string plusStatP)    // 장착한 아이템에 따른 상태창 변화
        {

            int addAttack = 0;  // 공격 추가 수치를 저장을 위한 변수
            int addProtect = 0;  // 마찬가지로 방어 추가 수치

            plusStatA = "";  // 함수 밖에서 쓰기위해 out으로 매개변수를 생성해줌
            plusStatP = "";

            player.BaseAttackP = 10;
            player.BaseProtectP = 5;

            foreach (Item item in inventory)
            {
                

                if (item.IsItemWear)   // 인벤토리에서 장착하고 있는 아이템이라면
                {
                    int value = Math.Abs(int.Parse(item.ItemEffectValue));  // "+7" 형식의 스트링값을 정수형으로 변환후 절대값을 취해주는 코드
                    switch (item.ItemAbilityType)  // 장착하고 있는 아이템의 능력 종류에 따라서 다른 능력에 반영
                    {
                        case "공격력":
                            addAttack += value;
                            plusStatA = $"({addAttack})";
                            break;
                        case "방어력":
                            addProtect += value;
                            plusStatP = $"({addProtect})";
                            break;

                    }
                }

                if (addAttack > 0) plusStatA = $"(+{addAttack})";
                if (addProtect > 0) plusStatP = $"(+{addProtect})";

                // 최종 능력치는 기본 능력치 + 장착 아이템 보너스
                player.AttackP = player.BaseAttackP + addAttack;
                player.ProtectP = player.BaseProtectP + addProtect;
            }
        }

        public void ItemSell (string itemNumber, List<Item> inventory, Player player)
        {
            

            if (!int.TryParse(itemNumber, out int iIndex) || iIndex < 0 || iIndex >= inventory.Count + 1)
            {
                Console.WriteLine("잘못된 아이템 번호입니다.");
                return;
            }


            if (iIndex == 0) return;
            Item item = inventory[iIndex-1];

            if ((item.IsPurchased))
            {
                double soldMoney = item.ItemPrice * 0.85;
                item.IsPurchased = false;             // 이미 판매했으니까 false
                player.PMoney += (int)soldMoney;      // 판매금액만큼 소지금액 상승
                inventory.Remove(item);               //인벤토리 아이템리스트에서 삭제
                item.IsItemWear = false;              // 판매했으니까 착용해제
                Console.WriteLine($"{item.ItemName}을 판매를 완료 하셨습니다!");
                

            }
            else Console.WriteLine("이미 구매한 아이템입니다!");


        }

        public void InputNull(string input)
        {
            if (input == null) return;
        }

	}
}
