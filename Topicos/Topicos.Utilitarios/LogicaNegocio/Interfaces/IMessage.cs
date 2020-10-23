using System;
using System.Collections.Generic;
using System.Text;

namespace Topicos.Utilitarios
{
    public interface IMessage
    {
        string Say(string theMessage);
        string Say(bool theMessage);

    }
}
