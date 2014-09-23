using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class HeapClient
    {
        public static void Main(string[] args)
        {
            ThreeHeap h = new ThreeHeap();

            Console.WriteLine("Welcome to the demo of Rose's Heap data structure.");
            Console.WriteLine("This heap is technically a three-heap implemented using an array");
            Console.WriteLine("********************************************************");
            Console.WriteLine();
            
            Console.WriteLine("Type a few words seperated by commas. Non-lettter characters are ok.");
            String input = Console.ReadLine();
            while (input.Length < 1)
            {
                Console.WriteLine("Whops, try again.");
                input = Console.ReadLine();
            }

            string[] words = input.Split(new Char [] {','});
            for (int i = 0; i < words.Length; i++)
            {
                string s = words[i].Trim();
                h.add(s);
            }

            Console.WriteLine("in order: ");
            while (h.hasNext())
            {
                Console.Write(h.getNext() + " ");
            }
            Console.WriteLine();

            //again...
            for (int i = 0; i < words.Length; i++)
            {
                string s = words[i].Trim();
                h.add(s);
            }

            Console.WriteLine("in order: ");
            while (h.hasNext())
            {
                Console.Write(h.getNext() + " ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
