//author: Rose Beede
//date: 9/22/14

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class ThreeHeap
    {
        private string[] heap;
        private int length;

        public ThreeHeap()
        {
            heap = new string[10];
            length = 0;
        }

        //returns true if not empty
        public bool hasNext()
        {
            if (length > 0)
            {
                return true;
            }
            return false;
        }

        //gets the lowest value string in the heap but does not delete it
        //thows exception if the heap is empty
        public string peek()
        {
            if (length == 0)
            {
                throw new Exception("The heap is empty");
            }
            return heap[1];
        }

        //gets the smallest string in the heap, and removes it
        //will throw an exception if the heap is empty
        public string getNext()
        {
            string n = peek();
            heap[1] = heap[length];
            length--;
            
            //check to see if array can be shortened
            if (length * 2 + 2 == heap.Length)
            {
                contractHeap(); //chop off extra space
            }
            
            //instead of shifting all the values up, O(n), I used the my tree structure to do the same thing in O(logn)
            swapDown(1);
            return n;
        }

        //adds a string to heap, and returns true if successful
        public bool add(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                return false;
            }
            str = str.ToLower(); //to lower case for accurate comparison
            length++;
            //check to see if array needs expanding
            if (length + 1 == heap.Length)
            {
                expandHeap();
            }
            //adds at the bottom and then moves it up into it's proper place
            heap[length] = str;
            swapUp();
            return true;
        }

        //moves values up from the bottom of the heap to their correct place
        private void swapUp()
        {
            if(length > 1) //if there is more than one thing in the heap
            {
                int cur = length;
                //compares to parent, if this is smaller, they switch
                while(cur > 1 && string.Compare(heap[cur], heap[(cur + 1) / 3]) < 0)
                {
                    string s = heap[(cur + 1) / 3];
                    heap[(cur + 1) / 3] = heap[cur];
                    heap[cur] = s;
                    cur = (cur + 1) / 3; //resetting cur
                }
            }
        }

        //swaps values down the tree into their proper places
        private void swapDown(int cur)
        {
            while (cur < length)
            {
                //finding the children and comparing to the parent
                int child = cur * 3 - 3 + 2; //getting the index for the theoretical leftmost child
                int min = cur; //min equals this element
                int i = 0;
                //comparing to the children, if they exist, to find the smallest entry
                while ((child + i <= length) && (i < 3)) //will loop up to three times to get all the children
                {
                    int next = child + i;
                    if (string.Compare(heap[next], heap[min]) < 0)
                    {
                        min = next;
                    }
                    i++;
                }

                if (cur != min) //switch cur and min if they aren't the same
                {
                    string temp = heap[cur];
                    heap[cur] = heap[min];
                    heap[min] = temp;
                    cur = min;
                }
                else
                {
                    //end the outermost loop
                    cur = length;
                }
            }
        }

        private void expandHeap()
        {
            string[] heapTwo = new string[heap.Length * 2];
            for (int i = 0; i < heap.Length; i++)
            {
                heapTwo[i] = heap[i];
            }
            heap = heapTwo;
        }

        private void contractHeap()
        {
            string[] heapTwo = new string[heap.Length * 3 / 4];
            for (int i = 0; i < heapTwo.Length; i++)
            {
                heapTwo[i] = heap[i];
            }
            heap = heapTwo;
        }
        
    }
}
