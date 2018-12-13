using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    /// <summary>
    ///  Classe \\vertice
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Vertex<T>
    {
        T data;
        public Dictionary<char, int> properties;

    }
}
