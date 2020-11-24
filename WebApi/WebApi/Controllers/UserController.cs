using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using System.Web.Http.Cors;

using System.Data;

using System.Data.SqlClient;

namespace WebApi.Controllers
{
    //[EnableCors(origins: "https://localhost:44347", headers: "*", methods: "*")]
    public class UserController : ApiController
    {



        [HttpGet]
        [ActionName("GetUsers")]

        public HttpResponseMessage GetUsers()
        {
            List<User> _list = new List<User>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            string query = "SELECT * FROM [tbluser]";
            SqlCommand cmd = new SqlCommand(query, conn);
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            _list = (from DataRow row in dt.Rows
                     select new User()
                     {
                         ID = Convert.ToInt32(row["Id"]),
                         Name = Convert.ToString(row["Name"]),
                         Email = Convert.ToString(row["Email"]),
                         Status = Convert.ToString(row["Status"]),
                         Role = Convert.ToString(row["Role"])
                     }).ToList();

            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, _list);
            }
            catch (Exception)
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, _list);
            }
        }

        public HttpResponseMessage AddNewUser(User objUser)
        {
            try
            {
                if (objUser.Name != string.Empty)
                {
                    objUser.Status = "Active";
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    conn.Open();
                    string sql = "INSERT INTO tbluser VALUES(@param1,@param2,@param3,@param4)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@param1", SqlDbType.VarChar, 100).Value = objUser.Name;
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar, 100).Value = objUser.Email;
                        cmd.Parameters.Add("@param3", SqlDbType.VarChar, 100).Value = objUser.Role;
                        cmd.Parameters.Add("@param4", SqlDbType.VarChar, 100).Value = objUser.Status;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return this.Request.CreateResponse(HttpStatusCode.OK, "");
            }
            catch (Exception)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, true);
            }
        }

        public HttpResponseMessage EditUser(User objUser)
        {
            try
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                string sql = "UPDATE tbluser SET Name=@param1,Email=@param2,Role=@param3 WHERE Id=@param4";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 100).Value = objUser.Name;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 100).Value = objUser.Email;
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 100).Value = objUser.Role;
                    cmd.Parameters.Add("@param4", SqlDbType.Int, 100).Value = objUser.ID;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                return this.Request.CreateResponse(HttpStatusCode.OK, "");
            }
            catch (Exception)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, true);
            }
        }

        public HttpResponseMessage DeleteUser(User objUser)
        {
            try
            {

                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                string sql = "Delete from tbluser WHERE Id=@param1";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.Int, 100).Value = objUser.ID;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                return this.Request.CreateResponse(HttpStatusCode.OK, "");
            }
            catch (Exception)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, true);
            }
        }
    }
}
