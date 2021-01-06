using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSampleXamarinForms.Data
{
	public class TestModel
	{
		public TestModel() { }

		public int TestModelId { get; set; }
		public string TestModelName { get; set; }
		public string Description { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }

		public List<FirstChild> FirstChildren { get; set; }
		public List<SecondChild> SecondChildren { get; set; }
	}
}
