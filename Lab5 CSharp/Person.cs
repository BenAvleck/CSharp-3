using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
    class Person : IDateAndCopy, IComparable, IComparer<Person>
    {
        //Поля:
        protected string name;
        protected string surname;
        protected System.DateTime birthDate;

        //Свойства:
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string SurName
        {
            get { return surname; }
            set { surname = value; }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public int BirthYear
        {
            get { return BirthDate.Year; }
            set { birthDate = new DateTime(value, BirthDate.Month, BirthDate.Day); }
        }
        public DateTime Date { get; set; }
        //Конструктори:
        public Person(string Name, string SurName, DateTime BirthDate) 
        {
            this.Name = Name;
            this.SurName = SurName;
            this.BirthDate = BirthDate;
        }
        public Person()
        {
            name = "Ann";
            surname = "Rither";
            birthDate = new DateTime(1980, 12, 01);
        }
        //Методы:
        public override string ToString()
        {
            return $"{Name} {SurName}\nBirthday: {BirthYear}\n";
        }
        public string ToShortString()
        {
            return $"Name: {Name}\nSurname: {SurName}\n";
        }
        public override bool Equals(Object obj) 
        {
            Person p = obj as Person;

            if (ReferenceEquals(p, null) == true)
                return false;
            else
            {
                return p.name == this.name && p.surname == this.surname && p.birthDate == this.birthDate;
            }
        }
        public static bool operator == (Person obj1, Person obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Person obj1, Person obj2)
        {
            return !obj1.Equals(obj2);
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public object DeepCopy()
        {
            return new Person(this.Name, this.SurName, this.BirthDate);
        }
        public int CompareTo(object obj)
        {
            return this.SurName.CompareTo((obj as Person).SurName);
        }
        public int Compare(Person x, Person y)
        {
            return x.BirthDate.CompareTo(y.BirthDate);
        }
    }
}

