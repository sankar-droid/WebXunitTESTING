using Microsoft.AspNetCore.Identity;
using WebXunitTESTING.Interface;
using Microsoft.Data.SqlClient;

namespace WebXunitTESTING.Services
{
    public class EmployeeService : IEmployee
    {


        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public EmployeeService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("NewConnection");
        }

        public virtual List<EmployeeClass> GetRows()
        {
            var employeelist = new List<EmployeeClass>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "SELECT * FROM employee";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeelist.Add(new EmployeeClass
                            {
                                Id = Convert.ToInt32(reader["empid"]),
                                Name = reader["lastname"].ToString(),
                                DeptNo = Convert.ToInt32(reader["deptno"])
                            });
                        }
                    }
                }
            }

            return employeelist;
        }


        public void InsertRow()
        {
            
        }
    }
}
