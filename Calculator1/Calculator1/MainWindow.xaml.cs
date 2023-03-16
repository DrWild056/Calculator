using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        public MainWindow()
        {
            InitializeComponent();

            
        }
        private void BtnChar_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;

            switch(name)
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
                    
                    if (!output.Contains("."))
                    {

                        output += ".";  
                        OutputTextBlock.Text = output;

                    }
                    
                       
                    break;
            }

        }

        

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Add";
            }
        }
       
        private void BtnSub_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Sub";
            }
        }

        private void BtnMul_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Mul";
            }
        }

        private void BtnDiv_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Div";
            }
        }

                private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            double outputTemp;

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
