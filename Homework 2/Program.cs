using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            2 Birthday reminder application:
            //            Design a console application that allows users to store and manage their friends' birthdays. 
            //Users should be able to add, edit, delete, and view birthdays. 
            //The application should also remind users of upcoming birthdays.
            //a.Create a new Console Application project in C#.
            //b. Create a Friend class
            //c. Implement methods for adding, editing, deleting, and viewing friends using a List<> to store the data.
            //d.Add a method to check for upcoming birthdays and notify the user.

            List<Friend> friends = new List<Friend>();






            Console.WriteLine("Welcome to Birthday Reminder!");

            bool isRunning = true;

            while (isRunning)
            {

                Console.WriteLine("1. Add a friend");
                Console.WriteLine("2. Edit a friend");
                Console.WriteLine("3. Delete a friend - still doesnt work");
                Console.WriteLine("4. View all friends");
                Console.WriteLine("5. Check for upcoming birthdays - still doesnt work");
                Console.WriteLine("6. Exit");

                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        AddFriend(friends);
                        break;
                    case 2:
                        EditFriend(friends);
                        break;
                    case 3:
                        DeleteFriend();
                        break;
                    case 4:
                        ViewAllFriends(friends);
                        break;
                    case 5:
                        CheckForUpcommingBirthdays();
                        break;
                    case 6:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choice, try again.");
                        break;
                }
            }



        }
        public static void AddFriend(List<Friend> friends)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            //string name = "Krystian";

            Console.Write("Birthday (MM/DD/YYYY): ");
            string birthday = Console.ReadLine();
            //string birthday = "22/10/1992";
            Console.WriteLine();

            DateTime birthdayDateTime = DateTime.Parse(birthday);
            Friend friend = new Friend(name, birthdayDateTime);
            friends.Add(friend);

            Console.WriteLine("{0} is added to you friend list.", name);
            Console.WriteLine();




        }
        public static void EditFriend(List<Friend> friends)
        {
            Console.Write("Type friend to edit: ");
            string name = Console.ReadLine();

            Friend friend = friends.Find(el => el.name == name);
                if (friend != null )
                {
                    Console.Write("New friend's name: ");
                    string newName = Console.ReadLine();

                    Console.Write("New friend's birthday (MM/DD/YYYY): ");
                    string newBirthday = Console.ReadLine();
                    DateTime newBirthdayDateTime = DateTime.Parse(newBirthday);

                    friend.name = newName;
                    friend.birthday = newBirthdayDateTime;

                    Console.WriteLine("Friend's data edited successfully");
                } else
                {
                    Console.WriteLine("Friend doesn't exists");
                }
                Console.WriteLine();
            

        }
        public static void DeleteFriend() { }

        public static void ViewAllFriends(List<Friend> friends)
        {
            Console.WriteLine("Your friends list: ");

            foreach (Friend friend in friends)
            {
                Console.WriteLine("{0} - {1}", friend.name, friend.birthday);
            }

            Console.WriteLine();
        }
        public static void CheckForUpcommingBirthdays() { }



    }
}
