using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObjects
{
    public class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(Driver.Instance, this);
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        private IWebElement FLD_Search;
        [FindsBy(How = How.CssSelector, Using = ".nav-input[type=submit]")]
        private IWebElement BTN_SubmitText;
        [FindsBy(How = How.Id, Using = "searchDropdownBox")]
        private IWebElement DDL_Departments;
        #endregion

        #region Methods
        public BookResultsPage SearchBooks(string text)
        {
            FilterSearchBy("Books");
            EnterIn_SearchField(text);
            SubmitTextSearch();

            return new BookResultsPage();
        }

        public BasePage EnterIn_SearchField(string text)
        {
            Do.ClearAndSendKeys(FLD_Search, text);

            return this;
        }

        public void SubmitTextSearch()
        {
            Do.Click(BTN_SubmitText);
        }

        public BasePage FilterSearchBy(string text)
        {
            Do.Click(DDL_Departments);
            new SelectElement(DDL_Departments).SelectByText(text);

            return this;
        }
        #endregion
    }
}
