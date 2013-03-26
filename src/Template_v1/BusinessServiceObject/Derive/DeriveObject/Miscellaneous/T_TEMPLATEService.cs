using System;
using System.Collections.Generic;
using CommonServiceObject.Base.BaseObject;

using DataAccessObject.Adapters.Base.BaseObject;
using DataAccessObject.Adapters.Derive.DeriveObject;

using mz_AppFramework_v1.Base.BaseObject.Data;
using mz_AppFramework_v1.Base.BaseObject.Data.Factory;
using BusinessServiceObject.Base.BaseObject.Miscellaneous;



namespace  BusinessServiceObject.Derive.DeriveObject.Miscellaneous
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

	public class T_TEMPLATEService : T_TEMPLATEServiceBase
	{
		#region Constants

		#endregion

		#region Fields
	        /// <summary>
		/// A static instance of the T_TEMPLATEService
		/// </summary>
		/// 

		static T_TEMPLATEService m_Instance;
		#endregion

		/// <summary>
		/// Initializes Properties of the T_TEMPLATE class.
		/// </summary>

		#region Properties
		public static T_TEMPLATEService Instance
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

		public T_TEMPLATEService()
		    : base()
		{

		}

        public T_TEMPLATEService(ConnectionObjectBase connection)
		    : base(connection)
		{

		}

		/// <summary>
		/// Initializes the static instance
		/// </summary>
		/// 

		static T_TEMPLATEService()
		{
		    m_Instance = new T_TEMPLATEService();
		}


		#endregion

		#region Public Methods

		#endregion

		#region Private Methods
		#endregion
		
		#region protected Methods

		#endregion

		#region Overrides
		#endregion
	}
}