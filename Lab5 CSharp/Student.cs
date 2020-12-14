using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Lab5_CSharp
{
    enum Education { Specialist, Bachelor, SecondEducation }
    class Student : Person , INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        //Поля:
        //private Person getperson;
        private Education education;
        private int groupnumber;
        private System.Collections.Generic.List<Test> testdone = new List<Test>();
        private System.Collections.Generic.List<Exam> list = new List<Exam>();
        //Свойства:
        public Person GetPerson
        {
            get { return new Person(this.Name, this.SurName, this.BirthDate); }
            set { this.Name = value.Name; this.SurName = value.SurName; this.BirthDate = value.BirthDate; }
        }
        public Education Education
        {
            get { return education; }
            set { education = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Education edited"));
            }
        }
        public int GroupNumber
        {
            get => groupnumber;
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Похоже вашей группы не существует");
                }
                else
                {
                    groupnumber = value;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Group number edited"));
            }
        }
        public List<Exam> List
        {
            get { return list; }
            set { list = value; }
        }
        public System.Collections.Generic.List<Test> TestDone
        {
            get { return testdone; }
            set { testdone = value; }
        }
        //Конструкторы:
        public Student(string Name, string SurName, DateTime BirthDate, Education Education, int _GroupNumber) : base(Name, SurName, BirthDate)
        {
            Education = new Education();
            GroupNumber = _GroupNumber;
        }
        public Student()
        {
            GetPerson = new Person("Ada", "Vong", new DateTime(1977, 8, 15));
            Education = Education.Bachelor;
            GroupNumber = 2;
        }
        //Методы:
        public double AverageMark
        {
            get
            {
                if (List.Count == 0)
                    return 0;

                double sum = 0;
                for (int i = 0; i < List.Count; i++)
                    sum += List[i].Mark;
                return sum / List.Count;
            }
        }
        public void AddExams(params Exam[] list)
        {
            this.List.AddRange(list);
        }
        public void AddTestDone(params Test[] testdone)
        {
            this.testdone.AddRange(testdone);
        }
        public override string ToString()
        {
            string k = $"Student:   {GetPerson}\n:Education:   {Education}\nGroup number:   {GroupNumber}\n\n";
            k += $"Exams list:_________\n";
            foreach (var examlist in List)
                k += examlist.SubjectName + "\n";
            k += $"Tests list:___________\n";
            foreach (var examdone in TestDone)
                k += examdone.SubjectName + "\n";

            return k;
        }
        public new virtual string ToShortString => $"Student:   {GetPerson}\nEducation:   {Education}\nGroup number:   {GroupNumber}\n\nAverage mark:   {AverageMark}\n";
        //public new object DeepCopy()
        //{
        //    return new Student(this.GetPerson, this.Education, this.GroupNumber);
        //}
        public IEnumerable<object> ZachetsAndExams()
        {
            foreach (var v in List) { yield return v; }
            foreach (var v in TestDone) { yield return v; }
        }
        public IEnumerable<Exam> ExamsWithGradeBiggerThen(int biggerthenvalue)
        {
            foreach (var v in List)
            {
                if (v.Mark > biggerthenvalue)
                    yield return v;
            }
        }
        internal class StudentComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return x.AverageMark.CompareTo(y.AverageMark);
            }
        }
    }
}
