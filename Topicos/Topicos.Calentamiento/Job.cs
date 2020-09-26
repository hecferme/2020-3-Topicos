using System;
using System.Collections.Generic;
using System.Text;

namespace Topicos.Calentamiento
{
    public class Job
    {
        public void Do ()
        {
            Console.WriteLine("Hello World!");
            var lasHerramientas = new Topicos.Utilitarios.Message();
            var elMensaje = lasHerramientas.Say("Hello World!");
            Console.WriteLine(elMensaje);
            lasHerramientas.MyProperty = 89123;
            elMensaje = lasHerramientas.elMensaje;
            Console.WriteLine(elMensaje);
        }
    }
}
