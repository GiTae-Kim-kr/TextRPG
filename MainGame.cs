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


        public int SelectRoute  // Program.cs에서 읽을 수 있게 프로퍼티 설정
        {
            get { return selectRoute; }
            set { selectRoute = value; }
        }


        public void IntroGame()
        {
            player = new Player(0, "무전직자", 10, 5, 100 ,1500);

            while (true)
            {
                Console.WriteLine(TextRpgCS.SetPlayerName);
                string PlayerName = Console.ReadLine();
                Console.WriteLine(string.Format(TextRpgCS.SavePlayerName, PlayerName));
                int IsSave = int.Parse(Console.ReadLine());
                //이름 저장 로직 작성
                if (IsSave == 1) break;
                else if (IsSave == 2) Console.WriteLine("이름을 다시 설정해주세요");
                else Console.WriteLine("잘못된 입력입니다!");
            }

            //게임 인트로 화면, 직업 설정
            Console.Clear();
            Console.WriteLine(TextRpgCS.Choicejob);        // 직업 선택.
            string Playerjob = Console.ReadLine();
            if (int.TryParse(Playerjob, out int jjob))
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
            if (int.TryParse(input, out int route))
            {
                SelectRoute = route;
                switch (SelectRoute)
                {
                    case 1: Console.WriteLine("상태창으로 이동합니다!"); break;
                    case 2: Console.WriteLine("인벤토리를 확인합니다!"); break;
                    case 3: Console.WriteLine("상점으로 이동합니다!"); break;
                    case 4: Console.WriteLine("던전으로 이동하빈다!"); break;
                    default: Console.WriteLine("잘못된 선택입니다!"); break;
                }
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요!");
                SelectRoute = 0;
            }


        }

        public void StatusScene()
        {
            

            Console.Clear();
            Console.WriteLine(string.Format(TextRpgCS.ShowPlayerStatus, player.PLevel, player.PJob, player.AttackP, player.ProtectP, player.PHealthG,player.PMoney)); //0.레벨 1.직업, 2.공격력 3.방어 4.체력 5. 골드
            Console.WriteLine(TextRpgCS.SetPlayerChoice);
        }

        public void InventoryScene()
        {
            Console.Clear();
        }

        public void ShopScene()
        {
            Console.Clear();
        }

    }
}
