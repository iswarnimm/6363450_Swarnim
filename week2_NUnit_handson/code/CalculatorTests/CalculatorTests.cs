using NUnit.Framework;
using ClassLibrary1;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calc;

        [SetUp]
        public void Init()
        {
            calc = new Calculator();
        }

        [TearDown]
        public void Cleanup()
        {
            // Cleanup code if needed
        }

        [Test]
        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        [TestCase(0, 0, 0)]
        public void Add_ShouldReturnCorrectResult(int a, int b, int expected)
        {
            int result = calc.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
