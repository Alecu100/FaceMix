using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace FaceMix.Base
{
    public abstract class AbstractModifier
    {
        private static List<Assembly> loadedAssemblies = new List<Assembly>();

        public static List<Assembly> LoadedAssemblies { get { return AbstractModifier.loadedAssemblies; } }

        public delegate void Ready(object sender, EventArgs e);

        public abstract event Ready WhenReady;

        public static AbstractModifier MakeModifier(string name)
        {
            bool found = false;
            Type ftype = typeof(Object);
            AbstractModifier ret = null;

            foreach (Assembly asm in AbstractModifier.loadedAssemblies)
            {
                foreach (Type item in asm.GetTypes())
                {
                    object[] at = item.GetCustomAttributes(typeof(ModifierAttribute), false);
                    string n = item.Name;
                    if (at.Length > 0 && ((ModifierAttribute)at[0]).Name == name)
                    {
                        found = true;
                        ftype = item;
                        break;
                    }
                }
                if (found == true)
                    break;
            }

            if (found == true)
            {
                ConstructorInfo info = ftype.GetConstructor(new Type[0]);
                ret = info.Invoke(new Type[0]) as AbstractModifier;
            }
            return ret;
        }

        public static string[] GetModifierNames()
        {
            Type ftype = typeof(Object);
            List<string> ret = new List<string>();

            foreach (Assembly asm in AbstractModifier.loadedAssemblies)
            {
                foreach (Type item in asm.GetTypes())
                {
                    object[] at = item.GetCustomAttributes(typeof(ModifierAttribute), false);
                    string n = item.Name;
                    if (at.Length > 0)
                    {
                        ret.Add(((ModifierAttribute)at[0]).Name);
                    }
                }
            }
            return ret.ToArray();
        }

        public abstract string Name { get; }

        public abstract HeadFile Apply();

        public abstract HeadFile Apply(HeadFile target);

        public abstract UserControl Menu { get; }

        public abstract ListViewItem ToListViewItem(int index);

        public abstract HeadFile Target { get; set; }

        public abstract bool Applied { get; }

        public abstract string Properties { get; }
    }
}
