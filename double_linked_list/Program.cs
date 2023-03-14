using System;
using System.Net.NetworkInformation;
using System.Security;

namespace double_linked_list
{
    class node // ini adalah class node yang berguna sebagai blueprint untuk membuat objek node
    {
        // public disini berarti variabel dapat digunakan diluar kelas/kelas yang lain
        public int noMhs; // ini adalah variabel noMhs bertipe data integer(angka) digunakan sebagai wadah untuk mengisi data angka
        public string name; // ini adalah variabel name bertipe data string yang digunakan sebagai wadah untuk mengisi data huruf
        public node next; // ini adalah objek yang dibuat langsung didalam code dengan nama next  
        public node prev; // ini adalah objek yang dibuat langsung didalam code dengan nama prev
    }

    class DoubleLinkedList
    {
        node START;

        public DoubleLinkedList()
        {
            START = null;
        }

        public void addnode()// ini adalah method void yang berguna untuk menambahkan data 
        {
            int nim;
            string nm;
            // input data nama dan nim
            Console.Write("\n Enter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Enter the name of the student: ");
            nm = Console.ReadLine();
            // memasukkan data yang telah diinput kedalam node
            node newNode = new node();
            newNode.noMhs = nim;
            newNode.name = nm;
            // jika data dinode masi kosong/belum ada data sama sekali
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
            // jika data yang dimasukkan kedalam node yang berada diantara 2 node
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
            //ini jika angkanya lebih besar dari semua elemen yang ada di linked list.
            if(current == null)  
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        // method untuk emncari data yang sudah dimasukkan
        public bool search(int rollNo, ref node previous, ref node current)
        {
            for (previous = current = START; current != null && rollNo != current.noMhs; previous = current, current = current.next) { }
            return (current != null);
        }
        // method untuk menghapus data yang sudah dimasukkan
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
        // methode untuk memastikan kekosongan data
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        // method untuk menampilkan data dari urutan atas ke bawah
        public void ascending()
        {
            if (listEmpty())
                Console.Write("\n List is empty");
            else
                Console.WriteLine("\n Record in the ascending order of" + " " + "roll number are:\n");
            node currentNode;
            for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                Console.Write(currentNode.noMhs + " " + currentNode.name + "\n");
        }
        // method untuk menampilkan data dari urutan bawah ke atas
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\n List is Empty");
            else
            {
                Console.WriteLine("\n Record in the descending order of" + " " + "roll number are: \n");
                node currentNode;
                for(currentNode = START; currentNode != null; currentNode = currentNode.next) { }
                while(currentNode != null)
                {

                    Console.Write(currentNode.noMhs + " " + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
            
        }
    }
    class Program // class untuk menjalankan program
    {
        static void Main(string[] args) // method untuk menjalankan program
        {
            DoubleLinkedList obj = new DoubleLinkedList(); // membuat objek dari class DoubleLinkedList
            while (true)
            {
                try 
                {
                    // Menu dari program yang dijalankan
                    Console.WriteLine("\n Menu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all records in the ascending order of roll numbers");
                    Console.WriteLine("4. View all records in the descending order of roll numbers");
                    Console.WriteLine("5. Search for a record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.Write("Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine()); // menerima input dari user memilih menu yang ada
                    switch (ch)
                    {
                        case '1':// jika pilihan menu 1
                            {
                                obj.addnode(); // memanggil objek dan methodnya
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty()) // memanggil objek dan methodnya
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                // user input data nim yang akan dihapus
                                Console.WriteLine("\n Enter the roll number of the student" + "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                // jika datanya tidak ada
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                // jika datanya ada
                                else 
                                    Console.WriteLine("Record with roll number" + " " +  rollNo + " " + "deleted\n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending(); // memanggil objek dan methodnya
                            }
                            break;
                        case '4':
                            {
                                obj.descending(); // memanggil objek dan methodnya
                            }
                            break;
                        case '5':
                            {
                                if(obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                // untuk mencari data 
                                node prev, curr;
                                prev = curr = null;
                                Console.Write("\n Enter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                // jika datanya tidak ada
                                if (obj.search(num, ref prev,ref curr) == false)
                                    Console.WriteLine("\n Record not found");
                                // jika datanya ada
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
                                Console.WriteLine("\n Invalid option"); // jika angka yang dimasukkan tidak ada di menu yang disediakan
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