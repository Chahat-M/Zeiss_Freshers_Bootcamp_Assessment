## String Calculator

1. Create a simple String calculator with a method signature:
———————————————
int Add(string numbers)
———————————————
The method can take up to two numbers, separated by commas, and will return their sum. 
for example “” or “1” or “1,2” as inputs.
(for an empty string it will return 0)

Hints:
——————
 - Start with the simplest test case of an empty string and move to one and two numbers
 - Remember to solve things as simply as possible so that you force yourself to write tests you did not think about
 - Remember to refactor after each passing test
———————————————————————————————
2. Allow the Add method to handle an unknown amount of numbers
————————————————————————————————
3. Allow the Add method to handle new lines between numbers (instead of commas).
the following input is ok: “1\n2,3” (will equal 6)
the following input is NOT ok: “1,\n” (not need to prove it - just clarifying)
——————————————————————————————-
4. Support different delimiters
to change a delimiter, the beginning of the string will contain a separate line that looks like this: “//[delimiter]\n[numbers…]” for example “//;\n1;2” should return three where the default delimiter is ‘;’ .
the first line is optional. all existing scenarios should still be supported
————————————————————————————————
5. Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed. 
if there are multiple negatives, show all of them in the exception message.
————————————————————————————————
STOP HERE if you are a beginner. Continue if you can finish the steps so far in less than 30 minutes.
————————————————————————————————
6. Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2
————————————————————————————————
7. Delimiters can be of any length with the following format: “//[delimiter]\n” for example: “//[***]\n1***2***3” should return 6
————————————————————————————————
8. Allow multiple delimiters like this: “//[delim1][delim2]\n” for example “//[*][%]\n1*2%3” should return 6.
————————————————————————————————
9. make sure you can also handle multiple delimiters with length longer than one char

## Requirement specifications -
1. Add function for 2 string numbers
2. Add the string numbers to return sum.
3. Delimiters allowed = comma, \n, 
4. for empty string, return 0
5. -ve numbers not allowed
6. delimiter can be changed by introducing // in the beginning
7. 4 digit nos ignored
8. Multi-length delimiters allowed

## Test specifications - 
1. Given " " when Add then 0
2. Given "1" (single digit) when Add then 1
3. Given "1,2" (2 digits separated by ,) when Add then 3
4. Given "1\n2,3" when Add then 6
5. Given "1,\n" when Add then exception raised
6. Given "1\n2" when Add then 3
7. Given "//;\n1;2" when Add then 3
8. Given "-1,-2" when Add then "Negatives not allowed - -1, -2"
9. Given "2 + 1001" when Add then 2
10. Given "1001 + -1" when Add then "Negatives not allowed - -1"
11. Given "//[**]\n1**2**3" when Add then 6
12. Given "//[*][%]\n1*2%3" when Add then 6
13. Given "//[*][%%]\n1*2%%3" when Add then 6
