using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CodingTest.Converters
{
	[ValueConversion(typeof(double[]), typeof(double))]
	public class DivideDoubleConverter : OperationGenericConverter<double>
	{
		protected override Func<object, CultureInfo, double> ConvertMethod =>
			(value, culture) =>
			{
				if (value == null)
					return 0;
				var result = System.Convert.ToDouble(value);
				return double.IsNaN(result) ? 0 : result;
			};

		protected override Func<double, double, double> BinaryMethod =>
			(value1, value2) => Math.Abs(value2) < double.Epsilon ? 0 : value1 / value2;

		protected override Func<double, double, double> ApplyParameterMethod =>
			(value, parameter) => Math.Round(value, System.Convert.ToInt32(Math.Abs(parameter)));
	}
}
