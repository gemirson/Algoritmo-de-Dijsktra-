using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{


    #region
    public class Graph
    {
        Dictionary<char, Dictionary<char, int>> vertice = new Dictionary<char, Dictionary<char, int>>();

        public void AddVertice(char nome, Dictionary<char, int> adjacente)
        {
            vertice[nome] = adjacente;

        }

        public int Distancia(char inicio, char fim)
        {
            /*
		     vetor de visitados serve para caso o vértice já tenha sido
		     expandido (visitado), não expandir mais
	     	*/
            var visitados = new Dictionary<char, char>();
            /*
             Armazena o indice e a distancia ao nó de referencia
            */
            var distancia = new Dictionary<char, int>();

            /*
             Lista de nos
            */
            var nos = new List<char>();

            foreach (var vertex in vertice)
            {
                // Primeira interação 
                if (vertex.Key == inicio)
                {
                    distancia[vertex.Key] = 0;
                }
                else
                {
                    // Demais inicia com uma valor muito grande
                    distancia[vertex.Key] = int.MaxValue;
                }

                // Adiciona o no na queue
                nos.Add(vertex.Key);


            }

            /*
             Loop
           */
            while (nos.Count != 0)
            {
                // Define a  prioridade
                nos.Sort((x, y) => distancia[x] - distancia[y]);
                var atual = nos[0];
                nos.Remove(atual);

               

                if (distancia[atual] == int.MaxValue)
                {
                    break;
                }

                if (atual == fim)
                {
                    while (visitados.ContainsKey(atual))
                    {
                        atual = visitados[atual];
                    }
                    break;
                }


                foreach (var vizinho in vertice[atual])
                {
                    if ((distancia[atual] + vizinho.Value) < distancia[vizinho.Key])
                    {
                        distancia[vizinho.Key] = distancia[atual] + vizinho.Value;
                        visitados[vizinho.Key] = atual;

                       
                    }
                }
            }

            return distancia[fim];


        }
    }

    #endregion
/*
    /// <summary>
    /// Classe que representa uma estrutura de um Grafo
    /// </summary>
    public class Grafos
    {
        // Coleção de vertices utilizando uma lista de adjacentes
        Dictionary<char, Dictionary<char, int>> vertice = new Dictionary<char, Dictionary<char, int>>();

     
        /// <summary>
        ///  Adiciona um né e seus adjacentes
        /// </summary>
        /// <param name="nome">Index do Vertices </param>
        /// <param name="adjacente">Adjacentes para o Vertice</param>
        public void AddVertice(char nome, Dictionary<char, int> adjacente)
        {
            vertice[nome] = adjacente;
         
        }


        /// <summary>
        /// Calcula a distancia Minima utilizando o algoritimo de Dijkstra
        /// </summary>
        /// <param name="inicio">Inicio do caminho</param>
        /// <param name="fim">Fim do Caminho</param>
        /// <returns></returns>
        public int DistanciaMinimaDijkstra(char inicio, char fim)
        {
            //---------------------------------------------------------
            // 1 . vetor de visitados serve para caso o vértice já tenha sido 
            //    expandido (visitado), não expandir mais
            // 2.  Armazena o indice e a distancia ao nó de referencia
            // 3.  Processo inicilização 
            var visitados = new Dictionary<char, char>();
            var distancia = new Dictionary<char, int>();

            foreach (var vertex in vertice)
            {
                // Primeira interação  a distância de orig para orig é 0
                if (vertex.Key == inicio)
                {
                    distancia[vertex.Key] = 0;
                }
                else
                {
                    // Demais inicia com uma valor muito grande
                    distancia[vertex.Key] = int.MaxValue;
                }

                 visitados[vertex.Key] = ' ';
            }


            //---------------------------------------------------------------------------------
            // 1. Define a fila de prioridade
            // 2. Insere na fila o inicio
            PriorityQueue<Node> Q = new PriorityQueue<Node>(vertice.Count, new CompareNode());

            Q.Push(new Node { Index = inicio, Custo = distancia[inicio] });

            //---------------------------------------------------------------------------------
            // loop do algoritmo de Dijkstra
            while (Q.Count!=0)
            {
                //-----------------------------------------
                // 1. Extrai o no do topo
                // 2. Obtém o index do nó
                // 3. Remove o nó da fila
                Node p = Q.Top; 
                var atual = p.Index; 
                Q.Pop();

                //-----------------------------------------
                // Verifica se o todos os nós já foram visitados;
                if (visitados[atual] == fim) break;

                //-------------------------------------------------------------
                // percorre o vértice atual   e seus adjacentes
                foreach (var vizinho in vertice[atual])
                 {                    
                        // Processo de relaxamento Relaxamento 
                        if ((distancia[atual] + vizinho.Value) < distancia[vizinho.Key])
                        {
                            // Atualiza a o custo
                            distancia[vizinho.Key] = distancia[atual] + vizinho.Value;
                            visitados[vizinho.Key] = atual;
                            Q.Push(new Node { Index = vizinho.Key, Custo = distancia[vizinho.Key] });
                       
                        }
                 }
                
            }

            return distancia[fim];
        }
      
    }*/

    class Program
    {
        static void Main(string[] args)
        {
            

            Graph g = new Graph();
            Grafos grafos = new Grafos();
           
            g.AddVertice('A', new Dictionary<char, int>() { { 'B', 7 }, { 'C', 8 } });
            g.AddVertice('B', new Dictionary<char, int>() { { 'A', 7 }, { 'F', 2 } });
            g.AddVertice('C', new Dictionary<char, int>() { { 'A', 8 }, { 'F', 6 }, { 'G', 4 } });
            g.AddVertice('D', new Dictionary<char, int>() { { 'F', 8 } });
            g.AddVertice('E', new Dictionary<char, int>() { { 'H', 1 } });
            g.AddVertice('F', new Dictionary<char, int>() { { 'B', 2 }, { 'C', 6 }, { 'D', 8 }, { 'G', 9 }, { 'H', 3 } });
            g.AddVertice('G', new Dictionary<char, int>() { { 'C', 4 }, { 'F', 9 } });
            g.AddVertice('H', new Dictionary<char, int>() { { 'E', 1 }, { 'F', 3 } });


            grafos.AddVertice('A', new Dictionary<char, int>() { { 'B', 7 }, { 'C', 8 } });
            grafos.AddVertice('B', new Dictionary<char, int>() { { 'A', 7 }, { 'F', 2 } });
            grafos.AddVertice('C', new Dictionary<char, int>() { { 'A', 8 }, { 'F', 6 }, { 'G', 4 } });
            grafos.AddVertice('D', new Dictionary<char, int>() { { 'F', 8 } });
            grafos.AddVertice('E', new Dictionary<char, int>() { { 'H', 1 } });
            grafos.AddVertice('F', new Dictionary<char, int>() { { 'B', 2 }, { 'C', 6 }, { 'D', 8 }, { 'G', 9 }, { 'H', 3 } });
            grafos.AddVertice('G', new Dictionary<char, int>() { { 'C', 4 }, { 'F', 9 } });
            grafos.AddVertice('H', new Dictionary<char, int>() { { 'E', 1 }, { 'F', 3 } });

            //  g.shortest_path('A', 'H').ForEach(x => Console.WriteLine(x));

            Console.WriteLine(g.Distancia('A', 'E'));

            Console.WriteLine("\n");

            Console.WriteLine(grafos.DistanciaMinimaDijkstra('A','E'));

            Console.Read();
        }
    }
}

