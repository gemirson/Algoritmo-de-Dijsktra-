using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    /// <summary>
     ///  Compara a prioridade da queue  usando o custo entre os vertices no grafo
     /// </summary>
    public class CompareNode : IComparer<Node>
    {
        /// <summary>
        /// Metodo usando para fazer a compararcao e inserir na fila  de prioridade
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        int IComparer<Node>.Compare(Node a, Node b)
        {
            return (a.Custo < b.Custo)  ? -1 : 1;
        }


    }
}

