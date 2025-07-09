using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class TextRpgCS
    {
        // TextRPG 게임에서 사용되는 텍스트 상수들을 정의하는 클래스.

        public static string EnterDungeon{ get; } = "스파르타 던전에 오신 여러분 환영합니다.";

        public static string SetPlayerName { get; } = "원하시는 이름을 설정해주세요.";

        public static string SetPlayerChoice { get; } = "원하시는 행동을 입력해주세요. \n" +
            ">>";

        public static string SavePlayerName { get; } =
            "입력하신 이름은 {0}입니다.\n" +
            "1. 저장\n" +
            "2. 취소\n" +
            "원하는 행동을 입력해주세요.";

        public static string Choicejob { get; } =
            "원하는 직업을 선택해주세요.\n" +
            "1. 전사\n" +
            "2. 마법사\n" +
            "3. 궁수\n" +
            "4. 도적\n" +
            "원하시는 행동을 입력해주세요.";

        public static string EnterTown { get; } =
            "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n" +
            "1. 상태 보기\n" +
            "2. 인벤토리\n" +
            "3. 상점\n" +
            "4. 던전 입장\n";

        public static string ShowPlayerStatus { get; } =
            "상태창 \n" +
            "캐릭터의 정보가 표시됩니다.\n\n" +
            "LV. {0}\n" +
            "Chad {1}\n" +
            "공격력 : {2}\n" +
            "방어력 : {3}\n" +
            "체 력  : {4}\n" +
            "Gold   : {5} G\n\n" +
            "0. 나가기";


        public static string ShowInventory { get; } =
            "인벤토리 \n" +
            "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
            "[아이템 목록]\n" +
            "1. 장착 관리\n" +
            "0. 나가기\n\n";



        //문자열 받아서 한글자씩 띄우는 함수
        static void PrintStringByTick (string s, int interval)
        {
            foreach (char c in s)
            {
                Console.Write(c);
                Thread.Sleep(interval); // 지정된 시간 동안 대기 (밀리초 단위)
            }
        }




    }
}
