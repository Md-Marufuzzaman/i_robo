using System;
using DataAccessObject.Adapters.Base.BaseObject.DAO.Miscellaneous;
using mz_AppFramework_v1.Base.BaseObject.Data;

namespace  DataAccessObject.Adapters.Derive.DeriveObject.Miscellaneous
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
	/// 		<description>{DATECREATED}</description>
	/// 		<description>Created</description>
	/// 	</item>
	/// </list>
	/// </remarks>
	#endregion

	
	public class T_TEMPLATEDataAdapter : T_TEMPLATEDataAdapterBase
	{
		#region Constants

		#endregion

		#region Fields
		static T_TEMPLATEDataAdapter m_Instance;
		#endregion

		/// <summary>
		/// Initializes Properties of the T_TEMPLATE class.
		/// </summary>

		#region Properties
		
		public static T_TEMPLATEDataAdapter Instance
		{
		    get { return m_Instance; }
		}


		#endregion
		
		#region protected Properties
		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new (no-args) instance of the T_TEMPLATE class.
		/// </summary>
		public T_TEMPLATEDataAdapter()
		    : base()
		{

		}

        public T_TEMPLATEDataAdapter(ConnectionObjectBase connection)
		    : base(connection)
		{

		}
			/// <summary>
			/// Initializes a new instance of the T_TEMPLATE class.
			/// </summary>

		static T_TEMPLATEDataAdapter()
		{
		    m_Instance = new T_TEMPLATEDataAdapter();
		}

		#endregion

		#region Public Methods
		/// <summary>
		/// Initializes a new instance of the T_TEMPLATE class.
		/// </summary>
		#endregion

		#region Private Methods
		#endregion

		#region Overrides
		#endregion
	}
}