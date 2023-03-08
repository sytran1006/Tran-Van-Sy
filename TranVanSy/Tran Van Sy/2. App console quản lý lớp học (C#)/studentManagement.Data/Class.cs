using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Data
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Class() { }
        public Class(int Id, string Name, int TeacherId)
        {
            this.Id = Id;
            this.Name = Name;
            this.TeacherId = TeacherId;
        }
    }
}
