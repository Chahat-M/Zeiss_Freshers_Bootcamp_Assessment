using System.Text.RegularExpressions;

namespace StringCalc
{
    public class StringSum
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)){
                return 0;
            }

            char[] delimiters = { ',', '\n' };

            if (numbers.StartsWith("//"))
            {
                string delimiterDefinition = numbers.Split('\n')[0].Substring(2);
                if (delimiterDefinition.StartsWith("[") && delimiterDefinition.EndsWith("]"))
                {
                    var matches = Regex.Matches(delimiterDefinition, @"\[(.*?)\]");
                    delimiters = delimiters.Concat(matches.Select(match => match.Groups[1].Value[0])).ToArray();
                }
                else
                {
                    delimiters = new[] { delimiterDefinition[0] };
                }

                numbers = numbers.Split('\n')[1];
            }

            List<int> negatives = new List<int>();
            int sum = 0;

            foreach (string numStr in numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries))
            {
                int number = int.Parse(numStr);

                if (number < 0)
                {
                    negatives.Add(number);
                }

                if (number <= 1000)
                {
                    sum += number;
                }
            }

            if (negatives.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negatives)}");
            }

            return sum;
        }


    }


}



