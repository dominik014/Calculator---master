using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using Calculator.Interfaces;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        ICalculate calcualte;

        [TestInitialize]
        public void Init()
        {
            calcualte = new Calculator.Calculators.BasicCalculator();
        }

        [DataTestMethod]
        [DataRow(4, 4, 8)]
        [DataRow(1, 3, 4)]
        [DataRow(-1, 3, 2)]
        [DataRow(1.75, 3, 4.75)]
        public void Addition(double x, double y, double expected)
        {
            double original = calcualte.Addition(x, y);
            Assert.AreEqual(original, expected);
        }

        [DataTestMethod]
        [DataRow(4, 4, 0)]
        [DataRow(1, 3, -2)]
        [DataRow(1, -3, 4)]
        [DataRow(-1, -3, 2)]
        [DataRow(5.25, 0.25, 5)]
        public void Subtraction(double x, double y, double expected)
        {
            double original = calcualte.Subtraction(x, y);
            Assert.AreEqual(original, expected);
        }

        [DataTestMethod]
        [DataRow(4, 4, 16)]
        [DataRow(100, 0, 0)]
        [DataRow(0, -3, 0)]
        [DataRow(-1, -3, 3)]
        public void Multiplication(double x, double y, double expected)
        {
            double original = calcualte.Multiplication(x, y);
            Assert.AreEqual(original, expected);
        }

        [DataTestMethod]
        [DataRow(4, 4, 1, (string)null)]
        [DataRow(100, 0, 0, "You can't divide by zero")]
        [DataRow(0, 2, 0, (string)null)]
        [DataRow(10, 20, 0.5, (string)null)]
        [DataRow(10, -20, -0.5, (string)null)]
        public void Division(double x, double y, double expectedResult, string expectedError)
        {
            (double? result, string error) expected = (expectedResult, expectedError);
            (double? result, string error) original = calcualte.Division(x, y);

            Assert.AreEqual(original, expected);
        }
    }
}
