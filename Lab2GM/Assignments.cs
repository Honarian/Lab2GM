using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2GM
{


    public class Assignments
    {
        static string assignmentName { get; set; }
        static List<int?> assignmentGrade = new List<int?>();
        public Assignments(string input)
        {
            string studentName = input;
            assignmentGrade = new List<int?>();
        }
        public Assignments()
        {

        }
        public static void StudentDetailsMenu(Students studentSelection)
        {
            bool keepRunning = true;

            do
            {
                Console.Clear();
                Console.WriteLine($"Welcome to {Students.studentName}'s Grade Management Portal");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Please choose from the following options: ");
                Console.WriteLine();
                Console.WriteLine("1: Add Assignment");
                Console.WriteLine("2: Edit Assignment");
                Console.WriteLine("3: Remove Assignment");
                Console.WriteLine("4: View all Assignment for Student");
                Console.WriteLine("5: Add Assignment Grade");
                Console.WriteLine("6: Edit Assignment Grade");
                Console.WriteLine("7: Remove Assignment Grade");
                Console.WriteLine("8: Check Entered Grades");
                Console.WriteLine("9: View Student Report");
                Console.WriteLine("0: Return to the previous Menu");
                Console.WriteLine("----------------------------------------");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        AddAssignment();
                        break;
                    case "2":
                        Console.Clear();
                        EditAssignment();
                        break;
                    case "3":
                        Console.Clear();
                        RemoveAssignment();
                        break;
                    case "4":
                        Console.Clear();
                        ShowAssignments();
                        break;
                    case "5":
                        Console.Clear();
                        AddGrade();
                        break;
                    case "6":

                        Console.Clear();
                        EditGrade();
                        break;
                    case "7":
                        Console.Clear();
                        RemoveGrade();
                        break;
                    case "8":
                        Console.Clear();
                        ShowGrade();
                        break;
                    case "9":
                        Console.Clear();
                        StudentReport();
                        break;
                    case "0":
                        Console.Clear();
                        keepRunning = false;
                        //ClassRooms.MainMenu();
                        break;
                } 
            } while (keepRunning == true);
        }
        public static void AddAssignment()
        {            
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Enter Assignment Name:");
            string name = Console.ReadLine();
            //Assignments assignment = new Assignments(name);
            Assignments.assignmentGrade.Add(null); 
            Students.assignments.Add(name);
            Console.WriteLine();
            Console.WriteLine($"Added: {name} to {Students.studentName}");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the previous menu.");
            Console.ReadLine();
        }
        public static void EditAssignment()
        {
            Console.Clear();
            for (int i = 0; i < Students.assignments.Count; i++)
            {
                Console.WriteLine($"{i}: {Students.assignments[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Please enter the assignment name to be edited:");
            Console.WriteLine("------------------------------------------");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the updated name for the assignment");
            string userInput2 = Console.ReadLine();
            for (var i = 0; i < ClassRooms.classRoster.Count; i++)
            {
                if (Students.assignments[i].Equals(userInput))
                {
                    Students.assignments.RemoveAt(i);
                    Students.assignments.Insert(i, userInput2);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Updated {userInput} to {userInput2}");
        }
        public static void RemoveAssignment()
        {
            Console.Clear();
            for (int i = 0; i < Students.assignments.Count; i++)
            {
                Console.WriteLine($"{i}: {Students.assignments[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Please enter the assignment name to be removed:");
            Console.WriteLine("------------------------------------------");
            string userInput = Console.ReadLine();
            //int selection = int.Parse(userInput);
            for (var i = 0; i < Students.assignments.Count; i++)
            {
                if (Students.assignments[i].Equals(userInput))
                {
                    Students.assignments.RemoveAt(i);
                    Assignments.assignmentGrade.RemoveAt(i);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Removed assignment {userInput}");
        }
        public static void ShowAssignments()
        {
            for (int i = 0; i < Students.assignments.Count; i++)
            {
                Console.WriteLine($"{i}: {Students.assignments[i]}");
            }
            Console.WriteLine("Press any key to return to the previous menu!");
            Console.ReadLine();
        }
        public static void AddGrade()
        {
            Console.Clear();
            Console.WriteLine("Please enter the assignment name to be graded:");
            Console.WriteLine("------------------------------------------");
            for (int i = 0; i < Students.assignments.Count; i++)
            {
                Console.WriteLine($"{i}: {Students.assignments[i]}");
            }
            string userInput = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Please enter the grade for {userInput}");
            string userInput2 = Console.ReadLine();
            int selection = int.Parse(userInput2);
            for (var i = 0; i < Students.assignments.Count; i++)
            {
                if (Students.assignments[i].Equals(userInput))
                {
                    Assignments.assignmentGrade.RemoveAt(i);
                    Assignments.assignmentGrade.Insert(i, selection);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Grade {selection} {userInput}");
        }
        public static void EditGrade()
        {
            Console.Clear();
            Console.WriteLine("Please enter the assignment name to edit grade:");
            Console.WriteLine("------------------------------------------");
            for (int i = 0; i < Students.assignments.Count; i++)
            {
                Console.WriteLine($"{i}: {Students.assignments[i]} : {Assignments.assignmentGrade[i]}");
            }
            string userInput = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Please enter the updated grade for {userInput}");
            string userInput2 = Console.ReadLine();
            int selection = int.Parse(userInput2);
            for (var i = 0; i < Students.assignments.Count; i++)
            {
                if (Students.assignments[i].Equals(userInput))
                {
                    Assignments.assignmentGrade.RemoveAt(i);
                    Assignments.assignmentGrade.Insert(i, selection);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Grade for {userInput} has been removed");
        }
        public static void RemoveGrade()
        {
            Console.Clear();
            Console.WriteLine("Please enter the assignment name to remove grade:");
            Console.WriteLine("------------------------------------------");
            for (int i = 0; i < Students.assignments.Count; i++)
            {
                Console.WriteLine($"{Students.assignments[i]}: {Assignments.assignmentGrade[i]}");
            }
            string userInput = Console.ReadLine();
            for (var i = 0; i < Students.assignments.Count; i++)
            {
                if (Students.assignments[i].Equals(userInput))
                {
                    Assignments.assignmentGrade.RemoveAt(i);
                    Assignments.assignmentGrade.Insert(i, 0);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Grade for {userInput} has been removed");
        }
        public static void ShowGrade()
        {
            Console.Clear();
            for (int i = 0; i < assignmentGrade.Count; i++)
            {
                if(Assignments.assignmentGrade[i] != null)
                    Console.WriteLine($"{i}: {Students.assignments[i]} : {Assignments.assignmentGrade[i]}");
                else
                    Console.WriteLine($"{i}: {Students.assignments[i]} : No Grade Entered");
            }
            Console.Read();
        }
        public static int StudentAverage()
        {
            List<int> allGrades = new List<int>();
            if (assignmentGrade.Count < 0)
            {
                Console.WriteLine("ERROR: No Grades");
                return 0;
            }
            foreach (int assignment in assignmentGrade)
            {
                allGrades.Add(assignment);
            }
            int sAvg = (int)allGrades.Average();
            return sAvg;
        }
        public static void StudentReport()
        {
            Console.Clear();
            Console.WriteLine($"Details for {Students.studentName}:");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            for (int i = 0; i < Students.assignments.Count; i++)
            {
                Console.WriteLine($"{Students.assignments[i]}: {assignmentGrade[i]}");
            }
            Console.WriteLine();
            Console.WriteLine($"Student Average:");
            Console.WriteLine($"    {StudentAverage()}");
            HighestGrade();
            Console.WriteLine();
            LowestGrade();
        }
        public static void HighestGrade()
        {
            int? maxValue = assignmentGrade.Max();
            int maxIndex = assignmentGrade.IndexOf(maxValue);
            Console.WriteLine("Best Grade:");
            Console.WriteLine($"    {Students.assignments[maxIndex]}: {assignmentGrade[maxIndex]}%");
        }
        public static void LowestGrade()
        {
            int? minValue = assignmentGrade.Min();
            int minIndex = assignmentGrade.IndexOf(minValue);
            Console.WriteLine("Worst Grade:");
            Console.WriteLine($"    {Students.assignments[minIndex]}: {assignmentGrade[minIndex]}%");
        }
    }
}
