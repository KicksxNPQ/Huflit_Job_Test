using NUnit.Framework;
using System;
using Huflit_Test;

namespace UnitTest
{
    [TestFixture]
    public class Testing
    {
        private LinkedList list;
        [SetUp]
        public void Setup()
        {
            list = new LinkedList();
        }

        [TestCase(new Object[] { 2, 3, 4, 5, 3, "abc" }, ExpectedResult = new Object[] { 2, 3, 4, 5, 3, "abc" })]
        [TestCase(new Object[] { 2, 2, 2, 2, 2, 2, 2 }, ExpectedResult = new Object[] { 2, 2, 2, 2, 2, 2, 2 })]
        [TestCase(new Object[] { null }, ExpectedResult = new Object[] { null })]
        [TestCase(new Object[] { "abcdefg", 2 }, ExpectedResult = new Object[] { "abcdefg", 2 })]
        public Object[] TraversingList(Object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));

            Object[] actualList = list.GetList();
            return actualList;
        }
        [Test]
        public void TraversingEmtpyList()
        {
            Object[] actualList = list.GetList();
            Object[] arr = new Object[] { };
            Assert.AreEqual(arr, actualList);
        }

        [TestCase(new Object[] { 2, 3, null }, ExpectedResult = new Object[] { 2, 3, null })]
        [TestCase(new Object[] { null, null, null, null, null, null, null }, ExpectedResult = new Object[] { null, null, null, null, null, null, null })]
        [TestCase(new Object[] { null }, ExpectedResult = new Object[] { null })]
        [TestCase(new Object[] { null, 2, 3, 4 }, ExpectedResult = new Object[] { null, 2, 3, 4 })]
        public Object[] TravereWithMoreThanOneStoredValueIsNull(Object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));

            Object[] actualList = list.GetList();
            return actualList;
        }

        [TestCase(new Object[] { }, 219, ExpectedResult = new Object[] { 219})]
        [TestCase(new Object[] { null}, null, ExpectedResult = new Object[] { null,null })]
        [TestCase(new Object[] { "abcd", null, 2 , 3 ,4 }, "300", ExpectedResult = new Object[] { "300", "abcd", null, 2, 3, 4 })]
        [TestCase(new Object[] { }, null, ExpectedResult = new Object[] { null })]
        [TestCase(new Object[] { 2, 2 ,2 , 2, 2 ,2 }, 219, ExpectedResult = new Object[] { 219, 2, 2, 2, 2, 2, 2 })]
        public Object[] AddAtBegin(Object[] arr, Object addedValue)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));
            
            this.list.AddToFirst(new Node(addedValue));

            Object[] actualList = list.GetList();
            return actualList;
        }

        [TestCase(new Object[] { }, 219, ExpectedResult = new Object[] { 219 })]
        [TestCase(new Object[] { null }, null, ExpectedResult = new Object[] { null, null })]
        [TestCase(new Object[] { "abcd", null, 2, 3, 4 }, "300", ExpectedResult = new Object[] { "abcd", null, 2, 3, 4, "300" })]
        [TestCase(new Object[] { }, null, ExpectedResult = new Object[] { null })]
        [TestCase(new Object[] { 2, 2, 2, 2, 2, 2 }, 219, ExpectedResult = new Object[] { 2, 2, 2, 2, 2, 2, 219 })]
        public Object[] AddAtLast(Object[] arr, Object addedValue)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));

            this.list.AddToLast(new Node(addedValue));

            Object[] actualList = list.GetList();
            return actualList;
        }

        [TestCase(new Object[] { 2 }, 0, "Huflit", ExpectedResult = new Object[] { "Huflit", 2 })]
        [TestCase(new Object[] { null, "HCMC" }, 1, null, ExpectedResult = new Object[] { null, null, "HCMC" })]
        [TestCase(new Object[] { "abcd", null, 2, 3, 4 }, 2, "300", ExpectedResult = new Object[] { "abcd", null, "300", 2, 3, 4 })]
        [TestCase(new Object[] { 2 , 3 , 4 , 5 ,6, 7}, 5, 8, ExpectedResult = new Object[] { 2, 3, 4, 5 ,6 , 8,7 })]
        public Object[] AddInSpecificedPosition(Object[] arr, int targetPosition, Object addedValue)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));
            //Position, Value will be added
            this.list.AddToPosition(targetPosition,new Node(addedValue));

            Object[] actualList = list.GetList();
            return actualList;
        }

        [TestCase(new Object[] {3 }, ExpectedResult = new Object[] { })]
        [TestCase(new Object[] { 2 }, ExpectedResult = new Object[] { })]
        [TestCase(new Object[] { 2, 3 , 4 }, ExpectedResult = new Object[] { 3, 4 })]
        [TestCase(new Object[] { null, 2 , 3, 4 }, ExpectedResult = new Object[] { 2, 3, 4 })]
        public Object[] DeleteAtBegin(Object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));
            //Position, Value will be added
            this.list.RemoveFirst();

            Object[] actualList = list.GetList();
            return actualList;
        }

        [TestCase(new Object[] { 3 }, ExpectedResult = new Object[] { })]
        [TestCase(new Object[] { 2 }, ExpectedResult = new Object[] { })]
        [TestCase(new Object[] { 2, 3, 4 }, ExpectedResult = new Object[] { 2,3 })]
        [TestCase(new Object[] { null, 2, 3, 4 }, ExpectedResult = new Object[] { null,  2, 3 })]
        public Object[] DeleteAtEnd(Object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));
            //Position, Value will be added
            this.list.RemoveLast();

            Object[] actualList = list.GetList();
            return actualList;
        }

        [TestCase(new Object[] { 2 }, 0, ExpectedResult = new Object[] { })]
        [TestCase(new Object[] { null, "HCMC" }, 1, ExpectedResult = new Object[] { null})]
        [TestCase(new Object[] { "abcd", null, 2, 3, 4 }, 2, ExpectedResult = new Object[] { "abcd", null, 3, 4 })]
        [TestCase(new Object[] { 2, 3, 4, 5, 6, 7 }, 5, ExpectedResult = new Object[] { 2, 3, 4, 5, 6})]
        public Object[] DeleteAtSpecificPosition(Object[] arr, int position)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));

            this.list.RemoveInPosition(position);

            Object[] actualList = this.list.GetList();
            return actualList;
        }

        [TestCase(new Object[] { 2 }, 0, ExpectedResult = new Object[] { 2 })]
        [TestCase(new Object[] { null, "HCMC" }, "HCMC", ExpectedResult = new Object[] { null })]
        [TestCase(new Object[] { "abcd", null, 2, 3, 2 }, 2, ExpectedResult = new Object[] { "abcd", null, 3})]
        [TestCase(new Object[] { 2,2,2,2,2,2,2}, 2, ExpectedResult = new Object[] {  })]
        public Object[] DeleteByValue(Object[] arr, Object deleteValue)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));

            this.list.RemoveByValue(deleteValue);

            Object[] actualList = this.list.GetList();
            return actualList;
        }
        
        [TestCase(new Object[] { 2 }, 0, 0, ExpectedResult = new Object[] { 2 })]
        [TestCase(new Object[] { null, "HCMC" }, 0, 1, ExpectedResult = new Object[] { "HCMC", null })]
        [TestCase(new Object[] { "abcd", null, 2, 3, 2 }, 0, 4, ExpectedResult = new Object[] { 2, null, 2, 3, "abcd" })]
        [TestCase(new Object[] { 2, 2, 2, 2, 2, 2, 2 }, 3, 3, ExpectedResult = new Object[] { 2, 2, 2, 2, 2, 2, 2 })]
        public Object[] SwapTwoItem(Object[] arr, int firstPosition, int secondPosition)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));

            this.list.Swap(firstPosition, secondPosition);

            Object[] actualList = this.list.GetList();
            return actualList;
        }

        [TestCase(new Object[] { 1} , new Object[] { 2 }, ExpectedResult = new Object[] {2, 1})]
        [TestCase(new Object[] { null, 3 }, new Object[] { 2 }, ExpectedResult = new Object[] { 2, null, 3 })]
        [TestCase(new Object[] { "Huflit", 3 }, new Object[] { }, ExpectedResult = new Object[] { "Huflit", 3 })]
        public Object[] AddFromAnotherListAtBegin(Object[] arr, Object[] anotherArr)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));

            LinkedList another = new LinkedList();
            for (int i = 0; i < anotherArr.Length; i++)
                another.AddToLast(new Node(anotherArr[i]));

            this.list.AddFromAnotherListAtBegin(another);

            Object[] actualList = this.list.GetList();
            return actualList;
        }

        [TestCase(new Object[] { 1 }, new Object[] { 2 }, ExpectedResult = new Object[] { 1, 2 })]
        [TestCase(new Object[] { null, 3 }, new Object[] { 2, 5 , 6 , 7 }, ExpectedResult = new Object[] { null, 3, 2 , 5 , 6, 7})]
        [TestCase(new Object[] { "Huflit", 3, 12 }, new Object[] { }, ExpectedResult = new Object[] { "Huflit", 3, 12 })]
        public Object[] AddFromAnotherListAtEnd(Object[] arr, Object[] anotherArr)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));

            LinkedList another = new LinkedList();
            for (int i = 0; i < anotherArr.Length; i++)
                another.AddToLast(new Node(anotherArr[i]));

            this.list.AddFromAnotherListAtEnd(another);

            Object[] actualList = this.list.GetList();
            return actualList;
        }

        [TestCase(new Object[] { 1 }, new Object[] { 2 }, 0 ,ExpectedResult = new Object[] { 2, 1 })]
        [TestCase(new Object[] { null, 3, 4 , 10 }, new Object[] { 2, 5, 6, 7 }, 2, ExpectedResult = new Object[] { null, 3, 2, 5, 6, 7 , 4 , 10})]
        [TestCase(new Object[] { "Huflit", 3, 12 }, new Object[] { "100" , 100 }, 2, ExpectedResult = new Object[] { "Huflit", 3, "100", 100, 12 })]
        public Object[] AddFromAnotherListAtSpecificPosition(Object[] arr, Object[] anotherArr, int position)
        {
            for (int i = 0; i < arr.Length; i++)
                this.list.AddToLast(new Node(arr[i]));

            LinkedList another = new LinkedList();
            for (int i = 0; i < anotherArr.Length; i++)
                another.AddToLast(new Node(anotherArr[i]));

            this.list.AddFromAnotherList(position, another);

            Object[] actualList = this.list.GetList();
            return actualList;
        }
    }
}
