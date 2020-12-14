using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    class Journal
    {
        protected List<JournalEntry> journal = new List<JournalEntry>();
        
        
        public void studentsChanged(object source, StudentChangedEventArgs<string> args)
        {
            journal.Add(new JournalEntry(args));
        }
    
        public override string ToString()
        {
            string info = "";
            for (int i = 0; i < journal.Count; i++)
                info += journal[i].ToString();
            return info;
        }
    }
}
