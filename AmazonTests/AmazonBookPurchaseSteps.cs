using NUnit.Framework;
using PageObjects;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace AmazonTests
{
    [Binding]
    public class AmazonBookPurchaseSteps : AmazonTestBase
    {
        HomePage homePage;
        BookResultsPage bookResultsPage;
        BookDetailsPage bookDetailsPage;
        AddedToBasketPage addedToBasketPage;
        CartPage cartPage;

        string m_ExpectedTitle = "Harry Potter and The Cursed Child - Parts One and Two: The Official Script Book of the Original West End Production (Special Rehearsal Edition)";

        [When]
        public void When_I_Open_Amazon_URL()
        {
            homePage = HomePage.Initialize();
        }
        
        [Then]
        public void Then_the_browser_URL_is_https_www_amazon_co_uk()
        {
            homePage.CheckURL("https://www.amazon.co.uk/");
        }

        [When]
        public void When_I_Search_for_P0_in_section_books(string p0)
        {
            bookResultsPage = homePage.SearchBooks("Harry Potter and the Cursed Child ");
        }

        [Then]
        public void Then_The_first_item_has_the_title_Harry_Potter_and_the_Cursed_Child_Parts_One_Two()
        {
            Assert.That(bookResultsPage.GetBook(1).Title, Is.EqualTo(m_ExpectedTitle));
        }

        [Then]
        public void Then_It_has_a_badge_Best_Seller()
        {
            Assert.That(bookResultsPage.IsBookBestSeller(1), Is.True);
        }

        [Then]
        public void Then_Selected_type_is_Hardcover()
        {
            Assert.That(bookResultsPage.IsBookHardcover(1), Is.EqualTo(true));
        }

        [Then]
        public void Then_The_price_is_P0(string p0)
        {
            Assert.That(bookResultsPage.GetBook(1).FormatPrice["Hardcover"], Is.EqualTo("£9.00"));
        }

        [When]
        public void When_I_navigate_to_the_book_details()
        {
            bookDetailsPage = bookResultsPage.OpenDetailsForItem(1);
        }

        [Then]
        public void Then_The_title_is_P0(string p0)
        {
            Assert.That(bookDetailsPage.Title, Is.EqualTo(m_ExpectedTitle));
        }

        [Then]
        public void Then_It_has_the_badge_Best_Seller()
        {
            Assert.That(bookDetailsPage.IsBestSeller, Is.True);
        }

        [Then]
        public void Then_The_price_again_is_P0(string p0)
        {
            Assert.That(bookDetailsPage.SelectedPrice, Is.EqualTo("£9.00"));
        }

        [Then]
        public void Then_Type_is_Hardcover()
        {
            Assert.That(bookDetailsPage.SelectedFormat, Is.EqualTo("Hardcover"));
        }

        [When]
        public void When_I_Add_the_book_to_the_basket()
        {
            addedToBasketPage = bookDetailsPage.AddToBasket();
        }

        [Then]
        public void Then_The_notification_is_shown()
        {
            Assert.That(addedToBasketPage.IsNotificationPresent, Is.True);
        }

        [Then]
        public void Then_The_title_Added_to_Basket()
        {
            Assert.That(addedToBasketPage.NotificationMessage, Is.EqualTo("Added to Basket"));
        }

        [Then]
        public void Then_There_is_one_item_in_the_basket()
        {
            Assert.That(addedToBasketPage.QuantityOfBasket, Is.EqualTo(1));
        }

        [When]
        public void When_I_Click_on_edit_the_basket()
        {
            cartPage = addedToBasketPage.EditCart();
        }

        [Then]
        public void Then_The_book_is_shown_on_the_list()
        {
            Assert.That(cartPage.GetBookItem(1).Title, Is.EqualTo(m_ExpectedTitle));
        }

        [Then]
        public void Then_The_type_of_print_is_Hardcover()
        {
            Assert.That(cartPage.GetBookItem(1).FormatPrice.Keys.First(), Is.EqualTo("Hardcover"));
        }

        [Then]
        public void Then_Price_is_still_P0(string p0)
        {
            Assert.That(cartPage.GetBookItem(1).FormatPrice["Hardcover"], Is.EqualTo("£9.00"));
        }

        [Then]
        public void Then_Quantity_is_P0(int p0)
        {
            Assert.That(cartPage.GetBookItem(1).Quantity, Is.EqualTo(1));
        }

        [Then]
        public void Then_Total_price_is_P0(string p0)
        {
            Assert.That(cartPage.GetTotalPrice(), Is.EqualTo("£9.00"));
        }
    }
}
