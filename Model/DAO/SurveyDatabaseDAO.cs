using System.Configuration;
using System.Data.SqlClient;

namespace AIT_Research.Model.DAO
{

    public class SurveyDatabaseDAO
    { //Connection string initializing with const string
        public const string ConnectionStringName = "AITSurvey";
        public SqlConnection connection;

        public SurveyDatabaseDAO()
        {
            //access connection string
            string connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
        }
    }
}