using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    class JournalEntry
    {




        public string CollectionName { get; set; }
        public Action WhatCall { get; set; }

        public string EventStudent { get; set; }
        public string KeyChanged { get; set; }
        public JournalEntry(StudentChangedEventArgs<string> item)
        {
            this.CollectionName = item.CollectionName;
            this.WhatCall = item.WhatCall;
            this.EventStudent = item.EventStudent;
            this.KeyChanged = item.KeyChanged.ToString();
        }
        public override string ToString()
        {
            return EventStudent.ToString() + "\n" + WhatCall + "\n" + CollectionName + "\n" + KeyChanged;
        }

    }
}
