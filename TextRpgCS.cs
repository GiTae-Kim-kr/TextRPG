﻿using System;
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
            "4. 던전 입장\n"+
            "5. 휴식하기\n\n"+
            "저장을 원하시면 \"저장\"이라고 입력하여 주세요!\n";

        public static string ShowPlayerStatus { get; } =
            "{0}의 상태창 \n" +
            "캐릭터의 정보가 표시됩니다.\n\n" +
            "LV. {1}\n" +
            "Chad {2}\n" +
            "공격력 : {3} {7}\n" +
            "방어력 : {4} {8}\n" +
            "체 력  : {5}\n" +
            "Gold   : {6} G\n\n" +
            "0. 나가기";


        public static string ShowInventory { get; } =
            "인벤토리 \n" +
            "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
            "[아이템 목록]\n";

        public static string SelectInven { get; } =
            "\n1. 장착 관리\n" +
            "0. 나가기\n\n";


        public static string EquipmentStatus { get; } =
            "인벤토리 - 장착관리 \n" +
            "보유 중인 아이템을 잘 관리할 수 있습니다.\n\n" +
            "[아이템 목록]\n";


        public static string ShowShop { get; } =
            "상점 \n" +
            "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
            "[보유 골드]\n" +
            "{0} G\n\n" +
            "[아이템 목록]\n";

        public static string SelectTwo { get; } =
            "1. 아이템 구매\n" +
            "2. 아이템 판매\n" +
            "0. 나가기";

        public static string BuyShopItem { get; } =
            "상점 - 아이템 구매\n" +
            "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
            "[보유 골드]\n" +
            "{0} G\n\n" +
            "[아이템 목록]";

        public static string SellInvenItem { get; } =
            "상점 - 아이템 판매\n" +
            "필요없는 아이템을 판매할 수 있습니다!\n\n" +
            "[보유 골드]\n" +
            "{0} G \n\n" +
            "[아이템 목록]\n";

        public static string RestHealth { get; } =
            "휴식하기\n" +
            "500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0} G)\n\n" +
            "1. 휴식하기\n" +
            "0. 나가기\n\n";


        public static string GoDungeon { get; } =
            "던전입장\n" +
            "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n\n" +
            "1. 던전(Easy)        | 방어력 5 이상 권장\n" +
            "2. 던전(Normal)      | 방어력 11 이상 권장\n" +
            "3. 던전(Hard)        | 방어력 17 이상 권장\n";

        public static string DungeonClear { get; } =
            "던전 클리어\n" +
            "축하합니다!!\n" +
            "{0} 던전을 클리어 하셨습니다!\n\n" +
            "[탐험 결과]\n" +
            "체력 {1} -> {2}\n" +
            "Gold {3} -> {4}\n\n";

        public static string DungeonFailed { get;  } =
            "{0} 던전을 탐험하는 것에 실패하셨습니다...!\n\n" +
            "[탐험 결과]\n"+
            "체력 {1} -> {2}\n" +
            "Gold {3} -> {4}\n\n";

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
