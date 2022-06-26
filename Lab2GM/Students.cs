using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2GM
{
    public class Students
    {
        public string selectedClass;
        public static string studentName { get; set; }
        public static List<string> assignments = new List<string>();

        public Students(string input)
        {
            string studentName = input;
            assignments = new List<string>();
        }
        public Students()
        {

        }
        public static void ClassDetailsMenu(ClassRooms classSelection)
        {
            bool keepRunning = true;

            do
            {
                string selectedClass = Convert.ToString(classSelection);
                Console.Clear();
                Console.WriteLine($"Welcome to {ClassRooms.className}'s Student Management Portal");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Please choose from the following options: ");
                Console.WriteLine();
                Console.WriteLine("1: Add Student");
                Console.WriteLine("2: Edit Student");
                Console.WriteLine("3: Remove Student");
                Console.WriteLine("4: View all students in class");
                Console.WriteLine("5: Manage Student Assignements");
                Console.WriteLine("6: Classroom Details Report");
                Console.WriteLine("0: Return to the previous Menu");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        AddStudent();
                        break;
                    case "2":
                        Console.Clear();
                        EditStudent();
                        break;
                    case "3":
                        Console.Clear();
                        RemoveStudent();
                        break;
                    case "4":
                        Console.Clear();
                        ShowStudents();
                        break;
                    case "5":
                        Console.Clear();
                        StudentSelection();
                        break;
                    case "0":
                        Console.Clear();
                        keepRunning = false;
                        ClassRooms.MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please try again.");
                        break;
                }
            } while (keepRunning == true);
        }
        public static void AddStudent()
        {
            Students student = new Students();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Enter Student Name:");
            string name = Console.ReadLine();
            studentName = name;
            ClassRooms.classRoster.Add(studentName);
            Console.WriteLine();
            Console.WriteLine($"Added: {studentName} to {ClassRooms.className}");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the previous menu.");
            Console.ReadLine();
        }
        public static void EditStudent()
        {
            Console.Clear();
            for (int i = 0; i < ClassRooms.classRoster.Count; i++)
            {
                Console.WriteLine($"{i}: {ClassRooms.classRoster[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Please enter the students name to be edited:");
            Console.WriteLine("------------------------------------------");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the updated name for the student");
            string userInput2 = Console.ReadLine();
            for (var i = 0; i < ClassRooms.classRoster.Count; i++)
            {
                if (ClassRooms.classRoster[i].Equals(userInput))
                {
                    ClassRooms.classRoster.RemoveAt(i);
                    ClassRooms.classRoster.Insert(i, userInput2);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Updated {userInput} to {userInput2}");
        }
        public static void RemoveStudent()
        {
            Console.Clear();
            for (int i = 0; i < ClassRooms.classRoster.Count; i++)
            {
                Console.WriteLine($"{i}: {ClassRooms.classRoster[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Please enter the students name to be removed:");
            Console.WriteLine("------------------------------------------");
            string userInput = Console.ReadLine();
            //int selection = int.Parse(userInput);
            for (var i = 0; i < ClassRooms.classRoster.Count; i++)
            {
                if (ClassRooms.classRoster[i].Equals(userInput))
                {
                    ClassRooms.classRoster.RemoveAt(i);
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Removed Class {userInput}");
        }
        public static void ShowStudents()
        {
            for(int i = 0; i < ClassRooms.classRoster.Count; i++)
            {
                Console.WriteLine(ClassRooms.classRoster[i]);
            }
            Console.ReadLine();
        }
        public static void StudentSelection()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Student name to view their details:");
            Console.WriteLine("------------------------------------------------");
            for (int i = 0; i < ClassRooms.classRoster.Count; i++)
            {
                Console.WriteLine(ClassRooms.classRoster[i]);
            }
            Console.WriteLine("------------------------------------------------");
            string userInput = Console.ReadLine();

            //bool valid = true;
            for (var i = 0; i < ClassRooms.classRoster.Count; i++)
            {
                if (ClassRooms.classRoster[i].Equals(userInput))
                {
                    Students studentSelection = new Students();
                    Assignments.StudentDetailsMenu(studentSelection);
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid selection, please press any key to return to the previous menu and try again.");
                    Console.Read();
                    StudentSelection();
                }
            }
        }
        public static void ClassReport()
        {
            Console.WriteLine($"Class Report for {ClassRooms.className}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            ClassAverage();
            Console.WriteLine();
            TopStudent();
            Console.WriteLine();
            LowStudent();
        }
        public static void ClassAverage()
        {
            List<int> classAverage = new List<int>();
            foreach(string student in ClassRooms.classRoster)
            {
                classAverage.Add(Assignments.StudentAverage());
            }
            int cAvg = (int)classAverage.Average();
            Console.WriteLine("Class Average:");
            Console.WriteLine($"    {cAvg}%");
        }
        public static void TopStudent()
        {
            List<string> topStudents = new List<string>();
            List<int> topStudentGrades = new List<int>();
            foreach(string student in ClassRooms.classRoster)
            {
                topStudents.Add(student);
                int s = Assignments.StudentAverage();
                topStudentGrades.Add(s);
            }
            int maxValue = topStudentGrades.Max();
            int maxIndex = topStudentGrades.IndexOf(maxValue);
            Console.WriteLine($"Top Student: {topStudents[maxIndex]}");
            Console.WriteLine($"Student Average: {topStudentGrades[maxIndex]}");
        }
        public static void LowStudent()
        {
            List<string> lowStudents = new List<string>();
            List<int> lowStudentGrades = new List<int>();
            foreach (string student in ClassRooms.classRoster)
            {
                lowStudents.Add(student);
                int s = Assignments.StudentAverage();
                lowStudentGrades.Add(s);
            }
            int minValue = lowStudentGrades.Min();
            int minIndex = lowStudentGrades.IndexOf(minValue);
            Console.WriteLine($"Top Student: {lowStudents[minIndex]}");
            Console.WriteLine($"Student Average: {lowStudentGrades[minIndex]}");
        }
        public static void CompareStudents()
        {
            string student1 = "null";
            int student1Grade = 0;
            string student2 = "null";
            int student2Grade = 0;
            Console.Clear();
            for (int i = 0; i < ClassRooms.classRoster.Count; i++)
            {
                Console.WriteLine(ClassRooms.classRoster[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Please enter the name of the first student:");
            string userInput1 = Console.ReadLine();
            Console.WriteLine("Please enter the name of the second student:");
            string userInput2 = Console.ReadLine();
            Console.WriteLine();

            foreach(string student in ClassRooms.classRoster)
            {
                if (student.Equals(userInput1))
                {
                    student1 = studentName;
                    student1Grade = Assignments.StudentAverage();
                }
                if (student.Equals(userInput2))
                {
                    student2 = studentName;
                    student2Grade = Assignments.StudentAverage();
                }
            }
            Console.WriteLine();
            Console.WriteLine($"{student1} has a GPA of {student1Grade}");
            Console.WriteLine($"{student2} has a GPA of {student2Grade}");
        }
    }
}
