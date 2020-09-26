using System;

namespace Topicos.Utilitarios
{
    public class Message : IMessage
    {
        public Message()
        {
            elMensaje = "Todavía no hay mensajes";
        }
        public Message(string elMensajeDeParametro)
        {
            elMensaje = elMensajeDeParametro;
        }

        public Message(bool elMensajeBooleano)
        {
            elMensaje = Say(elMensajeBooleano.ToString());
        }
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public string elMensaje { get; set; }
        public string Say (string theMessage)
        {
            string theResult = string.Empty;
            theResult = string.Format("El mensaje es: {0}", theMessage);
            elMensaje = theResult;
            return theResult;
        }

        public string Say(bool theMessage)
        {
            return Say (theMessage.ToString());
        }
    }
}
