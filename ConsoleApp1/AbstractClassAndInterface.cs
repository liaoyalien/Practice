using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilianPlayground
{
    class AbstractClassAndInterface
    {
    }

    interface SampleInterFace
    {
        void testMethod();

        //下面反註解掉會編譯錯誤,介面的method被實做必定得是public屬性,但本身不能宣告屬性
        //public void testMethod2();

        //下面反註解掉會編譯錯誤,介面裡頭不能宣告fields也稱為property
        //int test;

        //下面反註解掉會編譯錯誤,介面裡頭不能有任何真正實做
        //void testMethod3() { }
    }

    class test1 : SampleInterFace
    {
        //若沒這下面實作,會編譯報錯
        public void testMethod()
        {
            throw new NotImplementedException();
        }
    }


    //抽像
    abstract class Sampleabstract
    {
        abstract public void testMethod();

        //下面反註解掉會編譯錯誤,抽像類別中無實作的method一定得加上abstract關鍵字
        //public void testMethod2();

        //抽像類別中可以實作method
        public void testMetod2()
        {
            Console.WriteLine("hello");
        }

        //抽像類別中可以定義fields
        int test = 0;
    }


    class test2 : Sampleabstract
    {
        //有abstract關鍵字的methed "一定需要用" override實作
        public override void testMethod()
        {
            throw new NotImplementedException();
        }
    }


    class Sampleclass
    {
        virtual public void testMethod()
        {
            Console.WriteLine("hello");
        }

        //下面反註解掉會編譯錯誤,virtual必定需要為public屬性
        //virtual void testMethod() { }

        //下面反註解掉會編譯錯誤,virtual必定需要實作
        //virtual public void testMethod();
    }

    class test3 : Sampleclass
    {
        //有virtual關鍵字的methed "可以用"  override實作
        public override void testMethod()
        {
            throw new NotImplementedException();
        }
    }

}



    
