using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._2
{
    public class Node<T> where T : class
    {
        public T Value { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree<T> : IEnumerable<T> where T : class, IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public BinaryTree(T value)
        {
            Root = new Node<T>(value);
        }

        public BinaryTree(ICollection<T> values)
        {
            if (values == null || values.Count == 0) throw new ArgumentException("Values collection must not be empty.");
            using var e = values.GetEnumerator();
            e.MoveNext();
            Root = new Node<T>(e.Current!); 
            while (e.MoveNext())
            {
                Insert(e.Current!);
            }
        }

        public void Insert(T value) => Insert(value, Root);

        private Node<T> Insert(T value, Node<T>? parent)
        {
            if (parent == null) return new Node<T>(value);
            int compared = value.CompareTo(parent.Value);
            if (compared < 0)
            {
                parent.Left = Insert(value, parent.Left);
            }
            else if (compared > 0)
            {
                parent.Right = Insert(value, parent.Right);
            }
            return parent;
        }

        public T? Find(Predicate<T> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            foreach (var v in this)
            {
                if (predicate(v)) return v;
            }
            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return TraverseInOrder(Root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static IEnumerable<T> TraverseInOrder(Node<T>? node)
        {
            if (node == null) yield break;
            if (node.Left != null)
            {
                foreach (var v in TraverseInOrder(node.Left)) yield return v;
            }
            yield return node.Value;
            if (node.Right != null)
            {
                foreach (var v in TraverseInOrder(node.Right)) yield return v;
            }
        }
    }
}
