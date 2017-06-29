using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Common
{
    public static class Do
    {
        public static void ClearAndSendKeys(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void SendKeys(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void Click(IWebElement element)
        {
            element.Click();
        }

        public static void MouseOver(IWebElement element)
        {
            Actions action = new Actions(Driver.Instance);
            action.MoveToElement(element).Perform();
        }
    }
}