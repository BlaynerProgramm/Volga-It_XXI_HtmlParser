using System;
using System.IO;

namespace Volga_It_XXI_HtmlParser
{
	internal class Program
	{
		private static void Main()
		{
			Console.Write("Введите ссылку на HTML: ");
			var response = Console.ReadLine();
			if (File.Exists(response) && response.EndsWith(".html"))
			{
				string[] contentArray = HtmlParser.SplitHtmlContent(Console.ReadLine());
				var dic = HtmlParser.GetSortedDictionary(contentArray);

				Console.WriteLine("\nРезультат:");
				foreach (var (key, value) in dic)
				{
					Console.WriteLine($"{key} - {value} раз");
				}
			}
			else
			{
				Console.WriteLine("Файл не найден или не верный формат файла");
				Logger.WriteToLog("Ошибка ввода: Файл не найден или не верный формат файла");
			} 
		}
	}
}
