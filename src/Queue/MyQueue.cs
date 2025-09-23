//using System;
//using System.Collections.Generic;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//public class MyQueue<T>
//{
//    private object?[] _array; // Do not rename (binary serialization)
//    private int _head; // First valid element in the queue. Do not rename (binary serialization)
//    private int _tail; // Last valid element in the queue. Do not rename (binary serialization)
//    private int _size;

//    // Enqueue = Add item at the END
//    public virtual void Enqueue(object? obj)
//    {
//        _array[_tail] = obj;
//        _tail = (_tail + 1) % _array.Length;
//        _size++;
//    }

//    // Dequeue = Remove item from the FRONT
//    public T Dequeue()
//    {
//        if (_items.Count == 0)
//            throw new InvalidOperationException("Queue is empty!");

//        T value = _items[0];
//        _items.RemoveAt(0); // remove from front
//        return value;
//    }

//    // Peek = Look at the front item
//    public T Peek()
//    {
//        if (_items.Count == 0)
//            throw new InvalidOperationException("Queue is empty!");

//        return _items[0];
//    }

//    // Count = number of elements
//    public int Count => _items.Count;

//    // Print queue
//    public void PrintQueue()
//    {
//        Console.WriteLine(string.Join(", ", _items));
//    }
//}
