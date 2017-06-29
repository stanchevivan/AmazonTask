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
            Wait.ForElementPresent(ResultContainer);
            Wait.ForAsyncLoad();
        }

#region WebElements
        [FindsBy (How = How.CssSelector, Using = "#s-results-list-atf > li")]
        private IList<IWebElement> LST_Results;
        [FindsBy(How = How.CssSelector, Using = ".loadingSpinner")]
        private IWebElement LoadingSpinner;
        [FindsBy(How = How.Id, Using = "s-results-list-atf")]
        private IWebElement ResultContainer;
#endregion

        public IList<Book> Books
        {
            get
            {
                var temp = new List<Book>();
                foreach (var result in LST_Results)
                {
                    temp.Add(new Book
                    {
                        Badges = result.FindElements(By.CssSelector(".sx-badge-text")).Select(x => Get.Text(x)).ToList(),
                        Title = Get.Text(result.FindElement(By.CssSelector(".s-access-detail-page"))),
                    });
                }
                return temp;
            }
        }

#region Methods
        private IWebElement GetResult(int number)
        {
            return LST_Results[number - 1];
        }

        public string GetTitleOfResult(int number)
        {
            return Get.Text(GetResult(number).FindElement(By.CssSelector(".s-access-detail-page")));
        }

        public BookResultsPage OpenResult(int number)
        {
            Do.Click(GetResult(number).FindElement(By.CssSelector(".s-access-detail-page")));

            return this;
        }

        private IList<IWebElement> GetBadgesForResult(int number)
        {
            return GetResult(number).FindElements(By.CssSelector(".sx-badge-text"));
        }

        public bool IsResultBestSeller(int number)
        {
            return GetBadgesForResult(number).Any(x => Get.Text(x) == "Best Seller");
            //return Books[number + 1].Badges.Any(x => x == "Best Seller");
        }

        private IList<IWebElement> GetFormatsForResult(int number)
        {
            return GetResult(number).FindElements(By.CssSelector("[Title]:not(.s-access-detail-page)"));
        }

        public bool IsResultHardcover(int number)
        {
            return GetFormatsForResult(number).Any(x => Get.Text(x) == "Hardcover");
        }

        private IList<IWebElement> GetPricesForResult(int number)
        {
            return GetResult(number).FindElements(By.CssSelector(".s-price"));
        }

        public string GetFirstPriceForResult(int number)
        {
            return Get.Text(GetPricesForResult(number).First());
        }
#endregion
    }
}
