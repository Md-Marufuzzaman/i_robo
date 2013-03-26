using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonServiceObject.Base.BaseObject;
using mz_AppFramework_v1.Base.BaseObject.Data;
using mz_AppFramework_v1.Base.BaseObject.Data.Factory;


namespace DataAccessObject.Adapters.Base.BaseObject.DAO
{

    public abstract class DataAccessObject
    {
        #region Events

        /// <summary>
        /// The RowUpdating event is raised just before an Update to a row begins
        /// </summary>
        public event RowUpdatingEventHandler RowUpdating;

        /// <summary>
        /// The RowUpdated event message is raised after an Update to a row has completed
        /// </summary>
        public event RowUpdatedEventHandler RowUpdated;

        #endregion


        #region Constants



        #endregion


        #region Fields

        /// <summary>
        /// The factory used to create Database objects
        /// </summary>
        DatabaseAccessObjectBase m_DataObjectFactory;

        /// <summary>
        /// The Database Connection that will be used to read from and update the Database
        /// </summary>
        ConnectionObjectBase m_DatabaseConnection;

        /// <summary>
        /// The DataAdapter used to update the database
        /// </summary>
        DbDataAdapter m_DbDataAdapter;

        /// <summary>
        /// The IDbDataAdapter interface used to specify the Commands
        /// </summary>
        IDbDataAdapter m_AdapterCommands;

        /// <summary>
        /// The name of the stored procedure that is used to insert a new row
        /// </summary>
        protected string actionCommandName;

        /// <summary>
        /// The name of the stored procedure that is used to insert a new row
        /// </summary>
        protected string InsertCommandName;

        /// <summary>
        /// The name of the stored procedure that is used to update an existing row
        /// </summary>
        protected string UpdateCommandName;

        /// <summary>
        /// The name of the stored procedure that is used to delete a row
        /// </summary>
        protected string DeleteCommandName;

        /// <summary>
        /// The name of the stored procedure that is used to retrieve all rows
        /// </summary>
        protected string SelectAllCommandName;


        static protected String ACT_NEW = "NEW";
        static protected String ACT_UPDATE = "UPDATE";
        static protected String ACT_DELETE = "DELETE";

        public const int DB_NULL_INT = -2147483648;
        public const int DB_NULL_FLOAT = -2147483648;
        public const String DB_NULL_STR = "?";
        public const String DB_NULL_CHAR = "?";
        public static DateTime DB_NULL_DATE = new DateTime(1970, 01, 01);




        #endregion


        #region Constructors

        /// <summary>
        /// Creates a new DataAccess object
        /// </summary>
        public DataAccessObject()
        {
            DataObjectFactory = CreateDataObjectFactory();

            m_DbDataAdapter = (DbDataAdapter)DataObjectFactory.CreateDataAdapter();
            m_AdapterCommands = (IDbDataAdapter)m_DbDataAdapter;

            //
            // Hook the RowUpdating and RowUpdated events
            //
            if (m_DbDataAdapter is SqlDataAdapter)
            {
                SqlDataAdapter SqlAdapter = (SqlDataAdapter)m_DbDataAdapter;
                SqlAdapter.RowUpdating += new SqlRowUpdatingEventHandler(DataAdapter_SqlRowUpdating);
                SqlAdapter.RowUpdated += new SqlRowUpdatedEventHandler(DataAdapter_SqlRowUpdated);
            }
            else if (m_DbDataAdapter is OleDbDataAdapter)
            {
                OleDbDataAdapter OleDbAdapter = (OleDbDataAdapter)m_DbDataAdapter;
                OleDbAdapter.RowUpdating += new OleDbRowUpdatingEventHandler(DataAdapter_OleDbRowUpdating);
                OleDbAdapter.RowUpdated += new OleDbRowUpdatedEventHandler(DataAdapter_OleDbRowUpdated);

            }
        }


        #endregion


        #region Protected Properties

        /// <summary>
        /// The factory used to create Database objects
        /// </summary>
        protected DatabaseAccessObjectBase DataObjectFactory
        {
            get { return m_DataObjectFactory; }
            set { m_DataObjectFactory = value; }
        }


        /// <summary>
        /// The underlying DbDataAdapter
        /// </summary>
        protected DbDataAdapter Adapter
        {
            get { return m_DbDataAdapter; }
        }


        /// <summary>
        /// The Commands used by the underlying DataAdapter
        /// </summary>
        protected IDbDataAdapter AdapterCommands
        {
            get { return m_AdapterCommands; }
        }


        #endregion


        #region Public Properties

        /// <summary>
        /// The Database Connection that will be used to read from and update the Database
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        public ConnectionObjectBase DbConnection
        {
            get { return m_DatabaseConnection; }
        }


        #endregion


        #region Private Methods

        /// <summary>
        /// Creates an instance of a factory that is used to create Database objects
        /// </summary>
        /// <returns>A DatabaseAccessObjectFactory instance </returns>
        protected abstract DatabaseAccessObjectBase CreateDataObjectFactory();


        /// <summary>
        /// Executes the specified command and loads the resulting rows into a DataSet 
        /// </summary>
        /// <param name="dataSetFill">The DataSet to place the returned rows into</param>
        /// <param name="fillCommand">The command that will return rows to place into the DataTable</param>
        /// <returns>A count of the number of rows added</returns>
        protected virtual int LoadFromCommand(DataSet dataSetFill, SqlCommand fillCommand)
        {
            AdapterCommands.SelectCommand = fillCommand;

            return Adapter.Fill(dataSetFill);
        }


        /// <summary>
        /// Adds parameters representing the columns in the  
        /// new row to the Insert Command
        /// </summary>
        /// <param name="insertCommand">The command to add the parameters to</param>
        protected virtual void AddInsertCommandParameters(SqlCommand insertCommand)
        {
        }


        /// <summary>
        /// Adds parameters representing the columns in the 
        /// updated row to the Update Command
        /// </summary>
        /// <param name="updateCommand">The Command to add the parameters to</param>
        protected virtual void AddUpdateCommandParameters(SqlCommand updateCommand)
        {
        }


        /// <summary>
        /// Adds parameters representing the columns in the
        /// deleted row to the Delete Command
        /// </summary>
        /// <param name="deleteCommand">The Command to add the parameters to</param>
        protected virtual void AddDeleteCommandParameters(SqlCommand deleteCommand)
        {
        }


        /// <summary>
        /// Raises the RowUpdating event
        /// </summary>
        /// <param name="e">The RowUpdatingEventArgs for the event</param>
        protected virtual void OnRowUpdating(RowUpdatingEventArgs e)
        {
            if (RowUpdating != null)
            {
                RowUpdating(this, e);
            }
        }

        /// <summary>
        /// Raises the RowUpdated event
        /// </summary>
        /// <param name="e">The RowUpdatingEventArgs for the event</param>
        protected virtual void OnRowUpdated(RowUpdatedEventArgs e)
        {
            if (RowUpdated != null)
            {
                RowUpdated(this, e);
            }
        }


        #endregion


        #region Event Handlers

        /// <summary>
        /// Handles the RowUpdating Event from a SqlDataAdapter 
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event arguments</param>
        private void DataAdapter_SqlRowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            OnRowUpdating(e);
        }

        /// <summary>
        /// Handles the RowUpdated Event from a SqlDataAdapter 
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void DataAdapter_SqlRowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            OnRowUpdated(e);
        }



        /// <summary>
        /// Handles the RowUpdating Event from a OleDbDataAdapter
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void DataAdapter_OleDbRowUpdating(object sender, OleDbRowUpdatingEventArgs e)
        {
            OnRowUpdating(e);
        }


        /// <summary>
        /// Handles the RowUpdated Event from a OleDbDataAdapter
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The event arguments</param>
        private void DataAdapter_OleDbRowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            OnRowUpdated(e);
        }


        #endregion


        #region Public Methods

        /// <summary>
        /// Specifies the Database connection to use for any Data Access operations
        /// </summary>
        /// <param name="dbConnection">the Database connection to use for any Data Access operations</param>
        /// <returns>true on success, false otherwise</returns>
        public bool UseConnectionAndTransaction(ConnectionObjectBase dbConnection)
        {
            m_DatabaseConnection = dbConnection;

            return true;
        }


        #endregion


        #region IDataAdapter Implementation

        /// <summary>
        /// Adds a empty DataTable to the specified DataSet 
        /// and configures the schema to match that in the data source 
        /// based on the specified SchemaType.
        /// </summary>
        /// <param name="dataSetSchema">The DataSet to add the schema to</param>
        /// <param name="schemaType">One of the SchemaType values</param>
        /// <returns>An array of DataTable objects that contain schema information</returns>
        public virtual DataTable[] FillSchema(DataSet dataSetSchema, SchemaType schemaType)
        {
            return Adapter.FillSchema(dataSetSchema, schemaType);
        }


        /// <summary>
        /// Gets the parameters used when executing the SELECT statement
        /// </summary>
        /// <returns>An array of IDataParameter objects</returns>
        public virtual IDataParameter[] GetFillParameters()
        {
            return Adapter.GetFillParameters();
        }


        /// <summary>
        /// Fill the DataSet with all rows
        /// </summary>
        /// <param name="dataSetFill">The DataSet to fill</param>
        /// <returns>A count of the rows added to the DataSet</returns>
        public virtual int Fill(DataSet dataSetFill)
        {
            return 0;
        }


        ///// <summary>
        ///// Fill the DataSet by Query Definition
        ///// </summary>
        ///// <param name="dataSetFill">The DataSet to fill</param>
        ///// <param name="queryDefinition">An Query object that defines the the query</param>
        ///// <returns>A count of the rows added to the DataSet</returns>
        //public virtual int FillByQuery(DataSet dataSetFill, Query queryDefinition)
        //{
        //    return 0;
        //}


        /// <summary>
        /// Calls the respective INSERT, UPDATE, or DELETE statements 
        /// for each inserted, updated, or deleted row in the specified DataSet
        /// </summary>
        /// <param name="dataSetUpdate">The DataSet used to update the data source</param>
        /// <returns>The number of rows successfully updated from the DataSet</returns>
        public virtual int ExecuteInsertCommand(DataSet dataSetUpdate)
        {
            return 0;
        }


        /// <summary>
        /// Indicates or specifies whether unmapped source tables or columns are passed with 
        /// their source names in order to be filtered or to raise an error
        /// </summary>
        [DefaultValue(MissingMappingAction.Passthrough)]
        public MissingMappingAction MissingMappingAction
        {
            get { return m_DbDataAdapter.MissingMappingAction; }
            set { m_DbDataAdapter.MissingMappingAction = value; }
        }


        /// <summary>
        /// Indicates or specifies whether missing source tables, columns, and their 
        /// relationships are added to the data set schema, ignored, or cause an error to be raised
        /// </summary>
        [DefaultValue(MissingSchemaAction.Add)]
        public MissingSchemaAction MissingSchemaAction
        {
            get { return m_DbDataAdapter.MissingSchemaAction; }
            set { m_DbDataAdapter.MissingSchemaAction = value; }
        }


        /// <summary>
        /// Indicates how a source table is mapped to a data set table
        /// </summary>
        [Browsable(false)]
        public virtual ITableMappingCollection TableMappings
        {
            get { return m_DbDataAdapter.TableMappings; }
        }
        /// <summary>
        /// Executes the specified command and loads the resulting rows into a DataSet 
        /// </summary>
        /// <param name="dataSetFill">The DataSet to place the returned rows into</param>
        /// <param name="fillCommand">The command that will return rows to place into the DataTable</param>
        /// <returns>A count of the number of rows added</returns>
        //protected virtual int LoadFromCommand(DataSet dataSetFill, SqlCommand fillCommand)
        protected virtual int ExecuteCommand
            (
              DataTable dataTableFill
            , SqlCommand fillCommand
            )
        {
            AdapterCommands.SelectCommand = fillCommand;
            return Adapter.Fill(dataTableFill);
        }

        #endregion


    }
}
