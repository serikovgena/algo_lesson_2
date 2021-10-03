using System;
using System.Collections;
using System.Collections.Generic;

namespace lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoWayList<int> test = new TwoWayList<int>();
            test.AddNode(11);
            test.AddNode(22);
            test.AddNode(33);
            test.AddNode(44);
            test.AddNode(55);
            test.AddNode(66);
            test.AddNode(77);
            test.AddNode(88);
            test.AddNode(99);

            var fifthNode = test.FindNode(searchValue:56);
            if (fifthNode != null) {
                Console.WriteLine($"finded node value is {fifthNode.Value}");
            }
            else {
                Console.WriteLine("node with that params is not finded!");
            }
            test.AddNodeAfter(fifthNode, 120);
            foreach (var x in test)
            {
                Console.WriteLine(x.Value);
            }

            //test.RemoveNode(2);
            //test.RemoveNode(2);
            test.RemoveNode(fifthNode);
            foreach (var x in test)
            {
                Console.WriteLine(x.Value);
            }
        }
    }

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

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList<T> where T : IEquatable<T>
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(T value);  // добавляет новый элемент списка
        void AddNodeAfter(Node<T> node, T value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node<T> node); // удаляет указанный элемент
        Node<T> FindNode(T searchValue); // ищет элемент по его значению
        Node<T> FindNode(int index); // ищет элемент по его индексу
        Node<T> FindNode(Node<T> node); // ищет элемент по его значению
    }

    class TwoWayList<T> : ILinkedList<T> where T : IEquatable<T>
    {
        int count;
        public Node<T> root;
        public Node<T> head;

        public TwoWayList() {
          count = 0;
          root = new Node<T> {
            Value = default(T)
          };
          head = root;
        }

        public Node<T> this[int index] {
          get { 
            if(index >= 0 && index < GetCount()) { 
                var nodeNumber = index + 1;
                int i = 0;
                foreach(var item in this) { 
                    if(i++ == nodeNumber) { 
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
          Node<T> item = new Node<T> {
            Value = value
          };
          head.NextNode = item;
          item.PrevNode = head;
          
          head = item;
          count++;
        }

        public void AddNodeAfter(Node<T> node, T value) {
          if(node != null) { 
            var newNode = new Node<T> { 
              Value = value,
              PrevNode = node,
              NextNode = node.NextNode
            };
            node.NextNode = newNode;
          }
          count++;
        }

        public Node<T> FindNode(T searchValue)
        {
            Node<T> result = null;
            foreach (var item in this) {
              if (item.Value.Equals(searchValue)) {
                result = item;
              }
            }
            return result;
        }

        public Node<T> FindNode(int index) {
            return this[index];
        }

        public Node<T> FindNode(Node<T> node) {
            Node<T> result = null;
            foreach (var item in this) {
              if (item.Equals(node)) {
                result = item;
              }
            }
            return result;
        }

        public int GetCount() => count;

        public void RemoveNode(int index) {
          var removingNode = FindNode(index);
          ExecuteRemoveFor(removingNode);
        }

        public void RemoveNode(Node<T> node) {
          Node<T> removingNode = FindNode(node);
          ExecuteRemoveFor(removingNode);
        }

        private void ExecuteRemoveFor(Node<T> node) {
          if (node != null) {
            var prevNode = node.PrevNode;
            var nextNode = node.NextNode;
            if (prevNode != null) {
                prevNode.NextNode = nextNode;
            }
            if (nextNode != null) { 
                nextNode.PrevNode = prevNode;
            }
            count--;
          }
        }

        public bool IsEmpty() => GetCount() == 0;
    }
}
