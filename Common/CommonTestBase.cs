using NUnit.Framework;

namespace Common
{
    public class CommonTestBase
    {
        [SetUp]
        public void SetUp()
        {
            Driver.Initialize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Instance.Quit();
        }
    }
}