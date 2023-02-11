using Individuellt_databasprojekt;
using Individuellt_databasprojekt.Models;
using System;
using System.Reflection;

namespace Individuellt_databasprojekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleSettings();
            MainMenu();


        }

        public static void MainMenu()
        {

            string[] menuItems = { "Student Information", "Employee Information", "Department Information", "Exit" };
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to XYZ School Mangment System");
                Console.WriteLine("-------------------");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (selectedIndex == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                }

                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex < 0)
                        {
                            selectedIndex = menuItems.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex == menuItems.Length)
                        {
                            selectedIndex = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (menuItems[selectedIndex])
                        {
                            case "Student Information":
                                Console.WriteLine("You selected: " + menuItems[selectedIndex]);
                                StudentMenu();

                                Console.ReadKey();
                                break;
                            case "Employee Information":
                                Console.WriteLine("You selected: " + menuItems[selectedIndex]);
                                EmployeeMenu();

                                Console.ReadKey();
                                break;
                            case "Department Information":
                                Console.WriteLine("You selected: " + menuItems[selectedIndex]);
                                DepartmentMenu();

                                Console.ReadKey();
                                break;
                            case "Exit":
                                Console.WriteLine("This Application will exit");
                                Environment.Exit(0);
                                break;

                        }
                        break;
                }
            }
        }

        
        public static void StudentMenu()
        {

            Console.Clear();


            string[] menuItems = { "List all students", "List student in a class ", "Add student", "Show Information about student", "Important Student Info", "Back to mainmenu" };
            int selectedIndex = 0;
            
            while (true)
            {

                Console.Clear();
                

                Console.WriteLine("Student Information");
                Console.WriteLine("-------------------");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (selectedIndex == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                }

                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex < 0)
                        {
                            selectedIndex = menuItems.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex == menuItems.Length)
                        {
                            selectedIndex = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        //Console.WriteLine("Back to main menu");
                        Console.Clear();
                        
                        if (menuItems[selectedIndex] == "Back to mainmenu")
                        {
                            MainMenu();
                        }
                        if(menuItems[selectedIndex] == "List all students")
                        {
                            Console.Clear();
                            Methods.ListAllstudents();
                            
                        }
                        if (menuItems[selectedIndex] == "List student in a class ")
                        {
                            Console.Clear();
                            Methods.ChoseClassList();
                        }
                        if (menuItems[selectedIndex] == "Add student")
                        {
                            
                            Console.Clear();
                            Methods.AddStudent();

                        }
                        if (menuItems[selectedIndex] == "Show Information about student")
                        {
                            Console.Clear();
                            Methods.ShowIformation();

                        }
                        if (menuItems[selectedIndex] == "Important Student Info")
                        {
                            Console.Clear();
                            Methods.ShowImportantStudentInfo();
                        }
                        break;
                }
            }



        }

        public static void EmployeeMenu()
        {



            string[] menuItems = { "List all Employees", "List all Emloyees by role", "Add Employee", "List all active courses", "List all courses", "Back to main menu" };
            int selectedIndex = 0;

            while (true)
            {


                Console.Clear();

                Console.WriteLine("Student Information");
                Console.WriteLine("-------------------");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (selectedIndex == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                }

                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex < 0)
                        {
                            selectedIndex = menuItems.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex == menuItems.Length)
                        {
                            selectedIndex = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        
                        Console.ReadKey();
                        if (menuItems[selectedIndex] == "Back to main menu")
                        {
                            MainMenu();
                        }

                        if(menuItems[selectedIndex] == "List all Employees")
                        {
                            Console.Clear();
                            Methods.ListAllEmploees();
                        }
                        if (menuItems[selectedIndex] == "List all Emloyees by role")
                        {
                            Console.Clear();
                            Methods.ListAllEmployeesRole();
                        }
                        if (menuItems[selectedIndex] == "Add Employee")
                        {
                            Methods.AddEmployee();
                            Console.Clear();

                        }
                        if (menuItems[selectedIndex] == "List all active courses")
                            {
                            Methods.AcctiveCourses();
                            Console.Clear();

                        }
                        if (menuItems[selectedIndex] == "List all courses")
                        {
                            Methods.ListAllCourses();
                            Console.Clear();
                        }

                        break;
                }
            }



        }

        public static void DepartmentMenu()
        {
            
            



            string[] menuItems = { "List all departments", "List all employee in a department",  "Salary of department monthly and anual", "Back to mainmenu" };
            int selectedIndex = 0;

            while (true)
            {


                Console.Clear();

                Console.WriteLine("Department Information");
                Console.WriteLine("-------------------");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (selectedIndex == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                }

                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex < 0)
                        {
                            selectedIndex = menuItems.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex == menuItems.Length)
                        {
                            selectedIndex = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        //Console.WriteLine("Back to main menu");

                        if (menuItems[selectedIndex] == "Back to mainmenu")
                        {
                            MainMenu();
                        }
                        if (menuItems[selectedIndex] == "List all departments")
                        {
                            Console.Clear();
                            Methods.ListAllDepartmens();
                            
                            
                        }
                        if (menuItems[selectedIndex] == "List all employee in a department")
                        {
                            Console.Clear();
                            Methods.ListAllTeacherInDepartment();
                            
                        }
                        
                        if (menuItems[selectedIndex] == "Salary of department monthly and anual")
                        {
                            Console.Clear();
                            Methods.ListAllDepartmenEconomics();
                            

                        }
                       
                        break;
                }
            }



        }

        public static void ConsoleSettings()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
          
            Console.Title = "XYZ HighSchool";
        }
    }

    }



