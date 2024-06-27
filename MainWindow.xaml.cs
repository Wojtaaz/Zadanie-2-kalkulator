using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfCalculator
{
    public partial class MainWindow : Window
    {
        private string input = string.Empty;
        private string operand1 = string.Empty;
        private string operand2 = string.Empty;
        private char operation;
        private double result = 0.0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string buttonText = button.Content.ToString();

            if (buttonText == "C")
            {
                this.Clear();
                return;
            }
            else if (buttonText == "=")
            {
                this.Calculate();
                ResultTextBox.Text = result.ToString();
                input = result.ToString();
                operand1 = string.Empty;
                operand2 = string.Empty;
                return;
            }
            else if (buttonText == "+" || buttonText == "-" || buttonText == "*" || buttonText == "/")
            {
                operand1 = input;
                operation = Convert.ToChar(buttonText);
                input = string.Empty;
                return;
            }

            input += buttonText;
            ResultTextBox.Text = input;
        }

        private void Clear()
        {
            input = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;
            ResultTextBox.Text = "0";
        }

        private void Calculate()
        {
            operand2 = input;

            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                    {
                        MessageBox.Show("Dzielenie przez zero!");
                    }
                    break;
            }
        }
    }
}
