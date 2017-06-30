using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Common
{
    public static class Wait
    {
        public static void ForElementPresent(IWebElement element)
        {
            new WebDriverWait(new SystemClock(), Driver.Instance, TimeSpan.FromSeconds(20), TimeSpan.FromMilliseconds(20)).Until<bool>
                (x =>
                {
                    try
                    {
                        var tagName = element.TagName;
                        return true;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                }
                );
        }

        public static void ForElementNotPresent(IWebElement element)
        {
            new WebDriverWait(new SystemClock(), Driver.Instance, TimeSpan.FromSeconds(20), TimeSpan.FromMilliseconds(20)).Until<bool>
                (x =>
                {
                    try
                    {
                        var tagName = element.TagName;
                        return false;
                    }
                    catch (NoSuchElementException)
                    {
                        return true;
                    }
                }
                );
        }

        public static void ForLoad()
        {
            new WebDriverWait(new SystemClock(), Driver.Instance, TimeSpan.FromSeconds(20), TimeSpan.FromMilliseconds(20)).Until<bool>
                   (x =>
                   {
                       return ((IJavaScriptExecutor)Driver.Instance).ExecuteScript("return document.readyState").Equals("complete");
                   });
        }
    }
}