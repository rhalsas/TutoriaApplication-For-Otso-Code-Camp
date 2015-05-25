using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace TutorialApplication
{
    class DataObject
    {

        public DataObject(string setName,string setLastName)
        {
            this.Name = setName;
            this.LastName = setLastName;
        }
        public void GetName()
        {

            Debug.WriteLine(this.Name + " Also lastname: " + this.LastName);

        }

        private String Name;
        private String LastName;


    }
}
