using System;
using System.Configuration;
using OpenQA.Selenium;

namespace Common
{
    public static class Driver
    {
        private static IWebDriver m_Instance;

        public static IWebDriver Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    throw new NullReferenceException("Driver is not initialized!");
                }

                return m_Instance;
            }

            set
            {
                m_Instance = value;
            }
        }

        public static void Initialize()
        {
            Instance = new OpenQA.Selenium.Chrome.ChromeDriver();
            Instance.Navigate().GoToUrl(ConfigurationSettings.AppSettings["baseURL"]);
        }
    }
}