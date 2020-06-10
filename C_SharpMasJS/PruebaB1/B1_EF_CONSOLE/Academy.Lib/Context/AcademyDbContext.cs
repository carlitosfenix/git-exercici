using Academy_4_DbContext.Lib.Model;
using Academy_4_DbContext.Lib.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Academy.Lib.Context
{
    public  class AcademyDbContext : DbContext
    {
         
         public DbSet <Student> ListaStudents { get; set; }
         public DbSet<Subject> ListaSubjets { get; set; }
         public DbSet<Exam> ListaExams { get; set; }

        public AcademyDbContext() : base() { }

        public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseMySql("server=localhost;database=efacademy;user=root");
        
    }
}
