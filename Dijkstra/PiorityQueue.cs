using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
///  Baseado na implentação  .Net
/// </summary>
namespace Dijkstra
{
    /// <summary>
    /// Classe responsavel por implementar a lista de prioridade
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class PriorityQueue<T>
    {
        private T[] _heap;
        private int _count;
        private IComparer<T> _comparer;
        private const int CapacidadeDefault = 6;

        /// <summary>
        ///  Construtor da classe
        /// </summary>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        public PriorityQueue(int length, IComparer<T> comparer)
        {
            _heap = new T[length > 0 ? length : CapacidadeDefault];
            _count = 0;
            _comparer = comparer;
        }
                           
        /// <summary>
        ///  Retorna   o numero de prioridade 
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Status da fila de prioridade
        /// </summary>
        /// <returns>Retorna true se não mais nenhum objeto na fila de prioridade</returns>
        public bool Any()
        {
            return _heap.Length == 0 ? true : false;
        }

        /// <summary>
        ///  Retorna o  primeiro objeto na fila de prioridade com menor valor
        /// </summary>
        public T Top
        {
            get
            {
                Debug.Assert(_count > 0);
                return _heap[0];
            }
        }


        /// <summary>
        ///  Adiciona os objetos a fila de prioridade
        /// </summary>
        public void Push(T value)
        {
            // Redimensiona o array se necessário
            if (_count == _heap.Length)
            {
                T[] temp = new T[_count * 2];
                for (int i = 0; i < _count; ++i)
                {
                    temp[i] = _heap[i];
                }
                _heap = temp;
            }

            // Baseado em 
            // Loop invariant:
            //
            //  1.  index is a gap where we might insert the new node; initially
            //      it's the end of the array (bottom-right of the logical tree).
            //
            int index = _count;
            while (index > 0)
            {
                int parentIndex = HeapParent(index);
                if (_comparer.Compare(value, _heap[parentIndex]) < 0)
                {
                    // value is a better match than the parent node so exchange
                    // places to preserve the "heap" property.
                    _heap[index] = _heap[parentIndex];
                    index = parentIndex;
                }
                else
                {
                    
                    break;
                }
            }

            _heap[index] = value;
            _count++;
        }


        /// <summary>
        /// Remove o primeiro obejto da fila de prioridade baseado na logica para  heap.
        /// </summary>
        public void Pop()
        {
            Debug.Assert(_count != 0);

            if (_count > 1)
            {
                // Loop invariants:
                //
                //  1.  parent is the index of a gap in the logical tree
                //  2.  leftChild is
                //      (a) the index of parent's left child if it has one, or
                //      (b) a value >= _count if parent is a leaf node
                //
                int parent = 0;
                int leftChild = HeapLeftChild(parent);

                while (leftChild < _count)
                {
                    int rightChild = HeapRightFromLeft(leftChild);
                    int bestChild =
                        (rightChild < _count && _comparer.Compare(_heap[rightChild], _heap[leftChild]) < 0) ?
                        rightChild : leftChild;

                    // Promote bestChild to fill the gap left by parent.
                    _heap[parent] = _heap[bestChild];

                    // Restore invariants, i.e., let parent point to the gap.
                    parent = bestChild;
                    leftChild = HeapLeftChild(parent);
                }

                // Fill the last gap by moving the last (i.e., bottom-rightmost) node.
                _heap[parent] = _heap[_count - 1];
            }

            _count--;
        }


        #region Funcoes  para facilita  a leitura do algoritimo baseado no algoritimo para um heap

        /// <summary>
        /// Calculate the parent node index given a child node's index, taking advantage
        /// of the "shape" property.
        /// </summary>
        private static int HeapParent(int i)
        {
            return (i - 1) / 2;
        }

        /// <summary>
        /// Calculate the left child's index given the parent's index, taking advantage of
        /// the "shape" property. If there is no left child, the return value is >= _count.
        /// </summary>
        private static int HeapLeftChild(int i)
        {
            return (i * 2) + 1;
        }

        /// <summary>
        /// Calculate the right child's index from the left child's index, taking advantage
        /// of the "shape" property (i.e., sibling nodes are always adjacent). If there is
        /// no right child, the return value >= _count.
        /// </summary>
        private static int HeapRightFromLeft(int i)
        {
            return i + 1;
        }
        #endregion
    }
}
