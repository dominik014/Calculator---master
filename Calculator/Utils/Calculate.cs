using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Utils
{
    public class Calculate
    {
        #region Additional

        public static double Additional(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        #endregion

        #region Subtraction

        public static double Subtraction(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        #endregion

        #region Multiplication

        public static double Multiplication(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        #endregion

        #region Division

        public static double Division(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }

        #endregion
    }
}
