using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_5_2.Lib.Model
{
    public class Exam :Entity
    {
        private Student _student;
        private Subject _subject;
        private DateTime _dateTimeExam;
        private double _score;

        public Student Student { get => _student; set => _student = value; }
        public Subject Subject { get => _subject; set => _subject = value; }
        public DateTime DateTimeExam { get => _dateTimeExam; set => _dateTimeExam = value; }
        public double Score { get => _score; set => _score = value; }

        public Exam(Student student, Subject subject, DateTime dateTimeExam, double score)
        {
            Student = student;
            Subject = subject;
            DateTimeExam = dateTimeExam;
            Score = score;
        }
    }
}
