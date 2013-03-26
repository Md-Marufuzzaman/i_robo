using System;
using System.Runtime.Serialization;
using ExceptionServiceObject.ExceptionObject;
using ExceptionServiceObject.Interface;

namespace ExceptionServiceObject
{
   public  class HandleException : IHandleException
    {

        /// <summary>
        /// Handles an exception if one has occurred.
        /// </summary>
        /// <param name="exception">Exception that occurred.</param>
        /// <param name="message">Exception messag.e</param>
        /// <exception cref="DataLayerException">DataLayerException.</exception>
       public void HandleMyDataLayerException(Exception exception, string message)
        {
            DataLayerObjectException dataLayerExceptionObject = new DataLayerObjectException(message, exception);
            throw dataLayerExceptionObject;
        }

    }
}
