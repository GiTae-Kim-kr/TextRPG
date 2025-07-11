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
            if (!int.TryParse(BuyNumber, out int index) || index < 0 || index >= shopItem.ShopItems.Count+1)
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

            Item selectitem = inventory[wearIndex-1];

            if (selectitem.IsItemWear)
            {
                Console.WriteLine($"{selectitem.ItemName}을 장착 해제 합니다!");
                inventory[wearIndex - 1].IsItemWear = false;
                return;
            }

            bool alreadyEquipped = false;  // 같은 계열 아이템 중 이미 장착한 거 있는지 확인위해 생성
            foreach (Item item in inventory)
            {
                if (item.ItemTag == selectitem.ItemTag && item.IsItemWear)
                { // 선택한 아이템의 태그랑 같은 태그의 아이템 중에서 장착한게 있다면 진입
                    item.IsItemWear = false;  // 기존 착용한 아이템 착용 해제
                    alreadyEquipped = true;  //  이미 장착한 것 있다고 표시
                    if (alreadyEquipped)
                    {
                        Console.WriteLine("이미 같은 계열의 아이템을 장착 중입니다!");
                        Console.WriteLine($"{item.ItemName}의 장착을 해제합니다.");
                        
                    }
                }
            }

            selectitem.IsItemWear = true;    // 선택한 아이템은 무조건 장착
            Console.WriteLine($"{selectitem.ItemName}을(를) 장착하였습니다!");

            // 잠깐 멈춰서 BuyItem 문구 출력하게 할려고 추가. 
            Console.WriteLine("계속하려면 아무 키나 누르세요...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(TextRpgCS.EquipmentStatus);

            SeeInventoryItem(index, inventory);     // 인벤토리 아이템 나타내는 함수.

            Console.WriteLine("\n\n0. 나가기\n\n");
            Console.Write(TextRpgCS.SetPlayerChoice);

        }



        public void ReflectItemValue(Player player, List<Item> inventory,out string plusStatA,out string plusStatP)    // 장착한 아이템에 따른 상태창 변화
        {

            float addAttack = 0.0f;  // 공격 추가 수치를 저장을 위한 변수
            float addProtect = 0.0f;  // 마찬가지로 방어 추가 수치

            plusStatA = "";  // 함수 밖에서 쓰기위해 out으로 매개변수를 생성해줌
            plusStatP = "";


            foreach (Item item in inventory)
            {
                

                if (item.IsItemWear)   // 인벤토리에서 장착하고 있는 아이템이라면
                {
                    float value = Math.Abs(float.Parse(item.ItemEffectValue));  // "+7" 형식의 스트링값을 정수형으로 변환후 절대값을 취해주는 코드
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
                player.AttackP = player.PBaseAP + addAttack;
                player.ProtectP = player.PBasePP + addProtect;
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

        public void ReflectDungeonResult(Player player, string difficulty, out int PastHealth, out int PastMoney, out bool isSuccess)
        {
            PastHealth = player.PHealthC;   // 입장 전 HP
            PastMoney = player.PMoney;      // 입장 전 골드
            isSuccess = true;

            int properProtect;  // 권장 방어력
            int minusHealth;   // 체력 감소값
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
            
            if (player.ProtectP < properProtect)        // 권장 방어력보다 낮다면
            {
                           // 랜덤 객체생성
                int successValue = rand.Next(1, 101);   // 1~100 사이 정수 랜덤 뽑기
                if (successValue <= 40)                 // 40% 확률로 실패했을시
                {
                    player.PHealthC = PastHealth / 2;    // 체력 절반으로 감소
                    isSuccess = false;
                }
                else                                     // 권장 방어력보다 낮은데 60% 확률로 성공했을 시
                {
                    minusValue = rand.Next(20, 36) + (int)(properProtect - player.ProtectP);  // 20~35 감소수치 랜덤 뽑기 - 방어력 차이 = 최종 감소 수치
                    player.PHealthC = PastHealth - minusValue;
                    // 공격력에 따른 골드 추가 보상
                    double plusRewardValue = rand.NextDouble() * (player.AttackP * 2 - player.AttackP) + player.AttackP;  // 0 ~10 사이에 10 더해주면 10~20사이 됨.
                    player.PMoney = PastMoney + baseReward + (int)(baseReward * (plusRewardValue / 100.0));
                    isSuccess = true;
                    
                }
            }
            else   // 권장 방어력보다 높다면 항상 성공
            {
                minusValue = rand.Next(20, 36) + (int)(properProtect - player.ProtectP);  // 20~35 감소수치 랜덤 뽑기 - 방어력 차이 = 최종 감소 수치
                player.PHealthC = PastHealth - minusValue;
                // 공격력에 따른 골드 추가 보상
                double plusRewardValue = rand.NextDouble() * (player.AttackP * 2 - player.AttackP) + player.AttackP;  // 0 ~10 사이에 10 더해주면 10~20사이 됨.
                player.PMoney = PastMoney + baseReward + (int)(baseReward * (plusRewardValue / 100.0));
                isSuccess = true;
                
            }

        }

        public void LevelUp(Player player, int ClearCount)    // 레벨 업 함수
        {


            if (player.PLevel == ClearCount)
            {
                player.PLevel = ClearCount+1;
                player.PBaseAP = player.PBaseAP + 0.5f;
                player.PBasePP += 1;
                player.AttackP +=  Math.Abs(player.PBaseAP - player.AttackP);   // 그냥 베이스값에만 더해주면 값은 변했는데 눈으로 확인이 안됨
                player.ProtectP += Math.Abs(player.PBasePP - player.PㄴrotectP);  // 스탯창에서 ReflectValue함수에 AttackP 값 변경시키는게 있어서 그거 실행해야 추가된 레벨업 스탯 반영됨.
                // 그래서 레벨업되면 바로 스탯창에서 확인할 수 있게 AttackP, ProtectP 값을 설정해주는 것.

                Console.WriteLine($"축하합니다! Level이 LV.{player.PLevel - 1}에서 LV.{player.PLevel}이 되셨습니다!");
            }
        }


        public void InputNull(string input)
        {
            if (input == null) return;
        }

	}
}
