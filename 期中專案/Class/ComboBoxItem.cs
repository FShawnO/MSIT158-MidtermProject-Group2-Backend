using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 後台.Class
{
	public partial class ComboBoxItem : Component
	{
		public ComboBoxItem()
		{
			InitializeComponent();
		}

		public ComboBoxItem(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public string Value { get; set; }
		public string Text { get; set; }

		public ComboBoxItem(string value, string text)
		{
			Value = value;
			Text = text;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
