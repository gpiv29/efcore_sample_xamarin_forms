using System.IO;

using EFCoreSampleXamarinForms.Services;

namespace EFCoreSampleXamarinForms.Droid.Services
{
	public class FileHelper : IFileHelper
	{
		public string GetLocalFilePath(string filename)
		{
			string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var result = Path.Combine(path, filename);
			return result;
		}
	}
}