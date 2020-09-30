using CodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodingTest.ViewModels
{
	internal class DesignCellViewModel : ICellViewModel
	{
		public ICell Cell { get; set; } = Models.Cell.Empty;
		public ICommand ChangeCellStateCommand { get; } = null;
	}
}
