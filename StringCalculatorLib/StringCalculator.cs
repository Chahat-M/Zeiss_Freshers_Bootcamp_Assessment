using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StringCalculator
{
    public static int Add(string numbers)
    {
        return AddNumbers(ParseNumbers(numbers));
    }

    private static List<int> ParseNumbers(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return new List<int>();
        }

        string delimiter = GetDelimiter(numbers);
        string[] numberArray = SplitNumbers(numbers, delimiter);
        ValidateNegatives(numberArray);

        return numberArray.Select(int.Parse).Where(x => x <= 1000).ToList();
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

    private static void ValidateNegatives(string[] numberArray)
    {
        List<int> negativeNumbers = numberArray.Select(int.Parse).Where(x => x < 0).ToList();
        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives not allowed - {string.Join(", ", negativeNumbers)}");
        }
    }

    private static int AddNumbers(List<int> numbers)
    {
        return numbers.Sum();
    }
}
