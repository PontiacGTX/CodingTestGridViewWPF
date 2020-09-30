using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CodingTest.Converters
{
	[ValueConversion(typeof(double), typeof(double))]
	public class DecreaseDoubleConverter : ValueGenericConverter<double>
	{
		protected override Func<object, CultureInfo, double> ConvertMethod =>
				(value, culture) =>
				{
					if (value == null)
						return 0;
					var result = System.Convert.ToDouble(value);
					return double.IsNaN(result) ? 0 : result;
				};

		protected override Func<double, double, double> ApplyParameterMethod =>
			(value, parameter) => Math.Max(Math.Round(value - parameter, 2), 0);
	}
}
