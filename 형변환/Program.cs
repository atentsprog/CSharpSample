using System;

namespace 형변환
{
    class Program
    {
        static void Main(string[] args)
        {
            Rich rich = new Rich { money = 100 };
            Man man = new Man() { name = "na" };
            RichMan richMan = rich + man;
            VeryRich veryRich = rich + rich;
            Rich rich3 = (Rich)veryRich;
            Console.WriteLine($"name:{richMan.name}, money:{richMan.money}");
        }
    }

    class Rich
    {
        public int money;

        public Rich() { }
        public Rich(int money)
        {
            this.money = money;
        }

        // 연산자 오버라이드
        public static RichMan operator +(Rich rich, Man man)
        {
            var result = new RichMan();
            result.money = rich.money;
            result.name = man.name;
            return result;
        }

        public static VeryRich operator +(Rich rich1, Rich rich2)
        {
            var resul = new VeryRich();
            resul.money = rich1.money + rich2.money;
            return resul;
        }

        /// <summary>
        /// 명시적 형변환
        /// </summary>
        /// <param name="b"></param>
        public static explicit operator Rich(VeryRich b)
        {
            return new Rich(b.money);
        }
    }

    class VeryRich
    {
        public int money;
    }

    class Man
    {
        public string name;
    }

    class RichMan
    {
        public int money;
        public string name;
    }
}
