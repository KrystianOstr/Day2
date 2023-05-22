using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            4 Palindrome checker:
            //Create a console application that checks if a given word or phrase is a palindrome.
            //The application should ignore spaces, punctuation, and capitalization.
            //a.Create a new Console Application project in C#.
            //b. Create a method that takes a string input and removes spaces, punctuation, and capitalization using string.ToLower() and a regular expression with Regex.Replace().
            //c.Create a method to reverse the cleaned input string using a for loop or the Array.Reverse() method.
            //d.Add a method to compare the cleaned input string and its reversed version to check if it is a palindrome.
            //e.Prompt the user to input a word or phrase.
            //f.Use the created methods to check if the input is a palindrome and display the result to the user.

            Console.WriteLine("It's palindrome checker app - just gimme a sentence");
            //string palindrome = Console.ReadLine();
            string input = "A to idiota.";

            string cleanedString = CleanInput(input);
            string reversedString = ReversedString(cleanedString);

            Console.WriteLine(cleanedString);
            Console.WriteLine(reversedString);

            if (IsPalindrome(cleanedString, reversedString))
            {
                Console.WriteLine("It's palindrome");
            } else
            {
                Console.WriteLine("It's NOT palindrome");
            }

            Console.ReadKey();
        }

        //string stringWithOutWhitespaces = String.Concat(str.Where(c => !Char.IsWhiteSpace(c)));
        static string CleanInput(string input)
        {
            string cleanedInput = Regex.Replace(input.ToLower(), "[^a-z0-9]", "");
            return cleanedInput;
        }

        static string ReversedString(string input)
        {

            char[] charArr = input.ToCharArray();
            Array.Reverse(charArr);

            return new string(charArr);
        }

        static bool IsPalindrome(string input, string reversedString)
        {
            if (input == reversedString)
            {
                return true;
            } else
            {
                return false;
            }
        }

    }

}
