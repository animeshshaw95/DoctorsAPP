using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.DATACONNECTION
{
    public class DataConnection
    {
        #region Stored Procedure Execute Methods With Data Reader

        /// <summary>
        /// Get Data Objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public IEnumerable<T> GetDataObjects<T>(DbDataReader reader) where T : class, new()
        {
            var list = new List<T>();
            try
            {
                if (reader == null)
                    return list;

                HashSet<string> tableColumnNames = null;
                while (reader.Read())
                {
                    tableColumnNames = tableColumnNames ?? CollectColumnNames(reader);
                    var entity = new T();
                    foreach (var propertyInfo in typeof(T).GetProperties())
                    {
                        object retrievedObject = null;
                        if (tableColumnNames.Contains(propertyInfo.Name))
                        {
                            if (reader[propertyInfo.Name] != System.DBNull.Value && reader[propertyInfo.Name] != null)
                            {
                                retrievedObject = reader[propertyInfo.Name];
                                propertyInfo.SetValue(entity, retrievedObject);
                            }
                        }
                    }
                    list.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        /// <summary>
        /// Collect Column Names
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        static HashSet<string> CollectColumnNames(DbDataReader Reader)
        {
            var _CollectedColumnInfo = new HashSet<string>();
            for (int i = 0; i < Reader.FieldCount; i++)
            {
                _CollectedColumnInfo.Add(Reader.GetName(i));
            }
            return _CollectedColumnInfo;
        }

        /// <summary>
        /// Execute Stored Procedure For Reader
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="Con"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public DbDataReader ExecuteStoredProcedureForReader(string commandText, string Con, params object[] Parameters)
        {
            var _Connection = new SqlConnection(Con);
            if (_Connection.State == ConnectionState.Closed)
                _Connection.Open();
            try
            {
                using (var _Cmd = _Connection.CreateCommand())
                {
                    _Cmd.CommandText = commandText;
                    _Cmd.CommandType = CommandType.StoredProcedure;
                    _Cmd.CommandTimeout = 12500000;

                    string exec = EXECGetSPString(commandText, Parameters);

                    if (Parameters != null)
                        foreach (var p in Parameters)
                        {
                            if (p != null)
                                _Cmd.Parameters.Add(p);
                        }
                    var _Reader = _Cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return _Reader;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string EXECGetSPString(string spname, params object[] arr)
        {
            string temp = "Exec " + spname;
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    temp += " " + arr[i] + "  = '" + ((System.Data.SqlClient.SqlParameter)arr[i]).Value + "' , " + Environment.NewLine;
                }
            }
            temp = temp.TrimEnd(new char[] { ',' });
            return temp;
        }

        #endregion
    }
    public sealed class SqlServerParamManager
    {
        IDataParameter _param;

        public SqlServerParamManager()
        {
            // _dataProvider = provider;
        }

        /// <summary>
        /// Gets Parameter for Sproc with default parameter name "Id"
        /// </summary>
        /// <param name="value">parameter object value</param>
        /// <returns></returns>
        public IDataParameter Get(object value)
        {
            return Get("Id", value);
        }

        /// <summary>
        /// Gets Parameter for Sproc with default parameter direction as input & dbtype as string
        /// </summary>
        /// <param name="paramName"> parameter name w/o @</param>
        /// <param name="value">parameter object value</param>
        /// <returns></returns>
        public IDataParameter Get(string paramName, object value)
        {
            return Get(paramName, value, ParameterDirection.Input, DbType.String);
        }

        /// <summary>
        ///  Gets Parameter for Sproc with default paramete dbtype as string
        /// </summary>
        /// <param name="paramName">parameter name w/o @</param>
        /// <param name="value">parameter object value</param>
        /// <param name="direction">parameter direction as input/output</param>
        /// <returns></returns>
        public IDataParameter Get(string paramName, object value, ParameterDirection direction)
        {
            return Get(paramName, value, direction, DbType.String);
        }

        /// <summary>
        ///  Gets Parameter for Sproc
        /// </summary>
        /// <param name="paramName">parameter name w/o @</param>
        /// <param name="value">parameter object value</param>
        /// <param name="direction">parameter direction as input/output</param>
        /// <param name="type">parameter datatype</param>
        /// <returns></returns>
        public IDataParameter Get(string paramName, object value, ParameterDirection direction, DbType type)
        {
            // _param = _dataProvider.GetParameter();
            _param = new SqlParameter();
            _param.ParameterName = paramName;
            _param.Value = value;
            _param.Direction = direction;
            _param.DbType = type;
            return _param as SqlParameter;
        }

        /// <summary>
        /// Gets Parameter for Sproc
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IDataParameter GetNew(string paramName, object value, ParameterDirection direction, SqlDbType type)
        {
            SqlParameter _param = new SqlParameter();
            _param.ParameterName = paramName;
            _param.Value = value;
            _param.Direction = direction;
            _param.SqlDbType = type;
            return _param as SqlParameter;
        }

        /// <summary>
        /// Gets Parameter for Sproc
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="direction"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IDataParameter GetNew(string paramName, ParameterDirection direction, SqlDbType type)
        {
            SqlParameter _param = new SqlParameter();
            _param.ParameterName = paramName;
            _param.Direction = direction;
            _param.SqlDbType = type;
            return _param as SqlParameter;
        }

        /// <summary>
        /// Gets Parameter for Sproc
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="direction"></param>
        /// <param name="type"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        public IDataParameter GetNew(string paramName, ParameterDirection direction, SqlDbType type, int Size)
        {
            SqlParameter _param = new SqlParameter();
            _param.ParameterName = paramName;
            _param.Direction = direction;
            _param.SqlDbType = type;
            _param.Size = Size;
            return _param as SqlParameter;
        }
    }
}
