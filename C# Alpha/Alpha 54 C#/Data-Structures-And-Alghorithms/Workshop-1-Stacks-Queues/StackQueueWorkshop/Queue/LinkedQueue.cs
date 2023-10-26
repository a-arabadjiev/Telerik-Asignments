namespace StackQueueWorkshop.Queue
{
    using System;

    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> head, tail;
        private int size;

        public int Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                this.size = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.size == 0;
            }
        }

        public void Enqueue(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (this.tail == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.size++;
        }

        public T Dequeue()
        {
            this.ValidateTailNotEmpty();

            Node<T> nodeToReturn = this.head;

            this.head = this.head.Next;

            this.size--;

            if (this.head == null)
            {
                this.tail = null;
            }

            return nodeToReturn.Data;
        }

        public T Peek()
        {
            this.ValidateTailNotEmpty();

            return this.head.Data;
        }

        private void ValidateTailNotEmpty()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Element doesn't exist in queue.");
            }
        }
    }
}
