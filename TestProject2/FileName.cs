using System;
using System.Collections.Generic;

class Program
{
    // Функция для проверки, является ли число простым
    public static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    // Основная функция
    public static (List<(int, int)> primeSquares, int count, int sum, List<string> errors) FindPrimeSquares(int[] arr)
    {
        List<(int, int)> primeSquares = new List<(int, int)>();
        List<string> errors = new List<string>();
        int sum = 0;
        int count = 0;

        if (arr == null || arr.Length == 0)
        {
            errors.Add("Массив пустой или null.");
            return (primeSquares, count, sum, errors);
        }

        foreach (var num in arr)
        {
            if (num < 0)
            {
                errors.Add($"Число {num} отрицательное, пропускаем.");
                continue;
            }

            // Проходим по всем возможным простым числам, чтобы найти их квадраты
            for (int i = 2; i * i <= num; i++)
            {
                if (IsPrime(i))
                {
                    int square = i * i;
                    if (square == num)
                    {
                        primeSquares.Add((Array.IndexOf(arr, num), num));
                        sum += num;
                        count++;
                        break;
                    }
                }
            }
        }

        return (primeSquares, count, sum, errors);
    }

    public static void main()
    {
        // Пример массива
        int[] array = { 4, 9, 15, 25, 49, 16, 18, 81 };

        // Вызов функции
        var (primeSquares, count, sum, errors) = FindPrimeSquares(array);

        // Вывод результата
        Console.WriteLine("Массив квадратов простых чисел:");
        foreach (var (index, value) in primeSquares)
        {
            Console.WriteLine($"Индекс: {index}, Значение: {value}");
        }

        Console.WriteLine($"Количество квадратов простых чисел: {count}");
        Console.WriteLine($"Сумма квадратов простых чисел: {sum}");

        if (errors.Count > 0)
        {
            Console.WriteLine("Ошибки:");
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }
    }
}