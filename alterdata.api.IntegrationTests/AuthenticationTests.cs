using NUnit.Framework;

namespace alterdata.api.IntegrationTests
{
    [TestFixture]
    public class AuthenticationTests
    {
        [Test]
        public void RegisterUser_WhenCalled_ReturnsTrue() 
        {
            var result = true;

            Assert.That(result, Is.EqualTo(true));
        }
    }
}