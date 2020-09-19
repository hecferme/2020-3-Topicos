using System;

namespace Topicos.Utilitarios
{
    public class Message
    {
        public string Say (string theMessage)
        {
            string theResult = string.Empty;
            theResult = string.Format("El mensaje es: {0}", theMessage);
            return theResult;
        }
    }
}
