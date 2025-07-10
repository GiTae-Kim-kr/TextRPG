using System;
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
            game.IntroGame();
            game.StartGame();

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
                if (InvenInput == "0") game.StartGame();
            }
            else if (game.SelectRoute == 3)
            {
                game.ShopScene();     // 상점으로 이동
                string shopInput = Console.ReadLine();
                //if (shopInput == "0") game.StartGame();
            }

        }
    }
}
