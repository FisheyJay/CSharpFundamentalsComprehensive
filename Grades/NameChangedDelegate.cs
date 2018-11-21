using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // convention to follow for events
    // always pass sender and all of the arguments about that event
    //public delegate void NameChangedDelegate(string existingName, string newName);
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
}
