using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CentricProiect.PageObjectModel
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }
        IWebElement welcomeText => driver.FindElement(By.XPath("//h1[@class='page__heading']"));

        public string GetWelcomeText()
        {
            return welcomeText.Text;
        }
    }
}
