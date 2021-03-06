﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CodingTest.ViewModels
{
	public interface IDynamicGridViewModel
	{
		/// <summary>
		/// 2-dimensional collections for CellViewModels.
		/// </summary>
		ObservableCollection<ObservableCollection<ICellViewModel>> Cells { get; }

		/// <summary>
		/// Count of grid columns.
		/// </summary>
		int GridWidth { get; }

		/// <summary>
		/// Count of grid rows.
		/// </summary>
		int GridHeight { get; }

		/// <summary>
		/// Start, the lighter, color of cells.
		/// </summary>s
		Color StartColor { get; set; }

		/// <summary>
		/// Finish, the darker, color of cells.
		/// </summary>
		Color FinishColor { get; set; }

		/// <summary>
		/// Color of borders around cells.
		/// </summary>
		Color BorderColor { get; set; }

	}
}
