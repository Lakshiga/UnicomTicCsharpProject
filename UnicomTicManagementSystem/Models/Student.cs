using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManagementSystem.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string Stream { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
    }
}
