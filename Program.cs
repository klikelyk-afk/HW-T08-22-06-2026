using System;
using System.Collections.Generic;

class Program
{

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int[] numbers = { 1, 2, 3, 4, 5, 8, 11, 13, 17, 20, 21, 34, 55 };
        Console.WriteLine("Початковий масив: " + string.Join(", ", numbers));
        Console.WriteLine(new string('-', 40));

        int[] evens = FilterArray(numbers, IsEven);
        int[] odds = FilterArray(numbers, IsOdd);
        int[] primes = FilterArray(numbers, IsPrime);
        int[] fibonacci = FilterArray(numbers, IsFibonacci);

        Console.WriteLine("Парні числа: " + string.Join(", ", evens));
        Console.WriteLine("Непарні числа: " + string.Join(", ", odds));
        Console.WriteLine("Прості числа: " + string.Join(", ", primes));
        Console.WriteLine("Числа Фібоначчі: " + string.Join(", ", fibonacci));

        Console.WriteLine(new string('-', 40));
        Console.WriteLine("--- ЗАВДАННЯ 2 ---");

        Action showTime = DisplayCurrentTime;
        Action showDate = DisplayCurrentDate;
        Action showDay = DisplayCurrentDayOfWeek;

        Func<double, double, double> triangleArea = CalculateTriangleArea;
        Func<double, double, double> rectangleArea = CalculateRectangleArea;

        showTime();
        showDate();
        showDay();

        double tArea = triangleArea(5, 10);
        double rArea = rectangleArea(4, 7);

        Console.WriteLine("Площа трикутника (основа 5, висота 10): " + tArea);
        Console.WriteLine("Площа прямокутника (сторони 4 и 7): " + rArea);
    }

    static int[] FilterArray(int[] array, Predicate<int> condition)
    {
        List<int> result = new List<int>();
        foreach (int num in array)
        {
            if (condition(num))
            {
                result.Add(num);
            }
        }
        return result.ToArray();
    }

    static bool IsEven(int number) => number % 2 == 0;
    static bool IsOdd(int number) => number % 2 != 0;

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static bool IsFibonacci(int number)
    {
        if (number < 0) return false;

        return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
    }

    static bool IsPerfectSquare(int x)
    {
        int s = (int)Math.Sqrt(x);
        return s * s == x;
    }


    static void DisplayCurrentTime()
    {
        Console.WriteLine("Поточний час: " + DateTime.Now.ToLongTimeString());
    }

    static void DisplayCurrentDate()
    {
        Console.WriteLine("Поточна дата: " + DateTime.Now.ToShortDateString());
    }

    static void DisplayCurrentDayOfWeek()
    {
        Console.WriteLine("Поточний день тижня: " + DateTime.Now.DayOfWeek);
    }

    static double CalculateTriangleArea(double baseLen, double height)
    {
        return 0.5 * baseLen * height;
    }

    static double CalculateRectangleArea(double width, double height)
    {
        return width * height;
    }
}