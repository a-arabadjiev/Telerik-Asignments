namespace StackQueueWorkshop.Stack
{
    using System;

    public class LinkedStack<T> : IStack<T>
    {
        private Node<T> top;
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
                return this.top == null;
            }
        }

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element);
            newNode.Next = top;
            this.top = newNode;

            this.size++;
        }

        public T Pop()
        {
            this.ValidateTopNotEmpty();

            Node<T> nodeToReturn = this.top;
            this.top = this.top.Next;

            this.size--;

            return nodeToReturn.Data;
        }

        public T Peek()
        {
            this.ValidateTopNotEmpty();

            return this.top.Data;
        }

        private void ValidateTopNotEmpty()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Element doesn't exist in stack.");
            }
        }
    }
}
