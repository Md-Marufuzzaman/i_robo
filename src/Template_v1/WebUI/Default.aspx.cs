using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModelObject.ADO.Reference.Miscellaneous;
using WebUI.Gateway.YankClassObjects;

namespace WebUI
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                T_TEMPLATE templateObject = new T_TEMPLATE();
                templateObject.ct_page_count = 1;
                templateObject.ct_page_index = 1;
                templateObject.ct_page_size = 10;
                templateObject.ct_row_count = 1;
                this.gridViewTemplate.DataSource = YankClassTemplate.SEL_template
                    (
                        templateObject
                    );

                this.gridViewTemplate.DataBind();

            }
        }
    }
}