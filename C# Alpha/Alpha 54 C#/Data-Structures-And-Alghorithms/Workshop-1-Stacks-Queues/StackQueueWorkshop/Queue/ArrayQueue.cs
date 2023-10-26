using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private T[] items;
        private int top = 0;

        public ArrayQueue()
        {
            this.items = new T[4];
        }

        public int Size
        {
            get
            {
                return this.top;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.Size == 0;
            }
        }

        public void Enqueue(T element)
        {
            this.ShouldResize();

            this.items[this.top] = element;
            this.top++;
        }

        public T Dequeue()
        {
            this.ValidateTopNotEmpty();

            T itemToReturn = this.items[0];

            this.RemoveFirstItem();

            return itemToReturn;
        }

        public T Peek()
        {
            this.ValidateTopNotEmpty();

            return this.items[0];
        }

        private void RemoveFirstItem()
        {
            for (int i = 0; i <= this.top - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ShouldResize()
        {
            if (this.items.Length - 1 == this.top)
            {
                T[] newArray = new T[this.items.Length * 2];

                for (int i = 0; i < this.items.Length; i++)
                {
                    newArray[i] = this.items[i];
                }

                this.items = newArray;
            }
        }

        private void ValidateTopNotEmpty()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Element doesn't exist in queue.");
            }
        }
    }
}
