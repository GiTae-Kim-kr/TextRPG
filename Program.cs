﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Program
    {


        // 클래스들 인스턴스 생성해서 출력하는 곳.
        // 씬의 전환 로직. 그리고 진행 텍스트를 출력을 담당하는 메인 로직.
        static void Main(string[] args)
        {
            
            Console.WriteLine(TextRpgCS.EnterDungeon);  //게임 환영 문구
            MainGame game = new MainGame();
            game.IntroGame(out string selectLoad);

            while (true)    // 각 씬의 앞 뒤로 왔다 갔다 할 수 있게 StartGame() 씬을 기준으로 반복을 설정.
            {
                if (selectLoad == "Y")
                {
                    game.StartGame();
                    break;  // 게임 시작 씬으로 이동
                }
                else if (selectLoad == "N")
                {
                    game.IntroGame(out selectLoad);  // 게임 시작 전 인트로 씬으로 돌아가기
                    game.SetJobScene();  // 직업 선택 씬으로 이동
                    game.StartGame();  // 직업 선택 후 게임 시작 씬으로 이동
                    break;
                }
            }

            while (true)  // 게임 시작 후 루트 선택 씬으로 이동
            {

               game.StartGame();  // 게임 시작 씬으로 이동

                //게임 시작화면에서 루트 선택(상태,인벤,상점,던전)
                if (game.SelectRoute == 1)
                {
                    game.StatusScene();
                    string input = Console.ReadLine();
                    if (input == "0") game.StartGame();  // 0 입력 받으면 다시 StartGame으로 돌아가기
                    else game.StartGame();
                }
                else if (game.SelectRoute == 2)
                {
                    game.InventoryScene();               //인벤토리 화면으로
                    string InvenInput = Console.ReadLine();  // 1.장착관리 0.나가기
                    if (InvenInput == "1")
                    {
                        game.InventoryEquipmentScene();    // 장착 관리 화면으로 이동.
                    }

                }
                else if (game.SelectRoute == 3)
                {

                    game.ShopScene();     // 상점으로 이동
                    string shopInput = Console.ReadLine();
                    if (shopInput == "1")
                    {
                        game.ItemBuyScene();        // 상점-장비 구매창으로 이동

                    }
                    else if (shopInput == "2") game.ItemSellScene();  // 상점- 판매창으로 이동

                }
                else if (game.SelectRoute == 4)
                {

                    game.GoDungeonScene();    // 던전 난이도 선택창으로 이동
                    string selectDungeon = Console.ReadLine();
                    if (selectDungeon == "1") { string difficulty = "Easy"; game.DungeonClearScene(difficulty); }
                    else if (selectDungeon == "2") { string difficulty = "Normal"; game.DungeonClearScene(difficulty); }
                    else if (selectDungeon == "3") { string difficulty = "Hard"; game.DungeonClearScene(difficulty); }
                    string input = Console.ReadLine();
                }
                else if (game.SelectRoute == 5) game.RestScene();
                else if (game.SelectRoute == 0) break;
            
            }


        }
    }
}
