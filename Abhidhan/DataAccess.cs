using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
//DB Pass : SqPpy6XTSA37
namespace Abhidhan
{
    /// <summary>
    /// Summary description for DataAccess
    /// </summary>
    public class DataAccess
    {
        static string _ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=abhidhan.mdb;Jet OLEDB:Database Password=SqPpy6XTSA37";
        static OleDbConnection _Connection = null;
        public static OleDbConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new OleDbConnection(_ConnectionString);
                    _Connection.Open();

                    return _Connection;
                }
                else if (_Connection.State != System.Data.ConnectionState.Open)
                {
                    _Connection.Open();

                    return _Connection;
                }
                else
                {
                    return _Connection;
                }
            }
        }

        public static DataSet GetDataSet(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, Connection);
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();
            adp.Fill(ds);
            Connection.Close();

            return ds;
        }

        public static int ExecuteSQL(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, Connection);
            return cmd.ExecuteNonQuery();
        }
        public static void _CloseConnection()
        {
            try
            {
                if (_Connection != null)
                {
                    if (_Connection.State == System.Data.ConnectionState.Open)
                    {
                        _Connection.Close();
                    }
                }
            }
            catch(OleDbException dbEx)
            {

            }
        }
    }
}