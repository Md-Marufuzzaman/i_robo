using System;
using mz_AppFramework_v1.Base.BaseObject.Data.Factory;

namespace CommonServiceObject.Base.BaseObject
{
  public  class CommonObjectCreator
   {
       #region Constants



       #endregion


       #region Fields



       #endregion


       #region Constructors

       private CommonObjectCreator()
       {
       }


       #endregion


       #region Public Properties



       #endregion


       #region Private Methods



       #endregion


       #region Public static methods

       //public static DatabaseAccessObjectBase CreateDataObjectFactory()
       //{
       //    return new SqlDatabaseAccessObjectBase( SqlConnectionString.GetConnectionString ());
       //}

       #endregion

       public static DatabaseAccessObjectBase CreateDataObjectFactory()
       {
           return new SqlDatabaseAccessObjectBase(SqlConnectionString.GetConnectionString());
       }


   }
    
}
