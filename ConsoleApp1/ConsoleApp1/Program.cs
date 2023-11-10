using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int[] numbers = new int[10];
        Random random = new Random();

        Console.WriteLine("Масив чисел:");

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(0, 51);
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine();

        Thread thread1 = new Thread(() =>
        {
            int countGreaterThan10 = CountNumbersGreaterThan10(numbers);
            Console.WriteLine("Кiлькiсть чисел бiльших за 10: " + countGreaterThan10);
        });

        Thread thread2 = new Thread(() =>
        {
            int countEvenNumbers = CountEvenNumbers(numbers);
            Console.WriteLine("Кiлькiсть парних чисел: " + countEvenNumbers);
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }

    static int CountNumbersGreaterThan10(int[] array)
    {
        int count = 0;
        foreach (var number in array)
        {
            if (number > 10)
            {
                count++;
            }
        }
        return count;
    }

    static int CountEvenNumbers(int[] array)
    {
        int count = 0;
        foreach (var number in array)
        {
            if (number % 2 == 0)
            {
                count++;
            }
        }
        return count;
    }
}
