using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System;
using System.Configuration;

namespace XW_XMGL
{
    public class SqlHelperXhf
    {

        #region 初始化参数 public SqlConnection myConn
        public SqlConnection myConn = null;
        #endregion

        #region 构造函数 SqlHelperXhf()
        public SqlHelperXhf(string lsConnString)
        {
            myConn = new SqlConnection(lsConnString);
        }
        #endregion 

        #region 析构 ~SqlHelperXhf()

        ~SqlHelperXhf()
        {
            if (myConn.State != ConnectionState.Closed)
            {
                myConn.Close();
            } 
            myConn.Dispose();
        }
        #endregion

        #region 返回SqlDataAdapter + SqlDataAdapter Getsda(string str)
        /// <summary>
        /// 返回sda
        /// </summary>
        /// <param name="str">sql语句</param>
        /// <returns>SqlDataAdapter</returns>
        public SqlDataAdapter Getsda(string str)
        {
            return new SqlDataAdapter(str, myConn);
        }

        #endregion

        #region 返回第一行的第一列的数据 +object ExecuteScalar(string sql)
        /// <summary>
        /// 返回第一行的第一列
        /// </summary>
        /// <param name="sql">需要查询的SQL语句</param>
        /// <returns>返回Object类型的数据</returns>
        public object ExecuteScalar(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, this.myConn);
            try
            {
                if (myConn.State == ConnectionState.Closed) myConn.Open();
                object reObj = sqlCommand.ExecuteScalar();
                myConn.Close();
                return reObj;
            }
            catch (Exception ex)
            {
                myConn.Close();
                throw new Exception(ex + "<\r\n>" + sql);
            }
        }
        #endregion

        #region 返回第一行第一列的数据 +object ExecuteScalar(string sql, params SqlParameter[] sqlParames)
        /// <summary>
        /// 返回第一行第一列的数据
        /// </summary>
        /// <param name="sql">需要查询的SQL语句</param>
        /// <param name="sqlParames">SQL语句中的参数</param>
        /// <returns>object类型的数据</returns>
        public object ExecuteScalar(string sql, params SqlParameter[] sqlParames)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, this.myConn);

            try
            {
                if (myConn.State == ConnectionState.Closed) myConn.Open();
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddRange(sqlParames);
                object reObj = sqlCommand.ExecuteScalar();
                myConn.Close();
                return reObj;
            }
            catch (Exception ex)
            {
                myConn.Close();
                throw new Exception(ex + "<\r\n>" + sql);
            }
        }
        #endregion

        #region 返回数量 +int Count(string sql)
        public int Count(string sql)
        {
            return Convert.ToInt32(ExecuteScalar(sql));
        }
        #endregion

        #region 返回数量 +int Count(string sql, params SqlParameter[] sqlParames)
        public int Count(string sql, params SqlParameter[] sqlParames)
        {
            return Convert.ToInt32(ExecuteScalar(sql, sqlParames));
        }
        #endregion

        #region 执行SQL语句。返回受影响行数 +int ExecuteNonQuery(string sql)
        public int ExecuteNonQuery(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, this.myConn);
            try
            {
                if (myConn.State == ConnectionState.Closed) myConn.Open();
                int reInt = sqlCommand.ExecuteNonQuery();
                myConn.Close();
                return reInt;
            }
            catch (Exception ex)
            {
                myConn.Close();
                throw new Exception(ex + "<\r\n>" + sql);
            }
        }
        #endregion

        #region 执行SQL语句。返回 DataSet +DataSet ExecuteDataSet(string sql)
        public DataSet ExecuteDataSet(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, this.myConn);
            DataSet retrunDataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            try
            {
                sqlDataAdapter.Fill(retrunDataSet);
                return retrunDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex + "<\r\n>" + sql);
            }
        }
        
 
        public DataSet ExecuteDataSet(string sql,List<string> TableList)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, this.myConn);
            DataSet retrunDataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            try
            {
                int liRow = 0;
                foreach (string tablenale in TableList)
                {
                    if (liRow == 0)
                    {
                        sqlDataAdapter.TableMappings.Add("Table", tablenale);
                    }
                    else
                    {
                        sqlDataAdapter.TableMappings.Add("Table" + Convert.ToString(liRow), tablenale);
                    }

                    liRow = liRow + 1;
                }
                
                sqlDataAdapter.Fill(retrunDataSet);
                return retrunDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex + "<\r\n>" + sql);
            }
        }
        #endregion

        #region 执行SQL语句。返回 DataTable +DataTable ExecuteDataTable(string sql)
        public DataTable ExecuteDataTable(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, this.myConn);
            DataTable retrunDataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            try
            {
                sqlDataAdapter.Fill(retrunDataTable);
                return retrunDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex + "<\r\n>" + sql);
            }
        }
        #endregion

        #region 执行带参数的SQL语句。返回受影响行数 +int ExecuteNonQuery(string sql， params SqlParameter []sqlParames)
        public int ExecuteNonQuery(string sql, params SqlParameter[] sqlParames)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, this.myConn);
            if (sqlParames.Length > 0)
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddRange(sqlParames);
            }
            try
            {
                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }
                int reInt = sqlCommand.ExecuteNonQuery();
                myConn.Close();
                return reInt;
            }
            catch (Exception ex)
            {
                myConn.Close();
                throw new Exception(ex + "<\r\n>" + sql);
            }
        }
        #endregion

        #region 执行带参数的sql + DataSet ExecuteDataSet(string sql, params SqlParameter[] sqlParames)
        /// <summary>
        /// 执行带参数的sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParames"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string sql, params SqlParameter[] sqlParames)
        {
            SqlCommand cmd = new SqlCommand(sql, myConn);
            if (sqlParames.Length > 0)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(sqlParames);
            }
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                sda.Fill(ds); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex + "<\r\n>" + sql); 
            }
            return ds;
        }

        #endregion

        #region 执行带参数的sql + DataTable ExecuteDataTable(string sql, params SqlParameter[] sqlParames)
        /// <summary>
        /// 执行带参数的sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParames"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, params SqlParameter[] sqlParames)
        {
            SqlCommand cmd = new SqlCommand(sql, myConn);
            if (sqlParames.Length > 0)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(sqlParames);
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                sda.Fill(dt); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex + "<\r\n>" + sql);
            }
            return dt;
        }

        #endregion

        #region 执行一个带参数的存储过程，返回 DataSet +DataSet RunProcedure(string commandText, SqlParameter [] commandParameters)
        /// <summary>
        /// 执行一个带参数的存储过程，返回 DataSet
        /// 格式 DataSet ds = ExecuteDataset("GetOrders", new SqlParameter("@prodid", 24));
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public DataSet RunProcedure(string commandText, SqlParameter[] commandParameters)
        {
            //创建一个命令
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = commandText;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = myConn;
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddRange(commandParameters);

            //创建 DataAdapter 和 DataSet
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                sqlCommand.Parameters.Clear();
                //返回结果集
                return ds;
            }
            catch (Exception ex)
            {
                string parasList = "";
                foreach (SqlParameter para in commandParameters)
                {
                    parasList += "<\r\n>@" + para.ParameterName + ":" + para.Value;
                }
                throw new Exception(ex + "<\r\n>" + commandText + parasList);
            }

        }
        #endregion

        #region 执行一个存储过程，不返回结果 +void RunProcedureNoReturn(string commandText, SqlParameter commandParameters)
        public void RunProcedureNoReturn(string commandText, SqlParameter[] commandParameters)
        {
            //创建一个命令

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = commandText;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = myConn;
            sqlCommand.Parameters.AddRange(commandParameters);
            try
            {
                if (myConn.State == ConnectionState.Closed) myConn.Open();
                sqlCommand.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                myConn.Close();
                string parasList = "";
                foreach (SqlParameter para in commandParameters)
                {
                    parasList += "<\r\n>@" + para.ParameterName + ":" + para.Value;
                }
                throw new Exception(ex + "<\r\n>" + commandText + parasList);
            }

        }
        #endregion

         
        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public  SqlDataReader ExecuteReader(string strSQL)
        {
            SqlCommand cmd = new SqlCommand(strSQL, myConn);
            try
            {
                if (myConn.State == ConnectionState.Closed) myConn.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }

        }
    }
}