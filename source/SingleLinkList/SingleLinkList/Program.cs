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

    public class SumLinkList
    {
        public void SumOfTwoLinkList(LinkList list1, LinkList list2)
        {
            var sumLinkList = new LinkList();
            var carry = 0;
            while (list1.head != null || list2.head != null)
            {
                var sum = carry;

                if (list1.head != null)
                {
                    sum += list1.head.data;
                    list1.head = list1.head.next;
                }

                if (list2.head != null)
                {
                    sum += list2.head.data;
                    list2.head = list2.head.next;
                }
                var data = sum % 10;
                sumLinkList.AddAtEnd(data);
                carry = sum / 10;
            }

            if (carry > 0)
            {
                sumLinkList.AddAtEnd(carry);
            }

            sumLinkList.DisplayData();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var linkList1 = new LinkList();

            //Test case 1
            //linkList1.AddAtEnd(2);
            //linkList1.AddAtEnd(4);
            //linkList1.AddAtEnd(3);

            //Test case 2
            linkList1.AddAtEnd(9);
            linkList1.AddAtEnd(9);
            linkList1.AddAtEnd(9);
            linkList1.AddAtEnd(9);
            linkList1.AddAtEnd(9);
            linkList1.AddAtEnd(9);
            linkList1.AddAtEnd(9);




            var linkList2 = new LinkList();

            //Test case 1
            //linkList2.AddAtEnd(5);
            //linkList2.AddAtEnd(6);
            //linkList2.AddAtEnd(4);

            //Test case 2
            linkList2.AddAtEnd(9);
            linkList2.AddAtEnd(9);
            linkList2.AddAtEnd(9);
            linkList2.AddAtEnd(9);



            //Console.WriteLine(linkList1.DeleteNodeForProvidedKey(100));
            new SumLinkList().SumOfTwoLinkList(linkList1, linkList2);

            //  linkList1.DisplayData();
        }
    }
}
