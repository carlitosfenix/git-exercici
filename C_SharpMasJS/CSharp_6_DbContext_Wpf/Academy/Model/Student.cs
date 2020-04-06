using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_4_DbContext.Lib.Model
{ 
    public class Student : Entity
    {
        private string _name;
        private string _dni;
        private List<Exam> _exams;

        public string Name { get => _name; set => _name = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public List<Exam> Exams { get => _exams; set => _exams = value; }

        public Student(string name, string dni)
        {
            Name = name;
            Dni = dni;
            Id = Guid.NewGuid();
        }

        public bool AddExam(Exam newExam)
        {
            Exams.Add(newExam);
            return true;
        }
    }
}
