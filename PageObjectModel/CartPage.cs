using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CentricProiect.PageObjectModel
{
    class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver browser)
        {
            driver = browser;
        }
        IWebElement btnGoToCheckOut => driver.FindElement(By.ClassName("cart__action--checkout"));

        public CheckoutPage GoToCheckOut()
        {
            btnGoToCheckOut.Click();


            return new CheckoutPage(driver);
        }
    }
}
