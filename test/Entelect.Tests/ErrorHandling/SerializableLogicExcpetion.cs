using System;
using System.Runtime.Serialization;
using Entelect.ErrorHandling;

namespace Entelect.Tests.ErrorHandling
{
    public class SerializableLogicExcpetion: LogicException
    {
        public SerializableLogicExcpetion(LogicErrors errors, string additionalMessage = null) 
            : base(GetSerializationInfo(), new StreamingContext(), errors, additionalMessage)
        {
        }

        private static SerializationInfo GetSerializationInfo()
        {
            var info = new SerializationInfo(typeof (SerializableLogicExcpetion), new FormatterConverter());
            info.AddValue("ClassName", typeof(SerializableLogicExcpetion).Name);
            info.AddValue("Message", string.Empty);
            info.AddValue("InnerException", new Exception());
            info.AddValue("HelpURL", string.Empty);
            info.AddValue("StackTraceString", string.Empty);
            info.AddValue("RemoteStackTraceString", string.Empty);
            info.AddValue("RemoteStackIndex", 0);
            info.AddValue("ExceptionMethod", string.Empty);
            info.AddValue("HResult", 1);
            info.AddValue("Source", string.Empty);
            return info;
        }
    }
}