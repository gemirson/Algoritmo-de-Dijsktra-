using System;

namespace Dijkstra
{
    /// <summary>
    /// Classe para calcular o Score do candidato em função da distancia minima, nivel de experiência do candidato 
    /// e nível de experiência da vaga
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Score
    {
        /// <summary>
        /// Propriedades do score
        /// 1. NV nivel de experiencia da vaga
        /// 2. NC nivel de experiencia candidato
        /// 3. 
        /// </summary>
        public static int NV { get; set; }
        public static int NC { get; set; }
        public static int D  { get; set; } 

        /// <summary>
        ///  Calcular o score
        /// </summary>
        /// <returns></returns>
        public static  int Result()
        {
            return (int)((D + N(NV,NC))*0.5F);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NV"></param>
        /// <param name="NC"></param>
        /// <returns></returns>
        internal static int N(int NV, int NC)
        {
          return (100 - 25 * Math.Abs(NV-NC));
           
        }

       

    }
}
