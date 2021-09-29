using Microsoft.Data.SqlClient;
using Volga_It_XXI_HtmlParser.Core;

namespace Volga_It_XXI_HtmlParser
{
	public class AdoNetConnection
	{
		/// <summary>
		/// Отправить статистику в бд
		/// </summary>
		/// <param name="statistic">статистика</param>
		/// <returns></returns>
		public static bool SendStatistics(string statistic)
		{
			try
			{
				var queryStr = $"	INSERT dbo.Stat VALUES('{statistic}')";
				const string connectionStr = @"Server=(localdb)\MSSQLLocalDB;Database=Volga-It_Statistics;Trusted_Connection=True;";
				using SqlConnection connection = new(connectionStr);
				connection.Open();
				SqlCommand command = new(queryStr, connection);
				command.ExecuteNonQuery();
				return true;
			}
			catch (SqlException ex)
			{
				Logger.WriteToLog(ex.ToString());
				return false;
			}
		}
	}
}