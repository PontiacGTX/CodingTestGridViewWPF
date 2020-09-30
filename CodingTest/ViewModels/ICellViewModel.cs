using CodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodingTest.ViewModels
{
	public interface ICellViewModel
	{
		ICell Cell { get; set; }
		ICommand ChangeCellStateCommand { get; }
	}
}
