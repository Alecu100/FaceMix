using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceMix.Base
{
    public class ModifierAttribute : Attribute
    {
        private string name;

        public string Name { get { return this.name; } set { this.name = value; } }

        public ModifierAttribute()
        {
            this.name = "";
        }

        public ModifierAttribute(string name)
        {
            this.name = name;
        }
    }
}
