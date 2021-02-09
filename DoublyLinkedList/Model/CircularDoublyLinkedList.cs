using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedList.Model
{
    /// <summary>
    /// Circular Doubly Linked List.
    /// </summary>
    /// <typeparam name="T"> The type of data stored on the stack. </typeparam>
    public class CircularDoublyLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// The first item in the list.
        /// </summary>
        private Item<T> Head;

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        private int count;

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Create an empty list.
        /// </summary>
        public CircularDoublyLinkedList() => Clear();

        /// <summary>
        /// Add data to the end of the list.
        /// </summary>
        /// <param name="data"> Added data. </param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public void Add(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (count == 0)
            {
                // Create a new linked list item.
                SetHeadItem(data);

                return;
            }

            Item<T> item = new Item<T>(data)
            {
                Next = Head,
                Previous = Head.Previous
            };

            Head.Previous.Next = item;
            Head.Previous = item;
            count++;
        }

        /// <summary>
        /// Delete the first occurrence of data in the list.
        /// </summary>
        /// <param name="data"> Data to be deleted. </param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public void Delete(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (Head.Data.Equals(data))
            {
                RemoveItem(Head);
                Head = Head.Next;

                return;
            }

            Item<T> current = Head;

            for (int i = count; i > 0; i--)
            {
                if (current?.Data.Equals(data) == true)
                {
                    RemoveItem(current);
                }

                current = current.Next;
            }
        }

        /// <summary>
        /// Insert data after the desired value.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertAfter(T target, T data)
        {
            if (Head != null)
            {
                Item<T> current = Head;

                for (int i = count; i > 0; i--)
                {
                    if (current?.Data.Equals(target) == true)
                    {
                        Item<T> item = new Item<T>(data);

                        current.Next.Previous = item;
                        item.Previous = current;
                        item.Next = current.Next;
                        current.Next = item;

                        count++;

                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
        }

        /// <summary>
        /// Check for element.
        /// </summary>
        /// <param name="data"> Data to be checked </param>
        /// <returns> String with message </returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public string Contains(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Item<T> current = Head;

            while (current != Head)
            {
                if (current.Data.Equals(data))
                {
                    return $"Elements {data} is in the list.";
                }
                current = current.Next;
            }

            return $"Elements {data} is not in the list.";
        }

        /// <summary>
        /// Clear list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            count = 0;
        }

        /// <summary>
        /// Remove list item.
        /// </summary>
        /// <param name="current"> List item. </param>
        private void RemoveItem(Item<T> current)
        {
            current.Next.Previous = current.Previous;
            current.Previous.Next = current.Next;
            count--;
        }

        /// <summary>
        /// Set first element.
        /// </summary>
        /// <param name="data"> Data to set. </param>
        private void SetHeadItem(T data)
        {
            Head = new Item<T>(data);

            Head.Next = Head;
            Head.Previous = Head;
            count = 1;
        }

        /// <summary>
        /// Return an enumerator that iterates through all the elements in a list.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate over the collection. </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = Head;

            for (int i = 0; i < count * 2; i++)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Return an enumerator that iterates through the list.
        /// </summary>
        /// <returns> The IEnumerator used to traverse the collection. </returns>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
        // Just return the enumerator defined above.
        // This is required to implement the IEnumerable interface
        // to be able to iterate over the elements of the linked list with the foreach operation.
    }
}
