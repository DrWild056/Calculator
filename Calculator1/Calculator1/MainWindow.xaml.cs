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
        double temp = 0;

        string operation = "";

        string output = "";

        double outputTemp = 0;

        string parseOutput = "";

        
        public MainWindow()
        {
            InitializeComponent();

        }

        public enum OperationType
        {
            Add,
            Sub,
            Mul,
            Div
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

            if ((name = ",") && (name = output.Contains(",")))
            {
                return;
            }
            else
            {
                var item = numberDictionary.Where(d => d.Key == name).FirstOrDefault();

                output += item.Value;

                OutputTextBlock.Text = output;
            }





            switch (name)
            {
                case "BtnOne":

                    output += "1";

                    OutputTextBlock.Text = output;

                    break;

                case "BtnTwo":

                    output += "2";

                    OutputTextBlock.Text = output;

                    break;

                case "BtnThree":
                    output += "3";

                    OutputTextBlock.Text = output;

                    break;

                case "BtnFour":
                    output += "4";

                    OutputTextBlock.Text = output;

                    break;

                case "BtnFive":

                    output += "5";

                    OutputTextBlock.Text = output;

                    break;

                case "BtnSix":

                    output += "6";

                    OutputTextBlock.Text = output;

                    break;

                case "BtnSeven":

                    output += "7";

                    OutputTextBlock.Text = output;

                    break;

                case "BtnEight":

                    output += "8";

                    OutputTextBlock.Text = output;

                    break;

                case "BtnNine":

                    output += "9";

                    OutputTextBlock.Text = output;

                    break;

                case "BtnZero":

                    output += "0";

                    OutputTextBlock.Text = output;

                    break;

                case "BtnDecimal":

                    if (!output.Contains(","))
                    {

                        output += ",";

                        OutputTextBlock.Text = output;

                    }

                    break;
            }

        }

        private void AddOperation(OperationType type)
        {
            if (output != "")
            {
                temp = double.Parse(output);

                output = "";

                operation = "";
            }
        }
        private void RunOperation(OperationType type)
        {
            if (type == OperationType.Div && outputTemp == 0)
            {
                return;
            }
            else
            {
                var item = numberDictionary.Where(d => d.Key = type).FirstOrDefault();

                item.Value();

                OutputTextBlock.Text = output;


            }
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            RunOperation(operation);

            switch (operation)

            {


                case "Add":
                    outputTemp = temp + double.Parse(output);

                    output = outputTemp.ToString();

                    OutputTextBlock.Text = output;

                    break;

                case "Sub":
                    outputTemp = temp - double.Parse(output);

                    output = outputTemp.ToString();

                    OutputTextBlock.Text = output;

                    break;

                case "Mul":
                    outputTemp = temp * double.Parse(output);

                    output = outputTemp.ToString();

                    OutputTextBlock.Text = output;

                    break;

                case "Div":
                    if (double.Parse(output) != 0)
                    {
                        outputTemp = temp / double.Parse(output);

                        output = outputTemp.ToString();

                        OutputTextBlock.Text = output;
                    }

                    break;

            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            output = "";

            OutputTextBlock.Text = output;

        }

    }
}


 
