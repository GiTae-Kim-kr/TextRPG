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
                Console.Write($"-{index}.[{item.ItemRarity}]{item.ItemName}    |{item.ItemAbilityType} {item.ItemEffectValue} | ");
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

        public void SelectWearItem(int index, string itemNumber, List<Item> inventory)
        {


            // 아이템 선택하면 착용했다는 표시 나타나게 하기
            do
            {

                if (!int.TryParse(itemNumber, out int wearIndex) || wearIndex < 0 || wearIndex >= inventory.Count)
                {
                    Console.WriteLine("잘못된 아이템 번호입니다.");
                    return;
                }

                // 잠깐 멈춰서 BuyItem 문구 출력하게 할려고 추가. 
                Console.WriteLine("계속하려면 아무 키나 누르세요...");
                Console.ReadKey();

                Console.Clear();

                foreach (Item item in inventory)   // 인벤토리에 추가한 아이템 볼 수 있게 하기
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
