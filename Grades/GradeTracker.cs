using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : Object, IGradeTracker // Object is implicit asnd doesn't need to be there
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        public string Name
        {
            get { return _name; }

            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                // this is the only place we know that the GradeBook name is changing
                // we could broadcast a message about this if someone needs to know
                // THIS IS THE PERFECT PLACE FOR A DELEGATE
                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    if (NameChanged != null) NameChanged(this, args);
                    _name = value;
                }
            }
        }

        // class field - encapsulate by making private then can't see in Main() -
        // private by default, don't need to specify private access modifier

        public event NameChangedDelegate NameChanged;

        protected string _name;

    }
}
