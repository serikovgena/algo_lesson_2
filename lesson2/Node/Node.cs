using System;

namespace lesson2
{
    public class Node<T> where T : IEquatable<T>
    {
        public T Value { get; set; }
        public Node<T> NextNode { get; set; }
        public Node<T> PrevNode { get; set; }

        public override bool Equals(object obj) {
            if (obj == null) return false;

            var examNode = obj as Node<T>;
            return
                Value.Equals(examNode.Value)
             && NextNode == examNode.NextNode
             && PrevNode == examNode.PrevNode;
        }

        public override int GetHashCode() {
            throw new NotImplementedException();
        }
    }
}
