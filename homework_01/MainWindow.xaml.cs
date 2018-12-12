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

namespace homework_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool symbol = false;
        private string first_stored;
        private string symbol_value;
        private string second_stored;
        private int answer;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ButtonPress(string content)
        {
            if (content == "=")
            {
                if(first_stored != null)
                    second_stored = ResultBox.Text.Remove(0, first_stored.Length + 1);
                if (symbol_value == "+")
                {
                    answer = (Int32.Parse(first_stored)) + (Int32.Parse(second_stored));
                    ResultBox.Text = answer.ToString();
                }
                if (symbol_value == "-")
                {
                    answer = (Int32.Parse(first_stored)) - (Int32.Parse(second_stored));
                    ResultBox.Text = answer.ToString();
                }
                if (symbol_value == "*")
                {
                    answer = (Int32.Parse(first_stored)) * (Int32.Parse(second_stored));
                    ResultBox.Text = answer.ToString();
                }
                if (symbol_value == "/")
                {
                    answer = (Int32.Parse(first_stored)) / (Int32.Parse(second_stored));
                    ResultBox.Text = answer.ToString();
                }
            }
            else if (symbol && first_stored != null)
            {
                ResultBox.Text = ResultBox.Text.Remove(ResultBox.Text.Length - 1);
                ResultBox.Text += content;
                symbol_value = content;
            }
            else if (symbol && first_stored == null)
            {
                first_stored = ResultBox.Text;
                ResultBox.Text += content;
                symbol_value = content;
            }
            if (ResultBox.Text != "0" && !symbol)
            {
                ResultBox.Text += content;
            }
            else if (!symbol)
            {
                ResultBox.Text = content;
            }
            if (content == "C")
            {
                ResultBox.Text = "0";
                first_stored = null;
                second_stored = null;
                symbol_value = null;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            symbol = false;
            ButtonPress((sender as Button).Content.ToString());
        }
        private void Symbol_Click(object sender, RoutedEventArgs e)
        {
            symbol = true;
            ButtonPress((sender as Button).Content.ToString());
        }
    }
}
