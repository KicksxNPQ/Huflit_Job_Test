using System;
using System.Collections.Generic;

namespace Huflit_Test
{
    public class LinkedList
    {
        public Node head = null;
        public Node tail = null;
        public LinkedList()
        {
        }

        public void AddToFirst(Node newElement)
        {
            if (head == null || tail == null)
            {
                head = newElement;
                tail = newElement;
                return;
            }
            newElement.nextNode = head;
            head = newElement;
        }

        public void AddToLast(Node newElement)
        {
            if (head == null || tail == null)
            {
                head = newElement;
                tail = newElement;
                return;
            }
            tail.nextNode = newElement;
            tail = newElement;
        }

        public void AddToPosition(int position, Node newElement)
        {
            if (position == 0)
            {
                newElement.nextNode = head;
                head = newElement;
                return;
            }
            Node iterator = head;
            for (int i = 0; i < position-1; i++)
                iterator = iterator.nextNode;
            newElement.nextNode = iterator.nextNode;
            iterator.nextNode = newElement;
        }

        public void RemoveFirst()
        {
            if (head == tail)
            {
                head = null;
                tail = null;
                return;
            }
            if (head != null)
                head = head.nextNode;
        }

        public void RemoveLast()
        {
            if (head == tail)
            {
                head = null;
                tail = null;
                return;
            }
            Node pointer = head;
            while (pointer.nextNode != tail)
                pointer = pointer.nextNode;
            tail = pointer;
            tail.nextNode = null;
        }

        public void RemoveInPosition(int position)
        {
            if (position == 0)
            {
                this.RemoveFirst();
                return;
            }
            Node iterator = head;
            for (int i = 0; i < position - 1; i++)
                iterator = iterator.nextNode;
            Node nodeInPosition = iterator.nextNode;
            Node nodeInFuture = nodeInPosition.nextNode;

            iterator.nextNode = nodeInFuture;
            nodeInPosition = null;
        }

        public void RemoveByValue(Object value)
        {
            Node iterator = head;
            int position = 0;
            while (iterator != null)
            {
                Object data = iterator.data;               
                iterator = iterator.nextNode;
                if (value.Equals(data))
                    this.RemoveInPosition(position--);
                position++;
            }
        }

        public void AddFromAnotherListAtBegin(LinkedList another)
        {
            this.AddFromAnotherList(0, another);
        }

        public void AddFromAnotherListAtEnd(LinkedList another)
        {
            if (another.head == null) return;
            this.tail.nextNode = another.head;
        }

        public void AddFromAnotherList(int position, LinkedList another)
        {
            if (another.head == null || another.tail == null) return;
            if (position == 0)
            {
                another.tail.nextNode = this.head;
                head = another.head;
                return;
            }
            Node iterator = head;
            for (int i = 0; i < position - 1; i++)
                iterator = iterator.nextNode;
            another.tail.nextNode = iterator.nextNode;
            iterator.nextNode = another.head;
        }

        private Node GetNodeInPosition(int position)
        {
            Node iterator = head;
            while (position > 0)
            {
                iterator = iterator.nextNode;
                position--;
            }
            return iterator;
        }

        public void Swap(int firstPosition, int secondPosition) {
            Node firstNode = this.GetNodeInPosition(firstPosition);
            Node secondNode = this.GetNodeInPosition(secondPosition);
            Object temp = firstNode.data;
            firstNode.data = secondNode.data;
            secondNode.data = temp;     
        }

        public Object[] GetList()
        {
            List<Object> datas = new List<Object>();
            Node iterator = head;
            while (iterator != null)
            {
                datas.Add(iterator.data);
                iterator = iterator.nextNode;
            }
            return datas.ToArray();
        }
    }
}
