using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp 
{
    enum Action { Add, Remove, Property }

    class StudentChangedEventArgs<TKey> : EventArgs
    {
        
        
        public string CollectionName { get; set; }
        public Action WhatCall { get; set; }

        public string EventStudent { get; set; }
        public TKey KeyChanged { get; set; }
        public StudentChangedEventArgs(string CollectionName, Action WhatCall, string EventStudent, TKey KeyChanged)
        {
            this.CollectionName = CollectionName;
            this.WhatCall = WhatCall;
            this.EventStudent = EventStudent;
            this.KeyChanged = KeyChanged;
        }
        public override string ToString()
        {
            return EventStudent.ToString()+"\n" + WhatCall +"\n"+ CollectionName + "\n" + KeyChanged;
        }
    }
}
