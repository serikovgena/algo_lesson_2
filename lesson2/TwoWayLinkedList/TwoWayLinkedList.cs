using System;
using System.Collections.Generic;

namespace lesson2
{
    class TwoWayLinkedList<T> : ILinkedList<T> where T : IEquatable<T>
    {
        int count;
        Node<T> root;
        Node<T> head;

        public TwoWayLinkedList() {
            count = 0;
            root = new Node<T>
            {
                Value = default(T)
            };
            head = root;
        }

        public bool IsEmpty() => GetCount() == 0;
        public int GetCount() => count;
        public Node<T> this[int index]
        {
            get
            {
                if (index >= 0 && index < GetCount())
                {
                    var nodeNumber = index + 1;
                    int i = 0;
                    foreach (var item in this)
                    {
                        if (i++ == nodeNumber)
                        {
                            return item;
                        }
                    }
                }
                return null;
            }
        }
        public IEnumerator<Node<T>> GetEnumerator() {
            var current = root.NextNode;
            while (current != null)
            {
                yield return current;
                current = current.NextNode;
            }
        }

        public void AddNode(T value) {
            Node<T> item = new Node<T>
            {
                Value = value
            };
            head.NextNode = item;
            item.PrevNode = head;

            head = item;
            count++;
        }
        public void AddNodeAfter(Node<T> node, T value) {
            if (node != null)
            {
                var newNode = new Node<T>
                {
                    Value = value,
                    PrevNode = node,
                    NextNode = node.NextNode
                };
                node.NextNode = newNode;
            }
            count++;
        }

        public void RemoveNode(int index) => ExecuteRemoveFor(FindNodeBy(index));
        public void RemoveNode(Node<T> node) => ExecuteRemoveFor(FindNodeBy(node));
            
        public Node<T> FindNodeBy(T searchValue) {
            Node<T> result = null;
            foreach (var item in this) {
                if (item.Value.Equals(searchValue)) {
                    result = item;
                }
            }
            return result;
        }
        public Node<T> FindNodeBy(int index) => this[index];
        public Node<T> FindNodeBy(Node<T> node) {
            Node<T> result = null;
            foreach (var item in this) {
                if (item.Equals(node)) {
                    result = item;
                }
            }
            return result;
        }

        private void ExecuteRemoveFor(Node<T> node) {
            if (node != null)
            {
                var prevNode = node.PrevNode;
                var nextNode = node.NextNode;
                if (prevNode != null)
                {
                    prevNode.NextNode = nextNode;
                }
                if (nextNode != null)
                {
                    nextNode.PrevNode = prevNode;
                }
                count--;
            }
        }
    }
}
