namespace mz_AppFramework_v1.Base.BaseObject.Data
{
    using System;
    using System.Data;
    using System.Data.Common;
    using ExceptionServiceObject;
    using ExceptionServiceObject.Interface;
 
    public class ConnectionObjectBase  
    {

        #region Properties
        // Summary:
        //     The underlying Database connection
        public DbConnection connection { get; set; }


        #endregion Properties


        public IHandleException exceptionObject = new HandleException(); 

        public ConnectionObjectBase() { }

        public ConnectionObjectBase(IsolationLevel isolationLevel) { }

        public ConnectionObjectBase(DbConnection connection)
        {
            this.connection = connection;
        }


        #region Connection methods

        /// <summary>
        /// Opens the database connection.
        /// </summary>
        public void Open()
        {
            try
            {
                if (connection != null)
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
            }
            catch (Exception exception)
            {
                 exceptionObject.HandleMyDataLayerException(exception, exception.Message + " An unexpected error occured while trying to open the connection.");
            }
        }

        /// <summary>
        /// Closes the database connection.
        /// </summary>
        public void Close()
        {
            try
            {
                if (connection != null)
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
            catch (Exception exception)
            {
                 exceptionObject.HandleMyDataLayerException(exception, exception.Message + " An unexpected error occured while trying to close the connection.");
            }
        }

        #endregion Connection methods

        //public void Dispose()
        //{
            
        //}
    }
}
