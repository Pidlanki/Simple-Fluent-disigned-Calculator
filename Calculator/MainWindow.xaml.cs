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
	public partial class MainWindow : Window
	{
		private string left = "";
		private string right = "";
		private string operand = "";

		public MainWindow()
		{
			InitializeComponent();
			foreach (UIElement child in MainGrid.Children)
			{
				if (child is Button)
				{
					(child as Button).Click += Button_Click;
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string s = (string) (e.OriginalSource as Button).Content;
			double number;
			if (double.TryParse(s, out number) || s == ",")
			{
				TextBlock.Text += s;
				if (operand == "")
				{
					left += s;
				}
				else
				{
					right += s;
				}
			}
			else
			{
				if (s == "=")
				{
					procces();
				}
				else
				{
					if (s == "clear")
					{
						right = left = operand = TextBlock.Text = "";
					}
					else
					{
						if (s == ",")
						{
							
						}
						else
						{
							operand = s;
						}
					}
				}
			}
		}

		void procces()
		{
			double numLeft = Convert.ToDouble(left);
			double numRight = Convert.ToDouble(right);
			switch (operand)
			{
				case "+":
					TextBlock.Text += (numLeft + numRight).ToString();
					break;
				case "-":
					TextBlock.Text += (numLeft - numRight).ToString();
					break;
				case "*":
					TextBlock.Text += (numLeft * numRight).ToString();
					break;
				case "/":
					TextBlock.Text += (numLeft / numRight).ToString();
					break;
			}
		}
	}
}
