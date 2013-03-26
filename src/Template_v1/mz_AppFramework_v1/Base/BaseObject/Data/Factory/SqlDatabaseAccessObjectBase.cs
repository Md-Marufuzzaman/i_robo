using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using mz_AppFramework_v1.Base.BaseObject.Data;
using ExceptionServiceObject.Interface;
using ExceptionServiceObject;

namespace mz_AppFramework_v1.Base.BaseObject.Data.Factory
{
    public class SqlDatabaseAccessObjectBase : DatabaseAccessObjectBase
    {
        private const int COMMAND_TIMEOUT = 30;
        private const IsolationLevel DEFAULT_ISOLATION_LEVEL = IsolationLevel.ReadCommitted;


        #region Enums

        /// <summary>
        /// Enum for all available databases.
        /// </summary>
        protected enum Databases
        {
            /// <summary>
            /// Robo_v1 Database
            /// </summary>
            Robo_v1
        }

        #endregion Enums

        #region Members and Constants

        private string _tableName = string.Empty;
        private DbDataAdapter _dataAdapter;
        private DbDataReader _dataReader;
        private DbConnection _connection;
        //private DbCommand _insertCommand;
        //private DbCommand _deleteCommand;
        //private DbCommand _updateCommand;
        private DbCommand _command;
        //private Databases _database = Databases.Robo_v1;
        //private bool _initialising;
        //private string _appSettingsKeyPrefix;

        private const Databases DEFAULT_DATABASE = Databases.Robo_v1;

        #endregion Members and Constants

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public override string connectionString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public override int commandTimeout { get; set; }
        /// <summary>
        /// Gets or sets the DBConnection.
        /// </summary>
        private DbConnection connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }
        /// <summary>
        /// Gets or sets the current command object
        /// </summary>
        private DbCommand command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
            }
        }
        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        protected string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        /// <summary>
        /// Gets the DBDataAdapter.
        /// </summary>
        protected DbDataAdapter DataAdapter
        {
            get
            {
                return _dataAdapter;
            }
            private set
            {
                _dataAdapter = value;
            }
        }

        /// <summary>
        /// Gets the DbDataReader.
        /// </summary>
        protected DbDataReader DataReader
        {
            get
            {
                return _dataReader;
            }
            private set
            {
                _dataReader = value;
            }
        }

        #endregion Properties


        public SqlDatabaseAccessObjectBase() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlDatabaseAccessObjectBase(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SqlDatabaseAccessObjectBase CreateDataObjectFactory()
        {
            return new SqlDatabaseAccessObjectBase();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public SqlDatabaseAccessObjectBase CreateDataObjectFactory(string connectionString)
        {
            return new SqlDatabaseAccessObjectBase(connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            DbConnection connection = null;
            return connection = new SqlConnection(this.connectionString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public override DbConnection CreateConnection(string connectionString)
        {
            DbConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (Exception exception)
            {
                exceptionObject.HandleMyDataLayerException(exception, exception.Message + " An error occured while creating a new SQL connection.");
            }

            return connection;
        }

        /// <summary>
        /// Creates a new Data Adapter.
        /// </summary>
        /// <returns>DbDataAdapter.</returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }
        public override DbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="commandText">Command text.</param>
        /// <param name="connection">DbConnection.</param>
        /// <param name="transaction">DbTransaction.</param>
        /// <returns>DbCommand.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public override DbCommand CreateCommand(string commandText, DbConnection connection, DbTransaction transaction)
        {
            DbCommand command = null;

            try
            {
                command = connection.CreateCommand();
                command.CommandText = commandText;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = commandTimeout;

                if (transaction != null)
                {
                    command.Transaction = transaction;
                    command.Connection = transaction.Connection;
                }
            }
            catch (Exception exception)
            {
                  exceptionObject.HandleMyDataLayerException (exception, exception.Message + " An error occured while creating a new command.");
            }

            return command;
        }
        /// <summary>
        /// Creates a new stored procedure command.
        /// </summary>
        /// <param name="procedureName">Procedure name.</param>
        /// <param name="connection">DbConnection.</param>
        /// <param name="transaction">DbTransaction.</param>
        /// <returns>DbCommand.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        /// 
        public override DbCommand CreateStoredProcedureCommand(string procedureName, DbConnection connection, DbTransaction transaction)
        {
            DbCommand command=null;

            try
            {
                if (!procedureName.StartsWith("["))
                    procedureName = "[" + procedureName;

                if (!procedureName.EndsWith("["))
                    procedureName += "]";

                command = connection.CreateCommand();
                command.CommandText = procedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = commandTimeout;

                if (transaction != null)
                {
                    command.Transaction = transaction;
                    command.Connection = transaction.Connection;
                }
            }
            catch (Exception exception)
            {
                exceptionObject.HandleMyDataLayerException(exception, exception.Message + " An error occured while creating a new command.");
            }

            return command;
        }

         #region Start DbParameter
        /// <summary>
        /// Adds a return value parameter to the command object.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="dbType">DbType.</param>
        public override void AddReturnValueParameter(DbCommand command, string parameterName, DbType dbType)
        {
            AddReturnValueParameter(command, parameterName, dbType, null, null, null);
        }
        /// <summary>
        /// Adds a return value parameter to the command object.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        public override void AddReturnValueParameter(DbCommand command, string parameterName, DbType dbType, int size)
        {
            AddReturnValueParameter(command, parameterName, dbType, size, null, null);
        }
        /// <summary>
        /// Adds a return value parameter to the command object.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        public override void AddReturnValueParameter(DbCommand command, string parameterName, DbType dbType, byte precision, byte scale)
        {
            AddReturnValueParameter(command, parameterName, dbType, null, precision, scale);
        }

        /// <summary>
        /// Adds a return value parameter to the command object.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        protected override void AddReturnValueParameter(DbCommand command, string parameterName, DbType dbType, int? size, byte? precision, byte? scale)
        {
            parameterName = GetParameterName(parameterName);
            SqlCommand sqlCommand = (SqlCommand)command;
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;
            parameter.Direction = ParameterDirection.ReturnValue;
            parameter.DbType = dbType;

            if (size.HasValue)
                parameter.Size = size.Value;

            if (precision.HasValue)
                parameter.Precision = precision.Value;

            if (scale.HasValue)
                parameter.Scale = scale.Value;

            sqlCommand.Parameters.Add(parameter);
        }

        #region Start adding Input parameter
        
        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="sourceColumn">Source column.</param>
        /// <param name="size">Size.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        protected override void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType? dbType, string sourceColumn, int? size, byte? precision, byte? scale)
        {
            parameterName = GetParameterName(parameterName);
            SqlCommand sqlCommand = (SqlCommand)command;
            SqlParameter parameter = new SqlParameter();
            parameter.Direction = ParameterDirection.Input;
            parameter.ParameterName = parameterName;
            SetParameterValue(parameter, parameterValue);

            if (dbType.HasValue)
                parameter.DbType = dbType.Value;

            if (!string.IsNullOrEmpty(sourceColumn))
                parameter.SourceColumn = sourceColumn;

            if (size.HasValue)
                parameter.Size = size.Value;

            if (precision.HasValue)
                parameter.Precision = precision.Value;

            if (scale.HasValue)
                parameter.Scale = scale.Value;

            sqlCommand.Parameters.Add(parameter);
        }


        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        public override void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue)
        {
            CreateInPutParameter(command, parameterName, parameterValue, null, null, null, null, null);
        }

        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        public override void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType)
        {
            CreateInPutParameter(command, parameterName, parameterValue, dbType, null, null, null, null);
        }

        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="sourceColumn">Source column.</param>
        public override void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, string sourceColumn)
        {
            CreateInPutParameter(command, parameterName, parameterValue, dbType, sourceColumn, null, null, null);
        }

        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        public override void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, int size)
        {
            CreateInPutParameter(command, parameterName, parameterValue, dbType, null, size, null, null);
        }

        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        /// <param name="sourceColumn">Source column.</param>
        public override void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, int size, string sourceColumn)
        {
            CreateInPutParameter(command, parameterName, parameterValue, dbType, sourceColumn, size, null, null);
        }

        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        public override void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, byte precision, byte scale)
        {
            CreateInPutParameter(command, parameterName, parameterValue, dbType, null, null, precision, scale);
        }

        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="sourceColumn">Source column.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        public override void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, string sourceColumn, byte precision, byte scale)
        {
            CreateInPutParameter(command, parameterName, parameterValue, dbType, sourceColumn, null, precision, scale);
        }

        #endregion End adding Input parameter

        #region Start adding output parameter

        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        public override void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue)
        {
            CreateOutPutParameter(command, parameterName, parameterValue, null, null, null, null, null);
        }

        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        public override void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType)
        {
            CreateOutPutParameter(command, parameterName, parameterValue, dbType, null, null, null, null);
        }

        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="sourceColumn">Source column.</param>
        public override void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, string sourceColumn)
        {
            CreateOutPutParameter(command, parameterName, parameterValue, dbType, sourceColumn, null, null, null);
        }

        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        public override void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, int size)
        {
            CreateOutPutParameter(command, parameterName, parameterValue, dbType, null, size, null, null);
        }

        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        /// <param name="sourceColumn">Source column.</param>
        public override void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, int size, string sourceColumn)
        {
            CreateOutPutParameter(command, parameterName, parameterValue, dbType, sourceColumn, size, null, null);
        }

        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        public override void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, byte precision, byte scale)
        {
            CreateOutPutParameter(command, parameterName, parameterValue, dbType, null, null, precision, scale);
        }

        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="sourceColumn">Source column.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        public override void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, string sourceColumn, byte precision, byte scale)
        {
            CreateOutPutParameter(command, parameterName, parameterValue, dbType, sourceColumn, null, precision, scale);
        }

        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        /// <param name="sourceColumn">Source column.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        protected override void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType? dbType, string sourceColumn, int? size, byte? precision, byte? scale)
        {
            parameterName = GetParameterName(parameterName);
            SqlCommand cmd = (SqlCommand)command;
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;
            SetParameterValue(parameter, parameterValue);
            parameter.Direction = ParameterDirection.InputOutput;

            if (dbType.HasValue)
                parameter.DbType = dbType.Value;

            if (!string.IsNullOrEmpty(sourceColumn))
                parameter.SourceColumn = sourceColumn;

            if (size.HasValue)
                parameter.Size = size.Value;

            if (precision.HasValue)
                parameter.Precision = precision.Value;

            if (scale.HasValue)
                parameter.Scale = scale.Value;

            cmd.Parameters.Add(parameter);
        }

        #endregion End adding output parameter

        /// <summary>
        /// Checks whether a parameter exists.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <returns>True if found, otherwise false.</returns>
        public bool CheckParameterExists(DbCommand command, string parameterName)
        {
            parameterName = GetParameterName(parameterName);

            foreach (SqlParameter parameter in command.Parameters)
            {
                if (parameter.ParameterName == parameterName)
                    return true;
            }

            return false;
        }


        #endregion End DbParameter

        #region Private methods

        /// <summary>
        /// Returns the SQL parameter name for the given parameter name, prefixes it with '@'.
        /// </summary>
        /// <param name="parameterName">Parameter name.</param>
        /// <returns>string.</returns>
        private string GetParameterName(string parameterName)
        {
            if (!parameterName.StartsWith("@"))
                parameterName = "@" + parameterName;
            return parameterName;
        }

        /// <summary>
        /// Sets the value of a parameter.
        /// </summary>
        /// <param name="parameter">SqlParameter.</param>
        /// <param name="parameterValue">Parameter value.</param>
        private void SetParameterValue(SqlParameter parameter, object parameterValue)
        {
            if (parameterValue == null)
            {
                parameter.IsNullable = true;
                parameterValue = DBNull.Value;
            }
            else if (parameterValue is DateTime && ((DateTime)parameterValue) == DateTime.MinValue)
                parameterValue = System.Data.SqlTypes.SqlDateTime.MinValue;

            parameter.Value = parameterValue;
        }

        #endregion Private methods

        /// <summary>
        /// Gets a parameter value.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <returns>Parameter value as an object.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public override object GetParameterValue(DbCommand command, string parameterName)
        {
            object paramterValue = null;

            try
            {
                parameterName = GetParameterName(parameterName);
                SqlCommand sqlCommand = (SqlCommand)command;
                SqlParameter parameter = sqlCommand.Parameters[parameterName];
                paramterValue = parameter.Value;
            }
            catch (Exception exception)
            {
                exceptionObject.HandleMyDataLayerException(exception, "Could not get the value of parameter '" + parameterName + "'. " + exception.Message);

            }

            return paramterValue;
        }

        #region Transaction



        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="connection">DbConnection.</param>
        /// <returns>DbTransaction.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public override DbTransaction CreateTransaction(DbConnection connection)
        {
            return CreateTransaction(connection, null, string.Empty);
        }

        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="connection">DbConnection.</param>
        /// <param name="transactionName">The name of the transaction.</param>
        /// <returns>DbTransaction.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public override DbTransaction CreateTransaction(DbConnection connection, string transactionName)
        {
            return CreateTransaction(connection, null, transactionName);
        }

        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="connection">DbConnection.</param>
        /// <param name="isolationLevel">The isolation level to use.</param>
        /// <returns>DbTransaction.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public override DbTransaction CreateTransaction(DbConnection connection, IsolationLevel isolationLevel)
        {
            return CreateTransaction(connection, isolationLevel, string.Empty);
        }

        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="connection">DbConnection.</param>
        /// <param name="isolationLevel">The isolation level to use.</param>
        /// <param name="transactionName">The name of the transaction.</param>
        /// <returns>DbTransaction.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public override DbTransaction CreateTransaction(DbConnection connection, IsolationLevel? isolationLevel, string transactionName)
        {
            DbTransaction transaction = null;
            transactionName = transactionName.Trim();

            try
            {
                // open connection and begin transaction
                SqlConnection sqlConnection = (SqlConnection)connection;
                sqlConnection.Open();

                if (isolationLevel.HasValue)
                    transaction = sqlConnection.BeginTransaction((IsolationLevel)isolationLevel, transactionName);
                else
                    transaction = sqlConnection.BeginTransaction(DEFAULT_ISOLATION_LEVEL, transactionName);
            }
            catch (Exception exception)
            {
                exceptionObject.HandleMyDataLayerException(exception, exception.Message + " An error occured while creating a new transaction.");

            }

            return transaction;
        }

        #endregion Transaction

        #region Disposal methods

        /// <summary>
        /// Releases a command object
        /// </summary>
        protected void ReleaseCommand()
        {
            ReleaseCommand(command);
        }

        /// <summary>
        /// Releases a command object
        /// </summary>
        /// <param name="command">DbCommand</param>
        protected void ReleaseCommand(DbCommand command)
        {
            if (command != null)
                command.Dispose();
        }

        /// <summary>
        ///  Releases the reader object
        /// </summary>
        protected void ReleaseReader()
        {
            if (DataReader != null)
            {
                if (!DataReader.IsClosed)
                    DataReader.Close();
                DataReader.Dispose();
            }

            //CloseConnection();
        }

        /// <summary>
        /// Releases the connection
        /// </summary>
        protected void ReleaseConnection()
        {
            if (connection != null)
            {
                //CloseConnection();
                connection.Dispose();
            }
        }

        /// <summary>
        /// Releases the data adapter
        /// </summary>
        protected void ReleaseDataAdapter()
        {
            if (DataAdapter != null)
                DataAdapter.Dispose();
        }


        #endregion Disposal methods

    }
}
