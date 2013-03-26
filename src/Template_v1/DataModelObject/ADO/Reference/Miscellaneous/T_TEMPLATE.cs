using System;
using System.Data;
using System.Collections.Generic;
using DataModelObject.DataBaseHelper;

namespace DataModelObject.ADO.Reference.Miscellaneous
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

	public class T_TEMPLATE
	{
		#region Constants

		#endregion

		#region Fields
		
		#endregion

        #region Properties
        /// <summary>
        /// Gets or sets the ct_record_no value.
        /// </summary>
        public virtual Int32? ct_record_no { get; set; }

        /// <summary>
        /// Gets or sets the id_template_key value.
        /// </summary>
        public virtual Int32? id_template_key { get; set; }

        /// <summary>
        /// Gets or sets the tx_template_name value.
        /// </summary>
        public virtual String tx_template_name { get; set; }

        /// <summary>
        /// Gets or sets the tx_note value.
        /// </summary>
        public virtual String tx_note { get; set; }

        /// <summary>
        /// Gets or sets the dtt_mod value.
        /// </summary>
        public virtual DateTime dtt_mod { get; set; }
        /// <summary>
        /// Gets or sets the is_active value.
        /// </summary>
        public virtual Boolean is_active { get; set; }
        /// <summary>
        /// Gets or sets the dt_time_stamp value.
        /// </summary>
        public virtual Byte[] dt_time_stamp { get; set; }
        #endregion

		#region protected Properties
		#endregion

        #region public virtual Properties for define action and pageing
        #endregion

        #region protected Properties
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes Properties of the T_TEMPLATE class.
        /// </summary>

        /// <summary>
        /// Initializes a new (no-args) instance of the T_TEMPLATE class.
        /// </summary>

        public T_TEMPLATE()
        {
            // TODO: Complete member initialization
        }
        #endregion

		#region Public Methods
		/// <summary>
		/// Initializes a new instance of the T_TEMPLATE class.
		/// </summary>
		public List<T_TEMPLATE> GetT_TEMPLATEDetails (DataTable dataTableFill)
		{
		     List<T_TEMPLATE> listT_TEMPLATE = new  List<T_TEMPLATE>();	
		       foreach (DataRow row in dataTableFill.Rows)
				{
					  T_TEMPLATE    lstT_TEMPLATE = new T_TEMPLATE();
                      lstT_TEMPLATE.id_template_key = SqlDataTypeManager.GetInt(row["id_template_key"]);
                      lstT_TEMPLATE.tx_template_name = SqlDataTypeManager.GetString(row["tx_template_name"]);
                      lstT_TEMPLATE.tx_note = SqlDataTypeManager.GetString(row["tx_note"]);
 					  listT_TEMPLATE.Add(lstT_TEMPLATE);

				}

		    return listT_TEMPLATE;

		}


		#endregion
        #region public virtual Properties for define action and pageing
        public virtual Int32? ct_page_index { get; set; }
        public virtual Int32? ct_page_size { get; set; }
        public virtual Int32? ct_row_count { get; set; }
        public virtual Int32? ct_page_count { get; set; }
        #endregion

		#region Private Methods
		#endregion

		#region Overrides
		#endregion


       
    }
}