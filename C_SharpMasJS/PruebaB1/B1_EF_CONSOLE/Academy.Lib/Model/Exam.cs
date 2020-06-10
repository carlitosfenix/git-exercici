using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_4_DbContext.Lib.Model
{
    public class Exam :Entity
    {
        private Guid _studentGuid;
        private Guid _subjectGuid;
        private DateTime _dateTimeExam;
        private double _score;

        public Guid StudentGuid { get => _studentGuid; set => _studentGuid = value; }
        public Guid SubjectGuid { get => _subjectGuid; set => _subjectGuid = value; }
        public DateTime DateTimeExam { get => _dateTimeExam; set => _dateTimeExam = value; }
        public double Score { get => _score; set => _score = value; }

        public Exam(Guid studentGuid, Guid subjectGuid, DateTime dateTimeExam, double score)
        {
            StudentGuid = studentGuid;
            SubjectGuid = subjectGuid;
            DateTimeExam = dateTimeExam;
            Score = score;
        }

        public static double ValidarNota(string score)
        {
            Double.TryParse(score, out double nota);
            if(nota >=0 && nota <= 10)
            {
                return nota;
            }
            return -1;
        }
    }
}
