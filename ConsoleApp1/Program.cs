/*
---1---
Создайте приложение, которое отображает текстовое сообщение.
Используйте механизмы делегатов. Делегат должен
возвращать void и принимать один параметр типа string
(текст сообщения). Для тестирования приложения создайте
различные методы вызова через делегат.
---2---
Создайте приложение для выполнения арифметических операций. Поддерживаемые операции:
■ Сложение двух чисел;
Вычитание двух чисел; ■ Вычитание двух чисел;
Умножение двух чисел; ■ Умножение двух чисел.
Код приложения обязательно должен использовать механизм
делегатов.
---3---
Создайте приложения для выполнения арифметических операций. Поддерживаемые операции:
■ Проверка числа на четность;
■Проверка числа на нечетность; 
■ Проверка числа на нечетность;
■Проверка на простое число;
■Проверка на число Фибоначчи.
Обязательно используйте делегат типа Predicate
---4---
Реализуйте приложение из второго практического задания
с помощью вызова Invoke.
 */

using Microsoft.VisualBasic;
using System;

namespace HW_12_21_06_2024
{
    internal class Program
    {
        public delegate void StrDel(string text);
        public delegate int MathDel(int a, int b);
        Predicate<int> pred;
        static void Main(string[] args)
        {
            //task 1
            TextMessage message = new TextMessage();
            StrDel myDel = message.SayHello;
            myDel += message.AskAge;
            myDel += message.SayGoodBye;
            myDel.Invoke("Andrii");
            //task 2
            MyMath myMath = new MyMath();
            MathDel mathDel = myMath.Sum;
            mathDel += myMath.Mult;
            mathDel += myMath.Diff;
            foreach (var operation in mathDel.GetInvocationList())
            {
                Console.WriteLine(((MathDel)operation).Invoke(5, 2));
            }
            //task 3
            MathTest mathTest = new MathTest();
            Predicate<int> predicate = mathTest.isParity;
            Console.WriteLine($"Is parity: {predicate(16)}");
            predicate = mathTest.isOddnes;
            Console.WriteLine($"Is oddnes: {predicate(15)}");
            predicate = mathTest.isPrime;
            Console.WriteLine($"Is prime: {predicate(12)}");
            predicate = mathTest.isFibonacci;
            Console.WriteLine($"Is Fibonacci number: {predicate(10946)}");
            Console.WriteLine($"Is Fibonacci number: {predicate(10947)}");
        }
    }
}