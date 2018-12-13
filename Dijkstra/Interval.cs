using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    /// <summary>
    ///  Responsavel verificar se  um determinado valor está em um range 
    ///  
    /// </summary>
    public static class Interval
    {
       /// <summary>
       ///  Verifica se um valor está na faixa de um range
       /// </summary>
       /// <param name="_left">inferior</param>
       /// <param name="_rigth">superior</param>
       /// <param name="medium">valor</param>
       /// <returns>retornar true</returns>       
        public static bool Limit ( int _left, int _rigth ,int medium)
        {
            return  ( ((_left <= medium) && (medium <  _rigth)) ||
                      ((_left <  medium) && (medium <= _rigth)) ||
                       (_rigth < medium) ||   _left >   medium) ? true :false;

        }

       
    }
}
