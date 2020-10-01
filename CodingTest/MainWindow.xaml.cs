using CodingTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


		void GetInput(ref string sequence)
		{
			sequence = new TextRange(txtInput.Document.ContentStart, txtInput.Document.ContentEnd).Text.ToUpper();
			sequence = sequence.Replace("\r\n", String.Empty);
		}

		void GetReferenceCoordinates(out int x_ref, out int y_ref, out int x, out int y)
		{
			 x_ref = y_ref = y= x = 0;
			
			x_ref = x = dynamicGridViewModel.posX;
			y_ref = y = dynamicGridViewModel.posY;
		}

		void GetCoordinates(ref int x, ref int y, ref string sequence)
		{
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
		}

		void GetRowColCount(ref int row, ref int col)
		{
			row = dynamicGridViewModel.GridHeight; 
			col = dynamicGridViewModel.GridWidth;
		}

		void RefreshText(ref string outputStr)
		{
			txtInput.Document.Blocks.Clear();

			txtOutput.Document.Blocks.Clear();
			txtOutput.Document.Blocks.Add(new Paragraph(new Run(outputStr)));
		}

		string GetOutput(int x, int y, int x_ref, int y_ref, bool isXinBounds, bool isYinBounds, int maxWidth, int maxHeight)
		{
			string outputStr = "";

			if (isXinBounds && isYinBounds)
			{
				outputStr = $"True ";
			}
			else
			{
				outputStr = $"False ";
			}

			_x = 0;
			_y = 0;

			int origin_x = 0, origin_y = maxHeight;

			_x = origin_x + x;
			_y = origin_y - y;

			if (y < y_ref)
				outputStr += $"North ";
			if (y > y_ref)
				outputStr += $"South ";
			if (x < x_ref)
				outputStr += $"West ";
			if (x > x_ref)
				outputStr += $"East ";

			string pos = $"({_x},{_y})";
			return outputStr += $" {pos}";
		}
		
		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			
			var sequence = "" ;
			GetInput(ref sequence);
			if (!string.IsNullOrEmpty(sequence))
			{
				GetReferenceCoordinates(out var x_ref, out var y_ref, out var x, out var y);

				GetCoordinates(ref x, ref y, ref sequence);

				int totalRow = 0, totalCol = 0;

				GetRowColCount(ref totalRow, ref totalCol);

				bool isXinBounds = isValidX(x, totalCol);
				bool isYinBounds = isValidY(y, totalRow);

				string outputStr = GetOutput(x, y, x_ref, y_ref, isXinBounds, isYinBounds, totalCol, totalRow);




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

				RefreshText(ref outputStr);
			}
			else
			{
				sequence = "";
				MessageBox.Show("Input cant be empty");
			}
		}
	}
}
