using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

using System.Data.Entity;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                var student = new Student() { Name = "Corey DeRosa" };

                var mathSub = new Subject() { Name = "Math" };
                var progSub = new Subject() { Name = "Programming" };

                student.Subjects.Add(mathSub);
                student.Subjects.Add(progSub);

                db.Students.Add(student);
                db.SaveChanges();
            }
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public virtual List<Subject> Subjects { get; set; }

        public Student()
        {
            this.Subjects = new List<Subject>();
        }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public virtual Student Student{ get; set; }
    }

    class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
