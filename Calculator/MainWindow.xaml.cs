using System;
using System.Windows;
using Calculator.Calculations;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void _7_OnClick(object sender, RoutedEventArgs e)
        {
            Input.Text += "7";
        }

        private void _8_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "*";//throw new System.NotImplementedException();
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Nine_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "9";//throw new System.NotImplementedException();
        }

        private void Five_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "5";//throw new System.NotImplementedException();
        }

        private void Six_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "6";//throw new System.NotImplementedException();
        }

        private void Four_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "4";//throw new System.NotImplementedException();
        }

        private void One_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "1";//throw new System.NotImplementedException();
        }

        private void Two_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "2";//throw new System.NotImplementedException();
        }

        private void Three_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "3";//throw new System.NotImplementedException();
        }

        private void Zero_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "0";//throw new System.NotImplementedException();
        }

        private void Equals_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

            Parser p = new Parser();
            double r = p.parse(Input.Text);
            Input.Text = Convert.ToString(r);
            }
            catch (Exception exception)
            {
                MessageBox.Show("А по жопе?");
            }
        }

        private void Plus_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "+";//throw new System.NotImplementedException();
        }

        private void Minus_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "-";//throw new System.NotImplementedException();
        }

        private void Multiply_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "*";//throw new System.NotImplementedException();
        }

        private void Divide_OnClick(object sender, RoutedEventArgs e)
        {
            
            Input.Text += "/";//throw new System.NotImplementedException();
        }
    }
}