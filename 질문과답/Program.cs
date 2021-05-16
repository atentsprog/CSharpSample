using System;

namespace 질문과답
{
    class Program
    {
        // do while : 최초 1번  실행하고 조건 검사후 반복할때 사용.
        // while : 조건 검사후 반복할때 사용. <- 최초 1회 검사할때도 사용가능하나 조금 불편

        // y, n에 따라 루프 반복.
        static void Main(string[] args)
        {
            //DoWhileVersion();

            //WhileVersion();

            ForVersion();
        }

        private static void ForVersion()
        {
            int tryCount = 0;
            bool reTry = true;
            //반복.
            for (; reTry; )
            {
                Console.WriteLine($"[While문 사용]{++tryCount}번째 시도, 어떤 일을 여기서 합니다");
                Console.WriteLine("다시 하시겠습니까? (Y)es/(N)o");
                reTry = Console.ReadLine().ToUpper() == "Y";
            }
        }

        private static void WhileVersion()
        {
            /*
            int tryCount = 0;
            bool reTry = true;
            //반복.
            while(reTry)
            {
                Console.WriteLine($"[While문 사용]{++tryCount}번째 시도, 어떤 일을 여기서 합니다");
                Console.WriteLine("다시 하시겠습니까? (Y)es/(N)o");
                reTry = Console.ReadLine().ToUpper() == "Y";
            } 
            */

            int tryCount = 0;
            do
            {
                Console.WriteLine($"[While문 사용]{++tryCount}번째 시도, 어떤 일을 여기서 합니다");
                Console.WriteLine("다시 하시겠습니까? (Y)es/(N)o");
            } while (Console.ReadLine().ToUpper() == "Y");
        }

        private static void DoWhileVersion()
        {
            string answer;
            Player player;
            //반복.
            do
            {
                player = new Player();
                player.hp = 10;
                Console.WriteLine($"플레이어의 hp 는 {player.hp}입니다. 다시 만드시겠습니까?(Y/N)");
                answer = Console.ReadLine().ToUpper();
                //Y 루프를 반복하자.
                // Y가 아닐 경우 루프를 나가자.
            } while (answer != "Y");

            Console.WriteLine(player.hp);
        }
    }

    internal class Player
    {
        internal int hp;
    }
}
