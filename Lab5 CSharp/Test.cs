using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{

        class Test
        {
            //Авто свойства
            public string SubjectName { get; set; }
            public bool TestDone { get; set; }

            //Конструкторы
            public Test(string SubjectName, bool ExamDate)
            {
                this.SubjectName = SubjectName;
                this.TestDone = TestDone;
            }
            public Test()
            {
                this.SubjectName = "Програмирование";
                this.TestDone = true;
            }
            public override bool Equals(object obj)
            {
                if (obj != null && obj.ToString() == this.ToString())
                    return true;
                else
                    return false;
            }
            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }

            //Переопределенный метод ToString()
            public override string ToString()
            {
                return $"Предмет: {SubjectName}\nЗачет/неЗачет: {TestDone}\n";
            }
        }

}
