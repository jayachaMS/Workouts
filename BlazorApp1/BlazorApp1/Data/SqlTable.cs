using System.Data;
using System.Data.SqlClient;

namespace BlazorApp1
{
	public class SqlTable
	{
		#region Constants
		private static readonly DataTable tabInsurance = new DataTable("EDINS");
		#endregion

		#region Publics
		public static DataTable GetDataTableToBind()
		{
			using(SqlConnection connection = new SqlConnection("Data Source=MS-00502;Initial Catalog=BlazorEducation;User ID=sa;Password=password-123"))
			{
				string strQuery = "select * from EDINS";

				connection.Open();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, connection);
				connection.Close();

				dataAdapter.Fill(tabInsurance);
			}

			return tabInsurance;
		}
		#endregion
	}
}