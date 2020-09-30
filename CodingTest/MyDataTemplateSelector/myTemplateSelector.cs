using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CodingTest.MyDataTemplateSelector
{
    public class myTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CellTemplateSelector { get; set; }

        public bool NotNull(FrameworkElement e) => (e != null);
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is null)
                return null;

            FrameworkElement frameworkElement = container as FrameworkElement;

            if (NotNull(frameworkElement))
            {
                CellTemplateSelector = frameworkElement.FindResource("CellTemplate") as DataTemplate;
                return CellTemplateSelector;

            }

            return base.SelectTemplate(item, container);
        }
    }
}
