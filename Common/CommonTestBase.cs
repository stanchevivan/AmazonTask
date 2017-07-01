using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Common
{
    public class CommonTestBase
    {
        [SetUp]
        [BeforeScenario]
        public void SetUp()
        {
            Driver.Initialize();
        }

        [TearDown]
        [AfterScenario]
        public void TearDown()
        {
            Driver.Instance.Quit();
        }
    }
}