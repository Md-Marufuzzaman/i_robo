using System;
using System.Data;
using System.Data.Common;
using ExceptionServiceObject.Interface;
using ExceptionServiceObject;

namespace mz_AppFramework_v1.Base.BaseObject.Data.Factory
{
    public abstract class DatabaseAccessObjectBase
    {
        public IHandleException exceptionObject = new HandleException();

        /// <summary>
        /// Gets or sets the database connection.
        /// </summary>
        public abstract string connectionString { get; set; }
        /// <summary>
        /// Gets or sets the command timeout.
        /// </summary>
        public abstract int commandTimeout { get; set; }

        #region Start abstract methods / functions
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract DbConnection CreateConnection();
        /// <summary>
        /// Creates a new connection.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        /// <returns>DBConnection.</returns>
        public abstract DbConnection CreateConnection(string connectionString);
        /// <summary>
        /// Creates a new Data Adapter.
        /// </summary>
        /// <returns>DbDataAdapter.</returns>
        public abstract DbDataAdapter CreateDataAdapter();
        public abstract DbCommand CreateCommand();
        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="commandText">Command text.</param>
        /// <param name="connection">DbConnection.</param>
        /// <param name="transaction">DbTransaction.</param>
        /// <returns>DbCommand.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public abstract DbCommand CreateCommand(string commandText, DbConnection connection, DbTransaction transaction);
        /// <summary>
        /// Creates a new stored procedure command.
        /// </summary>
        /// <param name="procedureName">Procedure name.</param>
        /// <param name="connection">DbConnection.</param>
        /// <param name="transaction">DbTransaction.</param>
        /// <returns>DbCommand.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public abstract DbCommand CreateStoredProcedureCommand(string procedureName, DbConnection connection, DbTransaction transaction);
        /// <summary>
        /// Adds a return value parameter to the command object.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="dbType">DbType.</param>
        public abstract void AddReturnValueParameter(DbCommand command, string parameterName, DbType dbType);
        /// <summary>
        /// Adds a return value parameter to the command object.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        public abstract void AddReturnValueParameter(DbCommand command, string parameterName, DbType dbType, int size);
        /// <summary>
        /// Adds a return value parameter to the command object.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        public abstract void AddReturnValueParameter(DbCommand command, string parameterName, DbType dbType, byte precision, byte scale);
        /// <summary>
        /// Adds a return value parameter to the command object.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        protected abstract void AddReturnValueParameter(DbCommand command, string parameterName, DbType dbType, int? size, byte? precision, byte? scale);
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
        protected abstract void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType? dbType, string sourceColumn, int? size, byte? precision, byte? scale);
        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        public abstract void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue);
        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        public abstract void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType);
        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="sourceColumn">Source column.</param>
        public abstract void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, string sourceColumn);
        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        public abstract void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, int size);
        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        /// <param name="sourceColumn">Source column.</param>
        public abstract void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, int size, string sourceColumn);
        /// <summary>
        /// Adds an input parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        public abstract void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, byte precision, byte scale);
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
        public abstract void CreateInPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, string sourceColumn, byte precision, byte scale);
        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        public abstract void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue);
        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        public abstract void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType);
        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="sourceColumn">Source column.</param>
        public abstract void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, string sourceColumn);
        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        public abstract void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, int size);
        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="size">Size.</param>
        /// <param name="sourceColumn">Source column.</param>
        public abstract void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, int size, string sourceColumn);
        /// <summary>
        /// Adds an output parameter.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="dbType">DbType.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="scale">Scale.</param>
        public abstract void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, byte precision, byte scale);
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
        public abstract void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType dbType, string sourceColumn, byte precision, byte scale);
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
        protected abstract void CreateOutPutParameter(DbCommand command, string parameterName, object parameterValue, DbType? dbType, string sourceColumn, int? size, byte? precision, byte? scale);
        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="connection">DbConnection.</param>
        /// <returns>DbTransaction.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public abstract DbTransaction CreateTransaction(DbConnection connection);
        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="connection">DbConnection.</param>
        /// <param name="transactionName">The name of the transaction.</param>
        /// <returns>DbTransaction.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public abstract DbTransaction CreateTransaction(DbConnection connection, string transactionName);
        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="connection">DbConnection.</param>
        /// <param name="isolationLevel">The isolation level to use.</param>
        /// <returns>DbTransaction.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public abstract DbTransaction CreateTransaction(DbConnection connection, IsolationLevel isolationLevel);
        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="connection">DbConnection.</param>
        /// <param name="isolationLevel">The isolation level to use.</param>
        /// <param name="transactionName">The name of the transaction.</param>
        /// <returns>DbTransaction.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public abstract DbTransaction CreateTransaction(DbConnection connection, IsolationLevel? isolationLevel, string transactionName);
        /// <summary>
        /// Gets a parameter value.
        /// </summary>
        /// <param name="command">DbCommand.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <returns>Parameter value as an object.</returns>
        /// <exception cref="DbHelperException">DbHelperException.</exception>
        public abstract object GetParameterValue(DbCommand command, string parameterName);

        #endregion End abstract methods / functions
    }
}
