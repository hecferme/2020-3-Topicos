using System;
using System.Collections.Generic;
using System.Text;

namespace Topicos.Utilitarios
{
    public interface ICarton
    {

        //int[,] elCarton = new int[5, 5];
        public int[,] Inicializar();

        /// <summary>
        /// Este metodo verifica si un número está dentro de un cartón.
        /// </summary>
        /// <param name="elNumero">el número a buscar en el cartón.</param>
        /// <returns></returns>
        public bool ContieneUnNumero(int elNumero);

        /// <summary>
        /// Verifica si las cuatro esquinas del cartón ya han salido.
        /// </summary>
        /// <returns></returns>
        public bool CuatroEsquinas(IList<int> laListaDeNumerosJugados);

        /// <summary>
        /// Verifica si alguna de las filas del cartón se ha completado de acuerdo con la lista de números que se han jugado.
        /// </summary>
        /// <returns></returns>
        public bool AlgunaFilaCompleta(IList<int> laListaDeNumerosJugados);

        /// <summary>
        /// Verifica si alguna de las columnas del cartón se ha completado de acuerdo con la lista de números que se han jugado.
        /// </summary>
        /// <returns></returns>
        public bool AlgunaColumnaCompleta(IList<int> laListaDeNumerosJugados);

        /// <summary>
        /// Verifica si las posiciones del cartón que forman la letra X ya han salido.
        /// </summary>
        /// <param name="laListaDeNumerosJugados">Una lista con todos los números que han salido en el juego.</param>
        /// <returns></returns>
        public bool LetraX(IList<int> laListaDeNumerosJugados);

        /// <summary>
        /// Este método recibe una lista de números que han salido y un patrón que desea verificar si cumple el cartón para verificar si ganó.
        /// </summary>
        /// <param name="laListaDeNumerosJugados">Una lista con todos los números que han salido en el juego.</param>
        /// <param name="elPatronDeJuegoDeseado">Una matriz de 5x5 donde cada posición indica mediante un 0 o algo distinto a 0 si una determinada posición del cartón se debe tener.</param>
        /// <returns></returns>
        public bool ContienePatron(IList<int> laListaDeNumerosJugados, int[,] elPatronDeJuegoDeseado);
        //  1  1  1  1  1
        //  1  0  0  0  1
        //  1  1  1  1  1
        //  1  0  0  0  0
        //  1  0  0  0  0

        /// <summary>
        /// "Le informa al cartón" que un número ha salido.
        /// </summary>
        /// <param name="elNumeroQueSalio"></param>
        public void ReflejarNumeroQueHaSalido(int elNumeroQueSalio);

    }
}
