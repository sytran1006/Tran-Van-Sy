using studentManagement.Data;
using studentManagement.Database;
using studentManagement.DatabaseService;
using studentManagement.Service;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement
{
    public class Program
    {
        public static readonly StudentDatabaseService studentDatabaseService = new();
        public static readonly StudentService studentService = new(studentDatabaseService);
        public static readonly ClassDatabaseService classDatabaseService = new();
        public static readonly ClassService classService = new(classDatabaseService);
        public static readonly TeacherDatabaseService teacherDatabaseService = new();
        public static readonly TeacherService teacherService = new(teacherDatabaseService);
        public static readonly ConnectDatabase connectDatabase = new();
        public static void Main()
        {
            StudentService studentSreviceSearch = new StudentService();
            // Ask the user to choose an option.
            bool Option = true;
            while (Option)
            {
                Console.WriteLine("========================MENU==================================");
                Console.WriteLine("**  Choose an options for working with:                     **");
                Console.WriteLine("**  1 - Student Management                                  **");
                Console.WriteLine("**  2 - Teacher Management                                  **");
                Console.WriteLine("**  3 - Class Management                                    **");
                Console.WriteLine("**  0 - Exit                                                **");
                Console.WriteLine("**  Your option?                                            **");
                Console.WriteLine("==============================================================");
                Console.Write("Choose an option : ");
            // Use a switch statement to do the math.
            
                switch (Convert.ToString(Console.ReadLine()))
                {
                    case "1":
                        studentService.MenuStudent();
                        break;
                    case "2":
                        teacherService.MenuTeacher();
                        break;
                    case "3":
                        classService.MenuClass();
                        break;
                    case "0":
                        Option = false;
                        break;
                    default:
                        Console.WriteLine("\nDon't have this function!");
                        Console.WriteLine("\nPlease select the appropriate function in the menu.");
                        Console.Write("Choose an operation: ");
                        break;
                }
            }
        }
    }
}

