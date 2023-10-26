using System;

using StackQueueWorkshop.Queue;
using StackQueueWorkshop.Stack;

class Program
{
    static void Main(string[] args)
    {
        ArrayQueue<int> arrayQueue = new ArrayQueue<int>();

        arrayQueue.Enqueue(1);
        arrayQueue.Enqueue(2);
        arrayQueue.Enqueue(3);
        arrayQueue.Enqueue(4);
        arrayQueue.Enqueue(5);

        Console.WriteLine(arrayQueue.Dequeue());
        Console.WriteLine(arrayQueue.Dequeue());
        Console.WriteLine(arrayQueue.Dequeue());
        Console.WriteLine(arrayQueue.Dequeue());
        Console.WriteLine(arrayQueue.Dequeue());
    }
}
