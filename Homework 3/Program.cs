using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3 File - based to -do list:
            // Create a console application that manages a to -do list using a text file for storage.
            // Users should be able to add, edit, delete, and view tasks.Completed tasks should be marked as done.
            // a.Create a new Console Application project in C#.
            //b.Create a Task class
            //c. Implement methods for adding, editing, deleting, and viewing tasks using a List<> to store the data.
            //f.Allow users to mark tasks as complete.

            string filePath = @"c:\data\tasks.txt";

            Console.WriteLine("Welcome to your ToDoApp");
            Console.WriteLine("---------------");

            List<Task> tasks = LoadTasks(filePath);

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Type your choice:");

                Console.WriteLine("1. Add a task --------------- DONE");
                Console.WriteLine("2. Edit a task --------------- DONE");
                Console.WriteLine("3. Delete a task --------------- DONE");
                Console.WriteLine("4. View all tasks --------------- DONE");
                Console.WriteLine("5. Show only done tasks --------------- DONE");
                Console.WriteLine("6. Save tasks");
                Console.WriteLine("7. Exit");

                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        AddTask(tasks);
                        break;
                    case 2:
                        EditTask(tasks);
                        break;
                    case 3:
                        DeleteTask(tasks);
                        break;
                    case 4:
                        ViewAllTasks(tasks);
                        break;
                    case 5:
                        ShowOnlyDoneTasks(tasks);
                        break;
                    case 6:
                        SaveTasks(filePath, tasks);
                        Console.WriteLine("Saving...");
                        Console.WriteLine("Done!");
                        break;
                    case 7:
                        isRunning = false;
                        Console.WriteLine("See you next time!");
                        break;
                    default:
                        Console.WriteLine("Wrong choice, try again");
                        break;
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public static List<Task> LoadTasks(string filePath)
        {
            List<Task> tasks = new List<Task>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    Task task = new Task(parts[0], DateTime.Parse(parts[1]), bool.Parse(parts[2]));
                    tasks.Add(task);
                }
            }

            return tasks;
        }

        public static void SaveTasks(string filePath, List<Task> tasks)
        {
            List<string> lines = new List<string>();

            foreach (Task task in tasks)
            {
                string line = $"{task.name};{task.deadline};{task.isFinished}";
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);
        }

        public static void ShowOnlyDoneTasks(List<Task> tasks)
        {
            Console.WriteLine("FINISHED tasks list: ");

            foreach (Task task in tasks)
            {
                if (task.isFinished) Console.WriteLine($"{task.name} is completed");
            }
        }

        public static void ViewAllTasks(List<Task> tasks)
        {
            Console.WriteLine("Your tasks list: ");

            foreach (Task task in tasks)
            {
                Console.WriteLine($"Task name: {task.name}, Deadline: {task.deadline}, Completed? {task.isFinished}");
            }
        }

        public static void DeleteTask(List<Task> tasks)
        {
            Console.WriteLine("Task to delete: ");
            string taskName = Console.ReadLine();

            Task task = tasks.Find(el => el.name == taskName);

            if (task != null)
            {
                tasks.Remove(task);
                Console.WriteLine("Task deleted");
            }
            else
            {
                Console.WriteLine("Task doesn't exist");
            }
            Console.WriteLine();
        }

        public static void EditTask(List<Task> tasks)
        {
            Console.WriteLine("Type task to edit: ");
            string name = Console.ReadLine();
            //string name = "Cleaning";

            Task task = tasks.Find(el => el.name == name);
            if (task != null)
            {
                Console.WriteLine("Type new task's name: ");
                string newName = Console.ReadLine();
                //string newName = "Cleaning";

                Console.WriteLine("Type new deadline date: (MM/DD/YYYY): ");
                DateTime newDeadlineDate = DateTime.Parse(Console.ReadLine());
                //DateTime newDeadlineDate = DateTime.Parse("16/05/2023");

                Console.WriteLine("Is task finished? y/n");
                string newStatement = Console.ReadLine();
                if (newStatement == "y")
                {
                    task.isFinished = true;
                }
                else
                {
                    task.isFinished = false;
                }


                task.name = newName;
                task.deadline = newDeadlineDate;

                Console.WriteLine("Task's data edited successfully");
            }
            else
            {
                Console.WriteLine("Task doesn't exist");
            }
        }

        public static void AddTask(List<Task> tasks)
        {
            Console.WriteLine("Name of task: ");
            string name = Console.ReadLine();
            //string name = "Cleaning";

            Console.WriteLine("Date of task deadline (MM/DD/YYYY): ");
            DateTime deadlineDate = DateTime.Parse(Console.ReadLine());
            //DateTime deadlineDate = DateTime.Parse("20/05/2023");

            Task task = new Task(name, deadlineDate);
            tasks.Add(task);
            Console.WriteLine($"Task {task.name} added");
            Console.WriteLine();
        }

    }
}
