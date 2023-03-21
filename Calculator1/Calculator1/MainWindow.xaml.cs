using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Calculator1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        static double temp = 0;

        static OperationType operation;

        static string output = "";

        static double outputTemp = 0;

        static double parseOutput = 0;

        public enum OperationType
        {
            Add,
            Sub,
            Mul,
            Div
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> numberDictionary = new Dictionary<string, string>()
        {
            { "BtnOne", "1" },
            { "BtnTwo", "2" },
            { "BtnThree", "3" },
            { "BtnFour", "4" },
            { "BtnFive", "5" },
            { "BtnSix", "6" },
            { "BtnSeven", "7" },
            { "BtnEight", "8" },
            { "BtnNine", "9" },
            { "BtnZero", "0" },
            { "BtnDecimal", "," }
        };

        private Dictionary<OperationType, Action> operationDictionary = new Dictionary<OperationType, Action>()
        {
            { OperationType.Add, () => output = (temp + parseOutput).ToString() },
            { OperationType.Sub, () => output = (temp - parseOutput).ToString() },
            { OperationType.Mul, () => output = (temp * parseOutput).ToString() },
            { OperationType.Div, () => output = (temp / parseOutput).ToString() }
        };
        private void BtnChar_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;

            if ((name == ",") && (output.Contains(",")))
            {
                return;
            }
            else
            {
                var item = numberDictionary.Where(d => d.Key == name).FirstOrDefault();

                output += item.Value;

                OutputTextBlock.Text = output;
            }
        }
        private void AddOperation(OperationType type)
        {
            
            if (output != "")
            {
                temp = double.Parse(output);

                output = "";

                operation = type;
            }
        }

        private void RunOperation(OperationType type)
        {
            parseOutput = double.Parse(output);

            if (type == OperationType.Div && (temp == 0 || parseOutput == 0))
            {
                MessageBox.Show("На ноль делить нельзя");

                return;
            }
            else
            {
                var item = operationDictionary.Where(d => d.Key == type).FirstOrDefault();

                item.Value();

                OutputTextBlock.Text = output;

            }
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            RunOperation(operation);
        }

        

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            output = "";

            OutputTextBlock.Text = output;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(OperationType.Add);
        }

        private void BtnSub_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(OperationType.Sub);
        }

        private void BtnMul_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(OperationType.Mul);
        }

        private void BtnDiv_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(OperationType.Div);
        }
    }
}


 
