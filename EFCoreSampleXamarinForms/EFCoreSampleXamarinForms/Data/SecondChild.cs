using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSampleXamarinForms.Data
{
	public class SecondChild
	{
		public SecondChild() { }

		public int SecondChildId { get; set; }
		public string SecondChildName { get; set; }
		public string Description { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public int TestModelId { get; set; }

		public TestModel TestModel { get; set; }
	}
}
