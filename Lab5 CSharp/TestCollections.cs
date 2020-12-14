using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    class TestCollections
    {
        private List<Person> students = new List<Person>();
        private List<string> str = new List<string>();
        private Dictionary<Person, Student> studentsDictionary = new Dictionary<Person, Student>();
        private Dictionary<string, Student> strDictionary = new Dictionary<string, Student>();

        public static Student GenerateResStudents(int a)
        {
            Student stud = new Student();
            stud.SurName = stud.SurName + a.ToString();
            return stud;
        }
        public TestCollections(int amount)
        {
            for (int i = 0; i <= amount; i++)
            {
                Student stud = GenerateResStudents(i);
                students.Add(stud.GetPerson);
                str.Add(stud.ToString());
                studentsDictionary.Add(students[i], stud);
                strDictionary.Add(str[i], stud);
            }
        }

        public long TimeCounterStudents(Student stud)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            students.Contains(stud.GetPerson);

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
        public long TimeCounterStr(Student stud)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            str.Contains(stud.ToString());

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
        public long TimeCounterTmDictionary(Student stud)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            studentsDictionary.ContainsValue(stud);

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
        public long TimeCounterStrDictionary(Student stud)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            strDictionary.ContainsKey(stud.ToString());


            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
    }
}
