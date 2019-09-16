using System;
using System.Linq;

namespace StringMask
{
    class Program
    {
        static void Main(string[] args)
        {
            var origin = "廖小米";
            var masked = origin.ToMask('*');
        }

    
    }
}
