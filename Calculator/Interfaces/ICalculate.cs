﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface ICalculate
    {
        double Addition(double firstNumber, double secondNumber);
        double Subtraction(double firstNumber, double secondNumber);
        double Multiplication(double firstNumber, double secondNumber);
        (double? result, string error) Division(double firstNumber, double secondNumber);
    }
}
