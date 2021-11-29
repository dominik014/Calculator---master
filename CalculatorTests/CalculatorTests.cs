using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [DataTestMethod]
        [DataRow(4, 4, 1)]
        [DataRow(4, 3, 1)]
        public void DivisionIncorrectTestMethod(double x, double y, double answer)
        {
            double actual = Calculator.Utils.Calculate.Division(x, y);
            Assert.AreEqual(answer, actual);
        }

        [TestMethod]
        public void DivisionCorrectTestMethod()
        {
            double actual = Calculator.Utils.Calculate.Division(1, 3);
            Assert.AreNotEqual(null, actual);
        }
    }
}
