
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HCIProject.Models.DataRetriever
{
    public class SqlHandler
    {
        private string CONNECTION_STRING = "Server=M799748-W10;Database=MeMeats;Trusted_Connection=True;";
        private SqlCommand command;

        private Dictionary<string, string> Queries = new Dictionary<string, string>();

        public SqlHandler(string data) 
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.CONNECTION_STRING;
            conn.Open();
            this.command = new SqlCommand(data, conn);
        }
        public SqlHandler(string procedure, string[] parameters, object[] values) {
            if(procedure == null || procedure == "" || parameters == null || parameters.Length == 0 || values == null || values.Length == 0 )
            {
                return;
            }
            InitializeQueries();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = this.CONNECTION_STRING;
            conn.Open();
            this.command = new SqlCommand(Queries[procedure], conn);
            // not going to use stored procs for now cuz of mysql migration
            //command.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parameters.Length; i++)
            {
                // if values[i] instanceof string[]... build table for parameter
                if (values[i]?.GetType()?.Name == "String[]")
                {
                    command.Parameters.Add(new SqlParameter(parameters[i], CreateParameterTable((string[])values[i])));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter(parameters[i], values[i]));
                }
            }
        }

        public DataTable CreateParameterTable(string[] words)
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Word";
            column.AutoIncrement = false;
            column.Caption = "Word";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);
            DataRow row;
            foreach (string word in words)
            {
                row = table.NewRow();
                row["Word"] = word;
                table.Rows.Add(row);
            }
            return table;
        }

         public DataTable CreateErrorTable(string err)
        {
            // table
            DataTable table = new DataTable();
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            // column
            column.ColumnName = "Error";
            column.AutoIncrement = false;
            column.Caption = "Error";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);
            // row
            DataRow row;
            row = table.NewRow();
            row["Error"] = err;
            table.Rows.Add(row);
            return table;
        }

        public DataTable Execute()
        {
            try
            {
                DataTable dataTable = new DataTable();
                var dataReader = this.command.ExecuteReader();
                dataTable.Load(dataReader);
                return dataTable;

            } catch(System.Exception e)
            {
                return CreateErrorTable(e.ToString());
            }
            
        }

        private void InitializeQueries()
        {
            //register
            Queries.Add("IsAccountInfoAvailable", "SELECT Username, Email from Accounts where Username = @username OR Email = @email;");
            Queries.Add("SaveNewAccount", "INSERT INTO [dbo].[Accounts]([Username],[Password],[Email],[Type])" +
                "VALUES (@username, @password, @email, @type); SELECT SCOPE_IDENTITY();");

            //login
            Queries.Add("FindAccountByUsernamePassword", "SELECT * FROM Accounts where username = @username AND password = @password;");
           
            //user pages
            Queries.Add("GetAccountInfoByUserID", "Select * FROM Accounts where UserID = @userID;");
            Queries.Add("GetAllAccountsFollowedByUserID", "SELECT [Email],[Phone],[Street],[Town],[State],[Zipcode],[NumReviews],[NumPoints],[Type],[Image],[Name]"
                + " FROM Accounts A Where A.UserID In(SELECT[FollowedID] FROM [dbo].[Follows] WHERE UserID = @userID);");
            Queries.Add("GetAllAcountsFollowingUserID", "SELECT [NumReviews],[NumPoints],[Type],[Image],[Name], [UserID]"
                + " FROM Accounts A Where A.UserID In(SELECT[FollowedID] FROM [dbo].[Follows] WHERE FollowedID = @userID);");
           
        }

    }
}