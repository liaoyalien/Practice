using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace MilianPlayground
{

    public delegate int SomeOperation(int i, int j);

    class Program
    {
        static int Sum(int x, int y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {
            SomeOperation add = Sum;

            int result = add(10, 10);

            Console.WriteLine(result);
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //        var source = new List<string>
    //        {
    //            "Milian",
    //            "Mmm1",
    //            "Ace"
    //        };
    //        var names = GetNames(source).ToList();

    //        foreach (var name in names)
    //            Console.WriteLine("Found v1 " + name);

    //        source.Add("Mmm2");

    //        foreach (var name in names)
    //            Console.WriteLine("Found v2 " + name);



    //        //branch 1 update a little bit 2
    //        //branch 1 update 3

    //        //GroupJoin.GroupJoinExample();

    //        //var countries = new List<Country>();
    //        //countries.Add(new Country { Name = "Taiwan"});
    //        //countries.Add(new Country { Name = "Tailand" });
    //        //countries.Add(new Country { Name = "Britain" });

    //        ////A query expression must end with either a 'group' clause or a 'select' clause.
    //        //var queryCountryGroups =
    //        //    from country in countries
    //        //    group country by country.Name[0];

    //        //foreach (var g in queryCountryGroups)
    //        //    Console.WriteLine(g.Key + " ");

    //        ////let
    //        //string[] names = { "Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia" };
    //        //IEnumerable<string> queryFirstNames =
    //        //    from name in names
    //        //    let firstName = name.Split(' ')[0]
    //        //    select firstName;

    //        //foreach (string s in queryFirstNames)
    //        //    Console.WriteLine(s + " ");
    //        ////Output: Svetlana Claire Sven Cesar

    //    }

    //    public static IEnumerable<string> GetNames(List<string> list)
    //    {
    //        var q = list.Where(x => x.StartsWith("M"));
    //        return q;
    //    }

    //    public void Foo(IEnumerable<string> values)
    //    {
    //        ThrowIfNull(values, nameof(values));
    //        var x = values.ToList(); // Possible multiple enumeration of IEnumerable
    //    }
    //    //https://www.jetbrains.com/help/resharper/Reference__Code_Annotation_Attributes.html
    //    public static void ThrowIfNull<T>([NoEnumeration] T value, string name) where T : class
    //    {
    //        // custom check for null but no enumeration
    //    }
    //}

    public class Country
    {
        public string Name { get; set; }
    }
}
