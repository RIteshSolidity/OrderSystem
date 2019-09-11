using System;
using Xunit;
using OrderSystem;
using OrderSystem.Model.Core;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            DateTime c = DateTime.Now;
            OrderDateType dt1 = new OrderDateType(c);
            OrderDateType dt2 = new OrderDateType(c);
            Assert.Equal(dt1, dt2);

        }
    }
}
