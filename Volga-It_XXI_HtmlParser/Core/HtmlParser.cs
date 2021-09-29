using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Volga_It_XXI_HtmlParser.Core
{
	public static class HtmlParser
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
		public static string[] SplitHtmlContent(string url)
		{
			char[] arraySplit = { ' ', ',', '.', '!', '?', '\"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };

			var content = Regex.Replace(ReadHtml(url), @"<[^>]+>|&nbsp;", string.Empty);

			return content.Split(arraySplit).Where(x => x != string.Empty).ToArray();
		}

		/// <summary>
		/// Сортирует и считает слова
		/// </summary>
		/// <param name="contentHtml">Разделенные слова из HTML</param>
		/// <returns>Отсортированную и подсчитанную коллекцию</returns>
		public static IOrderedEnumerable<KeyValuePair<string, int>> GetSortedDictionary(string[] contentHtml)
		{
			Dictionary<string, int> words = new();

			foreach (var t in contentHtml)
			{
				if (words.ContainsKey(t))
				{
					continue;
				}
				else
				{
					words.Add(t, 0);
				}
			}

			foreach (var t1 in contentHtml)
			{
				foreach (var t in contentHtml)
				{
					if (t1 == t)
					{
						words[t1] += 1;
					}
				}
			}

			return words.OrderByDescending(x => x.Value);
		}
	}
}