using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace Individuellt_databasprojekt.Models
{
    class Methods
    {

        //Methos for StudentMenu 
        public static void ListAllstudents()
        {
            Program.ConsoleSettings();

            using (var context = new HighSchoolDbContext())
            {
                Console.Clear();
                
                var students = context.Student.ToList();

                Console.WriteLine("Enter 'FirstName' to sort by first name or 'LastName' to sort by last name:");
                string sortBy = Console.ReadLine();

                Console.WriteLine("Enter 'ascending' to sort in ascending order or 'descending' to sort in descending order:");
                string sortDirection = Console.ReadLine();
                Console.Clear();

                if (sortBy == "FirstName")
                {
                    if (sortDirection == "ascending")
                    {
                        students = students.OrderBy(s => s.FirstName).ToList();
                    }
                    else
                    {
                        students = students.OrderByDescending(s => s.FirstName).ToList();
                    }
                }

                else
                {
                    if (sortDirection == "ascending")
                    {
                        students = students.OrderBy(s => s.LastName).ToList();
                    }
                    else
                    {
                        students = students.OrderByDescending(s => s.LastName).ToList();
                    }





                }
                Console.WriteLine("All students at XYZ HighSchool");
                Console.WriteLine("------------------------------");
                foreach (var student in students)
                {
                    Console.WriteLine("Name : {0} {1}", student.FirstName, student.LastName, "Class" + student.Class);

                }

                Console.WriteLine("Press any key to return");
                Console.ReadKey();
                Console.Clear();
                Program.StudentMenu();

                //List<Student> students = context.Student.ToList();
                //Console.WriteLine("Sort by? (1) First Name, (2) Last Name");
                //int sortOption = int.Parse(Console.ReadLine());
                //Console.WriteLine("Order? (1) Ascending, (2) Descending");
                //int orderOption = int.Parse(Console.ReadLine());

                //switch (sortOption)
                //{
                //    case 1:
                //        students = orderOption == 1
                //            ? students.OrderBy(s => s.FirstName).ToList()
                //            : students.OrderByDescending(s => s.FirstName).ToList();
                //        break;
                //    case 2:
                //        students = orderOption == 1
                //            ? students.OrderBy(s => s.LastName).ToList()
                //            : students.OrderByDescending(s => s.LastName).ToList();
                //        break;
                //}

                //foreach (var student in students)
                //{
                //    Console.WriteLine($"{student.FirstName} {student.LastName}");
                //}

                Console.WriteLine("\nPress enter to return to Student Menu\n");
                Console.ReadLine();

                Program.StudentMenu();

            }

        }


        public static void ChoseClassList()
        {
            Program.ConsoleSettings();

            using (var context = new HighSchoolDbContext())
            {
                Console.Clear();
                var classNames = context.Class.Select(c => c.ClassName).Distinct().ToList();

                Console.WriteLine("Classes:");
                for (int i = 0; i < classNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {classNames[i]}");
                }
                Console.WriteLine("Enter a class name:");
                string selectClassName = Console.ReadLine();

                var Students = context.Student.Where(s => s.Class.ClassName == selectClassName).ToList();

                Console.WriteLine("Students:");

                foreach (var student in Students)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");
                }
                Console.WriteLine("\nPress enter to return to Student Menu\n");
                Console.ReadLine();

                Program.StudentMenu();



            }
        }

        public static void AddStudent()
        {
            Program.ConsoleSettings();
            using (var context = new HighSchoolDbContext())
            {
                
                Console.WriteLine("Register a new student\n");
                Console.WriteLine("------------------------");
                Console.WriteLine("First Name: ");
                string firstName = Console.ReadLine();

                Console.WriteLine("Last Name: ");
                string lastName = Console.ReadLine();

                Console.WriteLine("Adress: ");
                string adress = Console.ReadLine();

                Console.WriteLine("Person number");
                string personNumber = Console.ReadLine();

                Console.WriteLine("Email:");
                string email = Console.ReadLine();

                Console.WriteLine("Phone number:");
                string phoneNumber = Console.ReadLine();

                
                
                var classNames = context.Class.Select(c => c.ClassName).Distinct().ToList();

                int classId;
                bool isValidInput;

                do
                {
                    Console.WriteLine("Enter the number that appears to the left of the class name");
                    for (int i = 0; i < classNames.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {classNames[i]}");
                    }

                    Console.WriteLine("Class ID: ");
                    isValidInput = int.TryParse(Console.ReadLine(), out classId);

                    if (!isValidInput)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        
                    }
                } while (!isValidInput);

               

                

                var GenderNames = context.Gender.Select(g => g.GenderName).Distinct().ToList();
                int genderId;
                bool isValidGender;
                do
                {
                    Console.WriteLine("Enter the number that appears to the left of the Gender name");
                    for (int i = 0; i < GenderNames.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {GenderNames[i]}");
                    }

                    Console.WriteLine("Gender ID: ");
                    isValidGender = int.TryParse(Console.ReadLine(), out genderId);

                    if (!isValidInput)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                } while (!isValidGender);


                var newStudent = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Adress = adress,
                    PersonNumber = personNumber,
                    Email = email,
                    Phone = phoneNumber,
                    ClassId = classId,
                    GenderId = genderId

                    
                
                };

                Console.Clear();
                Console.WriteLine($"Name: {firstName}, {lastName}, \nAdress: {adress}, \nPersonnumber: {personNumber}, \nEmail:{email}, \nPhone:{phoneNumber}, \nClassID:{classId}, \nGenderID: {genderId} ");

                Console.WriteLine("\nDo you want to add this student to the database? Write yes or no ");

                
                string userChoice = Console.ReadLine().ToUpper();
                if (userChoice == "YES")
                {

                    context.Student.Add(newStudent);
                    context.SaveChanges();
                    Console.WriteLine("\nStudent has been added to the database");
                    Console.ReadLine();

                }

                if (userChoice == "NO")
                {
                    Console.WriteLine("Student was not added to database");
                    Console.ReadLine();
                    return;
                }

             ;

                Console.WriteLine("Student registred \n Press any key to return to Student Menu");
                Program.StudentMenu();
                Console.ReadKey();





            }
        }

        public static void ShowIformation()
        {
            Program.ConsoleSettings();

            using (var context = new HighSchoolDbContext())
            {

                //var students = context.Student.ToList();
                //Console.Clear();
                //Console.WriteLine("{0,-15} {1,-15} {2,-20} {3,-15} {4,-25} {5,-20}", "First Name", "Last Name", "Address", "Person Number", "Email", "Phone Number");
                //Console.WriteLine(new string('-', 120));

                //foreach (var student in students)
                //{
                //    Console.WriteLine("{0,-15} {1,-15} {2,-20} {3,-15} {4,-25} {5,-15}", student.FirstName, student.LastName,student.Adress, student.PersonNumber, student.Email, student.Phone);


                //}

                var students = context.Student.ToList();
                Console.Clear();
                Console.WriteLine("Student information");
                Console.WriteLine("-------------------");
                foreach (var student in students)
                {
                    Console.WriteLine($"\nName: {student.FirstName} {student.LastName} \nAdress: {student.Adress} \nPersonnumber: {student.PersonNumber} \nEmail: {student.Email} \nPhone: {student.Phone}");
                    Console.WriteLine(new string('-', 120));


                }







                Console.WriteLine("\nPress anykey to return\n");
                Console.ReadKey();
                Console.Clear();
                Program.StudentMenu();




            }



        }

        public static void ShowImportantStudentInfo()

        {
            Program.ConsoleSettings();

            using (var context = new HighSchoolDbContext())

                
            {
                var students = context.ImportanStudentInfo.Include(s => s.Student).ToList(); 
                
                Console.WriteLine("\nStudent ID with a dissability\n ");
                

                foreach(var student in students)
                {
                    
                    Console.WriteLine($"Student ID: {student.StudentId}");
                }

                Console.WriteLine("\nSelect a StudentID ");

                int studentID = int.Parse(Console.ReadLine());

                var selectStudent = context.ImportanStudentInfo.Include(c=>c.Student).FirstOrDefault(c=> c.StudentId == studentID);
                

                if (selectStudent != null)
                {
                    var studetnName = context.Student.Where(n => n.StudentId == studentID).Select(f => f.FirstName + "" + f.LastName).FirstOrDefault();
                    Console.WriteLine($"Student ID: {selectStudent.StudentId} Name: {studetnName}, Info: {selectStudent.Info}");
                }

                else
                {
                    Console.WriteLine("This Student is not in the table, nothing to report");
                }

                Console.WriteLine("Press any key to return ");
                Console.ReadKey();
               
            }



        }

        //Employee Methods

        public static void ListAllEmploees()
        {
            Program.ConsoleSettings();

            using (var context = new HighSchoolDbContext())
            {

                var displayEmployees = from p in context.Employee
                                       join e in context.Department on p.DepartmentId equals e.DepartmentId
                                       join pr in context.Proffesion on p.ProffesionId equals pr.ProffessionId
                                       select new
                                       {

                                           ID = p.EmployeeId,
                                           FirstName = p.FirstName,
                                           LastName = p.LastName,
                                           DepartmentName = e.DepartmentName,
                                           ProffesionName = pr.ProffessionName


                                       };

                Console.WriteLine("All Employess");
                Console.WriteLine("--------------");

                foreach (var item in displayEmployees)
                {
                    Console.WriteLine($"ID: {item.ID} | Name: {item.FirstName} {item.LastName} | Proffesion: {item.ProffesionName} | Department: {item.DepartmentName} |");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                }

                Console.WriteLine("\nPress any key to retrun to Employee menu");
                Console.ReadLine();



            }





        }

        public static void ListAllEmployeesRole()
        {
            Program.ConsoleSettings();


            using (var context = new HighSchoolDbContext())
            {


                

                var RoleAlternatives = context.Proffesion.Select(s => s.ProffessionName).Distinct().ToList();
                Console.WriteLine("Roles: ");

                for(int i = 0; i < RoleAlternatives.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {RoleAlternatives[i]}");

                }
                Console.WriteLine("Enter a Role that you want to filter out ");
                string userChoice = Console.ReadLine();


                var displayEmployees = from p in context.Employee
                                       join e in context.Department on p.DepartmentId equals e.DepartmentId
                                       join pr in context.Proffesion on p.ProffesionId equals pr.ProffessionId
                                       where pr.ProffessionName == userChoice
                                       select new
                                       {

                                           ID = p.EmployeeId,
                                           FirstName = p.FirstName,
                                           LastName = p.LastName,
                                           DepartmentName = e.DepartmentName,
                                           ProffesionName = pr.ProffessionName


                                       };

                
                foreach (var item in displayEmployees)
                {
                    Console.WriteLine($"ID: {item.ID} | Name: {item.FirstName}  {item.LastName} | Proffesion: {item.ProffesionName} | Department: {item.DepartmentName} |");
                }



                Console.WriteLine("\nPress any key to retrun to Employee menu");
                Console.ReadLine();



            }




        }

        public static void AddEmployee()
        {
            Program.ConsoleSettings();

            using (var context = new HighSchoolDbContext())
            {
                Console.Clear();
                Console.WriteLine("Add a new employee");
                Console.WriteLine("------------------");

                Console.WriteLine("\nFirst Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("\nLast name; ");
                string lastName = Console.ReadLine();
                Console.WriteLine("\nAge: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("\nSalary: ");
                decimal salary = decimal.Parse(Console.ReadLine());
                Console.WriteLine("\nDateOfHired (yyyy-MM-dd): ");
                string dateOfHireString = Console.ReadLine();


                DateTime dateofHire;
                try
                {
                    dateofHire = DateTime.ParseExact(dateOfHireString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid data format");
                    return;
                }

                var Profeesions = context.Proffesion.Select(p=> p.ProffessionName).Distinct().ToList();
                for(int i = 0; i < Profeesions.Count; i++)
                {
                    Console.WriteLine($"\n{i + 1}. {Profeesions[i]}");

                }
               
                Console.WriteLine("\nEnter a ProffesionID: ");
                int professionid = int.Parse(Console.ReadLine());

                var department =context.Department.Select(p=> p.DepartmentName).Distinct().ToList();
                for(var i = 0; i < department.Count; i++)
                {
                    Console.WriteLine($"\n{i + 1}, {department[i]}");
                }

                Console.WriteLine("Enter a department number: ");
                int departmentid =  int.Parse(Console.ReadLine());




                Employee employee = new Employee()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Salary = salary,
                    DateOfHired = dateofHire,
                    ProffesionId = professionid,
                    DepartmentId = departmentid
                    
                    

                };
                Console.Clear();

                Console.WriteLine($"Name: {firstName}, {lastName} \nAge: {age} \nSalary: {salary} \nDate of hired: {dateofHire} \nProffesionID: {professionid} \nDepartmentID: {departmentid} ");
                
                Console.WriteLine("\nDo you want to add this employee to the database? Yes or No ");
                string userChoice = Console.ReadLine().ToUpper();

                if(userChoice == "YES")
                {
                    context.Employee.Add(employee);
                    context.SaveChanges();
                    Console.WriteLine("Employer added to database ");
                    Console.ReadLine();

                }

                if(userChoice == "NO")
                {
                    Console.WriteLine("Employee was not added to database");
                    Console.ReadLine();
                    return;
                }

            }
        }

        public static void AcctiveCourses()
        {
            Program.ConsoleSettings();
            using (var context = new HighSchoolDbContext())
            {
                Console.Clear();
                Console.WriteLine("List of all acctive courses");
                Console.WriteLine("---------------------------");
                var displayActiveCourses = from e in context.Employee
                                           join s in context.Subject on e.EmployeeId equals s.EmployeeId                                   
                                           where s.IsAcctive == true
                                           select new
                                           {
                                               SubjectName = s.SubjectName,
                                               Teacher = e.FirstName + " " + e.LastName,
                                               IsActive = s.IsAcctive


                                           };

                foreach(var item in displayActiveCourses)
                {
                    string activeStatus = (bool)item.IsActive ? "Active" : "Not active";
                    Console.WriteLine($"Subject: {item.SubjectName} | Teacher: {item.Teacher} | Status: " + activeStatus);
                    Console.WriteLine("-----------------------------------------------------------------------------");
                }
                Console.WriteLine("\nPress any key to return to Employee menu ");

                Console.ReadKey();


            }


        }

        public static void ListAllCourses()
        {
            Program.ConsoleSettings();
            using (var context = new HighSchoolDbContext())

            {
                Console.Clear();
                Console.WriteLine("List every course avalibel at the school");
                Console.WriteLine("----------------------------------------");

                var displayAllCourses = from e in context.Employee
                                        join s in context.Subject on e.EmployeeId equals s.EmployeeId
                                        select new
                                        {
                                            SubjectName = s.SubjectName,
                                            Teacher = e.FirstName + "" + e.LastName,
                                            IsAcctive = s.IsAcctive

                                        };

                foreach( var item in displayAllCourses)
                {
                    string activeStatus = (bool)item.IsAcctive ? "Active" : "Not active";
                    Console.WriteLine($"Subject: {item.SubjectName} | Teacher: {item.Teacher} | Status: " + activeStatus);
                    Console.WriteLine("-----------------------------------------------------------------------------");
                }

                Console.WriteLine("\nPress any key to return to Employee menu");
                Console.ReadKey();


            }
            

            




        }

        //Department Methods 

        public static void ListAllDepartmens()
        {
            Program.ConsoleSettings();
            using (var context = new HighSchoolDbContext())
            {
                Console.WriteLine("All departments");
                Console.WriteLine("---------------");

                var DisplayAllDepartmens = from e in context.Employee
                                           join s in context.Department on e.EmployeeId equals s.DepartmentId
                                           select new
                                           {
                                               DepartmentName = s.DepartmentName,
                                               DepartmentID = s.DepartmentId

                                           };
                foreach ( var item in DisplayAllDepartmens)
                {
                    Console.WriteLine($"DepartmentID: {item.DepartmentID}, Name: {item.DepartmentName}");
                    Console.WriteLine("---------------------------------------------------------------");
                }
                Console.WriteLine("\nPress any key to return to department menu");
                Console.ReadKey();
            }


        }

        public static void ListAllTeacherInDepartment()


        {
            Program.ConsoleSettings();

            using (var context = new HighSchoolDbContext())
            {
                Console.WriteLine("All Employee in a department");
                Console.WriteLine("---------------------------");

                var DisplayAllDepartmens = from e in context.Employee
                                           join s in context.Department on e.EmployeeId equals s.DepartmentId
                                           select new
                                           {
                                               DepartmentName = s.DepartmentName,
                                               DepartmentID = s.DepartmentId

                                           };
                foreach (var item in DisplayAllDepartmens)
                {
                    Console.WriteLine($"DepartmentID: {item.DepartmentID}, Name: {item.DepartmentName}");
                    Console.WriteLine("---------------------------------------------------------------");
                }

                Console.WriteLine("Enter a DepartmentID to see number of employees in");
                int DepartmentChoice = int.Parse(Console.ReadLine());

                var CountTeacherInDepartment = from e in context.Employee
                                               where e.DepartmentId == DepartmentChoice
                                               group e by e.DepartmentId into departmentGroup
                                               select new
                                               {
                                                   DepartmentID = departmentGroup.Key,
                                                 
                                                   EmployeeCount = departmentGroup.Count()

                                                   

                                               };

                foreach(var item in CountTeacherInDepartment)
                {
                    Console.WriteLine("Department ID: " + item.DepartmentID);
                    
                    Console.WriteLine("Employee count: " + item.EmployeeCount);
                    Console.WriteLine();


                   



                }

                var Employee = context.Employee.Where(s => s.Proffesion.ProffessionId == DepartmentChoice).ToList();

                Console.WriteLine("Employees:");

                foreach (var emp in Employee)
                {
                    Console.WriteLine($"Name: {emp.FirstName} {emp.LastName}");
                }



                Console.WriteLine("\nPress any key to return to department menu");
                Console.ReadKey();

                
                                               
            }




        }

        public static void ListAllDepartmenEconomics()
        {
            Program.ConsoleSettings();
            using (var context = new HighSchoolDbContext())
            {
                Console.WriteLine("Department Name, Monthly Salary, and Annual Salary");
                Console.WriteLine("---------------------------------------------------");

                var IncomePayOut = from e in context.Employee
                                   join d in context.Department on e.DepartmentId equals d.DepartmentId
                                   group e by e.Department.DepartmentName into departmentGroup
                                   select new
                                   {
                                       DepartmentName = departmentGroup.Key,
                                       SalaryMonth = departmentGroup.Sum(x => x.Salary),
                                       SalaryAnnual = departmentGroup.Sum(x => x.Salary) * 12

                                   };

                foreach (var item in IncomePayOut)
                {
                    Console.WriteLine($"Department Name: {item.DepartmentName} Monthly Salary: {item.SalaryMonth} kr Salary Annual: {item.SalaryAnnual} kr");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                }

                Console.WriteLine("Press any key to return to Department menu");
                Console.ReadKey();


            }

        }



    }
}