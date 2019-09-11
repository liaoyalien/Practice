using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Generic
{
    public class MyGenericList<T>: IMyList<T>
    {
        //private List<T> _elements = new List<T>();

        private T[] _elements = new T[100];

        public int Count => _elements.Length;

        //indexer 讓class /struc 可以用array的[]的方式存取裡面的集合成員
        //https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/indexers/
        //https://dotblogs.com.tw/lazycodestyle/2016/05/29/161746
        public T this[int index]
        {
            get
            {
                Console.Write(index);
               return _elements[index]; 
                
            }
            set => _elements[index] = value;
        }
    }
}
