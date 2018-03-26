using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex_Test1
{
    class Program
    {
        static void Main()
        {
            NewQueue<int> queue = new NewQueue<int>();

            do
            {
                Console.WriteLine("Введите значение для очереди: ");
                int x = 0;
                try
                {
                    x = Int32.Parse(Console.ReadLine());
                    queue.Push(x);
                }
                catch
                {
                    Console.WriteLine("Ошбика при вводе! Число должно быть целым!");
                }             
           
                Console.WriteLine("Для выхода нажмите Escape; для продолжения - любую другую клавишу");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);


            if (queue.Count() == 0)
                Console.WriteLine("Очередь пуста!");
            else
            {
                Console.WriteLine();
                Console.WriteLine("{0,-7} - очередь в начальном положении", queue);
                Console.WriteLine("{1,-7} - очередь после того как удалили {0}", queue.Pop(), queue);
                Console.WriteLine("{1,-7} - очередь после того как удалили {0}", queue.Pop(), queue);
            }

            Console.ReadLine();
        }
    }

    class NewQueue<T>
    {
        private Stack<T> mainStack = new Stack<T>();
        private Stack<T> tempStack = new Stack<T>();

        public void Push(T Value)
        {
            mainStack.Push(Value);
        }

        public T Pop()
        {
            while (mainStack.Count != 0)
                tempStack.Push(mainStack.Pop());

            T Value = tempStack.Pop();

            while (tempStack.Count != 0)
                mainStack.Push(tempStack.Pop());

            return Value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            while (mainStack.Count != 0)
                tempStack.Push(mainStack.Pop());

            while (tempStack.Count != 0)
            {
                sb.Append(tempStack.Peek());
                sb.Append(" ");
                mainStack.Push(tempStack.Pop());
            }

            return sb.ToString();
        }

        public int Count()
        {
            return mainStack.Count;
        }
    }
}

