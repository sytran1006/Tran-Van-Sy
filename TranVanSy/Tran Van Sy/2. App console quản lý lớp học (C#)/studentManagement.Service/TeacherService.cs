using ConsoleTables;
using studentManagement.Data;
using studentManagement.Database;
using studentManagement.DatabaseService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace studentManagement.Service
{
    public class TeacherService
    {
        private TeacherDatabaseService _teacherDatabaseService = new();
        public TeacherService(TeacherDatabaseService teacherDatabaseService)
        {
            this._teacherDatabaseService = teacherDatabaseService;
        }
        public TeacherService() { }
        public void PrintListTeacher()
        {
            Console.WriteLine("list teacher");
            var teachers = this._teacherDatabaseService.getListTeacher();
            var table = new ConsoleTable("Id", "Name","DateOfBirth","StartYear","PhoneNumber","Email");
            foreach (var ateacher in teachers)
            {
                table.AddRow(ateacher.Id, ateacher.Name, ateacher.DateOfBirth,ateacher.StartYear,ateacher.PhoneNumber,ateacher.EmailAddress);
            }

            table.Write(Format.MarkDown);
            Console.WriteLine();
        }
        // show take-out list
        public void PrintListTeacherSearch(List<Teacher> ListTeacher)
        {
            var table = new ConsoleTable("Id", "Name", "DateOfBirth", "StartYear", "PhoneNumber", "Email");
            Console.WriteLine("  list teacher");
            foreach (var ateacher in ListTeacher)
            {
                table.AddRow(ateacher.Id, ateacher.Name, ateacher.DateOfBirth, ateacher.StartYear, ateacher.PhoneNumber, ateacher.EmailAddress);

            }

            table.Write(Format.MarkDown);
            Console.WriteLine();

        }
        //menu teacher
        public void MenuTeacher()
        {
        MenuTeacher:
            bool OptionTeacher = true;
            //FormatException:
            Console.WriteLine("------------------------ Teacher Management--------------------------------");
            Console.WriteLine("**   Choose an options for working with:                                 **");
            Console.WriteLine("**  1 - View List teacher                                                **");
            Console.WriteLine("**  2 - Search teacher                                                   **");
            Console.WriteLine("**  3 - Add new teacher                                                  **");
            Console.WriteLine("**  4 - Update a teacher                                                 **");
            Console.WriteLine("**  5 - Remove a teacher                                                 **");
            Console.WriteLine("**  6 - Student of teacher                                               **");
            Console.WriteLine("**  7 - Remove By name                                                   **");
            Console.WriteLine("**  8 - Update information by name                                       **");
            Console.WriteLine("**  0 - Exit                                                             **");
            Console.WriteLine("**  Your option?                                                         **");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("Choose an option : ");
            while (OptionTeacher)
            {
                switch (Convert.ToString(Console.ReadLine()))
                {
                    case "1":
                        Console.WriteLine("  Viewing teacher list");
                        PrintListTeacherSearch(_teacherDatabaseService.GetListTeacher());
                        Console.Write("Choose an operation: ");
                        break;
                    case "2":

                    SearchTeacher:
                        Console.Write("Search student by (id / name), if not sellected then enter \"exit\": ");
                        string SearchTeacher = Convert.ToString(Console.ReadLine());
                        bool SearchTeacherChoose = true;
                        while (SearchTeacherChoose)
                        {

                            if (SearchTeacher == "id")
                            {
                                while (true)
                                {
                                    Console.Write("Input teacher id for searching: ");
                                    string SearchIdStudent = Convert.ToString(Console.ReadLine());
                                    if (SearchIdStudent == "exit")
                                    {
                                        goto SearchTeacher;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            FindById(int.Parse(SearchIdStudent));
                                            SearchTeacherChoose = false;
                                            
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("This teacher does not exist");
                                        }
                                    }
                                }
                            }


                            else if (SearchTeacher == "name")
                            {
                                while (true)
                                {
                                    Console.Write("Input teacher name for searching: ");
                                    string SearchNameStudent = Convert.ToString(Console.ReadLine());
                                    if (SearchNameStudent == "exit")
                                    {
                                        goto SearchTeacher;
                                    }
                                    else
                                    {
                                        List<Teacher> searchResult = FindByName(SearchNameStudent);
                                        foreach(Teacher teacher in searchResult) { 
                                            if (teacher.Id != null)
                                            {
                                                PrintListTeacherSearch(searchResult);

                                            }
                                            else
                                                Console.WriteLine("This teacher does not exist");
                                        }                                      
                                    }
                                }
                            }
                            else if (SearchTeacher == "exit")
                            {
                                SearchTeacherChoose = false;
                                Console.WriteLine("You have exited the student search");
                            }
                            else
                            {
                                Console.WriteLine("This option is not available");
                                Console.Write("Confluent your option: ");
                                goto SearchTeacher;
                            }
                        }
                        Console.Write("Choose an operation: ");
                        break;
                    case "3":
                        Console.WriteLine("Enter new teacher information: ");
                        AddTeacher();
                        Console.Write("Choose an operation: ");
                        break;
                    case "4":
                        Console.WriteLine("Update teacher information");
                        Console.Write("Input class id for updating: ");
                        int IdForUpdate = Convert.ToInt32(Console.ReadLine());
                        FindById(IdForUpdate);
                        UpdateTeacherById(IdForUpdate);
                        Console.WriteLine("You have successfully update teacher! ");
                        Console.Write("Choose an operation: ");
                        break;
                    case "5":
                        Console.WriteLine("Delete a teacher ");
                        Console.Write("Input teacher id for deleting: ");
                        int IdForDelete = Convert.ToInt32(Console.ReadLine());
                        FindById(IdForDelete);
                        RemoveById(IdForDelete);
                        Console.Write("Choose an operation: ");
                        break;
                    case "6":
                        Console.Write("\tEnter teacher id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        List<Student> students = new List<Student>();
                        students = StudentOfTeacher(id);
                        _studentService.PrintListStudentSearch(students);
                        Console.Write("Choose an operation: ");
                        break;
                    case "7":
                        RemoveByName();
                        Console.Write("Choose an operation: ");
                        break;
                    case "8":
                        UpdateTeacherByName();
                        Console.WriteLine("You have successfully update teacher! ");
                        Console.Write("Choose an operation: ");
                        break;
                    case "0":
                        Console.WriteLine("Out menu");
                        OptionTeacher = false;
                        break;
                    case "help":
                        goto MenuTeacher;
                    default:
                        Console.WriteLine("\nDon't have this function!");
                        Console.WriteLine("\nPlease select the appropriate function in the menu.");
                        Console.Write("Choose an operation: ");
                        break;
                }
            }
        }

        // find by id
        public void FindById(int Id)
        {
            var teachers = this._teacherDatabaseService.GetListTeacher();
            var table = new ConsoleTable("Id", "Name", "DateOfBirth", "StartYear", "PhoneNumber", "Email");
            for (int i = 0; i < teachers.Count; i++)
            {
                if (teachers[i].Id == Id)
                {
                    table.AddRow(teachers[i].Id, teachers[i].Name, teachers[i].DateOfBirth, teachers[i].StartYear, teachers[i].PhoneNumber, teachers[i].EmailAddress);
                }
            }
            table.Write(Format.MarkDown);
            Console.WriteLine();
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

        //find byname
        public List<Teacher> FindByName(String keyword)
        {
            var teachers = this._teacherDatabaseService.GetListTeacher();
            List<Teacher> searchResult = new List<Teacher>();
            if (teachers != null && teachers.Count > 0)
            {
                foreach (Teacher ateacher in teachers)
                //for (int i = 0; i < students.Count; i++)
                {
                    if (ateacher.Name.ToUpper().Contains(keyword.ToUpper()))
                    {
                        searchResult.Add(ateacher);
                    }
                }
            }
            return searchResult;
        }

        //pop max id
        public int GenerateId()
        {
            var teachers = this._teacherDatabaseService.getListTeacher();
            int max = 1;
            if (teachers != null && teachers.Count > 0)
            {
                for (int i = 0; i <= teachers.Count; i++)
                {
                    if (max < i)
                    {
                        max = i;
                    }
                }
            }
            return max;
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

        // add teacher
        public void AddTeacher()
        {
            while (true)
            {
                var teachers = this._teacherDatabaseService.GetListTeacher();

                Teacher ateacher = new Teacher();

                ateacher.Id = _teacherDatabaseService.GenerateId() + 1;
                Console.Write("\t-Name: ");
                ateacher.Name = Convert.ToString(Console.ReadLine());
                if (NameIsvalId(ateacher.Name) == false)
                {
                    do
                    {
                        Console.Write("\tPlease input a valid name or type \"quit\" to quit process: ");
                        ateacher.Name = Convert.ToString(Console.ReadLine());
                        if (ateacher.Name == "quit")
                        {
                            Console.WriteLine("You don't add teacher! ");
                            goto Out;
                        }

                    } while (NameIsvalId(ateacher.Name) == false);
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
                            Console.WriteLine("You don't add teacher! ");
                            goto Out;
                        }
                        else if (TimeIsValid(dateOfBirth) == true)
                        {
                            DateOfBirth = dateOfBirth;
                            ateacher.DateOfBirth = DateTime.Parse(dateOfBirth);
                            break;
                        }
                        else
                        {
                            DateOfBirth = dateOfBirth;
                        }

                    } while (TimeIsValid(DateOfBirth) == false);
                }
                ateacher.DateOfBirth = DateTime.Parse(DateOfBirth);

                // add start year
                Console.Write("\t-Start year (yyyy > 1990): ");
                while (true)
                {
                    try
                    {
                        string startYear = Convert.ToString(Console.ReadLine());
                        if (startYear == "quit")
                        {
                            goto Out;
                        }
                        else
                        {
                            try
                            {
                                if (int.Parse(startYear) >= 1990)
                                {
                                    ateacher.StartYear = int.Parse(startYear);
                                    break;
                                }
                                else
                                {
                                    Exception e = new Exception();
                                    throw e;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.Write("\tWrong year format re-add: ");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Write("\tWrong year format re-add: ");
                    }
                }

                // add phonenumber
                Console.Write("\t-Phone number: ");
                ateacher.PhoneNumber = Convert.ToString(Console.ReadLine());
                if (ateacher.PhoneNumber == null || PhoneNumberIsvalId(ateacher.PhoneNumber) == false)
                {
                    do
                    {
                        Console.Write("\tPlease input a valid phone number or type \"quit\" to quit process: ");
                        ateacher.PhoneNumber = Convert.ToString(Console.ReadLine());
                        if (ateacher.PhoneNumber == "quit")
                        {
                            Console.WriteLine("You don't add teacher! ");
                            goto Out;
                        }

                    } while (ateacher.PhoneNumber == null || PhoneNumberIsvalId(ateacher.PhoneNumber) == false);
                }
                if (ateacher.PhoneNumber != null || PhoneNumberIsvalId(ateacher.PhoneNumber) == true)
                {
                    foreach (Teacher teacher in teachers)
                    {
                        if (ateacher.PhoneNumber == teacher.PhoneNumber)
                        {
                            do
                            {
                                Console.WriteLine("\tPhone number already exists, please re-add: ");
                                ateacher.PhoneNumber = Convert.ToString(Console.ReadLine());
                                while (ateacher.PhoneNumber == null || PhoneNumberIsvalId(ateacher.PhoneNumber) == false)
                                {
                                    Console.Write("\tPlease input a valid phone number or type \"quit\" to quit process: ");
                                    ateacher.PhoneNumber = Convert.ToString(Console.ReadLine());
                                    if (ateacher.PhoneNumber == "quit")
                                    {
                                        Console.WriteLine("You don't add teacher! ");
                                        goto Out;
                                    }

                                }
                            } while (ateacher.PhoneNumber == teacher.PhoneNumber);
                        }
                    }                  
                }

                // add email
                Console.Write("\t-Email: ");
                ateacher.EmailAddress = Convert.ToString(Console.ReadLine());
                if (EmailIsValId(ateacher.EmailAddress) == false)
                {
                    do
                    {
                        Console.Write("\tPlease input a valid email or type \"quit\" to quit process: ");
                        ateacher.EmailAddress = Convert.ToString(Console.ReadLine());
                        if (ateacher.EmailAddress == "quit")
                        {
                            Console.WriteLine("You don't add teacher! ");
                            goto Out;
                        }

                    } while (EmailIsValId(ateacher.EmailAddress) == false);
                }

                if (ateacher.EmailAddress != null || EmailIsValId(ateacher.EmailAddress) == true)
                {
                    foreach (Teacher teacher in teachers)
                    {
                        if (teacher.EmailAddress == ateacher.EmailAddress)
                        {
                            do
                            {
                                Console.Write("\tEmail already exists, please re-add: ");
                                ateacher.EmailAddress = Convert.ToString(Console.ReadLine());
                                while (ateacher.EmailAddress == null || EmailIsValId(ateacher.EmailAddress) == false)
                                {
                                    Console.Write("\tPlease input a valid email or type \"quit\" to quit process: ");
                                    ateacher.EmailAddress = Convert.ToString(Console.ReadLine());
                                    if (ateacher.EmailAddress == "quit")
                                    {
                                        Console.WriteLine("You don't add teacher! ");
                                        goto Out;
                                    }

                                }
                            } while (ateacher.EmailAddress == teacher.EmailAddress);

                        }
                    }
                }
                
                System.IO.File.AppendAllText(LogFile.logFilePath, " - " + System.DateTime.Now.ToString() + "    Add teacher:    -Id: " + ateacher.Id + "   " + "Name: " + ateacher.Name + "   " + Environment.NewLine);
                teachers.Add(ateacher);
                _teacherDatabaseService.AddTeacher(ateacher.Id, ateacher.Name, ateacher.DateOfBirth, ateacher.StartYear, ateacher.PhoneNumber, ateacher.EmailAddress);
                Console.WriteLine("You have successfully add teacher! ");
            Out:
                break;
            }
        }

        // update by id
        public void UpdateTeacherById(int Id)
        {
            var teachers = this._teacherDatabaseService.GetListTeacher();
            for (int i = 0; i < teachers.Count; i++)
            {
                if (Id == teachers[i].Id)
                {

                    // update name
                    Console.Write("\t-New Name: ");                   
                    string OldName = teachers[i].Name;

                    while (true)
                    {
                        string Name = Convert.ToString(Console.ReadLine());
                        if (Name == null || Name.Length == 0)
                        {
                            teachers[i].Name = OldName;
                            break;

                        }
                        else if (NameIsvalId(Name) == false)
                        {
                            do
                            {
                                Console.Write("\t-Error, re-add: ");
                                Name = Convert.ToString(Console.ReadLine());
                                teachers[i].Name = Name;
                            } while (NameIsvalId(Name) == false);
                            break;
                        }
                        else
                        {
                            teachers[i].Name = Name;
                            break;
                        }
                    }

                    //update DateOfBirth
                    Console.Write("\t-New DateOfBirth: ");
                    DateTime OldDateOfBirth = teachers[i].DateOfBirth;
                    //if nothing is entered, do not update the email
                    string DateOfBirth = Convert.ToString(Console.ReadLine());
                    while (true)
                    {
                        if (DateOfBirth == null || DateOfBirth.Length == 0)
                        {
                            teachers[i].DateOfBirth = OldDateOfBirth;
                            break;

                        }
                        else if (TimeIsValid(DateOfBirth) == false)
                        {
                            do
                            {
                                Console.Write("\t-Error, re-add: ");
                                DateOfBirth = Convert.ToString(Console.ReadLine()).Trim();
                                teachers[i].DateOfBirth = DateTime.Parse(DateOfBirth);
                            } while (TimeIsValid(DateOfBirth) == false);
                            break;
                        }
                        else
                        {
                            teachers[i].DateOfBirth = DateTime.Parse(DateOfBirth);
                            break;
                        }
                    }

                    //update email
                    Console.Write("\t-New email: ");
                    string OldEmail = teachers[i].EmailAddress;
                    //if nothing is entered, do not update the email
                    string Email = Convert.ToString(Console.ReadLine());
                    while (true)
                    {


                        if (Email == null || Email.Length == 0)
                        {
                            teachers[i].EmailAddress = OldEmail;
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
                            foreach (Teacher teacher in teachers) { 
                                if (teacher.EmailAddress == Email)
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
                                                MenuTeacher();
                                            }

                                        }
                                    } while (Email == teacher.EmailAddress);

                                }

                            }
                            teachers[i].EmailAddress = Email;
                            break;
                        }
                    }

                    // update start year
                    Console.Write("\t-New Start Year:  ");
                    int OldStartYear = teachers[i].StartYear;
                    // if nothing is entered, do not update the score
                    bool TestYear = true;
                    while (TestYear)
                    {
                        string startYear = Convert.ToString(Console.ReadLine());
                        if (startYear == null || startYear.Length == 0)
                        {
                            teachers[i].StartYear = OldStartYear;
                            TestYear = false;
                            break;
                        }
                        else
                        {
                            try
                            {
                                if (int.Parse(startYear) < 1990)
                                {
                                    Exception e = new Exception();
                                    throw e;
                                }
                                else
                                {
                                    teachers[i].StartYear = int.Parse(startYear);
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
                    string OldPhoneNumber = teachers[i].PhoneNumber;
                    // if nothing is entered, do not update the phonenumber
                    string PhoneNumber = Convert.ToString(Console.ReadLine());
                    while (true)
                    {
                        if (PhoneNumber == null || PhoneNumber.Length == 0)
                        {
                            teachers[i].PhoneNumber = OldPhoneNumber;
                            break;

                        }
                        if (PhoneNumberIsvalId(PhoneNumber) == false)
                        {
                            do
                            {
                                Console.Write("\t-Error, re-add: ");
                                PhoneNumber = Convert.ToString(Console.ReadLine());
                                teachers[i].PhoneNumber = PhoneNumber;
                            } while (PhoneNumberIsvalId(PhoneNumber) == false);

                        }
                        if (PhoneNumber != null || PhoneNumberIsvalId(PhoneNumber) == true)
                        {
                            foreach(Teacher teacher in teachers)
                            {
                                if (PhoneNumber == teacher.PhoneNumber)
                                {
                                    do
                                    {
                                        Console.Write("\tPhone Number already exists, please re-add: ");
                                        PhoneNumber = Convert.ToString(Console.ReadLine());
                                        while (teachers[i].PhoneNumber == null || PhoneNumberIsvalId(PhoneNumber) == false)
                                        {
                                            Console.Write("\tPlease input a valid phone number or type \"quit\" to quit process: ");
                                            PhoneNumber = Convert.ToString(Console.ReadLine());
                                            if (PhoneNumber == "quit")
                                            {
                                                MenuTeacher();
                                            }

                                        }
                                    } while (PhoneNumber == teacher.PhoneNumber);
                                    break;
                                }
                            }
                            teachers[i].PhoneNumber = PhoneNumber;
                            break;
                        }
                    }                 
                    System.IO.File.AppendAllText(LogFile.logFilePath, " - " + System.DateTime.Now.ToString() + "    Update teacher:    -Id: " + teachers[i].Id + "   " + "Name: " + teachers[i].Name + "   " + Environment.NewLine);
                    _teacherDatabaseService.UpDateTeacher(teachers[i], Id);
                }
            }
        }
        // delete by id
        public void RemoveById(int Id)
        {
            var teachers = this._teacherDatabaseService.GetListTeacher();
            for (int i = 0; i < teachers.Count; i++)
            {
                if (Id == teachers[i].Id)
                {
                    
                    System.IO.File.AppendAllText(LogFile.logFilePath, " - " + System.DateTime.Now.ToString() + "    Delete teacher:    -Id: " + teachers[i].Id + "   " + "Name: " + teachers[i].Name + "   " + Environment.NewLine);
                    teachers.Remove(teachers[i]);
                    _teacherDatabaseService.DeleteTeacher(Id);
                }
            }
        }

        // update by name
        public void UpdateTeacherByName()
        {
            var teachers = this._teacherDatabaseService.getListTeacher();
            Console.Write("\tEnter the teacher's name to be updated: ");
            string UpdateName = Convert.ToString(Console.ReadLine());
            PrintListTeacherSearch(FindByName(UpdateName));
            if (FindByName(UpdateName) != null && FindByName(UpdateName).Count > 0)
            {
                Console.Write("\tEnter the teacher's id to be updated: ");
                int UpdateById = Convert.ToInt32(Console.ReadLine());
                UpdateTeacherById(UpdateById);
            }
            else
            {
                Console.Write("\tNot in the list, please press \"quit\" to exit or press \"replace\" to enter again: ");
                string ReEnTerUpdateName = Convert.ToString(Console.ReadLine());
                if (ReEnTerUpdateName == "quit")
                {
                    MenuTeacher();
                }
                else
                {
                    UpdateTeacherByName();
                }

            }
        }

        // delete by name
        public void RemoveByName()
        {
            var teachers = this._teacherDatabaseService.GetListTeacher();
            Console.Write("\tEnter the name of the teacher you want to delete: ");
            string removeName = Convert.ToString(Console.ReadLine());
            PrintListTeacherSearch(FindByName(removeName));
            if (FindByName(removeName) != null && FindByName(removeName).Count > 0)
            {
                Console.Write("\tEnter the id of the teacher you want to delete: ");
                int RemoteId = Convert.ToInt32(Console.ReadLine());
                RemoveById(RemoteId);
            }
            else
            {
                Console.WriteLine("\tNot in the list, please press \"quit\" to exit or press \"replace\" to enter again: ");
                string ReEnTerRemoveName = Convert.ToString(Console.ReadLine());
                if (ReEnTerRemoveName == "quit")
                {
                    MenuTeacher();
                }
                else
                {
                    RemoveByName();
                }

            }

        }

        // find classmate
        private readonly ClassDatabaseService _classDatabaseservice = new();
        private readonly ClassService _classService = new();
        private readonly StudentDatabaseService _studentDatabaeService = new();
        private readonly StudentService _studentService = new();
        public List<Student> StudentOfTeacher(int IdTeacher)
        {
            //FindById(IdTeacher);
            // find teacher of class
            List<Class> ClassOfTeacher = new List<Class>();
            List<Student> StudentOfTeacher = new List<Student>();
            var students = this._studentDatabaeService.GetListStudent();
            var classes = this._classDatabaseservice.GetListClass();
            if (classes != null && classes.Count > 0)
            {
                foreach (Class class_ in classes)
                {
                    if (class_.TeacherId == IdTeacher)
                    {
                        ClassOfTeacher.Add(class_);
                    }
                }

            }
            foreach (Class class_ in ClassOfTeacher)
            {
                foreach (Student student_ in students)
                {
                    if (student_.ClassId == class_.Id)
                    {
                        StudentOfTeacher.Add(student_);
                    }
                }
            }
            return StudentOfTeacher;
        }
    }
}


