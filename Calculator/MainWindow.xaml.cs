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
using SourceChord.FluentWPF;

namespace Calculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		private string left = "";
		private string right = "";
		private string operand = "";
		private string answer = "";

		public MainWindow() {
			InitializeComponent();
			foreach (UIElement child in MainGrid.Children) {
				if (child is Button) {
					(child as Button).Click += Button_Click;
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			string s = (string) (e.OriginalSource as Button).Content;
			double number;
			if (s == "=" && right != "")
			{
				TextBlock.Text += " " + right + " " + s;
				proccess();
				TextBlock2.Text = answer;
				left = answer;
				right = answer = "";
			}
			if ((s == "+" || s == "-" || s == "x" || s == "÷") && right != "")
			{
				proccess();
				operand = s;
				left = answer;
				right = answer = "";
				TextBlock.Text = left + " " + operand;
				TextBlock2.Text = "";
				s = "";
			}
			if (double.TryParse(s, out number) || s == ",") {
				TextBlock2.Text += s;
				if (operand == "")
				{
					left += s;
				} else {
					right += s;
				}
			} 
			if (s == "+" || s == "-" || s == "x" || s == "÷") {
				operand = s;
				TextBlock.Text = TextBlock2.Text + " " + s + " ";
				TextBlock2.Text = "";
			}
		}

		void proccess()
		{
			double numLeft = Convert.ToDouble(left);
			double numRight = Convert.ToDouble(right);
			switch (operand)
			{
				case "+":
					answer = (numLeft + numRight).ToString();
					TextBlock2.Text = answer;
					break;
				case "-":
					answer = (numLeft - numRight).ToString();
					TextBlock2.Text = answer;
					break;
				case "x":
					answer = (numLeft * numRight).ToString();
					TextBlock2.Text = answer;
					break;
				case "÷":
					answer = (numLeft / numRight).ToString();
					TextBlock2.Text = answer;
					break;
			}
		}

		private void Button_Click_ce(object sender, RoutedEventArgs e)
		{
			if (right != "")
			{
				right = "";
				TextBlock2.Text = "";
				TextBlock.Text = left + " " + operand + " ";
			}
			else if (left != "")
			{
				left = "";
				TextBlock.Text = TextBlock2.Text = "";
			}
		}

		private void Button_Click_c(object sender, RoutedEventArgs e) {
			TextBlock.Text = TextBlock2.Text = left = right = answer = operand = "";
		}

		private void Button_Click_back(object sender, RoutedEventArgs e) {
			if (right != "")
			{
				right = right.Substring(0, right.Length - 1);
				TextBlock2.Text = right;
			}
			else if (left != "" && operand == "")
			{
				left = left.Substring(0, left.Length - 1);
				TextBlock2.Text = left;
			}
		}
	}
}
