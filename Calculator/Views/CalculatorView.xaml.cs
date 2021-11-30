using Calculator.ViewModels;
using System.Windows;

namespace Calculator.Views
{
    public partial class CalculatorView : Window
    {
        #region Members

        private CalculatorViewModel viewModel;

        #endregion

        #region .Ctor

        public CalculatorView()
        {
            InitializeComponent();
            viewModel = new CalculatorViewModel();
            DataContext = viewModel;
        }

        #endregion
    }
}
