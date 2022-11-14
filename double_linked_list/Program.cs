﻿using System;
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
}