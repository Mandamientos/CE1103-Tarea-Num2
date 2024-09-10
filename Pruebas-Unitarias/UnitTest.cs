namespace Pruebas_Unitarias
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void mergeSorted_OneNull()
        {
            doublyLinkedList listA = null;
            doublyLinkedList listB = new doublyLinkedList();

            Program.mergeSorted(listA, listB, Program.sortDirection.Asc);
        }

        [TestMethod]
        public void mergeSorted_AscendingSort()
        {
            doublyLinkedList listA = new doublyLinkedList();
            doublyLinkedList listB = new doublyLinkedList();

            List<int> listAContent = new List<int>{ 0, 2, 6, 10, 25 };
            List<int> listBContent = new List<int> { 3, 7, 11, 40, 50 };
            List<int> listSorted = new List<int> { 0, 2, 3, 6, 7, 10, 11, 25, 40, 50 };

            foreach (int element in listAContent)
            {
                listA.add(element);
            }

            foreach (int element in listBContent)
            {
                listB.add(element);
            }

            Program.mergeSorted(listA, listB, Program.sortDirection.Asc);

            node marker = listA.head;
            foreach (int element in listSorted)
            {
                Assert.AreEqual(element, marker.element);
                marker = marker.nextNode;
            }
        }

        [TestMethod]
        public void mergeSorted_DecescendingSort()
        {
            doublyLinkedList listA = new doublyLinkedList();
            doublyLinkedList listB = new doublyLinkedList();

            List<int> listAContent = new List<int> { 10, 15 };
            List<int> listBContent = new List<int> { 9, 40, 50 };
            List<int> listSorted = new List<int> { 50, 40, 15, 10, 9 };

            foreach (int element in listAContent)
            {
                listA.add(element);
            }

            foreach (int element in listBContent)
            {
                listB.add(element);
            }

            Program.mergeSorted(listA, listB, Program.sortDirection.Desc);

            node marker = listA.head;
            foreach (int element in listSorted)
            {
                Assert.AreEqual(element, marker.element);
                marker = marker.nextNode;
            }
        }
        [TestMethod]
        public void mergeSorted_ListAEmpty()
        {
            doublyLinkedList listA = new doublyLinkedList();
            doublyLinkedList listB = new doublyLinkedList();

            List<int> listBContent = new List<int> { 9, 40, 50 };
            List<int> listSorted = new List<int> { 50,40,9 };

            foreach (int element in listBContent)
            {
                listB.add(element);
            }

            Program.mergeSorted(listA, listB, Program.sortDirection.Desc);

            node marker = listA.head;
            foreach (int element in listSorted)
            {
                Assert.AreEqual(element, marker.element);
                marker = marker.nextNode;
            }
        }
        [TestMethod]
        public void mergeSorted_ListBEmpty()
        {
            doublyLinkedList listA = new doublyLinkedList();
            doublyLinkedList listB = new doublyLinkedList();

            List<int> listAContent = new List<int> { 10, 15 };
            List<int> listSorted = new List<int> { 10, 15 };

            foreach (int element in listAContent)
            {
                listA.add(element);
            }

            Program.mergeSorted(listA, listB, Program.sortDirection.Asc);

            node marker = listA.head;
            foreach (int element in listSorted)
            {
                Assert.AreEqual(element, marker.element);
                marker = marker.nextNode;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void invert_ListIsNull()
        {
            doublyLinkedList list = null;
            Program.invert(list);
        }

        [TestMethod]
        public void invert_ListIsEmpty()
        {
            doublyLinkedList list = new doublyLinkedList();

            Assert.AreEqual(null, list.head);
        }

        [TestMethod]
        public void invert()
        {
            doublyLinkedList list = new doublyLinkedList();

            List<int> listElements = new List<int> { 1, 0, 30, 50, 2 };
            List<int> listInvertedElements = new List<int> { 2, 50, 30, 0, 1 };

            foreach (int element in listElements) 
            {
                list.add(element);
            }
            list.showList();
            Program.invert(list);

            node marker = list.head;
            foreach(int element in listInvertedElements)
            {
                Assert.AreEqual(element, marker.element);
                marker = marker.nextNode;
            }
        }

        [TestMethod]
        [ExpectedException (typeof(Exception))]
        public void getMiddle_ListIsNull()
        {
            doublyLinkedList list = null;

            Program.getMiddleElement(list);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void getMiddle_ListIsEmpty()
        {
            doublyLinkedList list = new doublyLinkedList();

            Program.getMiddleElement(list);
        }

        [TestMethod]
        public void getMiddle_OneElement()
        {
            doublyLinkedList list = new doublyLinkedList();
            list.add(1);

            int middleElement = Program.getMiddleElement(list);
            Assert.AreEqual(middleElement, 1);
        }

        [TestMethod]
        public void getMiddle_TwoElements()
        {
            doublyLinkedList list = new doublyLinkedList();
            list.add(1);
            list.add(2);

            int middleElement = Program.getMiddleElement(list);
            Assert.AreEqual(middleElement, 2);
        }

        [TestMethod]
        public void getMiddle_ThreeElements()
        {
            doublyLinkedList list = new doublyLinkedList();
            list.add(1);
            list.add(2);
            list.add(3);

            int middleElement = Program.getMiddleElement(list);
            Assert.AreEqual(middleElement, 2);
        }

        [TestMethod]
        public void getMiddle_FourElements()
        {
            doublyLinkedList list = new doublyLinkedList();
            list.add(1);
            list.add(2);
            list.add(3);
            list.add(4);

            int middleElement = Program.getMiddleElement(list);
            Assert.AreEqual(middleElement, 3);
        }
    }
}