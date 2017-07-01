using AmazonTests;
using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace PageObjects
{
    public class CartPage : BasePage
    {
        #region WebElements
        [FindsBy(How = How.CssSelector, Using = ".sc-list-body > div")]
        private IList<IWebElement> m_LST_Items;
        [FindsBy(How = How.Id, Using = "sc-subtotal-amount-activecart")]
        private IWebElement m_TXT_TotalPrice;
        #endregion

        #region Methods
        public Book GetBookItem(int index)
        {
            Book m_Book = new Book();

            m_Book.Title = Get.Text(m_LST_Items[index - 1].FindElement(By.CssSelector(".sc-product-title")));
            m_Book.FormatPrice.Add(
            Get.Text(m_LST_Items[index - 1].FindElement(By.CssSelector(".sc-product-binding"))),
            Get.Text(m_LST_Items[index - 1].FindElement(By.CssSelector(".sc-product-price")))
            );
            m_Book.Quantity = int.Parse(Get.Text(m_LST_Items[index - 1].FindElement(By.CssSelector(".quantity"))));
        
            return m_Book;
        }

        public string GetTotalPrice()
        {
            return Get.Text(m_TXT_TotalPrice);
        }
        #endregion
    }
}
