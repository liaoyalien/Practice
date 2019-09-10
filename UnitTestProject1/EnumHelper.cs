using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass()]
    public class EnumHelper
    {

        public Type GetEnumType(string enumName)
        {
            var test = AppDomain.CurrentDomain;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType(enumName);
                if (type == null)
                    continue;
                if (type.IsEnum)
                    return type;
            }
            return null;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var test = this.GetEnumType("CompanyEnum");
        }
    }
    public enum CompanyEnum
    {
        [System.ComponentModel.Description("TW")]
        Tw = 1,
        [System.ComponentModel.Description("US")]
        Us = 2,
        [System.ComponentModel.Description("EU")]
        Eu = 3,
    }
}
