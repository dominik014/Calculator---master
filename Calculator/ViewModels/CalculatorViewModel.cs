using Calculator.Calculators;
using Calculator.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator.ViewModels
{
    public class CalculatorViewModel :
        INotifyPropertyChanged
    {
        #region Const

        private const string Zero = "0";
        private const string Comma = ",";
        private const string Equal = "=";
        private const string Cancel = "C";
        private const string Delete = "DEL";

        #endregion

        #region Members

        private BasicCalculator basicCalculator;

        private string helperResult;
        private string inputNumber;
        private string resultNumber;
        private string actualOperation;
        private string lastOperation;
        private string lastInputNumber;

        private bool operationButtonClicked;
        private bool equalButtonClicked;
        private bool errorOperation;

        #endregion

        #region Properties
        public Command<string> NumericButtonCommand { get; set; }
        public Command<string> OperationButtonCommand { get; set; }

        public string HelperResult
        {
            get
            {
                return helperResult;
            }
            set
            {
                helperResult = value;
                OnPropertyChanged();
            }
        }

        public string InputNumber
        {
            get
            {
                return inputNumber;
            }
            set
            {
                inputNumber = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region .Ctor

        public CalculatorViewModel()
        {
            basicCalculator = new BasicCalculator();

            InputNumber = Zero;
            NumericButtonCommand = new Command<string>(NumericButtonClick);
            OperationButtonCommand = new Command<string>(OperationButtonClick);
        }

        #endregion

        #region Command

        private void NumericButtonClick(string buttonNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(buttonNumber))
                {
                    if (errorOperation)
                    {
                        errorOperation = false;
                        HelperResult = string.Empty;
                    }

                    if (InputNumber == Zero || operationButtonClicked || equalButtonClicked)
                    {
                        equalButtonClicked = false;
                        operationButtonClicked = false;
                        InputNumber = buttonNumber;
                        return;
                    }

                    InputNumber += buttonNumber;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void OperationButtonClick(string buttonOperation)
        {
            try
            {
                if (!string.IsNullOrEmpty(buttonOperation))
                {
                    InputNumber = basicCalculator.ValidateComma(InputNumber);

                    switch (buttonOperation)
                    {
                        case Equal:
                            {
                                if (!errorOperation)
                                {
                                    if (string.IsNullOrEmpty(actualOperation) && !equalButtonClicked)
                                    {
                                        HelperResult = InputNumber + Equal;
                                    }
                                    else if (string.IsNullOrEmpty(actualOperation) && equalButtonClicked)
                                    {
                                        HelperResult = resultNumber + lastOperation + lastInputNumber + Equal;
                                        InputNumber = basicCalculator?.Calculate(lastOperation, Convert.ToDouble(resultNumber), Convert.ToDouble(lastInputNumber), out errorOperation).ToString();
                                    }
                                    else
                                    {
                                        lastInputNumber = InputNumber;
                                        lastOperation = actualOperation;

                                        if (!string.IsNullOrEmpty(resultNumber) && !string.IsNullOrEmpty(InputNumber))
                                        {
                                            HelperResult = resultNumber + actualOperation + InputNumber + Equal;
                                            InputNumber = basicCalculator?.Calculate(actualOperation, Convert.ToDouble(resultNumber), Convert.ToDouble(InputNumber), out errorOperation).ToString();
                                        }
                                    }

                                    equalButtonClicked = true;
                                    actualOperation = string.Empty;
                                    resultNumber = InputNumber;
                                }
                                break;
                            }
                        case Delete:
                            {
                                if (string.IsNullOrEmpty(actualOperation) || equalButtonClicked)
                                {
                                    HelperResult = string.Empty;
                                }

                                if (errorOperation)
                                {
                                    errorOperation = false;
                                    resultNumber = string.Empty;
                                    HelperResult = string.Empty;
                                    InputNumber = Zero;
                                    return;
                                }

                                if (!string.IsNullOrEmpty(InputNumber) && InputNumber != Zero && !equalButtonClicked)
                                {
                                    if (InputNumber.Trim().Length == 1)
                                    {
                                        InputNumber = Zero;
                                        return;
                                    }

                                    InputNumber = InputNumber.Remove(InputNumber.Trim().Length - 1);
                                }
                                break;
                            }
                        case Cancel:
                            {
                                resultNumber = string.Empty;
                                HelperResult = string.Empty;
                                InputNumber = Zero;
                                break;
                            }
                        case Comma:
                            {
                                if (string.IsNullOrEmpty(InputNumber) || operationButtonClicked || equalButtonClicked)
                                {
                                    InputNumber = Zero + Comma;
                                    equalButtonClicked = false;
                                    operationButtonClicked = false;
                                }

                                if (!InputNumber.Contains(Comma))
                                {
                                    InputNumber = InputNumber + Comma;
                                }

                                break;
                            }
                        default:
                            {
                                operationButtonClicked = true;
                                actualOperation = buttonOperation;

                                if (errorOperation)
                                {
                                    errorOperation = false;
                                    resultNumber = string.Empty;
                                    HelperResult = string.Empty;
                                    InputNumber = Zero;
                                    return;
                                }

                                resultNumber = InputNumber;
                                HelperResult = InputNumber + buttonOperation;
                                break;
                            }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
