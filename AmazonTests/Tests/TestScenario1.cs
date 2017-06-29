using NUnit.Framework;
using PageObjects;

namespace AmazonTests.Tests
{
    [TestFixture]
    class TestScenario1 : AmazonTestBase
    {
        [Test]
        public void Test()
        {
            var page = HomePage.Initialize()
                .SearchBooks("Harry Potter and the Cursed Child ");

            Assert.That(page.GetTitleOfResult(1), Is.EqualTo("Harry Potter and The Cursed Child - Parts One and Two: The Official Script Book of the Original West End Production (Special Rehearsal Edition)"));
            Assert.That(page.IsResultBestSeller(1), Is.True);
            Assert.That(page.IsResultHardcover(1), Is.EqualTo(true));
            Assert.That(page.GetFirstPriceForResult(1), Is.EqualTo("£9.00"));
        }
    }
}