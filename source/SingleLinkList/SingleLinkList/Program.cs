using System;

namespace SingleLinkList
{
    public class LinkListNode
    {
        public int data;
        public LinkListNode next;

        public LinkListNode(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    public class LinkList
    {
        public LinkListNode head;
        public LinkListNode traverse;

        public void AddAtHead(int data)
        {
            var node = new LinkListNode(data);
            node.next = head;
            this.head = node;
        }

        public void AddAtEnd(int data)
        {
            var node = new LinkListNode(data);
            if (this.head == null)
            {
                this.head = node;
            }

            else
            {
                this.traverse = this.head;

                while (this.traverse.next != null)
                {
                    this.traverse = this.traverse.next;
                }

                this.traverse.next = node;
            }
        }

        public string DeleteNodeForProvidedKey(int data)
        {
            this.traverse = this.head;
            LinkListNode temp = this.traverse;

            while (this.traverse != null)
            {
                if (this.traverse.data == data)
                {
                    temp.next = this.traverse.next;
                    this.traverse = null;
                    return $"Node is deleted.";
                }

                else
                {
                    temp = this.traverse;

                    this.traverse = this.traverse.next;
                }
            }

            return $"Provided data not found! Node not deleted.";
        }

        public void DisplayData()
        {
            while (this.head != null)
            {
                Console.WriteLine(this.head.data);
                this.head = this.head.next;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var linkList = new LinkList();
            linkList.AddAtEnd(4);
            linkList.AddAtEnd(5);
            linkList.AddAtEnd(1);
            linkList.AddAtEnd(9);

            Console.WriteLine(linkList.DeleteNodeForProvidedKey(100));

            linkList.DisplayData();
        }
    }
}
