using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CentricProiect.PageObjectModel
{
    class CookieConsent
    {
        private IWebDriver driver;

        public CookieConsent(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement btnConsent => driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[2]/button[1]"));

        public void CookieAccept()
        {
            btnConsent.Click();
        }
        public GoToSignIn GoToMenuAfterCookieAccept()
        {
            btnConsent.Click();
            return new GoToSignIn(driver);
        }
    }
}
