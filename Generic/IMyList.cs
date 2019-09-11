using System;
using System.Collections.Generic;
using System.Text;

namespace Generic
{
    public interface IMyList<T>
    {
        int Count { get; }
        T this[int index] { get; set; }
    }
}
