using AmazonTests;
using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class BookResultsPage : BasePage
    {
        public BookResultsPage()
        {
            Wait.ForElementPresent(m_ResultContainer);
            Wait.ForLoad();
        }

        #region WebElements
        [FindsBy (How = How.CssSelector, Using = "#s-results-list-atf > li")]
        private IList<IWebElement> m_LST_Results;
        [FindsBy(How = How.CssSelector, Using = ".loadingSpinner")]
        private IWebElement m_LoadingSpinner;
        [FindsBy(How = How.Id, Using = "s-results-list-atf")]
        private IWebElement m_ResultContainer;
        #endregion

        #region Methods
        public Book GetBook(int index)
        {
            Book m_Book = new Book();
            m_Book.Title = Get.Text(m_LST_Results[index - 1].FindElement(By.CssSelector(".s-access-title")));

            var formats = m_LST_Results[index - 1].FindElements(By.CssSelector("[Title]:not(.s-access-detail-page)"));
            var prices = m_LST_Results[index - 1].FindElements(By.CssSelector(".s-price"));

            if (formats.Count != prices.Count)
            {
                throw new System.Exception("Could not match book formats with prices !");
            }

            for (int i = 0; i< formats.Count; i++)
            {
                m_Book.FormatPrice.Add(Get.Text(formats[i]), Get.Text(prices[i]));
            }

            m_Book.Badges = m_LST_Results[index - 1].FindElements(By.CssSelector(".sx-badge-text")).Select(x => x.Text).ToList();

            return m_Book;
        }

        public bool IsBookBestSeller(int index)
        {
            return GetBook(index).Badges.Any(x => x == "Best Seller");
        }

        public bool IsBookHardcover(int index)
        {
            return GetBook(index).FormatPrice.Keys.Any(x => x == "Hardcover");
        }

        public BookDetailsPage OpenDetailsForItem(int index)
        {
            Do.Click(m_LST_Results[index - 1].FindElement(By.CssSelector(".s-access-detail-page")));
            return new BookDetailsPage();
        }
        #endregion
    }
}
