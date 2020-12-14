using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab5_CSharp
{
    delegate TKey KeySelector<TKey>(Student st);

    class StudentCollections<TKey>
    {

        public void PropertyChanged(object obj, PropertyChangedEventArgs e)
        {
            StudentsChanged?.Invoke(obj, new StudentChangedEventArgs<TKey>(collectionName, Action.Property, e.PropertyName, GetKey(obj as Student)));
        }

        public delegate void StudentsChangedHendler<TKey>(object source, StudentChangedEventArgs<TKey> args);

        public event StudentsChangedHendler<TKey> StudentsChanged;

        public string collectionName { get; set; }

        private Dictionary<TKey, Student> studentsDictionary = new Dictionary<TKey, Student>(0);

        private KeySelector<TKey> GetKey;
        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education value) {
            IEnumerable<KeyValuePair<TKey, Student>> sequence = studentsDictionary.Where(p => p.Equals(value));
            return sequence;
        }

        public double MaxAverageMark
        {
            get {
                double maxValue = 0;
                foreach (var value in studentsDictionary.Values)
                    if (maxValue < value.AverageMark) maxValue = value.AverageMark;
                return maxValue;
            }
        }
        public Dictionary<TKey, Student> StudentsDictionary
        {
            get { return studentsDictionary; }
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupBy
        {
            get
            {
                var studentsGroups = from student in studentsDictionary
                                     group student by student.Value.Education;
                return studentsGroups;
            }
        }
        public StudentCollections(KeySelector<TKey> _delegaate)
        {
            GetKey = _delegaate;   
        }
        public bool Remove(Student st)
        {
            if (studentsDictionary[GetKey(st)] == null)
                return false;
            else
            {
                st.PropertyChanged -= PropertyChanged;
                studentsDictionary.Remove(GetKey(st));
                StudentsChanged(st, new StudentChangedEventArgs<TKey>(this.collectionName, Action.Remove, st.ToString(), GetKey(st)));
                return true;
            }
        }
        public void AddDefaults()
        {
            const int AMOUNT = 3; 
            for (int i = 0; i < AMOUNT; ++i)
            {
                Student st = new Student();
                studentsDictionary.Add(GetKey(st), st);
                if (StudentsChanged != null)
                    StudentsChanged(new Student(), new StudentChangedEventArgs<TKey>(this.collectionName, Action.Add,new Student().ToString(), GetKey(new Student())));
            }
        }
        public void AddStudents(params Student[] students)
        {
            for (int i = 0; i < students.Length; ++i)
            {
                studentsDictionary.Add(GetKey(students[i]), students[i]);
                if (StudentsChanged != null)
                    StudentsChanged(students[i], new StudentChangedEventArgs<TKey>(this.collectionName, Action.Add, students[i].ToString(), GetKey(students[i])));
                students[i].PropertyChanged += PropertyChanged;
            }
        }
        public override string ToString()
        {
            string info = "Students List:\n";
            foreach (var students in studentsDictionary.Values)
                info += students.ToString();
            return info;
        }
        public string ToShortString()
        {
            string info = " ";
            foreach (var students in studentsDictionary.Values)
                info += "\n" + students.ToShortString() +
                    "Список экзаменов: " + students.List + "\n" +
                    "Список зачетов: " + students.TestDone + "\n";

            return info;
        }
    }
}
