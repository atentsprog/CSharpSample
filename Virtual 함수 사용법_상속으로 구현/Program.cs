﻿using System;
using System.Collections.Generic;

namespace Virtual_함수_사용법_상속으로_구현
{
    class Monster
    {
        public virtual void Attack(Player player)
        {
            Console.WriteLine("여기는 자식이 override한 함수가 없을때만 호출됨");
        }
    }

    class ChildMonsterA : Monster
    {
    }
    class ChildMonsterB : Monster
    {
        public void Attack(Player player)
        {
            Console.WriteLine("B Attack");
        }
    }

    class ChildMonsterC : Monster
    {
        override public void Attack(Player player)
        {
            Console.WriteLine("C Attack");
        }
    }

    class Player : IDo1, IDo2
    {

        public void Do1()
        {
            throw new NotImplementedException();
        }

        public void Do2()
        {
            throw new NotImplementedException();
        }

        void IDo1.Do()
        {
            throw new NotImplementedException();
        }

        void IDo2.Do()
        {
            throw new NotImplementedException();
        }
    }

    internal interface IDo2
    {
        void Do2();
        void Do();
    }

    internal interface IDo1
    {
        void Do1();
        void Do();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("virtual 사용법 - 상속으로 구현");

            Player player = new Player();
            ((IDo1)player).Do();
            ((IDo2)player).Do();

            ChildMonsterA a1 = new ChildMonsterA();
            ChildMonsterA a2 = new ChildMonsterA();
            ChildMonsterA a3 = new ChildMonsterA();

            ChildMonsterB b1 = new ChildMonsterB();
            ChildMonsterB b2 = new ChildMonsterB();
            
            ChildMonsterC c1 = new ChildMonsterC();

            List<Monster> allMonsters = new List<Monster> { a1, a2, a3, b1, b2, c1 };

            allMonsters.ForEach(x => x.Attack(player));
        }
    }
}
