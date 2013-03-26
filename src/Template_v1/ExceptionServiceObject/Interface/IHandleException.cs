using System;
using System.Text;

namespace ExceptionServiceObject.Interface
{
    public interface IHandleException
    {
        void HandleMyDataLayerException(Exception exception, string message);
    }

    public interface ILogWriter
    {

    }

}
