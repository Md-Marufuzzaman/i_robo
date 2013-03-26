using System;
 
namespace Tools.Interface
{
   public interface ITools : IDisposable
   {
       #region Get all the custom values from the web.config / app.config file.
       
       void GetCustomConfiguration();
       string GetConnectionString();
       
       #endregion
   }
}
