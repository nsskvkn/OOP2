using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_2.Collections
{
    public class Node<T> where T : class
    {
        public T Value { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }
        public Node(T value) { Value = value; }
    }

    // Узагальнене бінарне дерево
    public class BinaryTree<T> : IEnumerable<T> where T : class
    {
        private readonly IComparer<T>? _comparer;
        public Node<T>? Root { get; private set; }

        public BinaryTree(IComparer<T>? comparer = null)
        {
            _comparer = comparer;
        }

        public BinaryTree(IEnumerable<T> values, IComparer<T>? comparer = null) : this(comparer)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            foreach (var v in values) Insert(v);
        }

        // Порівняння з урахуванням IComparer або IComparable
        private int Compare(T x, T y)
        {
            if (_comparer != null) return _comparer.Compare(x, y);
            if (x is IComparable<T> cmpT) return cmpT.CompareTo(y);
            if (x is IComparable cmp) return cmp.CompareTo(y);
            throw new InvalidOperationException("Тип T має бути порівнянним через IComparer<T> або IComparable.");
        }

        public void Insert(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            Root = InsertNode(Root, value);
        }

        private Node<T> InsertNode(Node<T>? node, T value)
        {
            if (node == null) return new Node<T>(value);
            int c = Compare(value, node.Value);
            if (c < 0) node.Left = InsertNode(node.Left, value);
            else if (c > 0) node.Right = InsertNode(node.Right, value);
            else {}
            return node;
        }

        // Find: повертає перший елемент, що задовольняє предикат
        public T? Find(Predicate<T> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            foreach (var v in this) if (predicate(v)) return v;
            return null;
        }

        // Рreorder: current, left, right
        public IEnumerator<T> GetEnumerator()
        {
            return TraversePreOrder(Root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IEnumerable<T> TraversePreOrder(Node<T>? node)
        {
            if (node == null) yield break;
            yield return node.Value;
            if (node.Left != null)
            {
                foreach (var v in TraversePreOrder(node.Left)) yield return v;
            }
            if (node.Right != null)
            {
                foreach (var v in TraversePreOrder(node.Right)) yield return v;
            }
        }
    }
}