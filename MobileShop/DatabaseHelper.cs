using System.Configuration;
using System.Data.SqlClient;

public static class DatabaseHelper
{
    private static readonly string _cs =
        ConfigurationManager.ConnectionStrings["MobileShopDB"].ConnectionString;

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(_cs);
    }
}
