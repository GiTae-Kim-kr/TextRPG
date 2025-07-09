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
        static void Main(string[] args)
        {
            
            Console.WriteLine(TextRpgCS.EnterDungeon);  //게임 환영 문구
            MainGame game = new MainGame();
            game.IntroGame();
            game.StartGame();
        }
    }
}
