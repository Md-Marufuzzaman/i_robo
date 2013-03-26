using System;
using System.Data;
using System.Collections.Generic;
using CommonServiceObject.Base.BaseObject;

using DataAccessObject.Adapters.Base.BaseObject;
using DataAccessObject.Adapters.Derive.DeriveObject.Miscellaneous;
using DataModelObject.ADO.Reference.Miscellaneous;
using mz_AppFramework_v1.Base.BaseObject.Data;
using mz_AppFramework_v1.Base.BaseObject.Data.Factory;



namespace  BusinessServiceObject.Base.BaseObject.Miscellaneous
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


    public class T_TEMPLATEServiceBase : BusinessServiceObjectBase
	{
		#region Constants

		#endregion

		#region Fields
		/// <summary>
		/// The strongly-typed DataAdapter to use for Get and Update operations
		/// </summary>
		protected T_TEMPLATEDataAdapter m_T_TEMPLATEDataAdapter;

		#endregion

		/// <summary>
		/// Initializes Properties of the T_TEMPLATE class.
		/// </summary>
		
		#region protected Properties
		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new (no-args) instance of the T_TEMPLATE class.
		/// </summary>

		public  T_TEMPLATEServiceBase()
		    : base()
		{
            DataBaseConnection = new ConnectionObjectBase(DataObjectFactory.CreateConnection());
		    m_T_TEMPLATEDataAdapter = new  T_TEMPLATEDataAdapter(DataBaseConnection);
		}

		/// <summary>
		/// Creates a new  T_TEMPLATEService and sets the Database context
		/// </summary>

        public T_TEMPLATEServiceBase(ConnectionObjectBase connection)
		    : base()
		{
		    UseConnectionAndTransaction(connection);
		    m_T_TEMPLATEDataAdapter = new  T_TEMPLATEDataAdapter(connection);

		}

		#endregion

		#region Public Methods
		/// <summary>
		/// Initializes a new instance of the T_TEMPLATE class.
		/// </summary>
        public List<T_TEMPLATE> SEL_template(T_TEMPLATE templateObject)
		{
		    return m_T_TEMPLATEDataAdapter.SEL_template
                (
                    templateObject             
                );
		}

        public int INS_template
            (
                T_TEMPLATE templateObject
            )
        {
            return m_T_TEMPLATEDataAdapter.INS_template(templateObject);
        }


		#endregion

		#region Private Methods
		#endregion
		
		#region protected Methods
		/// <summary>
		/// Creates an insteance of a factory that is used to create Database objects
		/// </summary>
		/// <returns>A DatabaseAccessObjectFactory instance </returns>

		protected override DatabaseAccessObjectBase CreateDataObjectFactory()
		{
            return CommonServiceObject.Base.BaseObject.CommonObjectCreator.CreateDataObjectFactory();
		}

		#endregion

		#region Overrides
		#endregion
	}
}