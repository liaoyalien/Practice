using System;
using System.Collections;
using System.Collections.Generic;

namespace Convariance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Covariance();
            Contravariance();

        }

        static void Covariance()
        {
            //co-variance 把字串陣列 assign 給物件陣列 (隱含轉型)
            //雖然可以通過編譯，但執行時會exception, ArrayTypeMismatchException
            string[] strings = new string[3];
            object[] objects = strings;
            //exception
            //objects[0] = DateTime.Now; 
            //string s = (string)objects[0];

            /* 泛型本身具有 in-variance 特性
            不可以像陣列那樣隱含轉型*/
            List<string> stringList = new List<string>();        
            //List<object> objectList = stringList;    
            //IEnmurable的原型宣告 public interface IEnumerable<out T> : IEnumerable, out 表示只能做於方法傳回值不能當傳入參數 
            IEnumerable<object> objectList2 = stringList;  
            
            /*IEnumerable的操作是唯讀的無法替換或增刪元素
             * 因此不擔心有執行時期的exception
             */
        }

        static void Contravariance()
        {
            List<Apple> apples = new List<Apple>();
            apples.Add(new Apple() { SweetDegree = 54 });
            apples.Add(new Apple() { SweetDegree = 60 });
            apples.Add(new Apple() { SweetDegree = 35 });

            IComparer<Fruit> cmp = new FruitComparer();
            apples.Sort(cmp);

            foreach (var fruit in apples)
            {
                Console.WriteLine(fruit.SweetDegree);
            }

        }
    }
    public class Apple : Fruit
    {
    }

    public class Fruit
    {
        public int SweetDegree { get; set; }
    }

    public class FruitComparer : IComparer<Fruit>
    {
        public int Compare(Fruit x, Fruit y)
        {
            return x.SweetDegree - y.SweetDegree;
        }

    }

}
