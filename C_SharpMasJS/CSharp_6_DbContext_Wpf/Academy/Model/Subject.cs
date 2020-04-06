using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_4_DbContext.Lib.Model
{
    public class Subject : Entity
    {
        private string _name;
        private string _teacher;

        public string Name { get => _name; set => _name = value; }
        public string Teacher { get => _teacher; set => _teacher = value; }

        public Subject(string name, string teacher)
        {
            Name = name;
            Teacher = teacher;
        }
    }
}
