using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace CentricProiect.PageObjectModel
{
    class ProductPage
    {
        private IWebDriver driver;

        public ProductPage(IWebDriver browser)
        {
            driver = browser;
        }

        IWebElement btnAddToCart => driver.FindElement(By.XPath("/html/body/div[1]/main/section/div/section/section/div[2]/form/div[3]/div[1]/button"));
        IWebElement fieldProdCount => driver.FindElement(By.XPath("/html/body/div[1]/main/section/div/section/section/div[2]/form/div[2]/div/input"));
        IWebElement btnCart1 => driver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/div[3]/a[3]/div"));
        IWebElement btnCart2;

        public void AddToCart(int productCount)
        {
            if (productCount < 1)
                Assert.Fail("nr de produse invalid");

            fieldProdCount.Clear();
            fieldProdCount.SendKeys(productCount.ToString());

            btnAddToCart.Click();
        }

        public CartPage GoToCartPage()
        {
            btnCart1.Click();
            System.Threading.Thread.Sleep(1000);
            btnCart2 = driver.FindElement(By.ClassName("cart-dropdown__action--view-cart"));
            btnCart2.Click();

            return new CartPage(driver);
        }
    }
}
