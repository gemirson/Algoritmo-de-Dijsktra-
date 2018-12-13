using System.Collections.Generic;
using System.Diagnostics;

namespace Dijkstra
{
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
            while (Q.Count != 0)
            {
                //-----------------------------------------
                // 1. Extrai o no do topo
                // 2. Obtém o index do nó
                // 3. Remove o nó da fila
                Node node = Q.Top;
                var atual = node.Index;
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

    }

}
