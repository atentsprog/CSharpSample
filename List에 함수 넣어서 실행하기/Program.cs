using System;
using System.Collections.Generic;

namespace List에_함수_넣어서_실행하기
{
    class Program
    {
        static Random random = new Random();
        static List<Action<Player, List<Monster>>> attackActions = new List<Action<Player, List<Monster>>>();
        static List<Func<Player, Monster, bool>> returnBAttackActions = new List<Func<Player, Monster, bool>>();

        static void Main(string[] args)
        {
            attackActions.Add(NormalAttack);
            attackActions.Add(SkillAttack);


            Player player = new Player();
            List<Monster> monsters = new List<Monster>();
            monsters.Add(new Monster());

            int attackIndex = random.Next(0, attackActions.Count);
            attackActions[attackIndex](player, monsters);
            attackActions.RemoveAt(attackIndex); // 사용한 어택 삭제.



            attackIndex = random.Next(0, attackActions.Count);
            attackActions[attackIndex](player, monsters);
            attackActions.RemoveAt(attackIndex); // 사용한 어택 삭제.
        }
        static public bool ReturnBNormalAttack(Player player, Monster monster)
        {
            Console.WriteLine("플레이어가 몬스터를 일반 공격");
            return true;
        }

        static public bool ReturnBSkillAttack(Player player, Monster monster)
        {
            Console.WriteLine("플레이어가 몬스터를 스킬공격");
            return true;
        }

        static public void NormalAttack(Player player, List<Monster> monsters)
        {
            Console.WriteLine("플레이어가 몬스터를 일반 공격");
        }
        static public void SkillAttack(Player player, List<Monster> monsters)
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
