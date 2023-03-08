using ConsoleTables;
using studentManagement.Data;
using studentManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace studentManagement.Service
{
    public class ClassService
    {
        private readonly ClassDatabaseService _classDatabaseService = new();
        private readonly TeacherDatabaseService _teacherDatabaseService = new();
        public ClassService(ClassDatabaseService classDatabaseService)
        {
            this._classDatabaseService = classDatabaseService;
        }
        public void PrintListClass()
        {
            var classes = this._classDatabaseService.GetListClass();
            var table = new ConsoleTable("Id", "Name", "teacherId","StartTime", "EndTime");
            Console.WriteLine("list class");
            foreach (var clas in classes)
            {
                table.AddRow(clas.Id, clas.Name, clas.TeacherId, clas.StartTime,clas.EndTime);

            }

            table.Write(Format.MarkDown);
            Console.WriteLine();
        }
        public ClassService() { }
        // show take-out list
        public void PrintListClassSearch(List<Class> Listcl)
        {
            var table = new ConsoleTable("Id", "Name", "teacherId", "StartTime", "EndTime");
            Console.WriteLine("  list class");
            foreach (var classs in Listcl)
            {
                table.AddRow(classs.Id, classs.Name, classs.TeacherId, classs.StartTime, classs.EndTime);

            }

            table.Write(Format.MarkDown);
            Console.WriteLine();

        }
        //menu class
        public void MenuClass()
        {
        MenuClass:
            bool OptionClass = true;

            //FormatException:
            Console.WriteLine("------------------------ Class Management----------------------------------");
            Console.WriteLine("**   Choose an options for working with:                                 **");
            Console.WriteLine("**  1 - View List Class                                                  **");
            Console.WriteLine("**  2 - Search Class                                                     **");
            Console.WriteLine("**  3 - Add new Class                                                    **");
            Console.WriteLine("**  4 - Update a class                                                   **");
            Console.WriteLine("**  5 - Remove a class                                                   **");
            Console.WriteLine("**  6 - Remove By name                                                   **");
            Console.WriteLine("**  7 - Update information by name                                       **");
            Console.WriteLine("**  0 - Exit                                                             **");
            Console.WriteLine("**  Your option?                                                         **");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("Choose an option : ");
            while (OptionClass)
            {
                switch (Convert.ToString(Console.ReadLine()))
                {
                    case "1":
                        Console.WriteLine("  Viewing class list");
                        PrintListClassSearch(_classDatabaseService.GetListClass());
                        Console.Write("Choose an operation: ");
                        break;
                    case "2":

                    SearchClass:
                        Console.Write("Search student by (id / name), if not sellected then enter \"exit\": ");
                        string SearchClass = Convert.ToString(Console.ReadLine());
                        bool SearchClassChoose = true;
                        while (SearchClassChoose)
                        {

                            if (SearchClass == "id")
                            {
                                while (true)
                                {
                                    Console.Write("Input student id for searching: ");
                                    string SearchIdStudent = Convert.ToString(Console.ReadLine());
                                    if (SearchIdStudent == "exit")
                                    {
                                        goto SearchClass;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            FindById(int.Parse(SearchIdStudent));
                                            SearchClassChoose = false;
                                            
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("This student does not exist");
                                        }
                                    }
                                }
                            }


                            else if (SearchClass == "name")
                            {
                                while (true)
                                {
                                    Console.Write("Input student name for searching: ");
                                    string SearchNameStudent = Convert.ToString(Console.ReadLine());
                                    if (SearchNameStudent == "exit")
                                    {
                                        goto SearchClass;
                                    }
                                    else
                                    {
                                        List<Class> searchResult = FindByName(SearchNameStudent);
                                        PrintListClassSearch(searchResult);
                                        
                                    }
                                }
                            }
                            else if (SearchClass == "exit")
                            {
                                SearchClassChoose = false;
                                Console.WriteLine("You have exited the student search");
                            }
                            else
                            {
                                Console.WriteLine("This option is not available");
                                Console.Write("Confluent your option: ");
                                goto SearchClass;
                            }
                        }
                        Console.Write("Choose an operation: ");
                        break;
                    case "3":
                        Console.WriteLine("Enter new class information: ");
                        AddClass();
                        Console.Write("Choose an operation: ");
                        break;
                    case "4":
                        Console.WriteLine("Update class information");
                        Console.Write("Input class id for updating: ");
                        int IdForUpdate = Convert.ToInt32(Console.ReadLine());
                        FindById(IdForUpdate);
                        UpdateClassById(IdForUpdate);
                        Console.WriteLine("You have successfully update class! ");
                        Console.Write("Choose an operation: ");
                        break;
                    case "5":
                        Console.WriteLine("Delete a class ");
                        Console.Write("Input class id for deleting: ");
                        int IdForDelete = Convert.ToInt32(Console.ReadLine());
                        FindById(IdForDelete);
                        RemoveById(IdForDelete);
                        Console.Write("Choose an operation: ");
                        break;
                    case "6":
                        RemoveByName();
                        Console.WriteLine("delete successful class!");
                        Console.Write("Choose an operation: ");
                        break;
                    case "7":
                        UpdateClassByName();
                        Console.WriteLine("You have successfully update class! ");
                        Console.Write("Choose an operation: ");
                        break;
                    case "0":
                        Console.WriteLine("Out menu");
                        OptionClass = false;
                        break;
                    case "help":
                        goto MenuClass;
                    default:
                        Console.WriteLine("\nDon't have this function!");
                        Console.WriteLine("\nPlease select the appropriate function in the menu.");
                        Console.Write("Choose an operation: ");
                        break;
                }
            }
        }
        // find by classid
        public void FindById(int Id)
        {
            var classes = this._classDatabaseService.GetListClass();
            var table = new ConsoleTable("Id", "Name", "TeacherId","StartTime","EndTime");
            for (int i = 0; i < classes.Count; i++)
            {
                if (classes[i].Id == Id)
                {
                    table.AddRow(classes[i].Id, classes[i].Name, classes[i].TeacherId, classes[i].StartTime, classes[i].EndTime);
                }
            }
            table.Write(Format.MarkDown);
            Console.WriteLine();
        }

        //valid starttime endtime
        public static bool ValidTimeOnly(String n)
        {
            bool val = false;
            int val1, val2, val3, val4, len;
            char[] charattay = n.ToCharArray();
            val1 = (int)charattay[0];
            val2 = (int)charattay[1];
            val3 = (int)charattay[3];
            val4 = (int)charattay[4];
            len = n.Length;
            if ((len == 8) && (val1 >= 48 && val1 <= 57) && (val2 >= 48 && val2 <= 57) &&
            (charattay[2] == ':') && (val3 >= 48 && val3 <= 53) && (val4 >= 48 && val4 <= 57) &&
            (charattay[6] == 'p' || charattay[6] == 'P' || charattay[6] == 'a' || charattay[6] == 'A') &&
            (charattay[7] == 'm' || charattay[7] == 'M'))
            {
                return val=true;
            }else
            return val=false;
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

        //pop max id
        public int GenerateId()
        {
            var classs = this._classDatabaseService.getListClass();
            int max = 1;
            if (classs != null && classs.Count > 0)
            {
                for (int i = 0; i <= classs.Count; i++)
                {
                    if (max < i)
                    {
                        max = i;
                    }
                }
            }
            return max;
        }

        //get list of teachers of the same name
        public List<Class> FindByName(String keyword)
        {
            var classes = this._classDatabaseService.GetListClass();
            List<Class> searchResult = new List<Class>();
            if (classes != null && classes.Count > 0)
            {
                foreach (Class classs_ in classes)
                //for (int i = 0; i < students.Count; i++)
                {
                    if (classs_.Name.ToUpper().Contains(keyword.ToUpper()))
                    {
                        searchResult.Add(classs_);
                    }
                }
            }
            return searchResult;
        }

        //check teacherid
        public bool CheckTeacherId(int id)
        {
            var teachers = _teacherDatabaseService.GetListTeacher();
            foreach (Teacher ateacher in teachers)
            {
                if (ateacher.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        //add class by id
        public void AddClass()
        {
            while (true)
            {
                var classes = this._classDatabaseService.GetListClass();

                Class aclass = new Class();

                aclass.Id = _classDatabaseService.GenerateId() + 1;

                //add name
                Console.Write("\t-Name: ");
                aclass.Name = Convert.ToString(Console.ReadLine());
                if (aclass.Name == null || NameIsvalId(aclass.Name) == false)
                {
                    do
                    {
                        Console.Write("\tPlease input a valid Name or type \"quit\" to quit process: ");
                        aclass.Name = Convert.ToString(Console.ReadLine());
                        if (aclass.Name == "quit")
                        {
                            Console.WriteLine("You don't add class! ");
                            goto Out;
                        }

                    } while (aclass.Name == null || NameIsvalId(aclass.Name) == false);
                }
                if (aclass.Name != null || NameIsvalId(aclass.Name) == true)
                {
                    foreach (Class clas in classes)
                    {
                        if (aclass.Name == clas.Name)
                        {
                            do
                            {
                                Console.Write("\tName already exists, please re-add: ");
                                aclass.Name = Convert.ToString(Console.ReadLine());
                                while (aclass.Name == null || NameIsvalId(aclass.Name) == false)
                                {
                                    Console.Write("\tPlease input a name or type \"quit\" to quit process: ");
                                    aclass.Name = Convert.ToString(Console.ReadLine());
                                    if (aclass.Name == "quit")
                                    {
                                        Console.WriteLine("You don't add class! ");
                                        goto Out;
                                    }

                                }
                            } while (aclass.Name == clas.Name);

                        }
                    }
                }

                //add teacherid
                Console.Write("\t-TeacherId: ");
                var teachers = _teacherDatabaseService.GetListTeacher();
                while (true)
                {
                    string teacherid = Convert.ToString(Console.ReadLine());
                    if (teacherid == "quit")
                    {
                        Console.WriteLine("You don't add class! ");
                        goto Out;
                    }
                    try
                    {
                        if (CheckTeacherId(int.Parse(teacherid)) == false)
                        {
                            Exception e = new Exception();
                            throw e;
                        }
                        aclass.TeacherId = int.Parse(teacherid);
                        break;

                    }
                    catch (Exception e)
                    {
                        Console.Write("\tThis teacher does not exist or press \"quit\" to exit: ");
                    }
                }

                // add start time
                Console.Write("\t-StartTime (hh:mm AM/PM): ");
                string StartTime= Convert.ToString(Console.ReadLine());
                if (ValidTimeOnly(StartTime) == false)
                {
                    do
                    {
                        Console.Write("\tPlease input a valid time or type \"quit\" to quit process: ");
                        StartTime = Convert.ToString(Console.ReadLine());
                    } while (ValidTimeOnly(StartTime) == false);
                }
                if (StartTime == "quit")
                {
                    Console.WriteLine("You don't add class! ");
                    goto Out;
                }
                aclass.StartTime=DateTime.Parse(StartTime);

                // add end time
                Console.Write("\t-EndTime (hh:mm AM/PM): ");
                string EndTime = Convert.ToString(Console.ReadLine());
                //astudent.Name = Convert.ToString(Console.ReadLine());
                if (ValidTimeOnly(EndTime) == false)
                {
                    do
                    {
                        Console.Write("\tPlease input a valid time or type \"quit\" to quit process: ");
                        EndTime = Convert.ToString(Console.ReadLine());
                    } while (ValidTimeOnly(EndTime) == false);
                }
                if (EndTime == "quit")
                {
                    Console.WriteLine("You don't add class! ");
                    goto Out;
                }
                aclass.EndTime = DateTime.Parse(EndTime);
               
                System.IO.File.AppendAllText(LogFile.logFilePath, " - " + System.DateTime.Now.ToString() + "    Add Class:    -Id: " + aclass.Id + "   " + "Name: " + aclass.Name + "   " + "-TeacherId: " + "" + aclass.TeacherId + "   " + Environment.NewLine);
                classes.Add(aclass);
                _classDatabaseService.AddClass(aclass.Id, aclass.Name, aclass.TeacherId, aclass.StartTime, aclass.EndTime);
                Console.WriteLine("You have successfully add class! ");

            Out:
                break;
            }
        }

        // update class by id
        public void UpdateClassById(int Id)
        {
            var classes = this._classDatabaseService.GetListClass();
            for (int i = 0; i < classes.Count; i++)
            {
                if (Id == classes[i].Id)
                {
                    // update name
                    Console.Write("\t-New Name: ");
                    string OldName = classes[i].Name;
                    string Name = Convert.ToString(Console.ReadLine());
                    while (true)
                    {
                        if (Name == null || Name.Length == 0)
                        {
                            classes[i].Name = OldName;
                            break;
                        }
                        if (NameIsvalId(Name) == false)
                        {
                            do
                            {
                                Console.Write("\t-Error, re-add: ");
                                Name = Convert.ToString(Console.ReadLine());

                            } while (NameIsvalId(Name) == false);
                        }
                        if (Name != null || NameIsvalId(Name) == true)
                        {
                            foreach (Class Clas in classes)
                            {
                                if (Clas.Name == Name)
                                {
                                    do
                                    {
                                        Console.Write("\tName's class already exists, please re-add: ");
                                        Name = Convert.ToString(Console.ReadLine());
                                        while (Name == null || NameIsvalId(Name) == false)
                                        {
                                            Console.Write("\tPlease input a valid name or type \"quit\" to quit process: ");
                                            Name = Convert.ToString(Console.ReadLine());
                                            if (Name == "quit")
                                            {
                                                MenuClass();
                                            }

                                        }
                                    } while (Name == Clas.Name);

                                }

                            }
                            classes[i].Name = Name;
                            break;
                        }
                    }

                    // update teacherid
                    Console.Write("\t-New TeacherId: ");
                    int OldCTeacherId = classes[i].TeacherId;
                    // if nothing is entered, do not update the classid
                    bool TestClassId = true;
                    while (TestClassId)
                    {
                        string classid = Convert.ToString(Console.ReadLine());
                        if (classid == null || classid.Length == 0)
                        {
                            classes[i].TeacherId = OldCTeacherId;
                            TestClassId = false;
                            break;
                        }
                        else
                        {
                            try
                            {
                                if (CheckTeacherId(int.Parse(classid)) == false)
                                {
                                    Exception e = new Exception();
                                    throw e;
                                }
                                else
                                {
                                    classes[i].TeacherId = int.Parse(classid);
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.Write("\tError, re-add:");
                            }
                        }
                    }

                    // update starttime
                    Console.Write("\t-New StartTime (hh:mm AM/PM): ");
                    // if nothing is entered, do not update the name
                    DateTime OldStartTime = classes[i].StartTime;

                    while (true)
                    {
                        string StartTime = Convert.ToString(Console.ReadLine());
                        if (StartTime == null || StartTime.Length == 0)
                        {
                            classes[i].StartTime = OldStartTime;
                            break;

                        }
                        else if (ValidTimeOnly(StartTime) == false)
                        {
                            do
                            {
                                Console.Write("\t-Error, re-add: ");
                                StartTime = Convert.ToString(Console.ReadLine());
                                classes[i].StartTime = DateTime.Parse(StartTime);
                            } while (NameIsvalId(Name) == false);
                            break;
                        }
                        else
                        {
                            classes[i].StartTime = DateTime.Parse(StartTime);
                            break;
                        }
                    }

                    // update endtime
                    Console.Write("\t-New EndTime(hh:mm AM/PM): ");
                    // if nothing is entered, do not update the name
                    DateTime OldEndTime = classes[i].EndTime;
                    while (true)
                    {
                        string EndTime = Convert.ToString(Console.ReadLine());
                        if (EndTime == null || EndTime.Length == 0)
                        {
                            classes[i].EndTime = OldEndTime;
                            break;

                        }
                        else if (ValidTimeOnly(EndTime) == false)
                        {
                            do
                            {
                                Console.Write("\t-Error, re-add: ");
                                EndTime = Convert.ToString(Console.ReadLine());
                                classes[i].EndTime = DateTime.Parse(EndTime);
                            } while (NameIsvalId(Name) == false);
                            break;
                        }
                        else
                        {
                            classes[i].EndTime = DateTime.Parse(EndTime);
                            break;
                        }
                    }

                    
                    System.IO.File.AppendAllText(LogFile.logFilePath, " - " + System.DateTime.Now.ToString() + "    Update Class:    -Id: " + classes[i].Id + "   " + "Name: " + classes[i].Name + "   " + "-TeacherId: " + "" + classes[i].TeacherId + "   " + Environment.NewLine);
                    _classDatabaseService.UpDateClass(classes[i], Id);
                }
            }
        }

        // delete by Id
        public void RemoveById(int Id)
        {
            var classes = this._classDatabaseService.GetListClass();
            for (int i = 0; i < classes.Count; i++)
            {
                if (Id == classes[i].Id)
                {                  
                    System.IO.File.AppendAllText(LogFile.logFilePath, " - " + System.DateTime.Now.ToString() + "    Delete Class:    -Id: " + classes[i].Id + "   " + "Name: " + classes[i].Name + "   " + "-TeacherId: " + "" + classes[i].TeacherId + "   " + Environment.NewLine);
                    _classDatabaseService.DeleteClass(Id);
                }
            }
        }

        // update class by name
        public void UpdateClassByName()
        {
            var classes = this._classDatabaseService.GetListClass();
            Console.Write("\tEnter the class's name to be updated: ");
            string UpdateName = Convert.ToString(Console.ReadLine());
            PrintListClassSearch(FindByName(UpdateName));
            if (FindByName(UpdateName) != null && FindByName(UpdateName).Count > 0)
            {
                Console.Write("\tEnter the class's id to be updated: ");
                int UpdateById = Convert.ToInt32(Console.ReadLine());
                UpdateClassById(UpdateById);
            }
            else
            {
                Console.Write("\tNot in the list, please press \"quit\" to exit or press \"replace\" to enter again: ");
                string ReEnTerUpdateName = Convert.ToString(Console.ReadLine());
                if (ReEnTerUpdateName == "quit")
                {
                    MenuClass();
                }
                else
                {
                    UpdateClassByName();
                }

            }
        }

        // delete class by name
        public void RemoveByName()
        {
            var classes = this._classDatabaseService.GetListClass();
            Console.Write("\tEnter the class's name to be deleted: ");
            string RemoveName = Convert.ToString(Console.ReadLine());
            PrintListClassSearch(FindByName(RemoveName));
            if (FindByName(RemoveName) != null && FindByName(RemoveName).Count > 0)
            {
                Console.Write("\tEnter the class's id to be deleted: ");
                int RemoteId = Convert.ToInt32(Console.ReadLine());
                RemoveById(RemoteId);
            }
            else
            {
                Console.WriteLine("\tNot in the list, please press \"quit to\" exit or press \"replace\" to enter again: ");
                string ReEnTerRemoveName = Convert.ToString(Console.ReadLine());
                if (ReEnTerRemoveName == "quit")
                {
                    MenuClass();
                }
                else
                {
                    RemoveByName();
                }
            }
        }
    }
}
