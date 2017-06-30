using NUnit.Framework;
using PageObjects;
using System.Linq;

namespace AmazonTests.Tests
{
    [TestFixture]
    class TestScenario1 : AmazonTestBase
    {
        [Test]
        public void Test()
        {
            Assert.Multiple(() =>
            {
                string m_ExpectedTitle = "Harry Potter and The Cursed Child - Parts One and Two: The Official Script Book of the Original West End Production (Special Rehearsal Edition)";

                var bookResultsPage = HomePage.Initialize()
                    .SearchBooks("Harry Potter and the Cursed Child ");
            
                Assert.That(bookResultsPage.GetBook(1).Title, Is.EqualTo(m_ExpectedTitle));
                Assert.That(bookResultsPage.IsBookBestSeller(1), Is.True);
                Assert.That(bookResultsPage.IsBookHardcover(1), Is.EqualTo(true));
                Assert.That(bookResultsPage.GetBook(1).FormatPrice["Hardcover"], Is.EqualTo("£9.00"));

                var bookDetailsPage = bookResultsPage
                    .OpenDetailsForItem(1);

                Assert.That(bookDetailsPage.Title, Is.EqualTo(m_ExpectedTitle));
                Assert.That(bookDetailsPage.IsBestSeller, Is.True);
                Assert.That(bookDetailsPage.SelectedFormat, Is.EqualTo("Hardcover"));
                Assert.That(bookDetailsPage.SelectedPrice, Is.EqualTo("£9.00"));

                var addedToBasketPage = bookDetailsPage
                    .AddToBasket();

                Assert.That(addedToBasketPage.IsNotificationPresent, Is.True);
                Assert.That(addedToBasketPage.NotificationMessage, Is.EqualTo("Added to Basket"));
                Assert.That(addedToBasketPage.QuantityOfBasket, Is.EqualTo(1));

                var cartPage = addedToBasketPage
                    .EditCart();

                Assert.That(cartPage.GetBookItem(1).Title, Is.EqualTo(m_ExpectedTitle));
                Assert.That(cartPage.GetBookItem(1).FormatPrice["Hardcover"], Is.EqualTo("£9.00"));
                Assert.That(cartPage.GetBookItem(1).FormatPrice.Keys.First(), Is.EqualTo("Hardcover"));
                Assert.That(cartPage.GetBookItem(1).Quantity, Is.EqualTo(1));
                Assert.That(cartPage.GetTotalPrice(), Is.EqualTo("£9.00"));
            });
        }
    }
}