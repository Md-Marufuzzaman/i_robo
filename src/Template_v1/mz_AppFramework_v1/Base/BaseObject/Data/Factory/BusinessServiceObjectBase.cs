using System;

namespace mz_AppFramework_v1.Base.BaseObject.Data.Factory
{
    public abstract class BusinessServiceObjectBase
    {
        protected abstract DatabaseAccessObjectBase CreateDataObjectFactory();
        protected ConnectionObjectBase DataBaseConnection { get; set; }

        /// <summary>
        /// The Database Connection that will be used to read from and update the Database
        /// </summary>
        ConnectionObjectBase m_DatabaseConnection;

        /// <summary>
        /// The factory used to create Database objects
        /// </summary>
        DatabaseAccessObjectBase m_DataObjectFactory;
        #region Protected Properties

        /// <summary>
        /// The factory used to create Database objects
        /// </summary>
        protected DatabaseAccessObjectBase DataObjectFactory
        {
            get { return m_DataObjectFactory; }
            set { m_DataObjectFactory = value; }
        }

        public bool UseConnectionAndTransaction(ConnectionObjectBase dbConnection)
        {
            m_DatabaseConnection = dbConnection;
            DataBaseConnection = m_DatabaseConnection;
            return true;
        }

        public BusinessServiceObjectBase()
        {
            DataObjectFactory = CreateDataObjectFactory();

        }

        #endregion



    }
}
