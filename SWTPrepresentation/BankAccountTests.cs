using NUnit;
using NUnit.Framework;
using System.Collections;
using System.Diagnostics;

namespace SWTPrepresentation
{
    [TestFixture]
    public class Tests
    {
        private BankAccount account;

        [OneTimeSetUp]
        public void SetupAssembly()
        {
            Trace.WriteLine("Assembly setup");
        }
        [OneTimeTearDown]
        public void TeardownAssembly()
        {
            Trace.WriteLine("Assembly teardown");
        }

        [SetUp]
        public void Setup()
        {
            account = new BankAccount(1000);
        }

        [TearDown]
        public void Teardown()
        {
            account = null;
        }


        [Test]
        public void ShouldAddBalanceToAccount()
        {
            // ACT
            account.Add(500);

            // ASSERT
            Assert.That(account.Balance, Is.EqualTo(1500));
        }

        //[TestCase(500, 1500)]
        //[TestCase(300, 1300)]
        //[TestCase(4000, 5000)]
        [TestCaseSource(typeof(TestSource))]
        public void ShouldAddBalanceToAccount(double number, double expected)
        {
            // ACT
            account.Add(number);

            // ASSERT
            Assert.That(account.Balance, Is.EqualTo(expected));
        }

        public class TestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new double[] { 500, 1500 }; 
                yield return new double[] { 300, 1300 }; 
                yield return new double[] { 400, 1400 }; 
                yield return new double[] { 4000, 5000 }; 
            }
        }

        /*    [Test]
            public void AddNegativeShouldThrowError()
            {
                // ACT
                //account.Add(-500);

                // ACT & ASSERT 
                //Assert.That(account.Balance, Is.EqualTo(500));
                Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-500));
            }*/

        /*    [Test]
            public void ShouldSubtractBalanceToAccount()
            {
                // ACT
                account.Withdraw(500);

                // ASSERT
                Assert.That(account.Balance, Is.EqualTo(500));
            }*/
    }
}