using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using CommonServiceObject.Base.BaseObject;
using DataModelObject.ADO.Reference.Miscellaneous;
using mz_AppFramework_v1.Base.BaseObject.Data.Factory;
using DataAccessObject.Adapters.Base.BaseObject.DAO;
using mz_AppFramework_v1.Base.BaseObject.Data;
using System.Data.Common;

namespace DataAccessObject.Adapters.Base.BaseObject.DAO.Miscellaneous
{
    #region Comments
    /// <summary>
    /// T_TEMPLATE Class.
    /// </summary>
    /// <remarks>
    /// <h3>Changes</h3>
    /// <list type="table">
    /// 	<listheader>
    /// 		<th>Author: Md. Marufuzzaman</th>
    /// 		<th>Date</th>
    /// 		<th>Details</th>
    /// 	</listheader>
    /// 	<item>
    /// 		<term></term>
    /// 		<description>5/26/2012</description>
    /// 		<description>Created</description>
    /// 	</item>
    /// </list>
    /// </remarks>
    #endregion


    public class T_TEMPLATEDataAdapterBase : DataAccessObject
    {
        #region Constants

        #endregion

        #region Fields

        #endregion

        /// <summary>
        /// Initializes Properties of the T_TEMPLATE class.
        /// </summary>

        #region Properties
        /// <summary>
        /// Gets or sets the ct_robo_v1_rec_no value.
        /// </summary>
        public virtual Int32 ct_robo_v1_rec_no { get; set; }

        /// <summary>
        /// Gets or sets the id_robo_v1_key value.
        /// </summary>
        public virtual String id_robo_v1_key { get; set; }

        /// <summary>
        /// Gets or sets the dtt_mod value.
        /// </summary>
        public virtual DateTime dtt_mod { get; set; }

        /// <summary>
        /// Gets or sets the is_active value.
        /// </summary>
        public virtual Boolean is_active { get; set; }
        #endregion

        #region protected Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new (no-args) instance of the T_TEMPLATE class.
        /// </summary>
        public T_TEMPLATEDataAdapterBase(ConnectionObjectBase connection)
            : this()
        {
            UseConnectionAndTransaction(connection);
        }

        /// <summary>
        /// Initializes a new instance of the T_TEMPLATE class.
        /// </summary>
        public T_TEMPLATEDataAdapterBase()
            : base()
        {


            actionCommandName = "ACT_?";
            InsertCommandName = "";
            UpdateCommandName = "";
            DeleteCommandName = "";
            DatabaseAccessObjectBase DataObjectFactory = CommonObjectCreator.CreateDataObjectFactory();

            //
            // Map the default table name of "Table" to the strongly typed DataTable 
            //
            // Adapter.TableMappings.Add("Table", "T_TEMPLATE");
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the T_TEMPLATE class.
        /// </summary>

        public List<T_TEMPLATE> SEL_template(T_TEMPLATE templateObject)
        {
            int iRowAffected = -1;
            string skey = string.Empty;
            DataTable dataTableFill = new DataTable();
            List<T_TEMPLATE> listT_TEMPLATE = new List<T_TEMPLATE>();

            try
            {
                DataObjectFactory.CreateConnection();
                DbConnection.Open();
                DbCommand sqlCommand;
                sqlCommand = DataObjectFactory.CreateStoredProcedureCommand("SEL_template", this.DbConnection.connection, null);
                DataObjectFactory.CreateInPutParameter(sqlCommand, "@ct_page_index", templateObject.ct_page_index);
                DataObjectFactory.CreateInPutParameter(sqlCommand, "@ct_page_size", templateObject.ct_page_size);
                DataObjectFactory.CreateOutPutParameter(sqlCommand, "@ct_row_count", templateObject.ct_row_count);
                DataObjectFactory.CreateOutPutParameter(sqlCommand, "@ct_page_count", templateObject.ct_page_count);

                iRowAffected = ExecuteCommand(dataTableFill, (SqlCommand)sqlCommand);

                if (iRowAffected > 0)
                {
                    T_TEMPLATE template = new T_TEMPLATE();

                    listT_TEMPLATE = template.GetT_TEMPLATEDetails(dataTableFill);
                }
                sqlCommand.Dispose();
            }
            catch (Exception exception)
            {
                throw exception;
            }


            DbConnection.Close();

            return listT_TEMPLATE;
        }

        public int INS_template
            (
                T_TEMPLATE templateObject
            )
        {
            int iRowAffected = -1;
            string skey = string.Empty;

            try
            {
                DataObjectFactory.CreateConnection();
                DbConnection.Open();
                DbCommand sqlCommand;
                sqlCommand = DataObjectFactory.CreateStoredProcedureCommand("INS_robo_v1", this.DbConnection.connection, null);
                //DataObjectFactory.CreateInPutParameter(sqlCommand, "@tx_action", templateObject.tx_action);
                //DataObjectFactory.CreateOutPutParameter(sqlCommand, "@id_robo_v1_key", templateObject.id_robo_v1_key, DbType.AnsiString, 50);
                //DataObjectFactory.CreateInPutParameter(sqlCommand, "@dtt_mod", templateObject.dtt_mod);
                //DataObjectFactory.CreateInPutParameter(sqlCommand, "@is_active", templateObject.is_active);
                iRowAffected = sqlCommand.ExecuteNonQuery();

                if (iRowAffected > 0)
                {
                    skey = (string)DataObjectFactory.GetParameterValue(sqlCommand, "@id_robo_v1_key");

                }
                sqlCommand.Dispose();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            //    finally
            //    {

            //         DbConnection.Close();
            //    }
            DbConnection.Close();

            return iRowAffected;
        }


        #endregion

        #region Private Methods
        #endregion

        #region Overrides

        #endregion

        #region Overrides Protected Methods

        /// <summary>
        /// Creates an instance of a factory that is used to create Database objects
        /// </summary>
        /// <returns>A DatabaseAccessObjectFactory instance </returns>

        protected override DatabaseAccessObjectBase CreateDataObjectFactory()
        {
            return CommonObjectCreator.CreateDataObjectFactory();
        }



        #endregion

    }
}