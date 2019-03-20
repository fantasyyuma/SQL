using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //取得DataTable只要寫下列程式碼

        string sql = "select * from TableName";
        DataTable myDataTable = GetDataTable("ServerName", "DataBaseName", "UserName", "PassWord", sql);

        //MSSQL連線用法
        public static SqlConnection OpenSqlConn(string Server, string Database, string dbuid, string dbpwd)
        {
            string cnstr = string.Format("server={0};database={1};uid={2};pwd={3};Connect Timeout = 180", Server, Database, dbuid, dbpwd);
            SqlConnection icn = new SqlConnection();
            icn.ConnectionString = cnstr;
            if (icn.State == ConnectionState.Open) icn.Close();
            icn.Open();
            return icn;
        }

        public static DataTable GetSqlDataTable(string Server, string Database, string dbuid, string dbpwd, string SqlString)
        {
            DataTable myDataTable = new DataTable();
            SqlConnection icn = null;
            icn = OpenSqlConn(Server, Database, dbuid, dbpwd);
            SqlCommand isc = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(isc);
            isc.Connection = icn;
            isc.CommandText = SqlString;
            isc.CommandTimeout = 600;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            myDataTable = ds.Tables[0];
            if (icn.State == ConnectionState.Open) icn.Close();
            return myDataTable;
        }

        public static void SqlInsertUpdateDelete(string Server, string Database, string dbuid, string dbpwd, string SqlSelectString)
        {
            SqlConnection icn = OpenSqlConn(Server, Database, dbuid, dbpwd);
            SqlCommand cmd = new SqlCommand(SqlSelectString, icn);
            SqlTransaction mySqlTransaction = icn.BeginTransaction();
            try
            {
                cmd.Transaction = mySqlTransaction;
                cmd.ExecuteNonQuery();
                mySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                mySqlTransaction.Rollback();
                throw (ex);
            }
            if (icn.State == ConnectionState.Open) icn.Close();
        }

        //MYSQL用法
        /*public static MySqlConnection MyOpenConn(string Server, string Database, string dbuid, string dbpwd)
        {
            string cnstr = string.Format("server={0};database={1};uid={2};pwd={3};Connect Timeout = 180; CharSet=utf8", Server, Database, dbuid, dbpwd);
            MySqlConnection icn = new MySqlConnection();
            icn.ConnectionString = cnstr;
            if (icn.State == ConnectionState.Open) icn.Close();
            icn.Open();
            return icn;
        }

        public static DataTable GetMyDataTable(string Server, string Database, string dbuid, string dbpwd, string SqlString)
        {
            DataTable myDataTable = new DataTable();
            MySqlConnection icn = null;
            icn = MyOpenConn(Server, Database, dbuid, dbpwd);
            MySqlCommand isc = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter(isc);
            isc.Connection = icn;
            isc.CommandText = SqlString;
            isc.CommandTimeout = 600;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            myDataTable = ds.Tables[0];
            if (icn.State == ConnectionState.Open) icn.Close();
            return myDataTable;
        }

        public static void MySqlInsertUpdateDelete(string Server, string Database, string dbuid, string dbpwd, string SqlSelectString)
        {
            MySqlConnection icn = MyOpenConn(Server, Database, dbuid, dbpwd);
            MySqlCommand cmd = new MySqlCommand(SqlSelectString, icn);
            MySqlTransaction mySqlTransaction = icn.BeginTransaction();
            try
            {
                cmd.Transaction = mySqlTransaction;
                cmd.ExecuteNonQuery();
                mySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                mySqlTransaction.Rollback();
                throw (ex);
            }
            if (icn.State == ConnectionState.Open) icn.Close();
        }*/


        //Oracle用法

        /*public static OracleConnection OpenConn(string Server, string Database, string dbuid, string dbpwd)
        {
            string cnstr = string.Format("server={0};Data Source={1};User ID={2};Password={3}", Server, Database, dbuid, dbpwd);
            OracleConnection icn = new OracleConnection();
            icn.ConnectionString = cnstr;
            if (icn.State == ConnectionState.Open) icn.Close();
            icn.Open();
            return icn;
        }

        public static DataTable GetDataTable(string Server, string Database, string dbuid, string dbpwd, string SqlString)
        {
            DataTable myDataTable = new DataTable();
            OracleConnection icn = null;
            icn = OpenConn(Server, Database, dbuid, dbpwd);
            OracleCommand isc = new OracleCommand();
            OracleDataAdapter da = new OracleDataAdapter(isc);
            isc.Connection = icn;
            isc.CommandText = SqlString;
            isc.CommandTimeout = 600;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            myDataTable = ds.Tables[0];
            if (icn.State == ConnectionState.Open) icn.Close();
            return myDataTable;
        }

        public static void OracleInsertUpdateDelete(string Server, string Database, string dbuid, string dbpwd, string SqlSelectString)
        {
            OracleConnection icn = OpenConn(Server, Database, dbuid, dbpwd);
            OracleCommand cmd = new OracleCommand(SqlSelectString, icn);
            OracleTransaction mySqlTransaction = icn.BeginTransaction();
            try
            {
                cmd.Transaction = mySqlTransaction;
                cmd.ExecuteNonQuery();
                mySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                mySqlTransaction.Rollback();
                throw (ex);
            }
            if (icn.State == ConnectionState.Open) icn.Close();
        }*/


    }
}
