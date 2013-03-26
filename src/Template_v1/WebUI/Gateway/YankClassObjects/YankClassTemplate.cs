using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using BusinessServiceObject.Derive.DeriveObject.Miscellaneous;
using DataModelObject.ADO.Reference.Miscellaneous;

namespace WebUI.Gateway.YankClassObjects
{
    public static class YankClassTemplate
    {

        /// <summary>
        /// This procedure is using for evaluate:: e-mushok part
        /// </summary>
        /// <param name="?"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<T_TEMPLATE> SEL_template
            (
                T_TEMPLATE templateObject
             )
        {

            T_TEMPLATEService templateServiceObject = new T_TEMPLATEService();
            return templateServiceObject.SEL_template
                (
                  templateObject
                );
        }


    }
} 