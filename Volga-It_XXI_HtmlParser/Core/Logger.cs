using System.IO;
using System.Text;

namespace Volga_It_XXI_HtmlParser.Core
{
	public static class Logger
	{
		public static void WriteToLog(string message)
		{
			using StreamWriter stream = new("log.txt", true, Encoding.UTF8);
			stream.Write(message);
		}
	}
}
