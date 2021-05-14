using System;
using System.Collections.Generic;

namespace List에_함수_넣어서_실행하기
{
    class Program
    {
        static Random random = new Random();
        static List<Action<Player, Monster>> attackActions = new List<Action<Player, Monster>>();
        static void Main(string[] args)
        {
            attackActions.Add(NormalAttack);
            attackActions.Add(SkillAttack);

            Player player = new Player();
            Monster monster = new Monster();

            int attackIndex = random.Next(0, attackActions.Count);
            attackActions[attackIndex](player, monster);
            attackActions.RemoveAt(attackIndex); // 사용한 어택 삭제.



            attackIndex = random.Next(0, attackActions.Count);
            attackActions[attackIndex](player, monster);
            attackActions.RemoveAt(attackIndex); // 사용한 어택 삭제.
        }
        static public void NormalAttack(Player player, Monster monster)
        {
            Console.WriteLine("플레이어가 몬스터를 일반 공격");
        }
        static public void SkillAttack(Player player, Monster monster)
        {
            Console.WriteLine("플레이어가 몬스터를 스킬공격");
        }
    }

    class Monster
    {
        public int power;
        public int hp;
    }

    class Player
    {
        public int power;
        public int hp;
    }
}
