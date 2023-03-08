using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StartYear { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public Teacher() { }
        public Teacher(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
