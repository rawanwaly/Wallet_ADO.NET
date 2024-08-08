using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAManager
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        public DAManager()
        {
            string? constr = new ConfigurationBuilder()
            .AddJsonFile("D:\\ITI\\EF Core\\ADO.NET\\ADO_Wallet\\Wallet_ADO.NET\\DAL\\Data\\AppSetting.json")
            .Build()
            .GetSection("constr")
            .Value;
            conn = new SqlConnection (constr);
        }

        public DataTable GetAll(string stm)
        { 
            cmd = new SqlCommand(stm, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill (dt);
            return dt;
        }
        public int ExecuteNonQuery(string sql)
        {
            cmd = new SqlCommand (sql, conn);
            conn.Open ();
            int x = cmd.ExecuteNonQuery();
            conn.Close ();
            return x;
        }
        public int ExecuteNonqueryParam(string sql,List<SqlParameter> Spl) {
            cmd = new SqlCommand (sql, conn);
            for (int i = 0; i < Spl.Count; i++) { 
                cmd.Parameters.Add (Spl [i]);
            }
            conn.Open();
            int x = cmd.ExecuteNonQuery ();
            conn.Close();
            return x;

        }


    }
}
