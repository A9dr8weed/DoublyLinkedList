using DoublyLinkedList.Model;

using System;
namespace DoublyLinkedList
{
    public static class Program
    {
        public static void Main()
        {
            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();

            doublyLinkedList.Add(1);
            doublyLinkedList.Add(2);
            doublyLinkedList.Add(3);
            doublyLinkedList.Add(4);
            doublyLinkedList.Add(5);
            doublyLinkedList.InsertAfter(5, 99);

            doublyLinkedList.Delete(5);

            Console.WriteLine(doublyLinkedList.Contains(5));

            foreach (object item in doublyLinkedList)
            {
                Console.WriteLine(item);
            }

            foreach (object item in doublyLinkedList.Reverse())
            {
                Console.WriteLine(item);
            }

            CircularDoublyLinkedList<int> circularDoublyLinkedList = new CircularDoublyLinkedList<int>();

            circularDoublyLinkedList.Add(1);
            circularDoublyLinkedList.Add(2);
            circularDoublyLinkedList.Add(3);
            circularDoublyLinkedList.Add(4);
            circularDoublyLinkedList.Add(5);

            circularDoublyLinkedList.Delete(3);

            circularDoublyLinkedList.InsertAfter(2, 99);

            Console.WriteLine(circularDoublyLinkedList.Contains(3));

            foreach (object item in circularDoublyLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}