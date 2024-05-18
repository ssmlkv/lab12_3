using lab10;
using Laba12_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest1
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Point_DefaultConstructor_ShouldSetPropertiesToDefault()
        {
            // Arrange
            Point<int> point = new Point<int>();

            // Act

            // Assert
            Assert.AreEqual(default(int), point.Data);
            Assert.IsNull(point.Left);
            Assert.IsNull(point.Right);
        }

        [TestMethod]
        public void Point_ConstructorWithData_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            int testData = 42;

            // Act
            Point<int> point = new Point<int>(testData);

            // Assert
            Assert.AreEqual(testData, point.Data);
            Assert.IsNull(point.Left);
            Assert.IsNull(point.Right);
        }

        [TestMethod]
        public void Point_CompareTo_ShouldReturnCorrectComparisonResult()
        {
            // Arrange
            Point<int> point1 = new Point<int>(42);
            Point<int> point2 = new Point<int>(42);
            Point<int> point3 = new Point<int>(50);

            // Act
            int result1 = point1.CompareTo(point2);
            int result2 = point1.CompareTo(point3);

            // Assert
            Assert.AreEqual(0, result1);
            Assert.AreEqual(-1, result2);
        }

        [TestMethod]
        public void MyTree_ShowTree_ShouldNotThrowException()
        {
            // Arrange
            MyTree<Carriage> tree = new MyTree<Carriage>(0);

            // Act & Assert
            tree.ShowTree(); // Метод не должен вызывать исключение
        }

        [TestMethod]
        public void MyTree_ClearTree_ShouldResetCountToZero()
        {
            // Arrange
            MyTree<Carriage> tree = new MyTree<Carriage>(5);

            // Act
            tree.ClearTree();

            // Assert
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void MyTree_AddPointToEmptyTree_ShouldIncreaseCount()
        {
            // Arrange
            MyTree<Carriage> tree = new MyTree<Carriage>(0);
            int initialCount = tree.Count;

            // Act
            Carriage carriage = new Carriage();
            carriage.RandomInit();
            tree.AddPoint(carriage);

            // Assert
            Assert.AreEqual(initialCount + 1, tree.Count);
        }

        [TestMethod]
        public void MyTree_AddPointToNonEmptyTree_ShouldIncreaseCount()
        {
            // Arrange
            MyTree<Carriage> tree = new MyTree<Carriage>(0);
            Carriage carriage1 = new Carriage();
            carriage1.RandomInit();
            tree.AddPoint(carriage1); // Добавляем один элемент

            int initialCount = tree.Count;

            // Act
            Carriage carriage2 = new Carriage();
            carriage2.RandomInit();
            tree.AddPoint(carriage2);

            // Assert
            Assert.AreEqual(initialCount + 1, tree.Count);
        }

        [TestMethod]
        public void MyTree_AddFirstPoint_ShouldSetRootCorrectly()
        {
            // Arrange
            MyTree<Carriage> tree = new MyTree<Carriage>(0);

            // Act
            Carriage carriage = new Carriage();
            carriage.RandomInit();
            tree.AddPoint(carriage);

            // Assert
            Assert.IsNotNull(tree.root);
            Assert.IsTrue(tree.root.Data.Equals(carriage));
        }

        [TestMethod]
        public void CountLeaves_EmptyTree_ShouldReturnZero()
        {
            // Arrange
            MyTree<Carriage> tree = new MyTree<Carriage>(0);

            // Act
            int result = tree.CountLeaves();

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountLeaves_TreeWithSingleElement_ShouldReturnOne()
        {
            // Arrange
            MyTree<Carriage> tree = new MyTree<Carriage>(1);
            var carriage = new Carriage();
            tree.AddPoint(carriage);

            // Act
            int result = tree.CountLeaves();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CountLeaves_TreeWithMultipleElements_ShouldReturnCorrectCount()
        {
            // Arrange
            MyTree<Carriage> tree = new MyTree<Carriage>(5);
            tree.AddPoint(new Carriage());
            tree.AddPoint(new Carriage());
            tree.AddPoint(new Carriage());
            tree.AddPoint(new Carriage());
            tree.AddPoint(new Carriage());
            // Expected tree structure: 5 nodes in total, 1 leaf

            // Act
            int result = tree.CountLeaves();

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}
