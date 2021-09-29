using System;
using System.IO;
using Volga_It_XXI_HtmlParser.Core;

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
				var contentArray = HtmlParser.SplitHtmlContent(response);
				var dic = HtmlParser.GetSortedDictionary(contentArray);

				Console.WriteLine("\nРезультат:");
				string temp = default;
				foreach (var (key, value) in dic)
				{
					temp += $"{key} - {value} раз\n";
				}

				Console.WriteLine(temp);

				Console.WriteLine(AdoNetConnection.SendStatistics(temp)
					? "Данные отправились в базу данных"
					: "Произошла ошибка с подключением к бд.\nСм. log файл");
			}
			else
			{
				Console.WriteLine("Файл не найден или не верный формат файла");
				Logger.WriteToLog("Ошибка ввода: Файл не найден или не верный формат файла");
			} 
		}
	}
}
