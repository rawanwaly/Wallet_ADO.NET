using BLL.Entities;
using BLL.EntitiesList;
using DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManager
{
    public class WalletManger
    {
        public static WalletList GetWalletsList()
        {
            DAManager da = new DAManager();
            string sql = "select * from Wallets";
            DataTable dt = da.GetAll(sql);
            WalletList res = ConvertFromDTtoWL(dt);
            return res;
            
        }
        public static int ADD(string holder ,decimal balance)
        {
            DAManager da = new DAManager();
            string sqlInsert = $"insert into Wallets (Holder,Balance) values('{holder}',{balance})";
            int x = da.ExecuteNonQuery(sqlInsert);
            return x;
        }
        public static int Update(int wId,string holder, decimal balance)
        {
            DAManager da = new DAManager();
            string sqlUpdate = $"update Wallets set Holder='{holder}',Balance={balance} where Id ={wId} ";
            int x = da.ExecuteNonQuery(sqlUpdate);
            return x;
        }
        public static int Delete(int wId)
        {
            DAManager da =new DAManager();
            string SqlDelete = $"delete from Wallets where Id ={wId} ";
            int x = da.ExecuteNonQuery(SqlDelete);  
            return x;
        }
        public static int ADD2(string holder, decimal balance) { 
            DAManager da = new DAManager();
            string sqlInsert = $"insert into Wallets (Holder,Balance) values(@holder,@balance)";
            List<SqlParameter> spl = new List<SqlParameter>();
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName= "holder",
                Value=holder,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.NVarChar
            };
            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "balance",
                Value = balance,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Decimal
            };
            spl.Add(param1);
            spl.Add(param2);
            int x = da.ExecuteNonqueryParam(sqlInsert,spl);
            return x;
        }
        public static int Update2(int wId, string holder, decimal balance)
        {
            DAManager da = new DAManager();
            string sqlUpdate = $"update Wallets set Holder=@holder,Balance=@balance where Id =@wId ";
            List<SqlParameter> spl = new List<SqlParameter>();
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "holder",
                Value = holder,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.NVarChar
            };
            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "balance",
                Value = balance,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Decimal
            };
            SqlParameter param3 = new SqlParameter()
            {
                ParameterName = "wId",
                Value = wId,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int
            };
            spl.Add(param1);
            spl.Add(param2);
            spl.Add(param3);
            int x = da.ExecuteNonqueryParam(sqlUpdate, spl);
            return x;
        }
        public static int Delete2(int wId)
        {
            DAManager da = new DAManager();
            string SqlDelete = $"delete from Wallets where Id =@wId ";
            List<SqlParameter> spl = new List<SqlParameter>();
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "wId",
                Value = wId,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int
            };
            spl.Add(param1);
            int x = da.ExecuteNonqueryParam(SqlDelete, spl);
            return x;
        }
        internal static WalletList ConvertFromDTtoWL(DataTable dt)
        {
            WalletList wallets = new WalletList();
            foreach (DataRow row in dt.Rows)
            {
                wallets.Add(ConverFromDRtoW(row));
            }
            return wallets;
        }
        internal static Wallet ConverFromDRtoW(DataRow dr)
        {
            return new Wallet
            {
                WallId = Convert.ToInt32(dr["Id"]),
                Holder= dr[1].ToString(),
                Balance = Convert.ToDecimal(dr["Balance"]),
            };
        }
    }
}
