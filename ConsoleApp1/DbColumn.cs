using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DbColumn: Attribute
    {
        internal DbColumn(string description)
        {
            this.DbValue = description;
            this.Description = description;
        }

        public string DbValue { get; private set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
