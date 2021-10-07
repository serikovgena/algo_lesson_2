using System;

namespace lesson2
{
    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList<T> where T : IEquatable<T>
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(T value);  // добавляет новый элемент списка
        void AddNodeAfter(Node<T> node, T value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node<T> node); // удаляет указанный элемент
        Node<T> FindNodeBy(T searchValue); // ищет элемент по его значению
        Node<T> FindNodeBy(int index); // ищет элемент по его индексу
        Node<T> FindNodeBy(Node<T> node); // ищет элемент по его значению
    }
}
