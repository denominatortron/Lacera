using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserLibrary.Entities;

namespace ParserLibraryTest
{
    [TestClass]
    public class EmployeeTest
    {
        Employee employee;

        public EmployeeTest()
        {
            employee = null;
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize() 
        {
            employee = new Employee(); 
        }
        
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            employee = null;
        }
        
        #endregion

        [TestMethod]
        public void EmployeeConstructorTest()
        {
            Assert.IsNull(employee.Name);
            Assert.IsTrue(DateTime.Compare(employee.Birthdate, new DateTime()) == 0);
            Assert.IsTrue(employee.Salary == 0);
            Assert.IsTrue(DateTime.Compare(employee.DateHired, new DateTime()) == 0);
        }

        [TestMethod]
        public void EmployeeInflateMethodValidInputTest()
        {
            String[] inputs = new String[]{ "Nam Nguyen", "6/28/1984", "1000000.00", "9/13/2016" };
            employee.Inflate(inputs);

            Assert.IsFalse(employee.Invalid);
            Assert.AreEqual<String>(employee.Name, "Nam Nguyen");
            Assert.AreEqual<DateTime>(employee.Birthdate, new DateTime(1984, 6, 28));
            Assert.AreEqual<decimal>(employee.Salary, 1000000.00m);
            Assert.AreEqual<DateTime>(employee.DateHired, new DateTime(2016, 9, 13));
        }

        [TestMethod]
        public void EmployeeInflateMethodInvalidSalaryTest()
        {
            String[] inputs = new String[] { "Nam Nguyen", "6/28/1984", "not enough", "9/13/2016" };
            employee.Inflate(inputs);

            Assert.IsTrue(employee.Invalid);
        }

        [TestMethod]
        public void EmployeeInflateMethodZeroSalaryTest()
        {
            String[] inputs = new String[] { "Nam Nguyen", "6/28/1984", "0", "9/13/2016" };
            employee.Inflate(inputs);

            Assert.IsTrue(employee.Invalid);
        }

        [TestMethod]
        public void EmployeeInflateMethodMissingFieldTest()
        {
            String[] inputs = new String[] { "6/28/1984", "1000000.00", "9/13/2016" };
            employee.Inflate(inputs);

            Assert.IsTrue(employee.Invalid);
        }


        [TestMethod]
        public void EmployeeInflateMethodInvalidBirthdateTest()
        {
            String[] inputs = new String[] { "Nam Nguyen", "Big Bang", "1000000.00", "9/13/2016" };
            employee.Inflate(inputs);

            Assert.IsTrue(employee.Invalid);
        }

        public void EmployeeInflateMethodInvalidDateHiredTest()
        {
            String[] inputs = new String[] { "Nam Nguyen", "6/28/1984", "1000000.00", "Yesterday" };
            employee.Inflate(inputs);

            Assert.IsTrue(employee.Invalid);
        }
    }
}
