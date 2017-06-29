using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class HomePage : BasePage
    {
        public static HomePage Initialize()
        {
            return new HomePage();
        }
    }
}
