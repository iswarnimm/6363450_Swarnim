using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommTests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> mockMailSender;
        private CustomerComm customerComm;

        [SetUp]
        public void Setup()
        {
            // Create a mock object of IMailSender
            mockMailSender = new Mock<IMailSender>();

            // Setup mock: whenever SendMail is called, return true
            mockMailSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Inject the mock into CustomerComm
            customerComm = new CustomerComm(mockMailSender.Object);
        }

        [Test]
        public void SendMailToCustomer_ReturnsTrue_WhenMailIsMocked()
        {
            // Act
            bool result = customerComm.SendMailToCustomer();

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
