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
        public void IntroGame()
        {


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
            Console.WriteLine(TextRpgCS.Choicejob);
            int Playerjob = int.Parse(Console.ReadLine());
        }

        public void StartGame()  // 필수기능가이드1. 게임시작화면.
        {
            private int selectRoute;

            Console.Clear();
            Console.WriteLine(TextRpgCS.EnterTown);
            Console.Write(TextRpgCS.SetPlayerChoice);
            int SaveJob = int.Parse(Console.ReadLine());

            switch (SaveJob)
            {
                case 1: Console.WriteLine("상태창으로 이동합니다!"); break;
                case 2: Console.WriteLine("인벤토리를 확인합니다!"); break;
                case 3: Console.WriteLine("상점으로 이동합니다!"); break;
            }

            Public int SelectRoute
            {
                get { retrun selectRoute; }
                set { selectRoute = SaveJob; }
            }
        }

        public void StatusScene()
        {
            Console.Clear();
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
