using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    /// <summary>
    /// Classe para extrair a minima Distancia 
    /// </summary>
    public static  class Extracao
    {
        /// <summary>
        ///  Recebe o inicio e o fim dos vertices de referência
        /// </summary>
        /// <param name="inicio"></param>
        /// <param name="fim"></param>
        /// <returns>Retorna a distancia em um intervalo determinado</returns>
        public static int D(char inicio, char fim)
        {
            Grafos grafos = new Grafos();
            EstruraVagas(ref grafos);
            return value (grafos.DistanciaMinimaDijkstra(inicio, fim));
        }

        /// <summary>
        ///  Preencher o grafo
        /// </summary>
        /// <param name="grafos"></param>
        internal  static void EstruraVagas( ref Grafos  grafos)
        {
            grafos.AddVertice('A', new Dictionary<char, int>() { { 'B', 7 } });
            grafos.AddVertice('B', new Dictionary<char, int>() { { 'A', 5 }, { 'C', 7  }, { 'D', 3 } });
            grafos.AddVertice('C', new Dictionary<char, int>() { { 'B', 7 }, { 'E', 4  } });
            grafos.AddVertice('D', new Dictionary<char, int>() { { 'B', 3 }, { 'E', 10 }, { 'F', 8 } });
            grafos.AddVertice('E', new Dictionary<char, int>() { { 'C', 4 }, { 'D', 10 } });
            grafos.AddVertice('F', new Dictionary<char, int>() { { 'D', 8 } });
          

        }

        /// <summary>
        /// Extrair a distancia em fuçnão do intervalo
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        internal static int value(int v)
        {
           
            if (Interval.Limit(0,  5,  v))     return 100;
            if (Interval.Limit(5,  10, v))  return 75;
            if (Interval.Limit(10, 15, v)) return 50;
            if (Interval.Limit(15, 20, v)) return 25;
            if (Interval.Limit(0,  20, v))  return 0;
            return 0;
        }




    }
}
