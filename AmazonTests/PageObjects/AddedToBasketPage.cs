using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Text.RegularExpressions;

namespace PageObjects
{
    public class AddedToBasketPage : BasePage
    {
        #region WebElements
        [FindsBy(How = How.Id, Using = "huc-v2-order-row-container")]
        private IWebElement m_Notification;
        [FindsBy(How = How.Id, Using = "huc-v2-order-row-confirm-text")]
        private IWebElement m_NotificationMessage;
        [FindsBy(How = How.CssSelector, Using = "#hlb-subcart .huc-subtotal > span:first-of-type")]
        private IWebElement m_BasketSubTotal;
        [FindsBy(How = How.Id, Using = "hlb-view-cart-announce")]
        private IWebElement m_BTN_EditBasket;
        #endregion

        public bool IsNotificationPresent => Get.ElementPresent(m_Notification);
        public string NotificationMessage => Get.Text(m_NotificationMessage);
        public int QuantityOfBasket => int.Parse(new Regex(@"\d+").Match(Get.Text(m_BasketSubTotal)).Value);

        #region Methods
        public CartPage EditCart()
        {
            Do.Click(m_BTN_EditBasket);

            return new CartPage();
        }
        #endregion
    }
}
