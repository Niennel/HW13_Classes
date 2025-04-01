
using System.Diagnostics;

namespace HW13_Classes
{
 
    public class Program
    {
        static void Main(string[] args)
        {
            var s = new Stack("a", "b", "c");

           // size = 3, Top = 'c'
        Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");

            var deleted = s.Pop();

           // Извлек верхний элемент 'c' Size = 2
        Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
            s.Add("d");

           // size = 3, Top = 'd'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");

            s.Pop();
            s.Pop();
            s.Pop();
           // size = 0, Top = null
            Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
            //s.Pop();

            //Merge
            var s1 = new Stack("a", "b", "c");
            s1.Merge(new Stack("1", "2", "3"));

            //Concat
            var s_conc = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
        }
                    
    }
    public class Stack
    {
        //private List<string>? _items;

        private StackItem _top;
        private int _size;

        //конструктор
        public Stack(params string[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        private class StackItem
        {
            public String Val { get; }
            public StackItem Prev { get; }

            public StackItem(string val, StackItem prev)
            {
                Val = val;
                Prev = prev;
            }
        }

        
        //добавление
        public void Add(string item)
        {
            _top=new StackItem(item, _top);
            _size++;
        }
        public string Pop()
        {
            if (_top == null)
            {
                throw new EmptyStack();
            }

            var topItem = _top.Val;
            _top= _top.Prev;
            _size--;
            return topItem;
        }
        //размер
        public int Size
        {
            get { return _size; }
        }
        //top
        public string Top
        {
            get
            {
                if (_top == null)
                    return null;
                else
                    return _top.Val;
            }
        }
        public static Stack Concat( params Stack[] lot_s)
        {
            var result = new Stack();

            foreach (var lot in lot_s)
            {
             
                while (lot.Size > 0)
                    result.Add(lot.Pop());
            }

            return result;
        }


    }
    public static class StackExtensions
    {
        public static void Merge(this Stack s1, Stack s2)
        {
            while (s2.Size > 0)
                s1.Add(s2.Pop());
       
        }

    }
    public class EmptyStack() : Exception($"Стек пустой");
}
