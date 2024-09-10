using System.Collections.Generic;

public interface IList
{
    void InsertInOrder(int value);
    int DeleteFirst();
    int DeleteLast();
    bool DeleteValue(int value);
    int GetMiddle();
    void MergeSorted(IList listA, IList listB, Program.sortDirection direction);
}

public class node
{
    public node nextNode;
    public node prevNode;
    public node middleNode;
    public int element;

    public node(int element)
    {
        nextNode = null;
        prevNode = null;
        middleNode = null;
        this.element = element;
    }
}

public class doublyLinkedList : IList
{
    public node head;
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
        refreshMiddleNode();
    }

    public int remove(int index)
    {
        int element;
        if (head == null)
        {
            return -1;
        }
        else if (size == 1 && index == 0)
        {
            element = head.element;
            head = null;
            --size;
            refreshMiddleNode();
            return element;
        }
        else if (index == 0)
        {
            element = head.element;
            head.nextNode.prevNode = null;
            head = head.nextNode;
            --size;
            refreshMiddleNode();
            return element;
        }
        else
        {
            node marker = head;
            for (int i = 0; i != index; i++)
            {
                marker = marker.nextNode;
            }

            element = marker.element;
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
        refreshMiddleNode();
        --size;
        return element;
    }

    public int DeleteLast ()
    {
        int element = remove(size - 1);
        return element;
    }

    public int DeleteFirst ()
    {
        int element = remove(0);
        return element;
    }

    public bool DeleteValue (int value)
    {
        if (head == null)
        {
            return false;
        } else if (head.element == value && head.nextNode == null)
        {
            head = null;
            --size;
            refreshMiddleNode();
            return true;
        } else
        {
            node marker = head;
            while (marker.element != value)
            {
                if (marker.element != null)
                {
                    marker = marker.nextNode;
                } else
                {
                    return false;
                }
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
            --size;
            refreshMiddleNode();
            return true;
        }
    }

    public void InsertInOrder (int value)
    {
        node newNode = new node(value);
        if (head == null)
        {
            return;
        }
        else if (head.element > newNode.element)
        {
            head.prevNode = newNode;
            newNode.nextNode = head;
            head = newNode;
            ++size;
        }
        else
        {
            node current = head;
            while (current != null && current.element < newNode.element)
            {
                current = current.nextNode;
            }
            if (current == null)
            {
                this.add(value);
                return;
            }
            else
            {
                newNode.prevNode = current.prevNode;
                current.prevNode.nextNode = newNode;
                newNode.nextNode = current;
                current.prevNode = newNode;
                ++size;
            }
        }
        refreshMiddleNode();
    }

    public void refreshMiddleNode ()
    {
        node middleMarker = head;
        if (size % 2 != 0)
        {
            int middleIndex = size / 2;
            node middleNode;

            for (int i = 0; i < middleIndex; i++)
            {
                middleMarker = middleMarker.nextNode;
            }

            middleNode = middleMarker;
            middleMarker = head;
            while (middleMarker != null)
            {
                middleMarker.middleNode = middleNode;
                middleMarker = middleMarker.nextNode;
            }
        }
        else
        {
            int middleIndex = (size / 2);
            node middleNode;

            for (int i = 0; i < middleIndex; i++)
            {
                middleMarker = middleMarker.nextNode;
            }

            middleNode = middleMarker;
            middleMarker = head;
            while (middleMarker != null)
            {
                middleMarker.middleNode = middleNode;
                middleMarker = middleMarker.nextNode;
            }
        }
    }

    public int GetMiddle()
    {
        return head.middleNode.element;
    }

    public void MergeSorted(IList listA, IList listB, Program.sortDirection sortDirection)
    {
        Program.mergeSorted((doublyLinkedList)listA, (doublyLinkedList)listB, sortDirection);
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

public class Program
{
    public enum sortDirection { Asc, Desc }

    public static void Main(string[] args)
    {
    }

    public static void mergeSorted(doublyLinkedList listA, doublyLinkedList listB, sortDirection direction)
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
            }
        }
    }

    public static void invert(doublyLinkedList list)
    {
        if (list == null)
        {
            throw new Exception("That list is null.");
            return;
        }
        node tempMarker = list.head;
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
                list.head = tempMarker;
                tempMarker = tempNodeSave;
            }
        }
    }

    public static int getMiddleElement(doublyLinkedList list)
    {
        if (list == null)
        {
            throw new Exception("The list is null.");
        } else if (list.head == null)
        {
            throw new Exception("The list is empty.");
        } else
        {
            return list.GetMiddle();
        }
    }

}