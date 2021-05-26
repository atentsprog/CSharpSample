using System;

namespace 함수파리미터
{
    class MyClass
    {
        public int propertyI { get; set; }
        public int i;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("in out ref파라미터");

            int i = 1;
            MyClass myClass = new MyClass();

            // 일반 파라미터
            Fn(myClass.i);

            // 3. ref
            FnRef(ref myClass.i);
            //FnRef(ref myClass.propertyI); // 에러 안됨

            //1. in
            FnIn(in myClass.i);
            //FnRef(in myClass.propertyI); // 에러 안됨

            // 2. out
            FnOut(out myClass.i);
            FnRef(out myClass.propertyI); // 에러 안됨
        }

        private static void Fn(int i)
        {
            i++;
            Console.WriteLine(i);
        }

        private static void FnRef(ref int i)
        {
            i++;
        }

        private static void FnOut(out int i)
        {
            i = 1;
        }

        private static void FnIn(in int i)
        {
            Console.WriteLine(i);
        }
    }
}
