using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        List<Student> Students;
        public int Capacity { get; }
        public int Count => Students.Count;

        public Classroom(int capacity)
        {
            Students = new List<Student>();
            Capacity = capacity;
        }

        public string RegisterStudent(Student student)
        {
            if (Students.Count < Capacity)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }

        }
        public string DismissStudent(string firstName, string lastName)
        {
            var studentToDismiss = Students.Exists(s => s.FirstName == firstName && s.LastName == lastName);

            if (studentToDismiss)
            {
                Students.Remove(Students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName));
                return $"Dismissed student {firstName} {lastName}";
            }

            else
            {
                return "Student not found";
            }
        }
        public string GetSubjectInfo(string subject)
        {
            var studentsOfSubject = Students.Where(s => s.Subject == subject).ToList();

            StringBuilder sb = new StringBuilder();

            if (studentsOfSubject.Count() != 0)
            {
                sb.Append($"Subject: {subject}");
                sb.AppendLine();
                sb.Append($"Students:");
                sb.AppendLine();

                foreach (var student in studentsOfSubject)
                {
                    sb.Append($"{student.FirstName} {student.LastName}");
                    sb.AppendLine();
                }
            }

            else
            {
                return "No students enrolled for the subject";
            }

            return sb.ToString().TrimEnd();
        }
        public int GetStudentsCount() => Count;      
        public Student GetStudent(string firstName, string lastName)
            => Students.Where(s => s.FirstName == firstName && s.LastName == lastName).FirstOrDefault();

         
    }
}
