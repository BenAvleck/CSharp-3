using Lab5_CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_PPSE
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            st.AddExams(new Exam());

            Console.WriteLine("\n---------------------------------\n");

            Student copySyudent = st.DeepCopy();

            Console.WriteLine("Initial student:");
            Console.WriteLine(st);

            Console.WriteLine("Copied student:");
            Console.WriteLine(copySyudent);

            Console.WriteLine("\n---------------------------------\n");

            Console.Write("Enter filename for initialize student: ");
            string filename = Console.ReadLine();

            Console.WriteLine(st.Load(filename) ? "Object successfully loaded from file\n" : "Failed to load object\n");
            Console.WriteLine(st);

            Console.WriteLine("\n---------------------------------\n");

            Console.WriteLine(st.AddFromConsole() ? "Diploma successfully added\n" : "Failed to add exam\n");

            Console.Write("Enter filename to save student: ");
            filename = Console.ReadLine();

            Console.WriteLine(st.Save(filename) ? "Object successfully saved to file\n" : "Failed to save object\n");

            Console.WriteLine("\n---------------------------------\n");

            Console.WriteLine(st.Load(filename) ? "Object successfully loaded from file\n" : "Failed to load object\n");

            Console.WriteLine(st.AddFromConsole() ? "Exam successfully added\n" : "Failed to add exam\n");

            Console.WriteLine(st.Save(filename) ? "Object successfully saved to file\n" : "Failed to save object\n");
            Console.WriteLine(st);

            Console.WriteLine("\n---------------------------------\n");

            Console.ReadKey();
        }
    }
}
