using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 後台.Class
{
	public partial class ComboUtil : Component
	{
		public ComboUtil()
		{
			InitializeComponent();
		}

		public ComboUtil(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public static void SetItemValue(System.Windows.Forms.ComboBox cbo, string value)
		{
			var selectedObject = cbo.Items.Cast<ComboBoxItem>().SingleOrDefault(i => i.Value.Equals(value));
			if (selectedObject != null)
				cbo.SelectedIndex = cbo.FindStringExact(selectedObject.Text.ToString());
			else
				cbo.SelectedIndex = -1;
		}

		public static ComboBoxItem GetItem(System.Windows.Forms.ComboBox cbo)
		{
			ComboBoxItem item = new ComboBoxItem("", "");
			if (cbo.SelectedIndex > -1)
			{
				item = cbo.Items[cbo.SelectedIndex] as ComboBoxItem;
			}
			return item;
		}
		public static ComboBoxItem GetItem(System.Windows.Forms.ComboBox cbo, int index)
		{
			ComboBoxItem item = null;
			if (index > -1)
			{
				item = cbo.Items[index] as ComboBoxItem;
			}
			return item;
		}
	}
}
