using BLL.Entities;
using BLL.EntitiesList;
using DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManager
{
    public class TransactionManger
    {
        public static TransactionList GetTransList()
        {
            DAManager da = new DAManager();
            string sql = "select * from Transactions";
            DataTable dt = da.GetAll(sql);
            TransactionList res = ConvertFromDTtoTL(dt);
            return res;
        }
        public  static int Add(int wId, DateTime transDate, decimal amount, string transType)
        {
            DAManager da = new DAManager();
            string sqlInsert = $"insert into Transactions (WalletId, TransactionDate,Amount,TransactionType) values ({wId},'{transDate}',{amount},'{transType}') ";
            int x = da.ExecuteNonQuery(sqlInsert);
            return x;
        }
        public static int Update(int wId, DateTime transDate, decimal amount, string transType)
        {
            DAManager da = new DAManager();
            string sqlUpdate = $"update Transactions set TransactionDate ='{transDate}',Amount={amount}, TransactionType='{transType}' where WalletId ={wId} ";
            int x = da.ExecuteNonQuery(sqlUpdate);
            return x;
        }
        public static int Delete(int tId)
        {
            DAManager da = new DAManager();
            string SqlDelete = $"delete from Transactions where Id ={tId} ";
            int x = da.ExecuteNonQuery(SqlDelete);
            return x;
        }
        public static int Add2(int wId, DateTime transDate, decimal amount, string transType)
        {
            DAManager da = new DAManager();
            string sqlInsert = $"insert into Transactions (WalletId, TransactionDate,Amount,TransactionType) values (@wId,@transDate,@amount,@transType) ";
            List<SqlParameter> spl = new List<SqlParameter>();
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "wId",
                Value = wId,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "transDate",
                Value = transDate,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.DateTime
            };
       
            SqlParameter param3 = new SqlParameter()
            {
                ParameterName = "amount",
                Value = amount,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Decimal
            };
   
            SqlParameter param4 = new SqlParameter()
            {
                ParameterName = "transType",
                Value = transType,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.NVarChar
            };
            spl.Add(param1);
            spl.Add(param2);
            spl.Add(param3);
            spl.Add (param4);
            int x = da.ExecuteNonqueryParam(sqlInsert,spl);
            return x;
        }
        public static int Update2(int wId, DateTime transDate, decimal amount, string transType)
        {
            DAManager da = new DAManager();
            string sqlUpdate = $"update Transactions set TransactionDate =@transDate,Amount=@amount,TransactionType=@transType where WalletId =@wId ";
            List<SqlParameter> spl = new List<SqlParameter>();
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "wId",
                Value = wId,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter param2 = new SqlParameter()
            {
                ParameterName = "transDate",
                Value = transDate,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.DateTime
            };

            SqlParameter param3 = new SqlParameter()
            {
                ParameterName = "amount",
                Value = amount,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Decimal
            };

            SqlParameter param4 = new SqlParameter()
            {
                ParameterName = "transType",
                Value = transType,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.NVarChar
            };
            spl.Add(param1);
            spl.Add(param2);
            spl.Add(param3);
            spl.Add(param4);
            int x = da.ExecuteNonqueryParam(sqlUpdate, spl);
            return x;
        }
        public static int Delete2(int tId)
        {
            DAManager da = new DAManager();
            string SqlDelete = $"delete from Transactions where Id =@tId ";
            List<SqlParameter> spl = new List<SqlParameter>() ;
            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "tId",
                Value = tId,
                Direction = ParameterDirection.Input,
                SqlDbType= SqlDbType.Int
            };
            spl.Add (param1);
            int x = da.ExecuteNonqueryParam(SqlDelete, spl);
            return x;
        }
        internal static TransactionList ConvertFromDTtoTL(DataTable dt)
        {
            TransactionList transList = new TransactionList();
            foreach (DataRow dr in dt.Rows) {
                transList.Add(ConvertFromDRtoT(dr));
            }
            return transList;
        }
        internal static Transaction ConvertFromDRtoT(DataRow dr) {
            return new Transaction
            {
                TransId = (int)dr["Id"],
                WalletId = (int)dr["WalletId"],
                TransactionDate = (DateTime)dr["TransactionDate"],
                Amount = (decimal)dr["Amount"],
                TransactionType = dr[4].ToString()

            };
        }

    }
}
