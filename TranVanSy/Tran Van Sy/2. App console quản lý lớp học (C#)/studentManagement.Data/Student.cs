using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public double Score { get; set; }
        public int ClassId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student() { }
        public Student(int Id, string Name, string EmailAddress, string Gender, string PhoneNumber, float Score, int ClassId)
        {
            this.Id = Id;
            this.Name = Name;
            this.EmailAddress = EmailAddress;
            this.PhoneNumber = PhoneNumber;
            this.Gender = Gender;
            this.Score = Score;
            this.ClassId = ClassId;
        }
    }
}
