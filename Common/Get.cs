using OpenQA.Selenium;

namespace Common
{
    public static class Get
    {
        public static bool ElementPresent(IWebElement element)
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

        public static string Text(IWebElement element)
        {
            return element.Text;
        }
    }
}