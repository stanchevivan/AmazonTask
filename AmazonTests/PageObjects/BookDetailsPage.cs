using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PageObjects
{
    public class BookDetailsPage : BasePage
    {
        #region WebElements
        [FindsBy(How = How.Id, Using = "productTitle")]
        private IWebElement m_TXT_Title;
        [FindsBy(How = How.CssSelector, Using = ".a-button-selected a > span:first-of-type")]
        private IWebElement m_Format;
        [FindsBy(How = How.CssSelector, Using = ".a-button-selected a > span:nth-of-type(2) > span")]
        private IWebElement m_Price;
        [FindsBy(How = How.CssSelector, Using = ".badge-wrapper i")]
        private IList<IWebElement> m_Badges;
        [FindsBy(How = How.Id, Using = "add-to-cart-button")]
        private IWebElement m_BTN_AddToBasket;
        #endregion

        public string Title => Get.Text(m_TXT_Title);
        public string SelectedFormat => Get.Text(m_Format);
        public string SelectedPrice => Get.Text(m_Price);
        public IList<string> Badges => m_Badges.Select(x => Get.Text(x)).ToList();
        public bool IsBestSeller => Badges.Any(x => new Regex(@"(?<=[\s]+).*").Match(x).Value == "Best Seller");

        #region Methods
        public AddedToBasketPage AddToBasket()
        {
            Do.Click(m_BTN_AddToBasket);

            return new AddedToBasketPage();
        }
        #endregion
    }
}
