using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Data
{
    public class DummyData
    {
        public static List<Student> Students = new List<Student>()
        {
             new Student()
             {
                 Id = 1,
                 Name = "hieu",
                 EmailAddress = "hieu@gmail.com",
                 Gender="Male",
                 PhoneNumber = "0123456789",
                 ClassId = 1,
                 Score= 7,
             },
              new Student()
             {
                 Id = 2,
                 Name = "ha",
                 EmailAddress = "ha@gmail.com",
                 Gender="Female",
                 PhoneNumber = "0123456789",
                 ClassId = 1,
                 Score= 8,
             },
               new Student()
             {
                 Id = 3,
                 Name = "hien",
                 EmailAddress = "hien@gmail.com",
                 Gender="Female",
                 PhoneNumber = "0123456789",
                 ClassId = 3,
                 Score= 8,
             },
               new Student()
               {
                 Id = 4,
                 Name = "son",
                 EmailAddress = "son@gmail.com",
                 Gender="Male",
                 PhoneNumber = "0123456789",
                 ClassId = 2,
                 Score= 6,
               },
                   new Student()
             {
                 Id = 5,
                 Name = "ngoc",
                 EmailAddress = "ngoc@gmail.com",
                 Gender="Female",
                 PhoneNumber = "0123456789",
                 ClassId = 3,
                 Score= 7,
             },
                    new Student()
             {
                 Id = 6,
                 Name = "trung",
                 EmailAddress = "trung@gmail.com",
                 Gender="Male",
                 PhoneNumber = "0123456789",
                 ClassId = 4,
                 Score= 7,
             },
              new Student()
             {
                 Id = 7,
                 Name = "chuc",
                 EmailAddress = "chuc@gmail.com",
                 Gender="Male",
                 PhoneNumber = "0123456789",
                 ClassId = 5,
                 Score= 8,
             },
               new Student()
             {
                 Id = 8,
                 Name = "chien",
                 EmailAddress = "chien@gmail.com",
                 Gender="Male",
                 PhoneNumber = "0123456789",
                 ClassId = 1,
                 Score= 8,
             },
                 new Student()
             {
                 Id = 9,
                 Name = "sy",
                 EmailAddress = "sy@gmail.com",
                 Gender="Male",
                 PhoneNumber = "0123456789",
                 ClassId = 4,
                 Score= 6,
             },
                   new Student()
             {
                 Id = 10,
                 Name = "ngoc",
                 EmailAddress = "ngoc@gmail.com",
                 Gender="Female",
                 PhoneNumber = "0123456789",
                 ClassId = 3,
                 Score= 7,
             },
                    new Student()
             {
                 Id = 11,
                 Name = "chuc",
                 EmailAddress = "chuc1@gmail.com",
                 Gender="Male",
                 PhoneNumber = "0123456789",
                 ClassId = 5,
                 Score= 8,
             },
               new Student()
             {
                 Id = 12,
                 Name = "chien",
                 EmailAddress = "chien1@gmail.com",
                 Gender="Male",
                 PhoneNumber = "0123456789",
                 ClassId = 1,
                 Score= 8,
             },
                 new Student()
             {
                 Id = 13,
                 Name = "sy",
                 EmailAddress = "sy1@gmail.com",
                 Gender="Male",
                 PhoneNumber = "0123456789",
                 ClassId = 4,
                 Score= 6,
             },
                   new Student()
             {
                 Id = 14,
                 Name = "ngoc",
                 EmailAddress = "ngoc1@gmail.com",
                 Gender="Female",
                 PhoneNumber = "0123456789",
                 ClassId = 3,
                 Score= 7,
             },

        };
        public static List<Class> Classes = new List<Class>()
        {
            new Class()
            {
                Id = 1,
                Name = "toan",
                TeacherId = 1,
            },
            new Class()
            {
                Id = 2,
                Name = "ly",
                TeacherId = 1,
            },
            new Class()
            {
                Id = 3,
                Name = "sinh",
                TeacherId = 3,
            },
            new Class()
            {
                Id = 4,
                Name = "su",
                TeacherId = 4,
            },
            new Class()
            {
                Id = 5,
                Name = "dia",
                TeacherId = 5,
            },
        };
        public static List<Teacher> Teachers = new List<Teacher>()
        {
             new Teacher()
            {
                Id = 1,
                Name = "hoa",
            },

             new Teacher()
            {
                Id = 2,
                Name = "nhung",
            },

             new Teacher()
            {
                Id = 3,
                Name = "hien",
            },

             new Teacher()
            {
                Id = 4,
                Name = "nuong", 
                
            },
        };
    }
}
