using System;

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
    }
}