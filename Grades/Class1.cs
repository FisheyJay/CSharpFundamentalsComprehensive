using System;

namespace Grades
{
    // the conditional operator - string pass = age > 20 ? "pass" : "nopass";

    public class Animal
    {
        // field
        private readonly string _name;

        // we force someone to construct an animal by passing in a name
        // the constructor saves the name in a private field for the rest of the object to use
        public Animal(string name)
        {
            _name = name;
        }

        //********************************************************************************************************************
        // a property is similar to a field because it controls state and the data associated with an Object
        // properties have get and set accessors, so we can define what happens when someone reads the data or writes the data

        // get and set accessors are like methods and they can have code and logic
        // accessors are used to expose and control fields.

        // private fields have _underscore preceding identifier -  private readonly string _name;
        // 
        // public string Name - this property called Name is Pascal case
        //********************************************************************************************************************


        private string _example; // the field

        public string Example // the property
        {
            // the get accessor simply returns the readonly property
            get { return _example; }

            // the set accessor however, any time someone tries to write
            // to the value, the set accessor ensures that the value is not
            // null or empty prior to modifying it

            // setters are used for validation
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _example = value;
                }
            }

        }

        // these auto implemented accessor properties are behind the scenes
        // by default and use a hidden field
        public string Name { get; set; }
    }
}
