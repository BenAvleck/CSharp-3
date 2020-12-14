using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    class Program
    {
        public static string KeyGen(Student st){
            return st.Name;
        }
        static void Main(string[] args)
        {

            StudentCollections<string> collection1 = new StudentCollections<string>(KeyGen);
            collection1.collectionName = "collectuon1";
            StudentCollections<string> collection2 = new StudentCollections<string>(KeyGen);
            collection2.collectionName = "collectuon2";
            Journal journal = new Journal();

            collection1.StudentsChanged += journal.studentsChanged;
            collection2.StudentsChanged += journal.studentsChanged;

            Student st1 = new Student("Ben", "Avleck", new DateTime(2002, 02, 08), Education.Bachelor, 2);
            Student st2 = new Student("Thomas", "Norton", new DateTime(1999, 01,03), Education.SecondEducation, 1);
            Student st3 = new Student("Christopher", "Whitehead", new DateTime(2000,11,23), Education.Specialist, 3);
            Student st4 = new Student("Giles", "Parrish", new DateTime(2001, 03, 01), Education.Bachelor, 4);
            Student st5 = new Student("Den", "A", new DateTime(2002, 02, 08), Education.Bachelor, 2);
            Student st6 = new Student("T", "N", new DateTime(1999, 01, 03), Education.SecondEducation, 1);
            Student st7 = new Student("Name1", "Surname1", new DateTime(2000, 11, 23), Education.Specialist, 3);
            Student st8 = new Student("Surname2", "Surname2", new DateTime(2001, 03, 01), Education.Bachelor, 4);


            collection1.AddStudents(st1, st2, st3, st4);
            collection2.AddStudents(st5, st6, st7, st8);

            st4.Name = "Theodore";
            st8.GroupNumber = 3;

            collection1.Remove(st1);
            collection2.Remove(st5);

            collection1.StudentsDictionary[KeyGen(st1)].SurName = "Walton";
            collection1.StudentsDictionary[KeyGen(st4)].BirthYear = 2002;

            Console.WriteLine(journal.ToString());

            Console.WriteLine(collection1.MaxAverageMark);
            Console.WriteLine(collection2.MaxAverageMark);
            Console.WriteLine(collection1.EducationForm(Education.Specialist));
            Console.WriteLine(collection2.EducationForm(Education.Bachelor));
            Console.WriteLine(collection1.GroupBy);
            Console.WriteLine(collection2.GroupBy);
            Console.ReadKey();

        }

    }
}
