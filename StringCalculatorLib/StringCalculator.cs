using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StringCalculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        string delimiter = GetDelimiter(numbers);
        string[] numberArray = SplitNumbers(numbers, delimiter);

        ValidateInputFormat(numberArray);

        ValidateNegatives(numberArray);

        return IgnoreLargerNumbers(numberArray);
    }

    private static string GetDelimiter(string numbers)
    {
        string defaultDelimiter = ",|\n";

        if (numbers.StartsWith("//"))
        {
            int delimiterIndex = numbers.IndexOf('\n') + 1;
            return numbers.Substring(2, delimiterIndex - 3);
        }

        return defaultDelimiter;
    }

    private static string[] SplitNumbers(string numbers, string delimiter)
    {
        return Regex.Split(numbers, delimiter);
    }

    private static void ValidateInputFormat(string[] numberArray)
    {
        if (numberArray.Length == 2 && string.IsNullOrWhiteSpace(numberArray[1]))
        {
            throw new Exception("Invalid input format");
        }
    }

    private static void ValidateNegatives(string[] numberArray)
    {
        List<int> negativeNumbers = numberArray.Select(int.Parse).Where(x => x < 0).ToList();
        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives not allowed - {string.Join(", ", negativeNumbers)}");
        }
    }

    private static int IgnoreLargerNumbers(string[] numberArray)
    {
        List<int> numbers = numberArray.Select(int.Parse).Where(x => x <= 1000).ToList();
        return numbers.Sum();
    }

}

