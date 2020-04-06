using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleList list = new SingleList();
            Console.Write("Enter the number of nodes to be inserted : ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element {0} : ", i);
                int data = int.Parse(Console.ReadLine());
                Console.WriteLine("Select :\n1.Insert in the Beginning  2.Insert at the end \n3.Insert After Specific Node  4.Insert Before Specific Node");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        list.InsertInBeginning(data);
                        break;
                    case 2:
                        list.InsertAtEnd(data);
                        break;
                    case 3:
                        Console.Write("Enter Node to insert after it : ");
                        int x = int.Parse(Console.ReadLine());
                        list.InsertAfter(data, x);
                        break;
                    case 4:
                        Console.Write("Enter Node to insert before it : ");
                        x = int.Parse(Console.ReadLine());
                        list.InsertBefore(data, x);
                        break;
                }
                Console.WriteLine();
            }
            Console.Write("List is : ");
            list.Traverse();
            Console.WriteLine();
            Console.WriteLine("\nDo you want to delete a node? : 1.Yes  2.No");
            int wann = int.Parse(Console.ReadLine());
            switch (wann)
            {
                case 1:
                    goto Here;
                case 2:
                    Console.WriteLine("\nThanks, See u later");
                    goto Bye;
            }
        Here:
            Console.WriteLine("Select :\n1.Delete First Node    2.Delete Last Node      3.Delete Specific Node");
            int choice2 = int.Parse(Console.ReadLine());
            switch (choice2)
            {
                case 1:
                    list.DeleteFirstNode();
                    break;
                case 2:
                    list.DeleteLastNode();
                    break;
                case 3:
                    Console.Write("Enter Node u wanna to delete : ");
                    int x = int.Parse(Console.ReadLine());
                    list.DeleteSpecialNode(x);
                    break;
            }
            Console.Write("New List is : ");
            list.Traverse();
        Bye:
            Console.ReadKey();
        }
    }
    class Node
    {
        public int value;
        public Node next;
        public Node(int i)
        {
            value = i;
            next = null;
        }
    }
    class SingleList
    {
        Node head = null;
        public void InsertInBeginning(int data)
        {
            Node temp = new Node(data);
            if (head == null) //If list is empty
            {
                head = temp;
                return;
            }
            temp.next = head;
            head = temp;
        }
        public void InsertAtEnd(int data)
        {
            Node p = head;
            Node temp = new Node(data);
            if (head == null) //If list is empty
            {
                head = temp;
                return;
            }
            while (p.next != null) //Find the last node
            {
                p = p.next;
            }
            p.next = temp;
        }
        public void InsertAfter(int data, int x)
        {
            Node p = head;
            while (p != null) //Find position x
            {
                if (p.value == x) { break; }
                p = p.next;
            }
            if (p == null) //If list is empty
            {
                Console.WriteLine(x + " not present in the list");
            }
            else //Insert data
            {
                Node temp = new Node(data);
                temp.next = p.next;
                p.next = temp;
            }
        }
        public void InsertBefore(int data, int x)
        {
            Node p = head;
            while (p != null) //Find position x
            {
                if (p.next.value == x) { break; }
                p = p.next;
            }
            if (p == null) //If list is empty
            {
                Console.WriteLine(x + " not present in the list");
            }
            else //Insert data
            {
                Node temp = new Node(data);
                temp.next = p.next;
                p.next = temp;
            }
        }
        public void DeleteFirstNode()
        {
            if (head == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }
            head = head.next;
        }
        public void DeleteLastNode()
        {
            if (head == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }
            if (head.next == null)
            {
                head = null;
                return;
            }
            Node p = head;
            while (p.next.next != null) //Find last node
            {
                p = p.next;
            }
            p.next = null; //Set last node after deletetion to Null
        }
        public void DeleteSpecialNode(int x)
        {
            if (head == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }
            if (head.value == x) //If x is the first node
            {
                head = head.next;
                return;
            }
            //If x in between or at the end
            Node p = head;
            while (p.next != null) //Find x in the list
            {
                if (p.next.value == x)
                {
                    break;
                }
                p = p.next;
            }
            if (p.next == null)
            {
                Console.WriteLine(x + " not present in the list");
            }
            else
            {
                p.next = p.next.next;
            }
        }
        public void Traverse()
        {
            Node p = head;
            while (p != null)
            {
                Console.Write(p.value + " ");
                p = p.next;
            }
        }
    }
}