﻿using Calculator.Interfaces;

namespace Calculator.Calculators
{
    public class BasicCalculator :
        ICalculate
    {
        #region Const

        private const string AdditionSymbol = "+";
        private const string SubtractionSymbol = "-";
        private const string MultiplicationSymbol = "*";
        private const string DivisionSymbol = "/";
        private const string Comma = ",";

        #endregion

        #region .Ctor

        public BasicCalculator()
        {

        }

        #endregion

        #region ICalculate

        public double Addition(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public double Subtraction(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }

        public double Multiplication(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        public (double? result, string error) Division(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
            {
                return (null, "You can't divide by zero");
            }

            return (firstNumber - secondNumber, null);
        }

        #endregion

        #region Methods

        public string Calculate(string operation, double firstNumber, double secondNumber, out bool error)
        {
            if (!string.IsNullOrEmpty(operation))
            {
                error = false;
                switch (operation)
                {
                    case AdditionSymbol:
                    {
                        return Addition(firstNumber, secondNumber).ToString();
                    }
                    case SubtractionSymbol:
                    {
                        return Subtraction(firstNumber, secondNumber).ToString();
                    }
                    case MultiplicationSymbol:
                    {
                        return Multiplication(firstNumber, secondNumber).ToString();
                    }
                    case DivisionSymbol:
                    {
                        (double? result, string error) divisionResult = Division(firstNumber, secondNumber);
                        if (divisionResult.result == null && !string.IsNullOrEmpty(divisionResult.error))
                        {
                            error = true;
                            return divisionResult.error;
                        }

                        return divisionResult.result.ToString();
                    }
                }
            }

            error = true;
            return string.Empty;
        }

        public string ValidateComma(string number)
        {
            if (!string.IsNullOrEmpty(number))
            {
                if (number.EndsWith(Comma))
                {
                    return number.Remove(number.Length - 1);
                }

                return number;
            }

            return string.Empty;
        }

        #endregion
    }
}