using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSampleXamarinForms.Data
{
	public class FirstChild
	{
		public FirstChild() { }

		public int FirstChildId { get; set; }
		public string FirstChildName { get; set; }
		public string Description { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public int TestModelId { get; set; }

		public TestModel TestModel { get; set; }
	}
}
