public class MyStack<T>
{
    private List<T> _items = new List<T>();

    // Add (push) an item onto the stack
    public void Push(T item)
    {
        _items.Add(item);
    }

    // Remove (pop) the last item
    public T Pop()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        // get last item
        var lastIndex = _items.Count - 1;
        T item = _items[lastIndex];

        // remove it
        _items.RemoveAt(lastIndex);

        return item;
    }

    // Look at top item without removing
    public T Peek()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        return _items[_items.Count - 1];
    }

    // Check if stack is empty
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }

    // Count of items
    public int Count => _items.Count;
}

// learning purposes or very specialized cases (like constant-time insert/delete
public class MyStackArrayManual<T> 
{
    private T[] _items;
    private int _top; // index of the next free position

    public MyStackArrayManual(int capacity = 4)
    {
        _items = new T[capacity];
        _top = 0;
    }

    public void Push(T item)
    {
        if (_top == _items.Length)
        {
            // grow dynamically (like List<T>)
            Array.Resize(ref _items, _items.Length * 2);
        }
        _items[_top] = item;
        _top++;
    }

    public T Pop()
    {
        if (_top == 0)
            throw new InvalidOperationException("Stack is empty");

        _top--; // move back to last item
        return _items[_top];
    }

    public T Peek()
    {
        if (_top == 0)
            throw new InvalidOperationException("Stack is empty");

        return _items[_top - 1];
    }

    public bool IsEmpty() => _top == 0;

    public int Count => _top;
}

public class Node<T>
{
    public T Value;
    public Node<T>? Next;
    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}

public class LinkedListStack<T>
{
    private Node<T>? _top; // top points to head node
    private int _count;

    public void Push(T item)
    {
        var node = new Node<T>(item);
        node.Next = _top;   // new node points to old top
        _top = node;        // update top
        _count++;
    }

    public T Pop()
    {
        if (_top == null)
            throw new InvalidOperationException("Stack is empty");

        var value = _top.Value;
        _top = _top.Next;   // move down
        _count--;
        return value;
    }

    public T Peek()
    {
        if (_top == null)
            throw new InvalidOperationException("Stack is empty");
        return _top.Value;
    }

    public bool IsEmpty() => _top == null;
    public int Count => _count;
}
