using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            5 Password strength checker:
            //            Design a console application that evaluates the strength of a given password based on its length,
            //            use of special characters, numbers, and uppercase and lowercase letters.
            //The application should provide a password strength score and suggestions for improvement.
            //a.Create a new Console Application project in C#.
            //b.Create a method that takes a password input and calculates its strength based on its length, use of special characters, numbers, and uppercase and lowercase letters.
            //c.Assign a score to the password based on each strength criterion.
            //d.Add a method to provide suggestions for improving the password's strength.
            //e.Prompt the user to input a password.
            //f.Use the created methods to evaluate the password's strength, display the score, and provide suggestions for improvement.

            Console.WriteLine("Password checked - type ur password below: ");
            string password = Console.ReadLine();
            //string password = "tYr";

            int lowercaseScore = GetLowerCaseScore(password);
            int uppercaseScore = GetUpperCaseScore(password);
            int lengthScore = GetLengthScore(password);
            int numbersScore = GetNumberScore(password);
            int specialCharScore = GetSpecialCharScore(password);

            int totalScore = lowercaseScore + uppercaseScore + numbersScore + specialCharScore + lengthScore;
            Console.WriteLine($"Your password score is {totalScore}");

            if (totalScore < 6)
            {
                Console.WriteLine("Your password is weak.");
                PasswordSuggestions(password);
            }
            else
            {
                Console.WriteLine("Your password is strong, good job!");
            }

            Console.ReadKey();
        }

        private static int GetSpecialCharScore(string password)
        {
            if (password.Any(c => char.IsLetterOrDigit(c)))
            {
                return 2;
            } else
            {
                return 0;
            }
        }

        private static int GetLowerCaseScore(string password)
        {
            if (password.Any(c => char.IsLower(c)))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static int GetNumberScore(string password)
        {
            if (password.Any(c => char.IsNumber(c)))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static int GetLengthScore(string password)
        {
            int passwordLength = password.Length;
            if (passwordLength > 6 && passwordLength < 9)
            {
                return 1;
            }
            else if (passwordLength > 9)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        private static int GetUpperCaseScore(string password)
        {
            if (password.Any(c => char.IsUpper(c)))
            {
                return 1;
            }else
            {
                return 0;
            }
        }

        static string PasswordSuggestions(string password)
        {
            string suggestion = "";
            if (GetLowerCaseScore(password) == 0 && GetUpperCaseScore(password) == 0)
            {
                suggestion += "Mix more big and small letters! ";
            }
            if (GetNumberScore(password) == 0)
            {
                suggestion += "More numbers! ";
            }
            if (GetLengthScore(password) == 0)
            {
                suggestion += "Use longer password! ";
            }
            if (GetSpecialCharScore(password) == 0)
            {
                suggestion += "Use more special characters! ";
            }
            Console.WriteLine(suggestion);
            return suggestion;
        }
    }
}
