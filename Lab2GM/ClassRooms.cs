using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2GM
{
    public class ClassRooms
    {
        static public string className { get; set; }
        public static List<string> classes = new List<string>();
        public static List<string> classRoster = new List<string>();
        public ClassRooms(string input)
        {
            className = input;
            classRoster = new List<string>();
        }
        public ClassRooms()
        {

        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Class Management Portal!");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1: Show Classrooms");
            Console.WriteLine("2: Add Classrooms");
            Console.WriteLine("3: Edit Classroom");
            Console.WriteLine("4: Remove Classroom");
            Console.WriteLine("5: Classroom Details");
            Console.WriteLine("0: Exit");
            Console.WriteLine();
            Console.WriteLine("Please select from the options above: ");
            Console.WriteLine();

            string userInput = Console.ReadLine();
            //int selection = int.Parse(userInput);
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    ShowClasses();
                    Console.Read();
                    Console.WriteLine("Press any key to return to the previous menu");
                    MainMenu();
                    break;
                case "2":
                    Console.Clear();
                    AddClass();
                    MainMenu();
                    break;
                case "3":
                    Console.Clear();
                    EditClass();
                    MainMenu();
                    break;
                case "4":
                    Console.Clear();
                    RemoveClass();
                    MainMenu();
                    break;
                case "5":
                    Console.Clear();
                    ClassSelection();
                    break;
                case "6":
                    Console.Clear();
                    Students.ClassReport();
                    break;
                case "0":
                    Console.Clear();
                    Console.WriteLine("Thank you for using the Class Management Portal.");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to exit the system.");
                    Environment.Exit(-1);
                    break;
                default:
                    Console.WriteLine("Incorrect Option entered.  Please try again.");
                    MainMenu();
                    break;
            }
        }
        public static void AddClass()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the Class that you would like to add:");
            Console.WriteLine("-------------------------------------------------------");
            var userInput = Console.ReadLine();
            var classroom = new ClassRooms(userInput);
            className = userInput;
            classes.Add(className);
        }
        public static void ShowClasses()
        {
            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine($"{i}: {classes[i]}");
            }
            Console.WriteLine("Press any key to return to the previous menu!");
            Console.ReadLine();
            MainMenu();
        }

        public static void RemoveClass()
        {
            Console.Clear();
            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine($"{i}: {classes[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Please enter the class name to be removed:");
            Console.WriteLine("------------------------------------------");
            string userInput = Console.ReadLine();
            //int selection = int.Parse(userInput);
            for (var i = 0; i < classes.Count; i++)
            {
                if (classes[i].Equals(userInput))
                {
                    classes.RemoveAt(i);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Removed Class {userInput}");
            Console.ReadLine();
            Console.WriteLine("Press any key to return to the previous menu");
        }
        public static void ClassSelection()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Please enter the class name to view its details:");
            Console.WriteLine("------------------------------------------------");
            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine($"{i}: {classes[i]}");
            }
            Console.WriteLine("------------------------------------------------");
            string userInput = Console.ReadLine();
            //for(var i = 0; i < classes.Count; i++)
            for (var i = 0; i < classes.Count; i++)
            {
                if (classes[i].Equals(userInput))
                {
                    ClassRooms classSelection = new ClassRooms();
                    Students.ClassDetailsMenu(classSelection);
                }
                else
                {
                    Console.WriteLine("Invalid selection, please press any key to return to the previous menu and try again.");
                    Console.Read();
                    ClassSelection();
                }
            }
        }
        public static void EditClass()
        {
            Console.Clear();
            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine($"{i}: {classes[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Please enter the class name to be edited:");
            Console.WriteLine("------------------------------------------");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the updated name for the class");
            string userInput2 = Console.ReadLine();
            for (var i = 0; i < classes.Count; i++)
            {
                if (classes[i].Equals(userInput))
                {
                    classes.RemoveAt(i);
                    classes.Insert(i, userInput2);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Updated {userInput} to {userInput2}");
        }
    }
}

