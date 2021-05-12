﻿using System;

namespace 클래스_3.접근한정자
{
    public class Father
    {
        private int 아빠만사용하는비상금; // 상속하지 않음.
        protected int 은닉재산;           //protected 상속 받은 클래스에서도 사용가능
        public int 공개된재산;           // 상속 받은 클래스와 외부에서 모두 사용가능

        public Father()
        {
            아빠만사용하는비상금 = 1000000000;
            은닉재산 = 200000000;
            공개된재산 = 290000;
        }
        void PrintMyMoney()
        {
            Console.WriteLine(아빠만사용하는비상금);
            Console.WriteLine(은닉재산);
            Console.WriteLine(공개된재산);
        }
    }
    public class Son : Father
    {
        void PrintMyMoney()
        {
            //Console.WriteLine(아빠만사용하는비상금);
            Console.WriteLine(은닉재산);
            Console.WriteLine(공개된재산);
        }

        internal void 은닉재산입금(int amount)
        {
            은닉재산 += amount;
        }

        internal void 다른사람재산보기(Son otherSon)
        {
            Console.WriteLine(otherSon.은닉재산);
            Console.WriteLine(otherSon.공개된재산);
        }

        internal void 다른사람재산보기(Father otherFather)
        {
            //Console.WriteLine(otherFather.은닉재산); // error
            Console.WriteLine(otherFather.공개된재산);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Son mySon = new Son();
            Son yourSon = new Son();

            mySon.은닉재산입금(100);
            yourSon.다른사람재산보기(mySon);
            yourSon.다른사람재산보기((Father)mySon);

            //Console.WriteLine(me.아빠만사용하는비상금); // error
            //Console.WriteLine(me.은닉재산); // error
            Console.WriteLine(mySon.공개된재산);
        }
    }
}
