using System;
using System.Net.NetworkInformation;
using System.Security;

namespace double_linked_list
{
    class node
    {
        public int noMhs;
        public string name;
        public node next;
        public node prev;
    }

    class DoubleLinkedList
    {
        node START;

        public DoubleLinkedList()
        {
            START = null;
        }

        public void addnode()
        {
            int nim;
            string nm;
            Console.Write("\n Enter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Enter the name of the student: ");
            nm = Console.ReadLine();
            node newNode = new node();
            newNode.noMhs = nim;
            newNode.name = nm;

            if(START == null || nim <= START.noMhs)
            {
                if((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\n Duplicate number not allowed");
                }
                newNode.next = START;
                if (START != null)
                    START.prev = null;
                START = newNode;
                return;
            }
            node previous, current;
            for(current = previous = START; current != null && nim >= current.noMhs; previous = current, current = current.next)
            {
                if(nim == current.noMhs)
                {
                    Console.WriteLine("\n Duplicate roll numbers not allowed");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if(current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool search(int rollNo, ref node previous, ref node current)
        {
            for (previous = current = START; current != null && rollNo != current.noMhs; previous = current, current = current.next) { }
            return (current != null);
        }
        public bool delNode(int rollNo)
        {
            node previous, current;
            previous = current = null;
            if (search(rollNo, ref previous, ref current) == false)
                return false;
            // the begining of the data
            if(current.next == null)
            {
                previous.next = null;
                return true;
            }
            //node between 2 node in the list
            if (current == START)
            {
                START = START.next;
                if(START != null)
                {
                    START.prev = null;
                    return true;
                }
            }
            /*if the to be deleted is in between the list then the following lines of is executed*/
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (listEmpty())
                Console.Write("\n List is empty");
            else
                Console.WriteLine("\n Record in the ascending order of" + "roll number are:\n");
            node currentNode;
            for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                Console.Write(currentNode.noMhs + "" + currentNode.name + "\n");
        }
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\n List is Empty");
            else
            {
                Console.WriteLine("\n Record in the descending order of" + "roll number are: \n");
                node currentNode;
                for(currentNode = START; currentNode != null; currentNode = currentNode.next) { }

                while(currentNode != null)
                {
                    Console.Write(currentNode.noMhs + "" + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all records in the ascending order of roll numbers");
                    Console.WriteLine("4. View all records in the descending order of roll numbers");
                    Console.WriteLine("5. Search for a record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.Write("Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addnode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                Console.WriteLine("\n Enter the roll number of the student" + "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else 
                                    Console.WriteLine("Record with roll number" + rollNo + "deleted\n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if(obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                node prev, curr;
                                prev = curr = null;
                                Console.Write("\n Enter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev,ref curr) == false)
                                    Console.WriteLine("\n Record not found");
                                else
                                {
                                    Console.WriteLine("\n Record found");
                                    Console.WriteLine("\n Roll number: " + curr.noMhs);
                                    Console.WriteLine("\n Name: " + curr.name);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\n Invalid option");
                            }
                            break;

                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }
}