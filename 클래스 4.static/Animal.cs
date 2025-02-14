﻿using System;

namespace 클래스_4.static변수_함수
{
    public class Animal
    {
        static int totalCount;
        string name = "이름";
        int power = 1;

        // 실행파일 실행시 항상 고정된 static Main함수 실행.
        // static함수는 인스턴스가 없어도 실행된다.
        // 인스턴스가 없는 상태에서 시작되므로 static함수로 설정.
        static void Main(string[] args)
        {
            Console.WriteLine("static설명");

            // 인스턴스가 독립적으로 사용하는 변수 함수는 static이 없다.
            // 인스턴스가 공용으로 사용하는 변수 함수는 static이 있다.

            Animal fox;
            fox = new Animal();
            fox.name = "여우";
            fox.power = 3;
            Animal.totalCount++;

            Animal lion;
            lion = new Animal();
            lion.name = "사자";
            lion.power = 5;

            // Animal 클래스 내에서 사용하므로 "Animal."생략 가능.
            // static변수는 해당 클래스 내에서 언제나 사용가능
            Animal.totalCount++; 
            

            Console.WriteLine($"전체 동물은 {totalCount}마리 있다");
            Console.WriteLine($"{fox.name}의 power는{fox.power}입니다");
            Console.WriteLine($"{lion.name}의 power는{lion.power}입니다");
        }
    }
}
