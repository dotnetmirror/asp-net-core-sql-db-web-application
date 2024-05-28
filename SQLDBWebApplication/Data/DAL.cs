using Microsoft.AspNetCore.Mvc.RazorPages;
using DotnetMirror.ASPNETCORESQLDBWebApplication.Models;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DotnetMirror.ASPNETCORESQLDBWebApplication.Data;

namespace DotnetMirror.ASPNETCORESQLDBWebApplication.Data
{
    public class DAL : IDAL
    {
        public List<Cert> ListCertfications()
        {
            using (SqlConnection objCon = new SqlConnection(GetConString()))
            {
                string objc = "select Code,[Name],ExamDate from Certification";
                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = objc;
                objCmd.Connection = objCon;


                SqlDataAdapter da = new SqlDataAdapter(objCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                var myData = ds.Tables[0].AsEnumerable().Select(r => new Cert
                {
                    Code = r.Field<string>("Code"),
                    Description = r.Field<string>("Name"),
                    ExamDate = r.Field<DateTime>("ExamDate")
                });
                var list = myData.ToList();

                return list;
            }
        }

        public void Save(Cert cert)
        {
            // Query to be executed
            string query = "Insert Into [Certification] (Code,[Name],ExamDate) " +
                               "VALUES (@code, @desc, @examdt) ";

            // instance connection and command
            using (SqlConnection cn = new SqlConnection(GetConString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // add parameters and their values
                cmd.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 10).Value = cert.Code;
                cmd.Parameters.Add("@desc", System.Data.SqlDbType.NVarChar, 500).Value = cert.Description;
                cmd.Parameters.Add("@examdt", System.Data.SqlDbType.Date).Value = cert.ExamDate;
                

                // open connection, execute command and close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public void Delete(string code)
        {
            // Query to be executed
            string query = "Delete from [Certification] where code=@code";

            // instance connection and command
            using (SqlConnection cn = new SqlConnection(GetConString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // add parameters and their values
                cmd.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 10).Value = code;
               
                // open connection, execute command and close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public Cert GetCertfication(string id)
        {
            using (SqlConnection objCon = new SqlConnection(GetConString()))
            {
                string objc = "select Code,[Name],ExamDate from Certification where code=@code";

             
              

                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.AddWithValue("@code", id);
                objCmd.CommandText = objc;
                objCmd.Connection = objCon;

                
                SqlDataAdapter da = new SqlDataAdapter(objCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                var myData = ds.Tables[0].AsEnumerable().Select(r => new Cert
                {
                    Code = r.Field<string>("Code"),
                    Description = r.Field<string>("Name"),
                    ExamDate = r.Field<DateTime>("ExamDate")
                });
                var list = myData.ToList()[0];

                return list;
            }
        }

        public static string GetConString()
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();
            IConfiguration configuration = builder.Build();
            string _connstr = configuration.GetConnectionString("conStr");

            return _connstr;

        }

    }
}
