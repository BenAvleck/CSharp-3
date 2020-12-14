using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{

        class Exam : IDateAndCopy
        {
            //Автоматические свойства + значения по умолчанию:
            public string SubjectName { get; set; }
            public int Mark { get; set; }
            public System.DateTime ExamDate { get; set; }
            public DateTime Date { get; set; }
            //Конструкторы:
            public Exam(string SubjectName, int Mark, DateTime ExamDate)
            {
                this.SubjectName = SubjectName;
                this.Mark = Mark;
                this.ExamDate = ExamDate;
            }
            public Exam()
            {
                this.SubjectName = "Програмирование";
                this.Mark = 10;
                this.ExamDate = new DateTime(2020, 9, 13);
            }
            //Переопределенная(Override) версия виртуального метода string ToString():
            public override string ToString()
            {
                return $"Предмет: {SubjectName}\nОценка: {Mark}\nДата провидения: {ExamDate.ToShortDateString()}\n";
            }
            public object DeepCopy()
            {
                return new Exam(this.SubjectName, this.Mark, this.ExamDate);
            }
        }
}
