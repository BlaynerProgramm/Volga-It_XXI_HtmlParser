using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Volga_It_XXI_HtmlParser.Core
{
	public class HtmlParser : IHtmlParser<string, int>
	{
		/// <summary>
		/// Чтение html
		/// </summary>
		/// <param name="url">Ссылка на файл</param>
		/// <returns>Содержимое HTML файла</returns>
		private static string ReadHtml(string url)
		{
			using StreamReader stream = new(url, Encoding.UTF8);
				return stream.ReadToEnd().ToLower();
		}

		/// <summary>
		/// Разделяет слова по разделителям
		/// </summary>
		/// <param name="url">Ссылка на HTML</param>
		/// <returns>Массив слов</returns>
		public string[] SplitHtmlContent(string url)
		{
			char[] arraySplit = { ' ', ',', '.', '!', '?', '\"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };

			var content = Regex.Replace(ReadHtml(url), @"<[^>]+>|&nbsp;", string.Empty);

			return content.Split(arraySplit).Where(x => x != string.Empty).ToArray();
		}

		/// <summary>
		/// Получить отсортированный и посчитанный словарь, где key - слово, value - кол-во
		/// </summary>
		/// <param name="url">Ссылка на HTML</param>
		/// <returns>отсортированный и посчитанный словарь, где key - слово, value - кол-во</returns>
		public Dictionary<string, int> GetHtmlContent(string url)
		{
			Dictionary<string, int> words = new();
			var contentHtml = SplitHtmlContent(url); //TODO: Подумать над переносом в параметры

			foreach (var key in contentHtml)
			{
				if (!words.ContainsKey(key))
				{
					words.Add(key, contentHtml.Count(x => x == key));
				}
			}

			return words.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
		}
	}
}