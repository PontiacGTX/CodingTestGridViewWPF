using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CodingTest.ViewModels
{
	internal class DesignDynamicGridViewModel : IDynamicGridViewModel
	{
		public ObservableCollection<ObservableCollection<ICellViewModel>> Cells { get; set; } = null;
		public int GridWidth { get; } = 5;
		public int GridHeight { get; } = 5;


		public int SelectedIndex = 6;


		public Color StartColor { get; set; } = Colors.AliceBlue;
		public Color FinishColor { get; set; } = Colors.DarkBlue;
		public Color BorderColor { get; set; } = Colors.DarkGray;

	}
}
