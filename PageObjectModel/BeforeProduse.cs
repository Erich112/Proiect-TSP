using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CentricProiect.PageObjectModel
{
    class BeforeProduse
    {
        private IWebDriver driver;
        public BeforeProduse(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement btnCart => driver.FindElement(By.LinkText("În Stoc"));

        public Produse GoToProduse()
        {
            btnCart.Click();
            return new Produse(driver);
        }
    }
}
