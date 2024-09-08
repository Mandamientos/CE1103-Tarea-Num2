using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

public class node
{
    public node nextNode;
    public node prevNode;
    public int element;

    public node(int element)
    {
        nextNode = null;
        prevNode = null;
        this.element = element;
    }
}

public class doublyLinkedList
{
    public node head;
    public node tail;
    public int size;

    public doublyLinkedList()
    {
        head = null;
        size = 0;
    }

    public void add(int element)
    {
        node newNode = new node(element);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            node marker = head;
            while (marker.nextNode != null)
            {
                marker = marker.nextNode;
            }
            marker.nextNode = newNode;
            newNode.prevNode = marker;
        }
        size++;
    }

    public void remove(int index)
    {
        if (head == null)
        {
            return;
        }
        else if (size == 1 && index == 0)
        {
            head = null;
        }
        else if (index == 0)
        {
            head.nextNode.prevNode = null;
            head = head.nextNode;
        }
        else
        {
            node marker = head;
            for (int i = 0; i != index; i++)
            {
                marker = marker.nextNode;
            }
            marker.prevNode.nextNode = marker.nextNode;
            if (marker.nextNode == null)
            {
                marker.prevNode.nextNode = null;
            }
            else
            {
                marker.nextNode.prevNode = marker.prevNode;
            }
        }
        --size;
    }

    public void showList()
    {
        node marker = head;

        while (marker != null)
        {
            Console.WriteLine($"{marker.element}");
            marker = marker.nextNode;
        }
    }
}

public class Problema1
{
    public enum sortDirection { Asc, Desc }
    public static void Main(string[] args)
    {
        doublyLinkedList listA = new doublyLinkedList();
        //  listA.add(10);
        //  listA.add(20);
        //  listA.add(30);

        doublyLinkedList listB = new doublyLinkedList();
        listB.add(5);
        listB.add(15);
        listB.add(25);

        mergeSorted(listA, listB, sortDirection.Asc);
        listA.showList();

    }

    public static doublyLinkedList mergeSorted(doublyLinkedList listA, doublyLinkedList listB, sortDirection direction)
    {
        if (listA == null || listB == null)
        {
            throw new Exception("One of your two lists seems to be null.");
        }
        else
        {
            if (direction == sortDirection.Asc)
            {
                {
                    node markerB = listB.head;
                    while (markerB != null)
                    {
                        node markerA = listA.head;
                        while (markerA != null && markerB.element > markerA.element)
                        {
                            markerA = markerA.nextNode;
                        }

                        node newNode = new node(markerB.element);
                        if (markerA == null)
                        {
                            listA.add(markerB.element);
                        }
                        else
                        {
                            if (markerA == listA.head)
                            {
                                listA.head.prevNode = newNode;
                                newNode.nextNode = listA.head;
                                listA.head = newNode;
                            }
                            else
                            {
                                markerA.prevNode.nextNode = newNode;
                                markerA.prevNode = newNode;
                                newNode.nextNode = markerA;
                            }
                        }

                        markerB = markerB.nextNode;
                    }
                    return listA;
                }
            }
            else
            {
                node tempMarker = listA.head;
                node tempNodeSave = null;

                while (tempMarker != null)
                {
                    tempNodeSave = tempMarker.nextNode;
                    tempMarker.nextNode = tempMarker.prevNode;
                    tempMarker.prevNode = tempNodeSave;
                    if (tempNodeSave != null)
                    {
                        tempMarker = tempNodeSave;
                    }
                    else
                    {
                        listA.head = tempMarker;
                        tempMarker = tempNodeSave;
                    }
                }

                node markerB = listB.head;
                while (markerB != null)
                {
                    node markerA = listA.head;
                    while (markerA != null && markerB.element < markerA.element)
                    {
                        markerA = markerA.nextNode;
                    }

                    node newNode = new node(markerB.element);
                    if (markerA == null)
                    {
                        listA.add(markerB.element);
                    }
                    else
                    {
                        if (markerA == listA.head)
                        {
                            listA.head.prevNode = newNode;
                            newNode.nextNode = listA.head;
                            listA.head = newNode;
                        }
                        else
                        {
                            markerA.prevNode.nextNode = newNode;
                            markerA.prevNode = newNode;
                            newNode.nextNode = markerA;
                        }
                    }

                    markerB = markerB.nextNode;
                }
                return listA;
            }
        }
    }
}