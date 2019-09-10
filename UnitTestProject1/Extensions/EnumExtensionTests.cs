using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Enums;

namespace ConsoleApp1.Extensions.Tests
{
    [TestClass()]
    public class EnumExtensionTests
    {
        [TestMethod()]
        public void GetDescriptionTest()
        {
            var des = SoStatusEnum.Approved.GetDescription();
            Assert.Fail();
        }
    }
}