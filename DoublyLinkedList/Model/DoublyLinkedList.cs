using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedList.Model
{
    /// <summary>
    /// Doubly Linked List.
    /// </summary>
    /// <typeparam name="T"> The type of data stored on the stack. </typeparam>
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// The first item in the list.
        /// </summary>
        private Item<T> Head;

        /// <summary>
        /// The last item in the list.
        /// </summary>
        private Item<T> Tail;

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
        public DoublyLinkedList() => Clear();

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

            // Create a new linked list item.
            Item<T> item = new Item<T>(data);

            if (Head == null)
            {
                Head = item;
            }
            else
            {
                // If the list already contains elements, then the added item's Previous property points to the node
                // that was previously stored in the Tail variable
                Tail.Next = item;
                item.Previous = Tail;
            }
            Tail = item;

            // We increase the counter of the number of elements.
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

            Item<T> current = Head;

            // Find the item to remove.
            while (current != null)
            {
                // If you find the required item.
                if (current.Data.Equals(data))
                {
                    // If the item is not the last.
                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        // If the latter, reinstall tail.
                        Tail = current.Previous;
                    }

                    // If the node is not the first.
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        // If the first one, reinstall head.
                        Head = current.Next;
                    }
                    count--;

                    return;
                }

                current = current.Next;
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

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return $"Element {data} is in the list.";
                }
                current = current.Next;
            }

            return $"Element {data} is not in the list.";
        }

        /// <summary>
        /// Add an item first.
        /// </summary>
        /// <param name="data"> Added data. </param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public void AddFirst(T data)
        {
            // Check input data for emptiness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Create a new list item.
            Item<T> item = new Item<T>(data);
            // First element.
            Item<T> current = Head;

            item.Next = current;
            Head = item;

            if (count == 0)
            {
                Tail = Head;
            }
            else
            {
                current.Previous = item;
            }
            count++;
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

                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        Item<T> item = new Item<T>(data);

                        if (current.Next == null)
                        {
                            Add(data);

                            return;
                        }

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
        /// Reverse list.
        /// </summary>
        /// <returns> New reversed list. </returns>
        public DoublyLinkedList<T> Reverse()
        {
            DoublyLinkedList<T> result = new DoublyLinkedList<T>();

            Item<T> current = Tail;

            while (current != null)
            {
                result.Add(current.Data);

                current = current.Previous;
            }

            return result;
        }

        /// <summary>
        /// Clear list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        /// <summary>
        /// Return an enumerator that iterates through all the elements in a list.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate over the collection. </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            // We iterate over all the elements of the linked list to be presented as a collection of elements.
            Item<T> current = Head;

            while (current != null)
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

        /// <summary>
        /// To iterate over elements from the end.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate over the collection. </returns>
        public IEnumerable<T> BackEnumerator()
        {
            Item<T> current = Tail;

            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
