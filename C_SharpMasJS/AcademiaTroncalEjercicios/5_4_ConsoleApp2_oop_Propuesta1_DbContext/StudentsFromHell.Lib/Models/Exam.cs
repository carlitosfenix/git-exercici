using System;

namespace StudentsFromHell.Lib.Models
{
    public class Exam
    {
        public DateTime DateStamp { get; set; }

        public Subject Subject { get; set; }

        public Student student { get; set; }
    }
}
