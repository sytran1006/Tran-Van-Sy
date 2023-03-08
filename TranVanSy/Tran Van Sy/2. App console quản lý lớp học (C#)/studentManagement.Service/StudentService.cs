using studentManagement.Data;
using studentManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleTables;
using System.Data;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;

namespace studentManagement.Service
{
    public class StudentService
    {
        private readonly StudentDatabaseService _studentDatabaseService = new();
        //private readonly List<Student> students = new();
        private readonly ClassDatabaseService _classDatabaseService = new();


        public StudentService(StudentDatabaseService studentDatabaseService)
        {
            _studentDatabaseService = studentDatabaseService;
        }
        public StudentService() { }

        //menu student

        public void MenuStudent()
        {
        MenuStudent:
            bool OptionStudent = true;

            //FormatException:
            Console.WriteLine("------------------------ Student Management----------------------------------");
            Console.WriteLine("**   Choose an options for working with:                                   **");
            Console.WriteLine("**  1 - View List Student                                                  **");
            Console.WriteLine("**  2 - Search student                                                     **");
            Console.WriteLine("**  3 - Add new Student                                                    **");
            Console.WriteLine("**  4 - Update a student                                                   **");
            Console.WriteLine("**  5 - Remove a student                                                   **");
            Console.WriteLine("**  6 - Get classmates of a student                                        **");
            Console.WriteLine("**  7 - Remove By name                                                     **");
            Console.WriteLine("**  8 - Update information by name                                         **");
            Console.WriteLine("**  9 - Student Of Class                                                   **");
            Console.WriteLine("**  10 -Top 10 students with the highest scores                            **");
            Console.WriteLine("**  11 -Male Of Student                                                    **");
            Console.WriteLine("**  12 -Avg Score of class                                                 **");
            Console.WriteLine("**  13 -Class Of Teacher                                                   **");
            Console.WriteLine("**  14 -Teacher with the most classes                                      **");
            Console.WriteLine("**  15 -Teacher And Height Score                                           **");
            Console.WriteLine("**  0 - Exit                                                               **");
            Console.WriteLine("**  Your option?                                                           **");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.Write("Choose an option : ");
            while (OptionStudent)
            {
            
                switch (Convert.ToString(Console.ReadLine()))
                {
                    case "1":
                        Console.WriteLine("  Viewing student list");
                        PrintListStudentSearch(_studentDatabaseService.GetListStudent());
                        Console.Write("Choose an operation: ");
                        break;
                    case "2":

                    SearchStudent:
                        Console.Write("Search student by (id / name), if not sellected then enter \"exit\": ");
                        string SearchStudent = Convert.ToString(Console.ReadLine());
                        bool SearchStudentChoose = true;
                        while (SearchStudentChoose)
                        {

                            if (SearchStudent == "id")
                            {
                                while (true)
                                {
                                    Console.Write("Input student id for searching: ");
                                    string SearchIdStudent = Convert.ToString(Console.ReadLine());
                                    if (SearchIdStudent == "exit")
                                    {
                                        goto SearchStudent;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            FindByIdAndLog(int.Parse(SearchIdStudent));
                                            SearchStudentChoose = false;
                                            
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("This student does not exist");
                                        }
                                    }
                                }
                            }


                            else if (SearchStudent == "name")
                            {
                                while (true)
                                {
                                    Console.Write("Input student name for searching: ");
                                    string SearchNameStudent = Convert.ToString(Console.ReadLine());
                                    if (SearchNameStudent == "exit")
                                    {
                                        goto SearchStudent;
                                    }
                                    else
                                    {
                                        List<Student> searchResult = FindByName(SearchNameStudent);
                                        PrintListStudentSearch(searchResult);
                                        
                                    }
                                }
                            }
                            else if (SearchStudent == "exit")
                            {
                                SearchStudentChoose = false;
                                Console.WriteLine("You have exited the student search");
                            }
                            else
                            {
                                Console.WriteLine("This option is not available");
                                Console.Write("Confluent your option: ");
                                goto SearchStudent;
                            }
                        }
                        Console.Write("Choose an operation: ");
                        break;
                    case "3":
                        Console.WriteLine("Enter new student information: ");
                        AddStudent();
                        Console.Write("Choose an operation: ");
                        break;
                    case "4":
                        Console.WriteLine("Update student information");
                        Console.Write("Input student id for updating: ");
                        int IdForUpdate = Convert.ToInt32(Console.ReadLine());
                        FindByIdAndLog(IdForUpdate);
                        UpdateStudentById(IdForUpdate);
                        Console.WriteLine("You have successfully update student! ");
                        Console.Write("Choose an operation: ");
                        break;
                    case "5":
                        Console.WriteLine("Delete a student ");
                        Console.Write("Input student id for deleting: ");
                        int IdForDelete = Convert.ToInt32(Console.ReadLine());
                        FindByIdAndLog(IdForDelete);
                        RemoveById(IdForDelete);
                        Console.Write("Choose an operation: ");
                        break;
                    case "6":
                        Console.WriteLine("Getting Classmate: ");
                        Console.Write("Input class id for getting others: ");
                        int IdForFindClassmate = Convert.ToInt32(Console.ReadLine());
                        List<Student> ListClassmates = new List<Student>();
                        ListClassmates = GetClassmate(IdForFindClassmate);
                        PrintListStudentSearch(ListClassmates);
                        Console.WriteLine("take out a list of successful classmates!");
                        Console.Write("Choose an operation: ");
                        break;
                    case "7":
                        RemoveByName();
                        Console.WriteLine("delete successful students!");
                        Console.Write("Choose an operation: ");
                        break;
                    case "8":
                        UpdateStudentByName();
                        Console.WriteLine("You have successfully update student! ");
                        Console.Write("Choose an operation: ");
                        break;
                    case "9":                    
                        _studentDatabaseService.StudentOfClass();
                        Console.Write("Choose an operation: ");
                        break;
                    case "10":
                        Console.Write("\tEnter classId: ");
                        string classid = Convert.ToString(Console.ReadLine());
                        _studentDatabaseService.TopHightScore(int.Parse(classid));
                        Console.Write("Choose an operation: ");
                        break;
                    case "11":
                        _studentDatabaseService.MaleStudent();
                        Console.Write("Choose an operation: ");
                        break;
                    case "12":
                        _studentDatabaseService.AvgScore();
                        Console.Write("Choose an operation: ");
                        break;
                    case "13":
                        Console.Write("\tEnter TeacherId: ");
                        string teacherid = Convert.ToString(Console.ReadLine());
                        _studentDatabaseService.ClassOfTeacher(int.Parse(teacherid));
                        Console.Write("Choose an operation: ");
                        break;
                    case "14":
                        _studentDatabaseService.TeacherWithTheMostClasses();
                        Console.Write("Choose an operation: ");
                        break;
                    case "15":
                        _studentDatabaseService.TeacherAndHeightScore();
                        Console.Write("Choose an operation: ");
                        break;
                    case "0":
                        Console.WriteLine("Out menu");
                        OptionStudent = false;
                        break;
                    case "help":
                        goto MenuStudent;
                    default:
                        Console.WriteLine("\nDon't have this function!");
                        Console.WriteLine("\nPlease select the appropriate function in the menu.");
                        Console.Write("Choose an operation: ");
                        break;
                }
            }
        }

        // show student list
        public void PrintListStudent()
        {
            var students = this._studentDatabaseService.getListStudent();
            var table = new ConsoleTable("Id", "Name", "Gender","DateOfBirth","EmailAddress", "PhoneNumber", "Score", "ClassId");
            foreach (var student in students)
            {
                table.AddRow(student.Id, student.Name, student.Gender,student.DateOfBirth, student.EmailAddress, student.PhoneNumber, student.Score, student.ClassId);

            }

            table.Write(Format.MarkDown);
            Console.WriteLine();

        }

        // show take-out list
        public void PrintListStudentSearch(List<Student> Listsv)
        {
            var table = new ConsoleTable("Id", "Name", "Gender", "DateOfBirth", "EmailAddress", "PhoneNumber", "Score", "ClassId");
            Console.WriteLine("  list student");
            foreach (var student in Listsv)
            {
                table.AddRow(student.Id, student.Name, student.Gender, student.DateOfBirth, student.EmailAddress, student.PhoneNumber, student.Score, student.ClassId);

            }

            table.Write(Format.MarkDown);
            Console.WriteLine();

        }

        //take out the largest id
        public int GenerateId()
        {
            var students = _studentDatabaseService.GetListStudent();
            int max = 1;
            if (students != null && students.Count > 0)
            {
                for (int i = 0; i <= students.Count; i++)
                {
                    if (max < (int)students[i].Id)
                    {
                        max = (int)students[i].Id;
                    }
                }
            }
            return max;
        }

        //returns the number of students
        public int AmountStudent()
        {

            var students = this._studentDatabaseService.getListStudent();
            int count = 0;
            if (students != null)
            {
                count = students.Count;
            }
            return count;
        }

        //validate time
        private bool TimeIsValid(string dateInString)
        {
            DateTime temp;
            if (DateTime.TryParse(dateInString, out temp))
            {
                return true;
            }
            return false;

        }

        //validate email
        public static bool EmailIsValId(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // validate phonenumber
        public static bool PhoneNumberIsvalId(string PhoneNumber)
        {
            string expression = @"^\d{9,11}$";
            if (Regex.IsMatch(PhoneNumber, expression))
            {
                if (Regex.Replace(PhoneNumber, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // validate name
        public static bool NameIsvalId(string Name)
        {
            string expression = @"^[A-z][A-z|\.|\s]+$";
            if (Regex.IsMatch(Name, expression))
            {
                if (Regex.Replace(Name, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        //checkc classid
        public bool CheckClassId(int id)
        {
            var classs = _classDatabaseService.GetListClass();
            foreach (Class clas in classs)
            {
                if (clas.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        //add new students by id
        public void AddStudent()
        {
            while (true)
            {
                var students = this._studentDatabaseService.GetListStudent();

                Student astudent = new Student();

                astudent.Id = _studentDatabaseService.GenerateId() + 1;

                //add name
                Console.Write("\t-Name: ");
                astudent.Name = Convert.ToString(Console.ReadLine());
                if (NameIsvalId(astudent.Name) == false)
                {
                    do
                    {
                        Console.Write("\tPlease input a valid name or type \"quit\" to quit process: ");
                        astudent.Name = Convert.ToString(Console.ReadLine());
                    } while (NameIsvalId(astudent.Name) == false);
                }
                if (astudent.Name == "quit")
                {
                    Console.WriteLine("You don't add student! ");
                    goto Out;
                }

                // add dateofbirth
                Console.Write("\t-DateOfBirth (yyyy/mm/dd): ");
                string DateOfBirth = Convert.ToString(Console.ReadLine());
                if (TimeIsValid(DateOfBirth) == false)
                {
                    do
                    {
                        Console.Write("\tPlease input a validDateTime or type \"quit\" to quit process: ");
                        string dateOfBirth = Convert.ToString(Console.ReadLine());
                        if (dateOfBirth == "quit")
                        {
                            Console.WriteLine("You don't add student! ");
                            goto Out;
                        }
                        else if (TimeIsValid(dateOfBirth) == true)
                        {
                            DateOfBirth = dateOfBirth;
                            astudent.DateOfBirth = DateTime.Parse(dateOfBirth);
                            break;
                        }
                        else
                        {
                            DateOfBirth = dateOfBirth;
                        }

                    } while (TimeIsValid(DateOfBirth) == false);
                }
                astudent.DateOfBirth = DateTime.Parse(DateOfBirth);

                //add email
                Console.Write("\t-Email: ");
                astudent.EmailAddress = Convert.ToString(Console.ReadLine());
                if (EmailIsValId(astudent.EmailAddress) == false)
                {

                    do
                    {
                        Console.Write("\tPlease input a valid email or type \"quit\" to quit process: ");
                        astudent.EmailAddress = Convert.ToString(Console.ReadLine());
                        if (astudent.EmailAddress == "quit")
                        {
                            Console.WriteLine("You don't add student! ");
                            goto Out;
                        }

                    } while (EmailIsValId(astudent.EmailAddress) == false);
                }

                if (astudent.EmailAddress != null || EmailIsValId(astudent.EmailAddress) == true)
                {
                    foreach (Student student in students)
                    {
                        if (student.EmailAddress == astudent.EmailAddress)
                        {
                            do
                            {
                                Console.Write("\tEmail already exists, please re-add: ");
                                astudent.EmailAddress = Convert.ToString(Console.ReadLine());
                                while (astudent.EmailAddress == null || EmailIsValId(astudent.EmailAddress) == false)
                                {
                                    Console.Write("\tPlease input a valid email or type \"quit\" to quit process: ");
                                    astudent.EmailAddress = Convert.ToString(Console.ReadLine());
                                    if (astudent.EmailAddress == "quit")
                                    {
                                        Console.WriteLine("You don't add student! ");
                                        goto Out;
                                    }

                                }
                            } while (astudent.EmailAddress == student.EmailAddress);
                        }
                    }
                }

                //add gender
                Console.Write("\t-Gender (male/female): ");

                while (true)
                {
                    string gender = Convert.ToString(Console.ReadLine());
                    if (gender.ToLower() == "male")
                    {
                        gender = "Male";
                        astudent.Gender = gender;
                        break;
                    }
                    else if (gender.ToLower() == "female")
                    {
                        gender = "Female";
                        astudent.Gender = gender;
                        break;
                    }
                    else if (gender == "quit")
                    {
                        goto Out;
                        break;
                    }
                    else
                    {
                        try
                        {
                            Exception e = new Exception();
                            throw e;
                        }
                        catch (Exception e)
                        {
                            Console.Write("\tPlease input a valid gender or type \"quit\" to quit process: ");
                        }
                    }
                }

                //add phone
                Console.Write("\t-Phone number: ");
                astudent.PhoneNumber = Convert.ToString(Console.ReadLine());
                if (astudent.PhoneNumber == null || PhoneNumberIsvalId(astudent.PhoneNumber) == false)
                {
                    do
                    {
                        Console.Write("\tPlease input a valid phone number or type \"quit\" to quit process: ");
                        astudent.PhoneNumber = Convert.ToString(Console.ReadLine());
                        if (astudent.PhoneNumber == "quit")
                        {
                            Console.WriteLine("You don't add student! ");
                            goto Out;
                        }

                    } while (astudent.PhoneNumber == null || PhoneNumberIsvalId(astudent.PhoneNumber) == false);
                }
                if (astudent.PhoneNumber != null || PhoneNumberIsvalId(astudent.PhoneNumber) == true)
                {
                    foreach (Student student in students)
                    {
                        if (astudent.PhoneNumber == student.PhoneNumber)
                        {
                            do
                            {
                                Console.WriteLine("\tPhone number already exists, please re-add: ");
                                astudent.PhoneNumber = Convert.ToString(Console.ReadLine());
                                while (astudent.PhoneNumber == null || PhoneNumberIsvalId(astudent.PhoneNumber) == false)
                                {
                                    Console.Write("\tPlease input a valid phone number or type \"quit\" to quit process: ");
                                    astudent.PhoneNumber = Convert.ToString(Console.ReadLine());
                                    if (astudent.PhoneNumber == "quit")
                                    {
                                        Console.WriteLine("You don't add student! ");
                                        goto Out;
                                    }

                                }
                            } while (astudent.PhoneNumber == student.PhoneNumber);

                        }
                    }
                }

                // add score
                Console.Write("\t-Score (0-10): ");
                while (true)
                {
                    string score = Convert.ToString(Console.ReadLine());
                    if (score == "quit")
                    {
                        goto Out;

                    }
                    try
                    {
                        if (double.Parse(score) >= 0 && double.Parse(score) <= 10)
                        {
                            astudent.Score = double.Parse(score);
                            break;
                        }
                        else
                        {
                            try
                            {
                                if (double.Parse(score) < 0 || double.Parse(score) > 10)
                                {
                                    Exception e1 = new Exception();
                                    throw e1;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.Write("\tScore in betwen [0-10] or Press \"quit\" to exit: ");
                            }

                        }
                    }
                    catch (Exception e)
                    {

                        Console.Write("\tShould be a number or press \"quit\" to exit: ");
                    }
                }

                // add class id
                Console.Write("\t-ClassId: ");
                while (true)
                {
                    string classid = Convert.ToString(Console.ReadLine());
                    if (classid == "quit")
                    {
                        goto Out;

                    }
                    try
                    {
                        if (CheckClassId(int.Parse(classid)) == false)
                        {
                            Exception e = new Exception();
                            throw e;
                        }
                        astudent.ClassId = int.Parse(classid);
                        break;

                    }
                    catch (Exception e)
                    {
                        Console.Write("\tThis class does not exist or press \"quit\" to exit: ");
                    }
                }              
                System.IO.File.AppendAllText(LogFile.logFilePath, " - " + System.DateTime.Now.ToString() + "    Add Student:    -Id: " + astudent.Id + "   " + "Name: " + astudent.Name + "   " + "-Email: " + "" + astudent.EmailAddress + "   " +
                    "-Gender: " + "" + astudent.Gender + "   " + "-PhoneNumber: " + "" + astudent.PhoneNumber + "   " + "-Score: " + "" + astudent.Score + "   " + "-ClassId: " + "" + astudent.ClassId + Environment.NewLine);
                students.Add(astudent);
                _studentDatabaseService.AddStudent(astudent.Id, astudent.Name, astudent.Gender, astudent.DateOfBirth, astudent.EmailAddress, astudent.PhoneNumber, astudent.Score, astudent.ClassId);
                Console.WriteLine("You have successfully add student! ");
            Out:

                break;
            }
        }

        // delete students by id
        public void RemoveById(int Id)
        {
            var students = this._studentDatabaseService.GetListStudent();
            for (int i = 0; i < students.Count; i++)
            {
                if (Id == students[i].Id)
                {                    
                    System.IO.File.AppendAllText(LogFile.logFilePath, " - " + System.DateTime.Now.ToString() + "    Delete Student:    -Id: " + students[i].Id + "   " + "Name: " + students[i].Name + "   " + "-Email: " + "" + students[i].EmailAddress + "   " +
                        "-Gender: " + "" + students[i].Gender + "   " + "-PhoneNumber: " + "" + students[i].PhoneNumber + "   " + "-Score: " + "" + students[i].Score + "   " + "-ClassId: " + "" + students[i].ClassId + Environment.NewLine);
                    students.Remove(students[i]);
                    _studentDatabaseService.DeleteStudent(Id);
                }
            }
        }

        // update students by id
        public void UpdateStudentById(int Id)
        {
            var students = this._studentDatabaseService.GetListStudent();
            for (int i = 0; i < students.Count; i++)
            {
                if (Id == students[i].Id)
                {
                    // update name
                    Console.Write("\t-New name: ");
                    // if nothing is entered, do not update the name
                    string OldName = students[i].Name;
                    while (true)
                    {
                        string Name = Convert.ToString(Console.ReadLine());
                        if (Name == null || Name.Length == 0)
                        {
                            students[i].Name = OldName;
                            break;

                        }
                        else if (NameIsvalId(Name) == false)
                        {
                            do
                            {
                                Console.Write("\t-Error, re-add: ");
                                Name = Convert.ToString(Console.ReadLine());
                                students[i].Name = Name;
                            } while (NameIsvalId(Name) == false);
                            break;
                        }
                        else
                        {
                            students[i].Name = Name;
                            break;
                        }
                    }

                    //update DateOfBirth
                    Console.Write("\t-New DateOfBirth(yyyy/mm/dd): ");
                    DateTime OldDateOfBirth = students[i].DateOfBirth;
                    //if nothing is entered, do not update the email
                    string DateOfBirth = Convert.ToString(Console.ReadLine());
                    while (true)
                    {
                        if (DateOfBirth == null || DateOfBirth.Length == 0)
                        {
                            students[i].DateOfBirth = OldDateOfBirth;
                            break;

                        }
                        else if (TimeIsValid(DateOfBirth) == false)
                        {
                            do
                            {
                                Console.Write("\t-Error, re-add: ");
                                DateOfBirth = Convert.ToString(Console.ReadLine()).Trim();
                                students[i].DateOfBirth = DateTime.Parse(DateOfBirth);
                            } while (TimeIsValid(DateOfBirth) == false);
                            break;
                        }
                        else
                        {
                            students[i].DateOfBirth = DateTime.Parse(DateOfBirth);
                            break;
                        }
                    }

                    //update email
                    Console.Write("\t-New email: ");
                    string OldEmail = students[i].EmailAddress;
                    //if nothing is entered, do not update the email
                    string Email = Convert.ToString(Console.ReadLine());
                    while (true)
                    {


                        if (Email == null || Email.Length == 0)
                        {
                            students[i].EmailAddress = OldEmail;
                            break;

                        }
                        if (EmailIsValId(Email) == false)
                        {
                            do
                            {
                                Console.Write("\t-Error, re-add: ");
                                Email = Convert.ToString(Console.ReadLine());

                            } while (EmailIsValId(Email) == false);


                        }
                        if (Email != null || EmailIsValId(Email) == true)
                        {
                            foreach (Student student in students)
                            {
                                if (student.EmailAddress == Email)
                                {
                                    do
                                    {
                                        Console.Write("\tEmail already exists, please re-add: ");
                                        Email = Convert.ToString(Console.ReadLine());
                                        while (Email == null || EmailIsValId(Email) == false)
                                        {
                                            Console.Write("\tPlease input a valid email or type \"quit\" to quit process: ");
                                            Email = Convert.ToString(Console.ReadLine());
                                            if (Email == "quit")
                                            {
                                                MenuStudent();
                                            }

                                        }
                                    } while (Email == student.EmailAddress);

                                }

                            }
                            students[i].EmailAddress = Email;
                            break;
                        }
                    }

                    //update gender
                    Console.Write("\t-New Gender: ");
                    string OldGender = students[i].Gender;
                    bool TestGender = true;
                    while (TestGender)
                    {
                        string Gender = Convert.ToString(Console.ReadLine());
                        // if nothing is entered, do not update the gender
                        if (Gender == null || Gender.Length == 0)
                        {
                            students[i].Gender = OldGender;
                            break;
                        }
                        else
                        {
                            try
                            {
                                if (Gender.ToLower() != "male" && Gender.ToLower() != "female")
                                {
                                    Exception e = new Exception();
                                    throw e;
                                }
                                if (Gender.ToLower() == "male")
                                {
                                    Gender = "Male";
                                    students[i].Gender = Gender;
                                    break;
                                }
                                if (Gender.ToLower() == "female")
                                {
                                    Gender = "Female";
                                    students[i].Gender = Gender;
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.Write("\tError, re-add: ");
                            }
                        }
                    }

                    // update phonenumber
                    Console.Write("\t-New Phone Number:  ");
                    string OldPhoneNumber = students[i].PhoneNumber;
                    // if nothing is entered, do not update the phonenumber
                    string PhoneNumber = Convert.ToString(Console.ReadLine());
                    while (true)
                    {


                        if (PhoneNumber == null || PhoneNumber.Length == 0)
                        {
                            students[i].PhoneNumber = OldPhoneNumber;
                            break;

                        }
                        if (PhoneNumberIsvalId(PhoneNumber) == false)
                        {
                            do
                            {
                                Console.Write("\t-Error, re-add: ");
                                PhoneNumber = Convert.ToString(Console.ReadLine());
                                students[i].PhoneNumber = PhoneNumber;
                            } while (PhoneNumberIsvalId(PhoneNumber) == false);

                        }
                        if (PhoneNumber != null || PhoneNumberIsvalId(PhoneNumber) == true)
                        {
                            foreach (Student student in students)
                            {
                                if (PhoneNumber == student.PhoneNumber)
                                {
                                    do
                                    {
                                        Console.WriteLine("\tPhone Number already exists, please re-add: ");
                                        PhoneNumber = Convert.ToString(Console.ReadLine());
                                        while (students[i].PhoneNumber == null || PhoneNumberIsvalId(PhoneNumber) == false)
                                        {
                                            Console.Write("\tPlease input a valid phone number or type \"quit\" to quit process: ");
                                            PhoneNumber = Convert.ToString(Console.ReadLine());
                                            if (PhoneNumber == "quit")
                                            {
                                                MenuStudent();
                                            }

                                        }
                                    } while (students[i].PhoneNumber == student.PhoneNumber);
                                    break;
                                }
                            }
                            students[i].PhoneNumber = PhoneNumber;
                            break;
                        }
                    }

                    // update score
                    Console.Write("\t-New Score: ");
                    double OldScore = students[i].Score;
                    // if nothing is entered, do not update the score
                    bool TestScore = true;
                    while (TestScore)
                    {
                        string score = Convert.ToString(Console.ReadLine());
                        if (score == null || score.Length == 0)
                        {
                            students[i].Score = OldScore;
                            TestScore = false;
                            break;
                        }
                        else
                        {
                            try
                            {
                                if (Double.Parse(score) < 0 || Double.Parse(score) > 10)
                                {
                                    Exception e = new Exception();
                                    throw e;
                                }
                                else
                                {
                                    students[i].Score = Double.Parse(score);
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.Write("\tError, re-add: ");
                            }
                        }

                    }

                    // update classid
                    Console.Write("\t-New ClassId: ");
                    int OldClassId = students[i].ClassId;
                    // if nothing is entered, do not update the classid
                    bool TestClassId = true;
                    while (TestClassId)
                    {
                        string classid = Convert.ToString(Console.ReadLine());
                        if (classid == null || classid.Length == 0)
                        {
                            students[i].ClassId = OldClassId;
                            TestClassId = false;
                            break;
                        }
                        else
                        {
                            try
                            {

                                if (CheckClassId(int.Parse(classid)) == false)
                                {
                                    Exception e = new Exception();
                                    throw e;
                                }
                                else
                                {
                                    students[i].ClassId = int.Parse(classid);
                                    break;
                                }

                            }
                            catch (Exception e)
                            {
                                Console.Write("\tError, re-add:");
                            }
                        }
                    }
                   
                    System.IO.File.AppendAllText(LogFile.logFilePath, " - " + System.DateTime.Now.ToString() + "    Update Student:    -Id: " + students[i].Id + "   " + "Name: " + students[i].Name + "   " + "-Email: " + "" + students[i].EmailAddress + "   " +
                        "-Gender: " + "" + students[i].Gender + "   " + "-PhoneNumber: " + "" + students[i].PhoneNumber + "   " + "-Score: " + "" + students[i].Score + "   " + "-ClassId: " + "" + students[i].ClassId + Environment.NewLine);
                    _studentDatabaseService.UpDateStudent(students[i], Id);
                }
            }
        }

        //delete students by name
        public void RemoveByName()
        {
            var students = this._studentDatabaseService.GetListStudent();
            Console.Write("\tEnter the student's name to be deleted: ");
            string RemoveName = Convert.ToString(Console.ReadLine());
            PrintListStudentSearch(FindByName(RemoveName));
            if (FindByName(RemoveName) != null && FindByName(RemoveName).Count > 0)
            {
                Console.Write("\tEnter the student's id to be deleted: ");
                int RemoteId = Convert.ToInt32(Console.ReadLine());
                RemoveById(RemoteId);
            }
            else
            {
                Console.Write("\tNot in the list, please press \"quit to\" exit or press \"replace\" to enter again: ");
                string ReEnTerRemoveName = Convert.ToString(Console.ReadLine());
                if (ReEnTerRemoveName == "quit")
                {
                    MenuStudent();
                }
                else
                {
                    RemoveByName();
                }

            }

        }

        // update students by name
        public void UpdateStudentByName()
        {
            var students = this._studentDatabaseService.GetListStudent();
            Console.Write("\tEnter the student'name to update: ");
            string UpdateName = Convert.ToString(Console.ReadLine());
            PrintListStudentSearch(FindByName(UpdateName));
            if (FindByName(UpdateName) != null && FindByName(UpdateName).Count > 0)
            {
                Console.Write("\tEnter the student'id to update: ");
                int UpdateById = Convert.ToInt32(Console.ReadLine());
                UpdateStudentById(UpdateById);
            }
            else
            {
                Console.Write("\tNot in the list, please press \"quit\" to exit or press \"replace\" to enter again: ");
                string ReEnTerUpdateName = Convert.ToString(Console.ReadLine());
                if (ReEnTerUpdateName == "quit")
                {
                    MenuStudent();
                }
                else
                {
                    UpdateStudentByName();
                }
            }
        }

        // find by id
        public void FindByIdAndLog(int Id)
        {
            var students = this._studentDatabaseService.GetListStudent();
            var table = new ConsoleTable("Id", "Name", "Gender","DateOfBirth", "EmailAddress", "PhoneNumber", "Score", "ClassId");
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == Id)
                {
                    table.AddRow(students[i].Id, students[i].Name, students[i].Gender, students[i].DateOfBirth, students[i].EmailAddress, students[i].PhoneNumber, students[i].Score, students[i].ClassId);
                }
            }
            table.Write(Format.MarkDown);
            Console.WriteLine();
        }
        //take out the student of the same name
        public List<Student> FindByName(String keyword)
        {
            var students = this._studentDatabaseService.GetListStudent();
            List<Student> searchResult = new List<Student>();
            if (students != null && students.Count > 0)
            {
                foreach (Student astudent in students)
                //for (int i = 0; i < students.Count; i++)
                {
                    if (astudent.Name.ToUpper().Contains(keyword.ToUpper()))
                    {
                        searchResult.Add(astudent);
                    }
                }
            }
            return searchResult;
        }

        // sort students by score
        public void SortByScore()
        {
            var students = this._studentDatabaseService.GetListStudent();
            students.Sort(delegate (Student sv1, Student sv2) {
                return sv1.Score.CompareTo(sv2.Score);
            });
        }

        // sort students by name
        public void SortByName()
        {
            var students = this._studentDatabaseService.GetListStudent();
            students.Sort(delegate (Student sv1, Student sv2) {
                return sv1.Name.CompareTo(sv2.Name);
            });
        }

        // sort students by id
        public void SortById()
        {
            var students = this._studentDatabaseService.GetListStudent();
            students.Sort(delegate (Student sv1, Student sv2) {
                return sv1.Id.CompareTo(sv2.Id);
            });
        }

        // find classmates
        public List<Student> GetClassmate(int id)
        {
            var students = this._studentDatabaseService.GetListStudent();
            List<Student> ListClassmate = new List<Student>();
            var Classmateid = 0;
            foreach (Student student in students)
            {
                if(student.ClassId == id)
                {
                    ListClassmate.Add(student);
                }
            }
            return ListClassmate;
        }

        //pop id
        public Student FindByID(int ID)
        {
            var students = this._studentDatabaseService.getListStudent();
            Student searchResult = null;
            if (students != null && students.Count > 0)
            {
                foreach (Student student in students)
                {
                    if (student.Id == ID)
                    {
                        searchResult = student;
                    }
                }
            }
            return searchResult;
        }
    }
}
