using System;

namespace Inheritance
{
    /// <summary>
    /// 了解使用 Override 和 New 關鍵字的時機
    /// https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new BaseClass();
            DerivedClass dc = new DerivedClass();
            BaseClass bcdc = new DerivedClass();

            bc.Method1();
            bc.Method2();
            bc.Method3();
            dc.Method1();
            dc.Method2();
            bcdc.Method1();
            bcdc.Method2();
            bcdc.Method3();
        }
    }
    class BaseClass
    {
        public void Method1()
        {
            Console.WriteLine("Base - Method1");
        }

        public void Method2()
        {
            Console.WriteLine("Base - Method2");
        }

        public virtual void Method3()
        {
            Console.WriteLine("Base - Method3");
        }
    }
    class DerivedClass : BaseClass
    {
        public new void Method2()
        {
            Console.WriteLine("Derived - Method2");
        }

        public override void Method3()
        {
            Console.WriteLine("Derived - Method3");
        }
    }
}
