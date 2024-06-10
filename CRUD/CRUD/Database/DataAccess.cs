using CRUD.Common;
using CRUD.Model.Request;
using CRUD.Model.Response;
using System.Data;
using System.Data.SqlClient;

namespace CRUD.Database
{
    public interface IDataAccess
    {
        string InsertData(InsertRequest request);
        List<SelectResponse> SelectData();
        string UpdateData(UpdateRequest request);
        string DeleteData(DeleteRequest request);
    }
    public class DataAccess : IDataAccess
    {
        private string _connectionString = string.Empty;
        private IConfiguration _configuration { get; set; }

        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings"];
        }
        public string InsertData(InsertRequest request)
        {
            string message = "";
            using (SqlConnection Sqlcon = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlcmd = new SqlCommand(_connectionString))
                {
                    sqlcmd.Connection = Sqlcon;
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.CommandText = "INSERT INTO Employee(EmployeeName, Password,Status_ID) VALUES(@EmployeeName, @Password,1)";

                    sqlcmd.Parameters.AddWithValue("@EmployeeName", request.EmployeeName);
                    sqlcmd.Parameters.AddWithValue("@Password", CommonMethods.ConvertToEncrypt(request.Password));
                    Sqlcon.Open();
                    int rowsAffected = sqlcmd.ExecuteNonQuery();
                    // Sqlcon.Close();
                    if (rowsAffected > 0)
                    {
                        message = "Login Successfull";
                    }
                    else
                    {
                        message = "Login Failed";
                    }

                    return message;

                }
            }
        }

        public List<SelectResponse> SelectData()
        {
            try
            {
                List<SelectResponse> employeelist = new List<SelectResponse>();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "select EmployeeCode,EmployeeName, case when Status_ID=1 then 'Live' when Status_ID=0 then 'Resigned' when Status_ID=2 then 'Long Leave'end as Status from Employee ;";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            employeelist.Add(new SelectResponse

                            {
                                EmployeeCode = Convert.ToInt32(reader["EmployeeCode"]),
                                EmployeeName = reader["EmployeeName"].ToString(),
                                Status = reader["Status"].ToString(),
           
                            });
                        }
                    }


                    return employeelist;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateData(UpdateRequest request)
        {
            string message = "";
            using (SqlConnection Sqlcon = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlcmd = new SqlCommand(_connectionString))
                {
                    sqlcmd.Connection = Sqlcon;
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.CommandText = "update Employee set Status_ID=@Status_ID where EmployeeCode=@EmployeeCode";

                    sqlcmd.Parameters.AddWithValue("@EmployeeCode", request.EmployeeCode);
                    sqlcmd.Parameters.AddWithValue("@Status_ID", request.Status_ID);
                    Sqlcon.Open();
                    int rowsAffected = sqlcmd.ExecuteNonQuery();
                    // Sqlcon.Close();
                    if (rowsAffected > 0)
                    {
                        message = "Employee Status Changed Successfully";
                    }
                    else
                    {
                        message = "Employee Status Changed Failed";
                    }

                    return message;

                }
            }
        }

        public string DeleteData(DeleteRequest request)
        {
            string message = "";
            using (SqlConnection Sqlcon = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlcmd = new SqlCommand(_connectionString))
                {
                    sqlcmd.Connection = Sqlcon;
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.CommandText = "DELETE FROM Employee  where EmployeeCode=@EmployeeCode";

                    sqlcmd.Parameters.AddWithValue("@EmployeeCode", request.EmployeeCode);
             
                    Sqlcon.Open();
                    int rowsAffected = sqlcmd.ExecuteNonQuery();
                    // Sqlcon.Close();
                    if (rowsAffected > 0)
                    {
                        message = "Employee data deleted Successfully";
                    }
                    else
                    {
                        message = "Employee data deleted Failed";
                    }

                    return message;

                }
            }
        }
    }
}
