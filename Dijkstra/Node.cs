using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    /// <summary>
    ///  Struct  de representaçao de um Nó
    /// </summary>
    public struct Node
    {
        public char Index { get; set; }
        public int  Custo { get; set; }
    }
}
