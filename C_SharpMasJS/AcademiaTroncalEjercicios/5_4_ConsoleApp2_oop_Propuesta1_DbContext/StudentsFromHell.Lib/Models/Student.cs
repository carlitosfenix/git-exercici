using System.Collections.Generic;

namespace StudentsFromHell.Lib.Models
{
    public class Student
    {
        public string Dni { get; set; }
        public string Name { get; set; }

        public List<double> Marks { get; set; }
    }
}
