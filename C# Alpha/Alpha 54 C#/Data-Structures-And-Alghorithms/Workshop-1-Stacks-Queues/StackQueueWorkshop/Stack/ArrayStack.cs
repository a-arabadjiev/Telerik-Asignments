namespace StackQueueWorkshop.Stack
{
    using System;

    public class ArrayStack<T> : IStack<T>
    {
        private T[] items;
        private int top = -1;

        public ArrayStack()
        {
            this.items = new T[4];
        }

        public int Size
        {
            get
            {
                return this.top + 1;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.Size == 0;
            }
        }

        public void Push(T element)
        {
            this.ShouldResize();

            this.top++;
            this.items[top] = element;
        }

        public T Pop()
        {
            this.ValidateTopNotEmpty();

            T itemToReturn = this.items[top];
            this.items[top] = default(T);
            this.top--;

            return itemToReturn;
        }

        public T Peek()
        {
            this.ValidateTopNotEmpty();

            return this.items[top];
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
                throw new InvalidOperationException("Element doesn't exist in stack.");
            }
        }
    }
}
