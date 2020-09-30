using CodingTest.ViewModels;
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

namespace CodingTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		DynamicGridViewModel dynamicGridViewModel = null;

		bool isValidX(int target, int upper) => target >= 0 && target < upper;
		bool isValidY(int target, int upper) => target >= 0 && target < upper;
		int CheckCount(int value, int def) => (value != null && value > 0) ? value : def;
		int SetYOriginDifference(int y) => y == 0 ? dynamicGridViewModel.GridHeight - 1 : y;
		bool IsYOrigin(int y) => y == 0;
		int _x = 0;
		int _y = 0;

		char[] validInput = { 'A', 'B', 'L', 'R' };

		public MainWindow()
		{

			InitializeComponent();
			dynamicGridViewModel = new DynamicGridViewModel
			{
				GridWidth = 12,
				GridHeight = 12,
				BorderColor = Colors.Blue,
				StartColor = Colors.Azure,
				FinishColor = Colors.CornflowerBlue,
				posX = 11,
				posY = 11,
			};
			_y = dynamicGridViewModel.GridHeight;
			_x = dynamicGridViewModel.GridWidth;
			dynamicGridViewModel.SelectCell(0, 11, Colors.Gray);
			DataContext = dynamicGridViewModel;



		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			var sequence = new TextRange(txtInput.Document.ContentStart, txtInput.Document.ContentEnd).Text.ToUpper();

			var x_ref = dynamicGridViewModel.posX;
			var y_ref = dynamicGridViewModel.posY;

			var x = dynamicGridViewModel.posX;
			var y = dynamicGridViewModel.posY;


			foreach (char c in sequence)
			{
				if (validInput.Any(ch => ch == c))
				{
					switch (c)
					{
						case 'A': //FORWARD
							y -= 1;
							break;
						case 'B'://BACKWARD
							y += 1;
							break;
						case 'L'://LEFT
							x -= 1;
							break;
						case 'R'://RIGHT
							x += 1;
							break;

					}
				}
			}

			var totalRow = dynamicGridViewModel.GridHeight;
			var totalCol = dynamicGridViewModel.GridWidth;

			bool isXinBounds = isValidX(x, totalRow);
			bool isYinBounds = isValidY(y, totalRow);

			string outputStr = "";

			if (isXinBounds && isYinBounds)
			{
				outputStr = $"True ";
			}
			else
			{
				outputStr = $"False ";
			}

			string pos = $"({x},{y})";

			if (y < y_ref)
				outputStr += $"North ({x},{y})";
			if (y > y_ref)
				outputStr += $"South ({x},{y})";
			if (x < x_ref)
				outputStr += $"East ({x},{y})";
			if (x > x_ref)
				outputStr += $"West ({x},{y})";

			while (outputStr.Contains(pos))
			{
				outputStr = outputStr.Replace(pos, String.Empty).ToString();
			}

			outputStr += $" {pos}";

			int cols = CheckCount(int.Parse(txtColCount.Text), 12);
			int row = CheckCount(int.Parse(txtColCount.Text), 12);

			if (isXinBounds && isYinBounds)
			{
				dynamicGridViewModel = new DynamicGridViewModel()
				{
					GridWidth = cols,
					GridHeight = row,
					BorderColor = Colors.Blue,
					StartColor = Colors.Azure,
					FinishColor = Colors.CornflowerBlue,
					posX = x,
					posY = y,
				};
				dynamicGridViewModel.SelectCell(x, y, Colors.Gray);
				DataContext = dynamicGridViewModel;
			}

			txtInput.Document.Blocks.Clear();

			txtOutput.Document.Blocks.Clear();
			txtOutput.Document.Blocks.Add(new Paragraph(new Run(outputStr)));
		}
	}
}
