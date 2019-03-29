using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //branch 1 update a little bit

            GroupJoin.GroupJoinExample();

            var countries = new List<Country>();
            countries.Add(new Country { Name = "Taiwan"});
            countries.Add(new Country { Name = "Tailand" });
            countries.Add(new Country { Name = "Britain" });

            //A query expression must end with either a 'group' clause or a 'select' clause.
            var queryCountryGroups =
                from country in countries
                group country by country.Name[0];

            foreach (var g in queryCountryGroups)
                Console.WriteLine(g.Key + " ");

            //let
            string[] names = { "Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia" };
            IEnumerable<string> queryFirstNames =
                from name in names
                let firstName = name.Split(' ')[0]
                select firstName;

            foreach (string s in queryFirstNames)
                Console.WriteLine(s + " ");
            //Output: Svetlana Claire Sven Cesar
        
        }
    }

    public class Country
    {
        public string Name { get; set; }
    }
}
