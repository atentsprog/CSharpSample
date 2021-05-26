using System;
using System.Diagnostics;

namespace 속성_Property_사용법
{
    class Player
    {
        #region power 를 함수 사용해서 접근 구현
        int power;
        public int GetPower() { return power; }
        public void SetPower(int value, string log)
        {
            if (power < 0)
            {
                Console.WriteLine($"너무 작은 값으로 설정시도함 {value}");
                return;
            }

            var temp = power;
            power = value;

            Console.WriteLine($"함수 사용해서 Power 변경 {temp} -> {power}, {log}이유때문");

            Debug.Assert(power > 0, "파워는 0보다 작으면 안되요! 분명 프로그래머가 실수 했어요");
        }
        #endregion 끝) power 를 함수 사용해서 접근 구현 

        #region hp 를 속성 사용해서 접근 구현
        int hp;

        public int HP // 프로퍼티는 대문자로 시작(코딩 규칙)
        {
            get { return hp; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine($"여기서 hp를 {value}설정함, 콜스택 확인해서 버그인지 체크하자");
                    return;
                }
                var temp = hp;
                hp = value;
                Console.WriteLine($"프로퍼티로 hp 변경 {temp} -> {hp}");


                // Assert : 조건이 true일 거라고 확신한다, 조건이 false라면 디버깅 모드로 실행했을때 자동으로 breakpoint 걸린다. 
                Debug.Assert(hp < 10000, "HP가 10000보다 크다는건 프로그래머가 실수 했거나. 유저가 해킹한거에요, 이 유저를 밴 합시다");
            }
        }
        #endregion 끝) hp 를 속성 사용해서 접근 구현 

        // 일반적인 변수를 통해서 접근.
        private string name; // 접근 권한 공통. 브레이크포인트 걸 수 없음. 추가 동작 지정불가
        public string GetName() { return name; }
        // 매직 변수는 클래스 내부에서만 설정 가능하고 (private)
        // 외부에서는 읽는 것만 가능하게 설정
        int magic;
        public int Magic
        {
            get { return magic * power; }
            private set { magic = value; }
        }
        public float MagicPower => magic * power;
        public float GetMagicPower(){return magic * power;}

        // 실제 변수 없이 프로퍼티만 사용 - 접근 권한만 간단히 제한할때.
        public int Age
        {
            get;
            private set;
        }

        public Player(string userName)
        {
            name = userName;
            // 변수에 바로 접근해서 변경해도 가능은 하지만 가능하면 래핑된 프로퍼티나 함수 통해서 변경하는게 버그 추적하기 쉽다.
            SetPower(1);
            power = 1;

            hp = 1;
            HP = 1;

            magic = 2;
            Magic = 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("속성 사용 예제예요");

            Player player = new Player("플레이어");

            //Console.WriteLine(player.name);
            //player.name = "새로운이름"; // 변수를 통한 접근
            player.SetPower(2);     // 함수를 통한 접근
            player.HP = 3;          // 속성을 통한 접근

            //player.Magic = 1;       //설정불가.
            int playerMagic = player.Magic; // 읽기만 가능
            int playerPower = player.GetPower();
            int playerHP = player.HP;
            Console.WriteLine($"{player.GetName()}, {playerMagic}, {playerPower}, {playerHP}");


            player.SetPower(-1);
            player.HP = 1000000;
        }
    }
}

