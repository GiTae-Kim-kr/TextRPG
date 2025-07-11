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
    internal class MainGame
    { // 메인 게임 로직. 클래스로 작성해서 Program으로 넘겨줌.

        private int selectRoute; // StartScene의 분기 이동 선택 저장을 위한 필드 선언
        private Player player;  // Player.cs의 프로퍼티 사용하기 위해 인스턴스 만들어야 함. 그걸 위한 필드 선언.
        private List<Item> inventory = new List<Item>();  //인벤토리에 추가된 아이템 리스트 담을 객체
        private Shop shopItem = new Shop();      //상점에 추가한 아이템 볼 수 있게 클래스 받아온 객체
        DoLogic doLogic = new DoLogic();    // DoLogic 클래스의 함수 사용할려고 인스턴스 생성

        private int index = 1;  // 인벤토리, 상점창에서 아이템 번호 나타내기 위한 변수 선언

        public int SelectRoute  // Program.cs에서 읽을 수 있게 프로퍼티 설정
        {
            get { return selectRoute; }
            set { selectRoute = value; }
        }


        public void IntroGame()
        {

            player = new Player(0, "무전직자", 10, 5, 100 ,1500);  // 초기값!

            while (true)
            {
                Console.WriteLine(TextRpgCS.SetPlayerName);
                string PlayerName = Console.ReadLine();
                Console.WriteLine(string.Format(TextRpgCS.SavePlayerName, PlayerName));
                int IsSave = int.Parse(Console.ReadLine());
                //이름 저장 로직 작성
                if (IsSave == 1) { player.PName = PlayerName; break; }    //Player.cs의 이름필드에 입력한 이름 저장.
                else if (IsSave == 2) Console.WriteLine("이름을 다시 설정해주세요");
                else Console.WriteLine("잘못된 입력입니다!");
            }

            //게임 인트로 화면, 직업 설정
            Console.Clear();
            Console.WriteLine(TextRpgCS.Choicejob);        // 직업 선택.
            string Playerjob = Console.ReadLine();
            doLogic.InputNull(Playerjob);
            if (int.TryParse(Playerjob, out int jjob))    // 선택 값 받아서 정수값 해주고 switch문으로 직업 저장.
            {
                switch(jjob)
                {
                    case 1: player.PJob = "전사"; break;
                    case 2: player.PJob = "마법사"; break;
                    case 3: player.PJob = "궁수"; break;
                    case 4: player.PJob = "도적"; break;
                }

                
            }


        }

        public void StartGame()  // 필수기능가이드1. 게임시작화면.
        {

            Console.Clear();
            Console.WriteLine(TextRpgCS.EnterTown);
            Console.Write(TextRpgCS.SetPlayerChoice); //상태창,인벤토리,상점,던전 선택

            string input = Console.ReadLine();
            doLogic.InputNull(input);
            if (int.TryParse(input, out int route))
            {
                SelectRoute = route;
                switch (SelectRoute)
                {
                    case 1: Console.WriteLine("상태창으로 이동합니다!"); break;
                    case 2: Console.WriteLine("인벤토리를 확인합니다!"); break;
                    case 3: Console.WriteLine("상점으로 이동합니다!"); break;
                    case 4: Console.WriteLine("던전으로 이동합니다!"); break;
                    case 5: Console.WriteLine("휴식을 위해 이동합니다!"); break;
                    default: Console.WriteLine("잘못된 선택입니다!"); break;
                }
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요!");
                SelectRoute = 0;
            }


        }

        public void StatusScene()  // 상태창 씬 함수
        {
            string plusStatA, plusStatP;
            Console.Clear();
            doLogic.ReflectItemValue(player, inventory, out plusStatA, out plusStatP);
            Console.WriteLine(string.Format(TextRpgCS.ShowPlayerStatus, player.PName, player.PLevel, player.PJob,
                player.AttackP, player.ProtectP, player.PHealthC,player.PMoney, plusStatA, plusStatP)); //0.플레이어 1.레벨 2.직업, 3.공격력 4.방어 5.체력 6. 골드 7. 공격 추가스탯 8. 방어 추가 스탯
            Console.Write(TextRpgCS.SetPlayerChoice);
        }

        public void InventoryScene()    // 인벤토리 씬 함수
        {
            Console.Clear();
            Console.WriteLine(TextRpgCS.ShowInventory);


            doLogic.SeeInventoryItem(index, inventory);   // 인벤토리에 추가한 아이템 볼 수 있게 하기
            
            Console.WriteLine(TextRpgCS.SelectInven);
            Console.Write(TextRpgCS.SetPlayerChoice);

            

        }

        public void InventoryEquipmentScene()  //인벤토리 장착 관리 씬
        {
            
            Console.Clear();
            Console.WriteLine(TextRpgCS.EquipmentStatus);

            doLogic.SeeInventoryItem(index, inventory);

            Console.WriteLine("\n\n0. 나가기\n\n");
            Console.Write(TextRpgCS.SetPlayerChoice);
            

            do
            {
                string itemNumber = Console.ReadLine();
                doLogic.InputNull(itemNumber);
                doLogic.SelectWearItem(index, itemNumber, inventory);
                

                if (itemNumber == "0") break;

            }while (true);
            

        }

        public void ShopScene()  //상점창
        {
            
            Console.Clear();
            Console.WriteLine(string.Format(TextRpgCS.ShowShop, player.PMoney));

            doLogic.SeeShopItem(index, shopItem, player);  // 상점에 추가한 아이템 볼 수 있게 코드 작성

            Console.WriteLine();
            Console.WriteLine(TextRpgCS.SelectTwo);
            Console.WriteLine();
            Console.Write(TextRpgCS.SetPlayerChoice);
        }

        public void ItemBuyScene()   // 아이템 구매 창
        {
            
            do
            {
                Console.Clear();
                Console.WriteLine(string.Format(TextRpgCS.BuyShopItem, player.PMoney));

                doLogic.SeeShopItem(index, shopItem, player);  // 상점에서 보여줬던 리스트랑 똑같이.

                Console.WriteLine("\n\n0. 나가기\n\n");
                Console.Write(TextRpgCS.SetPlayerChoice);

                string buyitem = Console.ReadLine();
                doLogic.InputNull(buyitem);
                doLogic.BuyItem(buyitem, player, shopItem, inventory);
                index = 1;

                // 잠깐 멈춰서 BuyItem 문구 출력하게 할려고 추가. 
                Console.WriteLine("계속하려면 아무 키나 누르세요...");
                Console.ReadKey();
                
                if (buyitem == "0") break;
            }while (true);


        }

        public void ItemSellScene()    // 아이템 판매 창
        {

            do
            {


                Console.Clear();
                Console.WriteLine(string.Format(TextRpgCS.SellInvenItem, player.PMoney));
                foreach (Item item in inventory)
                {// 인벤토리 아이템에 가격 표시해서 상점 판매창에서 볼 수 있게 하기

                    Console.Write($"-{index}.[{item.ItemRarity}]{item.ItemName}    |{item.ItemAbilityType} {item.ItemEffectValue} | ");
                    Console.WriteLine($"{item.ItemDescription}    | {item.ItemPrice}");
                    index++;
                }
                Console.WriteLine("\n0. 나가기\n");
                Console.Write(TextRpgCS.SetPlayerChoice);
                string itemNumber = Console.ReadLine();
                doLogic.InputNull(itemNumber);
                doLogic.ItemSell(itemNumber, inventory, player);               // 아이템 판매 함수
                index = 1;

                if (itemNumber == "0") break;

                // 잠깐 멈춰서 BuyItem 문구 출력하게 할려고 추가. 
                Console.WriteLine("계속하려면 아무 키나 누르세요...");
                Console.ReadKey();
            }while (true);
        }


        public void RestScene()   // 회복할 수 있는 창.
        {
            Console.Clear();
            Console.WriteLine(string.Format(TextRpgCS.RestHealth,player.PMoney) );
            Console.Write(TextRpgCS.SetPlayerChoice);
            string restSelect = Console.ReadLine();
            doLogic.InputNull(restSelect);
            if (restSelect == "1")
            {
                int CureHealth = player.PHealthG - player.PHealthC; // 전체 HP에서 현재 체력을 뺴면 회복에 필요한 HP 양을 구할 수 있음

                if (CureHealth <= 0)
                {
                    Console.WriteLine("이미 체력이 가득찼습니다!");
                    Console.WriteLine("계속하려면 아무 키나 누르세요...");
                    Console.ReadKey();

                }
                else
                {
                    player.PMoney -= 500;
                    player.PHealthC += CureHealth;
                    Console.WriteLine($"{CureHealth} 만큼 HP를 회복하였습니다!");
                    // 잠깐 멈춰서 BuyItem 문구 출력하게 할려고 추가. 
                    Console.WriteLine("계속하려면 아무 키나 누르세요...");
                    Console.ReadKey();
                }

            }
            else 
            { 
                Console.WriteLine("시작화면으로 돌아갑니다!");

                // 잠깐 멈춰서 BuyItem 문구 출력하게 할려고 추가. 
                Console.WriteLine("계속하려면 아무 키나 누르세요...");
                Console.ReadKey();
            }
            
        }

        public void GoDungeonScene()
        {
            Console.Clear();
            Console.WriteLine(TextRpgCS.GoDungeon);
            Console.WriteLine("0. 나가기\n\n");
            Console.Write(TextRpgCS.SetPlayerChoice);
            
        }

        public void DungeonClearScene(string difficulty)
        {
            int PastHealth = 0, PastMoney = 0;
            Console.Clear();

            doLogic.ReflectDungeonResult(player, difficulty, out PastHealth, out PastMoney);

            Console.WriteLine(string.Format(TextRpgCS.DungeonClear, difficulty, PastHealth, player.PHealthC, PastMoney, player.PMoney));
            Console.WriteLine("\n0. 나가기\n\n");
            Console.Write(TextRpgCS.SetPlayerChoice);

            Console.ReadKey();
        }


    }
}
