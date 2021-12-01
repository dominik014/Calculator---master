using Calculator.Interfaces;
using System;

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
        private const string DivideError = "You can't divide by zero";

        #endregion

        #region .Ctor

        public BasicCalculator()
        {

        }

        #endregion

        #region ICalculate

        public string Calculate(string operation, double firstNumber, double secondNumber, out bool error)
        {
            try
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
                                (double result, string error) divisionResult = Division(firstNumber, secondNumber);
                                if (divisionResult.result == 0 && !string.IsNullOrEmpty(divisionResult.error))
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
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public double Addition(double firstNumber, double secondNumber)
        {
            try
            {
                return firstNumber + secondNumber;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public double Subtraction(double firstNumber, double secondNumber)
        {
            try
            {
                return firstNumber - secondNumber;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public double Multiplication(double firstNumber, double secondNumber)
        {
            try
            {
                return firstNumber * secondNumber;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public (double result, string error) Division(double firstNumber, double secondNumber)
        {
            try
            {
                if (secondNumber == 0)
                {
                    return (0, DivideError);
                }

                return (firstNumber / secondNumber, null);
            }
            catch (Exception exception)
            {
                throw exception;
            }
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
