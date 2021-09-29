using System.Collections.Generic;

namespace Volga_It_XXI_HtmlParser.Core
{
	public interface IHtmlParser<T, Y>
	{
		/// <summary>
		/// HTML-контент
		/// </summary>
		/// <param name="url">Ссылка на HTML</param>
		/// <returns>Массив HTML-контента</returns>
		string[] SplitHtmlContent(string url);
		/// <summary>
		/// Готовый словарь с HTML-контентом
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		Dictionary<T, Y> GetHtmlContent(string url);
	}
}