using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifo_page_replacement
{
    class kuyruk
    {
        public int data;
        public kuyruk next;
        public kuyruk prev;
    }
    
    class Program
    {
        static kuyruk front = null;
        static kuyruk rear = null;
        public static void addData(int data)
        {
            kuyruk bl = new kuyruk();
            bl.data = data;
            bl.next = null;
            bl.prev = null;

            if (front == null)
            {
                front = bl;
                rear = bl;
            }
            else
            {
                rear.next = bl;
                bl.prev = rear;
                rear = bl;
            }
        }

        static int getData()
        {
            int data = front.data;

            if (front.next != null)
            {
                front.next.prev = null;
                front = front.next;
            }
            return data;
        }
        static void Main(string[] args)
        {
            int sayac = 0;
            Console.WriteLine("Kaç tane Frame gelecek?");
            int frameAdet = Int32.Parse(Console.ReadLine());

            for (int i = 1; i <= frameAdet; i++)
            {
                Console.WriteLine(i + ". Frame giriniz: ");
                addData(Int32.Parse(Console.ReadLine()));
            }

            int[] pageFrame = { -1, -1, -1 }; // page Frame ilk 3 gelen frame 0 olduğu zaman çalışması için
            

            for (int i = 0; i < frameAdet; i++)
            {
                int data = getData();
                if (pageFrame[0] != data | pageFrame[1] != data | pageFrame[2] != data)
                {
                    pageFrame[sayac] = data;
                    sayac++;
                }
                if (sayac == 3)
                {
                    sayac = 0;
                    
                }

                for (int j = 0; j < pageFrame.Length; j++)
                {
                    Console.Write("  " + pageFrame[j] + "  ");
                    
                }
                Console.WriteLine();
            }
        }
    }
}
